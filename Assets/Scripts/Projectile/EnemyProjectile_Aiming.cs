using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile_Aiming : Projectile
{
    private void Awake()
    {
        SetTarget(GameObject.FindGameObjectWithTag("Player"));
    }

    protected override void OnEnable()
    {
        //因为浮点数在一开始可能会不够精确，所以应该先等待一帧再取用，所以下面的方法不好。
        //if (target.activeSelf)
        //    moveDirection = (target.transform.position - transform.position).normalized;
        StartCoroutine(nameof(MoveDirectionCoroutine));
        base.OnEnable();
    }

    private IEnumerator MoveDirectionCoroutine()
    {
        yield return null;
        if (target.activeSelf)
        {
            moveDirection = (target.transform.position - transform.position).normalized;
        }
    }
}
