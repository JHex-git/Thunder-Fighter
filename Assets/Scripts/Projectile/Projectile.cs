using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject hitVFX;
    [SerializeField] AudioData hitSFX;
    [SerializeField] float damage;
    [SerializeField] float moveSpeed;
    [SerializeField] protected Vector2 moveDirection;
    protected GameObject target;
    protected virtual void OnEnable()
    {
        StartCoroutine(nameof(MoveDirectly));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(MoveDirectly));
    }

    IEnumerator MoveDirectly()
    {
        while (gameObject.activeSelf)
        {
            Move();
            yield return null;
        }
    }

    public void Move() => transform.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime);

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Character>(out Character character))
        {
            character.TakeDamage(damage);
            var contactPoint = collision.GetContact(0);
            PoolManager.Release(hitVFX, contactPoint.point, Quaternion.LookRotation(contactPoint.normal));
            AudioManager.Instance.PlayRandomSFX(hitSFX);
            gameObject.SetActive(false);
        }
    }

    protected void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
