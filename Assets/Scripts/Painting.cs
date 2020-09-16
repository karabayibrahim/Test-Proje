
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;


public class Painting : MonoBehaviour
{
    
    public TextMeshProUGUI YüzdeGöster;
    public GameObject Carpan;
   public GameObject Kamera;
    public GameObject[] Küpler;
    public Material Kırmızı;
    public Material Def;
    //float Range = 1000f;
    float Yüzde;
    float Sonuc;
    float Carpanim;
    public float BrushSize = 0.1f;
   
    void Start()
    {
        Carpanim = 100f / 133f;
        
        Küpler = GameObject.FindGameObjectsWithTag("Küp");
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(Yüzde);
        Boyama();

    }
    void Boyama()
    {
        
        if (Input.GetMouseButton(0))
        {
            
            Ray Isık;
            Isık = Kamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(Isık, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.GetComponent<MeshRenderer>().material.name == "Default-Material (Instance)")
                {
                    Yüzde++;
                }
                if (hit.collider.CompareTag("Küp"))
                {
                    
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = Kırmızı;
                    
                    
                }
                
                
                
                
            }
        }
        
        Sonuc =Yüzde*Carpanim;
        
        YüzdeGöster.text = "%" + Mathf.RoundToInt(Sonuc); 
        
    }
}
