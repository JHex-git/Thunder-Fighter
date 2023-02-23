using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    [SerializeField] GameObject prefab;
    [SerializeField] int size;
    Transform parent;
    Queue<GameObject> queue;

    public GameObject Prefab => prefab;
    public int RuntimeSize => queue.Count;
    public int Size => size;
    public void Initialize(Transform parent)
    {
        queue = new Queue<GameObject>();
        this.parent = parent;
        for (int i = 0; i < size; i++)
        {
            queue.Enqueue(Copy());
        }
    }

    GameObject Copy()
    {
        var copy = GameObject.Instantiate(prefab, parent);

        copy.SetActive(false);

        return copy;
    }

    GameObject AvailableObject()
    {
        GameObject availableObject = null;
        if (queue.Count > 0 && !queue.Peek().activeSelf)
        {
            availableObject = queue.Dequeue();
        }
        else
        {
            availableObject = Copy();
        }
        queue.Enqueue(availableObject);
        return availableObject;
    }
    public GameObject PreparedObject()
    {
        var preparedObject = AvailableObject();

        preparedObject.SetActive(true);

        return preparedObject;
    }
    public GameObject PreparedObject(Vector3 position)
    {
        var preparedObject = AvailableObject();

        preparedObject.transform.position = position;

        preparedObject.SetActive(true);

        return preparedObject;
    }
    public GameObject PreparedObject(Vector3 position, Quaternion rotation)
    {
        var preparedObject = AvailableObject();

        preparedObject.transform.position = position;
        preparedObject.transform.rotation = rotation;

        preparedObject.SetActive(true);

        return preparedObject;
    }

    public GameObject PreparedObject(Vector3 position, Quaternion rotation, Vector3 localScale)
    {
        var preparedObject = AvailableObject();

        preparedObject.transform.position = position;
        preparedObject.transform.rotation = rotation;
        preparedObject.transform.localScale = localScale;

        preparedObject.SetActive(true);

        return preparedObject;
    }

}
