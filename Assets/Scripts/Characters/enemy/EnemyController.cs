using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("---- Move ----")]
    [SerializeField] float moveSpeed;
    [SerializeField] float moveRotationAngle;
    Vector3 targetPosition;

    [Header("---- Fire ----")]
    [SerializeField] GameObject[] projectiles;
    [SerializeField] AudioData[] projectileLaunchSFX;
    [SerializeField] float minFireInterval;
    [SerializeField] float maxFireInterval;
    [SerializeField] Transform muzzle;

    WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
     float paddingX;
     float paddingY;

    private void Awake()
    {
        var size = transform.GetChild(0).GetComponent<Renderer>().bounds.size;
        paddingX = size.x / 2f;
        paddingY = size.x / 2f;
    }
    private void OnEnable()
    {
        StartCoroutine(nameof(RandomlyMovingCoroutine));
        StartCoroutine(nameof(RandomlyFireCoroutine));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator RandomlyMovingCoroutine()
    {
        transform.position = ViewPort.Instance.RandomEnemySpawnPosition(paddingX, paddingY);

        targetPosition = ViewPort.Instance.RandomRightHalfPosition(paddingX, paddingY);
        while (gameObject.activeSelf)
        {
            if (Vector3.Distance(transform.position, targetPosition) >= moveSpeed * Time.fixedDeltaTime)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);

                transform.rotation = Quaternion.AngleAxis((targetPosition - transform.position).normalized.y * moveRotationAngle, Vector3.right);
                yield return waitForFixedUpdate;
            }
            else
            {
                targetPosition = ViewPort.Instance.RandomRightHalfPosition(paddingX, paddingY);
            }
        }
    }

    IEnumerator RandomlyFireCoroutine()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(Random.Range(minFireInterval, maxFireInterval));
            foreach(var projectile in projectiles)
            {
                PoolManager.Release(projectile, muzzle.position);
            }
            AudioManager.Instance.PlayRandomSFX(projectileLaunchSFX);
        }
    }
}
