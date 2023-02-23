using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    TrailRenderer trailRenderer;
    private void Awake()
    {
        if(moveDirection != Vector2.right)
        {
            transform.GetChild(0).rotation = Quaternion.FromToRotation(Vector2.right, moveDirection);
        }
        trailRenderer = GetComponentInChildren<TrailRenderer>();
    }
    private void OnDisable()
    {
        trailRenderer.Clear();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        PlayerEnergy.Instance.Obtain(PlayerEnergy.PERCENT);
    }
}
