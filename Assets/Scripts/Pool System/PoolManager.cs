using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Header("-------- Pools -------")]
    [SerializeField] Pool[] enemyPools;
    [SerializeField] Pool[] playerProjectilePools;
    [SerializeField] Pool[] enemyProjectilePools;
    [SerializeField] Pool[] VFXPools;

    static Dictionary<GameObject, Pool> dictionary;
    void Awake()
    {
        dictionary = new Dictionary<GameObject, Pool>();

        //TODO: Initialize all pools
        Initialize(enemyPools);
        Initialize(playerProjectilePools);
        Initialize(enemyProjectilePools);
        Initialize(VFXPools);
    }

    
    void Initialize(Pool[] pools)
    {
        foreach(var pool in pools)
        {
        #if UNITY_EDITOR
            if (dictionary.ContainsKey(pool.Prefab))
            {
                Debug.LogError("Same prefab in multiple pools!");
                continue;
            }
        #endif
            dictionary.Add(pool.Prefab, pool);
            Transform poolParent = new GameObject("Pool:" + pool.Prefab.name).transform;
            poolParent.parent = transform;
            pool.Initialize(poolParent);
        }
    }

    /// <summary>
    /// <para>Return a prepared gameObject in pool specified by the param prefab</para>
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    public static GameObject Release(GameObject prefab)
    {
    #if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could NOT find prefab:" + prefab.name);
            return null;
        }
    #endif
        return dictionary[prefab].PreparedObject();
    }
    
    public static GameObject Release(GameObject prefab, Vector3 position)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could NOT find prefab:" + prefab.name);
            return null;
        }
#endif
        return dictionary[prefab].PreparedObject(position);
    }

    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could NOT find prefab:" + prefab.name);
            return null;
        }
#endif
        return dictionary[prefab].PreparedObject(position, rotation);
    }

    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation, Vector3 localScale)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could NOT find prefab:" + prefab.name);
            return null;
        }
#endif
        return dictionary[prefab].PreparedObject(position, rotation, localScale);
    }

#if UNITY_EDITOR
    private void OnDestroy()
    {
        //TODO: Add pool here to check the size
        Check(enemyPools);
        Check(playerProjectilePools);
        Check(enemyProjectilePools);
        Check(VFXPools);
    }
    void Check(Pool[] pools)
    {
        foreach(var pool in pools)
        {
            if (pool.Size < pool.RuntimeSize)
            {
                Debug.LogWarning($"Pool:{pool.Prefab.name} has a runtime size of {pool.RuntimeSize} bigger than its initial size{pool.Size}");
            }
        }
    }
#endif
}
