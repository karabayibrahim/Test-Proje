using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject Paint;
    public GameObject MainCam;
    public GameObject Kamera;
    public bool Yolla = false;
    GameObject Control;
    void Start()
    {
        //Paint = GameObject.Find("Duvar");
        //Paint.SetActive(false);
        //MainCam = GameObject.FindGameObjectWithTag("MainCamera");
        Kamera = GameObject.FindGameObjectWithTag("Kamera");
        Control = GameObject.Find("Control");
        //Paint.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Yolla = true;
            FindObjectOfType<KameraTakip>().enabled = false;
            collision.gameObject.SetActive(false);
            Control.SetActive(false);
            Paint.SetActive(true);
            MainCam.SetActive(true);
            Kamera.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("bOT");
            collision.gameObject.GetComponent<AIControl>().Den1.SetActive(false);
            collision.gameObject.GetComponent<AIControl>().Den2.SetActive(false);
        }
     }
    // Update is called once per frame
    void Update()
    {
        
    }
}
