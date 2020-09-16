using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerControl : MonoBehaviour
{
    Rigidbody Rb;
    Animator Anim;
    public float Speed = 5f;
    public Collider MainCollider;
    public Collider[] AllCollider;
    public Rigidbody[] AllRb;
    public  bool DoKontrol = false;
    AudioSource Au;
    public AudioClip HitSfx;
    public AudioClip WaterSfx;
    public GameObject HitParticle;
    public GameObject WaterParticle;
    public GameObject Den1;
    public GameObject Den2;
    public Transform BubblePoint;
    public GameObject GameOverMenü;
    float CarpismaSiddet = 5f;
    Vector3 vel;
    bool RotK = false;
    bool RotOk = false;
    float Ver;
    
    public FixedTouchField TocuhField;
    void Start()
    {
        Anim = GetComponent<Animator>();
        MainCollider = GetComponent<Collider>();
        Den1 = GameObject.Find("boy_2");
        Den2 = GameObject.Find("boy_3");
        BubblePoint = GameObject.Find("BubblePoint").transform;
        AllCollider = GetComponentsInChildren<Collider>(true);
        Rb = gameObject.GetComponent<Rigidbody>();
        AllRb = GetComponentsInChildren<Rigidbody>(true);
        

        DoRagdoll(false);
        Au = GetComponent<AudioSource>();
        
    }
    #region Collision Durumları
    private void OnCollisionEnter(Collision collision)
    {



        if (collision.gameObject.CompareTag("Water"))
        {
            Instantiate(WaterParticle, BubblePoint.transform.position, Quaternion.identity);
            Au.PlayOneShot(WaterSfx);
            Den1.SetActive(false);
            Den2.SetActive(false);
            GameOverMenü.SetActive(true);
            FindObjectOfType<KameraTakip>().enabled = false;
        }
        if (collision.gameObject.CompareTag("Rot"))
        {
            RotK = true;
        }
        if (collision.gameObject.CompareTag("RotO"))
        {
            RotOk = true;
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            RotK = false;
            RotOk = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 direction = collision.transform.position - transform.position;
            direction.y = 0;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * CarpismaSiddet, ForceMode.Impulse);

        }

    }
    #endregion
    #region TriggerDurumları
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EngelYatay"))
        {
            Instantiate(HitParticle, transform.position, Quaternion.identity);
            Au.PlayOneShot(HitSfx);
            DoRagdoll(true);
            GameOverMenü.SetActive(true);



        }
        if (other.gameObject.CompareTag("Engel"))
        {
            Instantiate(HitParticle, transform.position, Quaternion.identity);
            Au.PlayOneShot(HitSfx);
            DoRagdoll(true);
            GameOverMenü.SetActive(true);
        }

        if (other.gameObject.CompareTag("Donut"))
        {
            Instantiate(HitParticle, transform.position, Quaternion.identity);
            Au.PlayOneShot(HitSfx);
            DoRagdoll(true);
            GameOverMenü.SetActive(true);
        }
        
        
    }
    #endregion




    // Update is called once per frame
    void Update()
    {
        if (transform.position.y<=-1)
        {
            //DoRagdoll(true);
           
            Anim.SetTrigger("FallTrig");
        }
        Ver = TocuhField.TouchDist.x;

        Anim.SetFloat("vertical", Ver);
    }
    private void FixedUpdate()
    {
        CharacterMove();
    }
    void CharacterMove()
    {

        
        //Debug.Log(Ver);
        if (!DoKontrol)
        {
            vel = transform.forward * Speed;//Yer çekimi etkisi için
            vel.z = (Rb.velocity.z + TocuhField.TouchDist.x)*0.4f;
            vel.y = Rb.velocity.y;
            //vel.z = Rb.velocity.z;
            if (RotK)
            {
                //vel.z = (Rb.velocity.z + TocuhField.TouchDist.x) * 0.5f;
                //vel.z = Rb.velocity.z + 0.1f;
                vel.z += 2f;
            }
            if (RotOk)
            {

                //vel.z = Rb.velocity.z + 0.5f;
                vel.z += 2f;
            }
            
            Rb.velocity = vel;
            //Rb.AddForce(vel-Rb.velocity,ForceMode.VelocityChange);
        }
        
    }
    
    public void DoRagdoll(bool isRagdoll)
    {
        foreach(var col in AllCollider)
        {
            
            DoKontrol = isRagdoll;
            GetComponent<Rigidbody>().isKinematic = isRagdoll;
            
            col.enabled = isRagdoll;
            MainCollider.enabled = !isRagdoll;
            GetComponent<Rigidbody>().useGravity = !isRagdoll;
            GetComponent<Animator>().enabled = !isRagdoll;
            
        }
        foreach(var rig in AllRb)
        {
            GetComponent<Rigidbody>().useGravity = !isRagdoll;
            rig.useGravity = isRagdoll;//Stabil bir ragdoll fiziği için.
        }
    }
}
