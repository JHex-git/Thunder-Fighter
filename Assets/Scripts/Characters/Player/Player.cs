using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Character
{
    [SerializeField] StatsBar_HUD statsBar_HUD;
    [Header("-------- Health --------")]
    [SerializeField] bool regenerateHealth = true;
    [SerializeField, Range(0f, 1f)] float healthRegeneratePercent;
    [SerializeField] float healthRegenerateTime;

    [Header("-------- Input --------")]
    [SerializeField] PlayerInput input;

    [Header("-------- Move --------")]
    [SerializeField] float moveAmout;
    [SerializeField] float accelerationTime;
    [SerializeField] float decelerationTime;
    [SerializeField] float moveRotationAngle = 28f;

    [Header("-------- Fire --------")]
    [SerializeField] GameObject projectileTopBias;
    [SerializeField] GameObject projectileHorizontal;
    [SerializeField] GameObject projectileBottomBias;
    [SerializeField] GameObject projectileOverdrive;
    [SerializeField] Transform muzzleMiddle;
    [SerializeField] Transform muzzleTop;
    [SerializeField] Transform muzzleBottom;
    [SerializeField] float attackCoolDown = 0.2f;
    [SerializeField, Range(0, 2)] int weaponPower;
    [SerializeField] AudioData projectileLaunchSFX;

    [Header("-------- Dodge --------")]
    [SerializeField, Range(0, 100)] int dodgeEnergyCost = 25;
    [SerializeField] float maxRoll = 720f;
    [SerializeField] float rollSpeed = 360f;
    [SerializeField] AudioData dodgeSFX;

    [Header("-------- Overdrive --------")]
    [SerializeField] int overdriveDodgeFactor = 2;
    [SerializeField] float overdriveSpeedFactor = 1.2f;
    [SerializeField] float overdriveFireFactor = 1.2f;

    bool isDodging = false;
    bool isOverdriving = false;

    float paddingX;
    float paddingY;
    readonly float slowMotionDuration = 1f;
    float currentRoll;

    float t;
    Vector2 previousVelocity;
    Quaternion previousRotation;
    WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
    WaitForSeconds waitDecelerationTime;
    WaitForSeconds waitForFireInterval;
    WaitForSeconds waitForOverdriveFireInterval;
    WaitForSeconds waitHealthRegenerateTime;

    Coroutine moveCoroutine;
    Coroutine healthRegenerateCoroutine;
    new Rigidbody2D rigidbody;
    new Collider2D collider;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        var size = transform.GetChild(0).GetComponent<Renderer>().bounds.size;
        paddingX = size.x / 2f;
        paddingY = size.y / 2f;
        rigidbody.gravityScale = 0f;

        waitForFireInterval = new WaitForSeconds(attackCoolDown);
        waitForOverdriveFireInterval = new WaitForSeconds(attackCoolDown / overdriveFireFactor);
        waitHealthRegenerateTime = new WaitForSeconds(healthRegenerateTime);
        waitDecelerationTime = new WaitForSeconds(decelerationTime);
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        input.onMove += Move;
        input.onStopMove += StopMove;
        input.onFire += Fire;
        input.onStopFire += StopFire;
        input.onDodge += Dodge;
        input.onOverdrive += Overdrive;

        PlayerOverdrive.on += OverdriveOn;
        PlayerOverdrive.off += OverdriveOff;
    }

    private void OnDisable()
    {
        input.onMove -= Move;
        input.onStopMove -= StopMove;
        input.onFire -= Fire;
        input.onStopFire -= StopFire;
        input.onDodge -= Dodge;
        input.onOverdrive -= Overdrive;

        PlayerOverdrive.on -= OverdriveOn;
        PlayerOverdrive.off -= OverdriveOff;
    }
    void Start()
    {
        statsBar_HUD.Initialize(health, maxHealth);
        input.EnableGameplayInput();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        statsBar_HUD.UpdateStats(health, maxHealth);
        if (gameObject.activeSelf)
        {
            if (regenerateHealth)
            {
                if (healthRegenerateCoroutine != null)
                {
                    StopCoroutine(healthRegenerateCoroutine);
                }
                healthRegenerateCoroutine = StartCoroutine(HealthRestoreCoroutine(waitHealthRegenerateTime, healthRegeneratePercent));
            }
        }
    }

    public override void RestoreHealth(float value)
    {
        base.RestoreHealth(value);
        statsBar_HUD.UpdateStats(health, maxHealth);
    }

    public override void Die()
    {
        statsBar_HUD.UpdateStats(0f, maxHealth);
        base.Die();
    }
    #region Move
    private void Move(Vector2 moveInput)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        StopCoroutine(nameof(DecelerationCoroutine));
        moveCoroutine = StartCoroutine(MoveCoroutine(moveInput.normalized * moveAmout, accelerationTime, Quaternion.AngleAxis(moveRotationAngle * moveInput.y, Vector3.right)));
        StartCoroutine(nameof(MoveRangeLimitationCoroutine));

    }

    private void StopMove()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = StartCoroutine(MoveCoroutine(Vector2.zero, decelerationTime, Quaternion.identity));
        StartCoroutine(nameof(DecelerationCoroutine));
    }

    IEnumerator MoveCoroutine(Vector2 moveVelocity, float time, Quaternion moveRotation)
    {
        t = 0;
        previousVelocity = rigidbody.velocity;
        previousRotation = transform.rotation;
        while (t < time)
        {
            t += Time.fixedDeltaTime;
            rigidbody.velocity = Vector2.Lerp(previousVelocity, moveVelocity, t / time);
            transform.rotation = Quaternion.Lerp(previousRotation, moveRotation, t / time);
            yield return waitForFixedUpdate;
        }
    }

    IEnumerator MoveRangeLimitationCoroutine()
    {
        while (true)
        {
            transform.position = ViewPort.Instance.PlayerMoveablePosition(transform.position, paddingX, paddingY);
            yield return null;
        }
    }

    IEnumerator DecelerationCoroutine()
    {
        yield return waitDecelerationTime;
        StopCoroutine(nameof(MoveRangeLimitationCoroutine));
    }
    #endregion

    #region Fire
    private void Fire()
    {
        StartCoroutine(nameof(FireCoroutine));
    } 

    private void StopFire()
    {
        StopCoroutine(nameof(FireCoroutine));//"FireCoroutine" will not work somehow
    }

    IEnumerator FireCoroutine()
    {
        while (true)
        {
            switch (weaponPower)
            {
                case 0:
                    PoolManager.Release(isOverdriving ? projectileOverdrive : projectileHorizontal, muzzleMiddle.position);
                    break;
                case 1:
                    PoolManager.Release(isOverdriving ? projectileOverdrive : projectileHorizontal, muzzleTop.position);
                    PoolManager.Release(isOverdriving ? projectileOverdrive : projectileHorizontal, muzzleBottom.position);
                    break;
                case 2:
                    PoolManager.Release(isOverdriving ? projectileOverdrive : projectileTopBias, muzzleTop.position);
                    PoolManager.Release(isOverdriving ? projectileOverdrive : projectileHorizontal, muzzleMiddle.position);
                    PoolManager.Release(isOverdriving ? projectileOverdrive : projectileBottomBias, muzzleBottom.position);
                    break;
            }

            AudioManager.Instance.PlayRandomSFX(projectileLaunchSFX);
            yield return isOverdriving ? waitForOverdriveFireInterval : waitForFireInterval;
        }
    }
    #endregion

    #region Dodge
    void Dodge()
    {
        if (isDodging || !PlayerEnergy.Instance.IsEnough(dodgeEnergyCost)) return;
        StartCoroutine(nameof(DodgeCoroutine));
    }

    IEnumerator DodgeCoroutine()
    {
        isDodging = true;
        AudioManager.Instance.PlayRandomSFX(dodgeSFX);
        PlayerEnergy.Instance.Use(dodgeEnergyCost);
        collider.isTrigger = true;
        currentRoll = 0f;
        while (currentRoll < maxRoll)
        {
            currentRoll += rollSpeed * Time.deltaTime;
            transform.rotation = Quaternion.AngleAxis(currentRoll, Vector3.right);
            yield return null;
        }
        collider.isTrigger = false;
        isDodging = false;
    }
    #endregion

    #region Overdrive
    void Overdrive()
    {
        if (!PlayerEnergy.Instance.IsEnough(PlayerEnergy.MAX)) return;
        PlayerOverdrive.on.Invoke();
    }

    void OverdriveOn()
    {
        isOverdriving = true;
        dodgeEnergyCost *= overdriveDodgeFactor;
        moveAmout *= overdriveSpeedFactor;
        TimeController.Instance.BulletTime(slowMotionDuration, 5f, slowMotionDuration);
    }

    void OverdriveOff()
    {
        isOverdriving = false;
        dodgeEnergyCost /= overdriveDodgeFactor;
        moveAmout /= overdriveSpeedFactor;
    }
    #endregion
}
