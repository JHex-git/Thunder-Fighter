using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGuidanceSystem : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    Vector3 targetDirection;
    [SerializeField] float minBallisticAngle = 50f;
    [SerializeField] float maxBallisticAngle = 75f;
    float ballisticAngle;
    public IEnumerator HomingCoroutine(GameObject target)
    {
        ballisticAngle = Random.Range(minBallisticAngle, maxBallisticAngle);
        while (gameObject.activeSelf)
        {
            if (target.activeSelf)
            {
                targetDirection = (target.transform.position - transform.position).normalized;
                transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg, Vector3.forward);//Atan2返回的为弧度制,angle应为角度制
                transform.rotation *= Quaternion.Euler(0f, 0f, ballisticAngle);
                projectile.Move();
            }
            else
            {
                projectile.Move();
            }
            yield return null;
        }
    }
}
