using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityScript.Lang;

public class Rank : MonoBehaviour
{
    public GameObject[] Objeler;
    public TextMeshProUGUI Sıra;
    GameObject Player;
    int Sıram;
    float EnKucuk;
    float Ben;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Atama();
        SıralamaFonk();
        
        //Debug.Log("K" + EnKucuk);

        //if (Ben == EnKucuk)
        //{
        //    Debug.Log("1.");
        //}
        //else
        //{
        //    Debug.Log("Sg");
        //}

    }
    void Atama()
    {
        Objeler[0] = GameObject.FindGameObjectWithTag("Player");
        Objeler[1] = GameObject.Find("Girl");
        Objeler[2] = GameObject.Find("Girl1");
        Objeler[3] = GameObject.Find("Girl2");
        Objeler[4] = GameObject.Find("Girl3");
        Objeler[5] = GameObject.Find("Girl4");
        Objeler[6] = GameObject.Find("Girl5");
        Objeler[7] = GameObject.Find("Girl6");
        Objeler[8] = GameObject.Find("Girl7");
        Objeler[9] = GameObject.Find("Girl8");
        Objeler[10] = GameObject.Find("Girl9");
    }
    public void SıralamaFonk()
    {
        //float Birinci=0, İkinci=0, Ücüncü = 0;
        float[] Sıralama = new float[11];
        float Gecici;
        for (int i = 0; i < Objeler.Length; i++)
        {
            if (FindObjectOfType<Finish>().Yolla == false)
            {
                Sıralama[i] = Objeler[i].transform.position.x;
                if (Objeler[i].gameObject.CompareTag("Player"))
                {

                    Ben = Objeler[i].gameObject.transform.position.x;


                }
                
            }
            
            
        }
        for (int i = 0; i < Sıralama.Length; i++)
        {
            for (int t = 0; t < Sıralama.Length; t++)
            {
                if (Sıralama[t]>Sıralama[i])
                {
                    Gecici = Sıralama[i];
                    Sıralama[i] = Sıralama[t];
                    Sıralama[t] = Gecici;
                }
            }
        }

#region
        if (Ben==Sıralama[0])
        {
            Sıram= 1;
        }
        if (Ben == Sıralama[1])
        {
            Sıram = 2;
        }
        if (Ben == Sıralama[2])
        {
            Sıram = 3;
        }
        if (Ben == Sıralama[3])
        {
            Sıram = 4;
        }
        if (Ben == Sıralama[4])
        {
            Sıram = 5;
        }
        if (Ben == Sıralama[5])
        {
            Sıram = 6;
        }
        if (Ben == Sıralama[6])
        {
            Sıram = 7;
        }
        if (Ben == Sıralama[7])
        {
            Sıram = 8;
        }
        if (Ben == Sıralama[8])
        {
            Sıram = 9;
        }
        if (Ben == Sıralama[9])
        {
            Sıram = 10;
        }
        #endregion
        Sıra.text = Sıram + "/10";
        //Debug.Log(Sıralama[0]);
        

    }
    
}
