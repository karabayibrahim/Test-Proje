using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Stick : MonoBehaviour
{
    Rigidbody Rb;
    public Vector2 Asagi;
    public Vector2 Yukari;
    float Zaman;
   public bool SayiK = false;
    public bool HareketK = false;
    public bool AsagiKontrol = false;
    public float Speed;
    
    void Start()
    {
        
        Rb = GetComponent<Rigidbody>();
        
    }
    void SayiSec()
    {
        
        if (!SayiK)
        {
            Rb.isKinematic = false;
            float Secilen = Random.Range(2, 11);
            Zaman = Secilen;
            SayiK = true;
            
        }
        
        Zaman -= Time.deltaTime;
        if (Zaman<=0)
        {
            Zaman = 0;
            HareketK = true;
            
        }
    }
    void StickMove()
    {
        if (transform.position.y>=Yukari.y&&HareketK)
        {
            
            Rb.velocity = -transform.up * Speed;
            
        }
        if (transform.position.y<=Asagi.y)
        {
            
            AsagiKontrol = true;
            Rb.velocity = transform.up * Speed;
        }
        if (transform.position.y >= Yukari.y&&AsagiKontrol)
        {
            
            AsagiKontrol = false;
            Rb.isKinematic = true;
            SayiK = false;
            HareketK = false;

        }
    }
    // Update is called once per frame
    void Update()
    {
        StickMove();
        SayiSec();
       // Debug.Log(Zaman);
        
    }
}
