using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileOverdrive : PlayerProjectile
{
    [SerializeField] ProjectileGuidanceSystem projectileGuidanceSystem;
    protected override void OnEnable()
    {
        SetTarget(EnemyManager.Instance.RandomEnemy);
        transform.rotation = Quaternion.identity;

        if (target == null)
        {
            base.OnEnable();
        }
        else
        {
            StartCoroutine(projectileGuidanceSystem.HomingCoroutine(target));
        }
    }
}
