using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpmaBoy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<MeshRenderer>().material.name== "Kırmızı (Instance)")
        {
            Debug.Log("Dogru");
        }
        else
        {
            Debug.Log("sg");
            Debug.Log(gameObject.GetComponent<MeshRenderer>().material.name);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
