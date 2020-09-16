using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform target;
    //public float smoothSpeed = 0.125f;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {

        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
