using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] Vector2 scrollVelocity;
    Material material;
    private void Awake()
    {
        material = GetComponent<Renderer>().material;// material = GetComponent<Material>()�Ǵ����
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += scrollVelocity * Time.deltaTime;
    }
}
