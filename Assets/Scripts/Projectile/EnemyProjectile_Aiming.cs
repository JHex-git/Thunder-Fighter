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
        //��Ϊ��������һ��ʼ���ܻ᲻����ȷ������Ӧ���ȵȴ�һ֡��ȡ�ã���������ķ������á�
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
