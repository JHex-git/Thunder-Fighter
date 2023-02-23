using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeactivate : MonoBehaviour
{
    [SerializeField] bool destroyGameObject;
    [SerializeField] WaitForSeconds waitForSeconds;
    [SerializeField] float lifetime = 3f;

    private void Awake()
    {
        waitForSeconds = new WaitForSeconds(lifetime);
    }

    private void OnEnable()
    {
        StartCoroutine(nameof(DeactivateCoroutine));
    }
    IEnumerator DeactivateCoroutine()
    {
        yield return waitForSeconds;

        if (destroyGameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
