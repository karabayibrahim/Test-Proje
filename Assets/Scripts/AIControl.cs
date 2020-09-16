using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    Rigidbody Rb;
    Vector3 vel;
    public Transform Point;
    public NavMeshAgent agent;
    float Speed = 4f;
    public Collider MainCollider;
    public Collider[] AllCollider;
    public Rigidbody[] AllRb;
    public bool DoKontrol = false;
    bool RagAgentKonrol = false;
    float CarpismaSiddet = 5f;
    AudioSource Au;
    public bool Sapma = false;
    float Sayac = 2f;
    public AudioClip HitSfx;
    public bool NavKontrol=false;
    Transform SpawnPoint;
    public GameObject Den1;
    public GameObject Den2;

    void Start()
    {
        AllCollider = GetComponentsInChildren<Collider>(true);
        MainCollider = GetComponent<Collider>();
        AllRb = GetComponentsInChildren<Rigidbody>(true);
        DoRagdoll(false);
        Rb = GetComponent<Rigidbody>();
        Au = GetComponent<AudioSource>();
        SpawnPoint = GameObject.Find("SpawnPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        AIMove();
        Carpisma();
        //Debug.Log(Sayac);
    }

    void Carpisma()
    {
        if (NavKontrol)
        {
            Sayac -= Time.deltaTime;
            
            if (Sayac<=0)
            {
                NavKontrol = false;
                gameObject.GetComponent<NavMeshAgent>().obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
                Sayac = 4;
            }
        }
    }
    void AIMove()
    {
        //RaycastHit hit;
        //if (Physics.Raycast(Point.position,Point.transform.forward,out hit,1000f))
        //{
        //    agent.SetDestination(hit.point);
        //}
        if (Sapma)
        {
            vel.z=Rb.velocity.z*2f;
        }
        if (!RagAgentKonrol)
        {
            agent.SetDestination(Point.position);



        }
        vel = transform.forward * Speed;
        vel.y = Rb.velocity.y;
        Rb.velocity = vel;
    }
    public void DoRagdoll(bool isRagdoll)
    {
        
        foreach (var col in AllCollider)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = !isRagdoll;
            DoKontrol = isRagdoll;
            GetComponent<Rigidbody>().isKinematic = isRagdoll;
            RagAgentKonrol = isRagdoll;
            col.enabled = isRagdoll;
            MainCollider.enabled = !isRagdoll;
            GetComponent<Rigidbody>().useGravity = !isRagdoll;
            GetComponent<Animator>().enabled = !isRagdoll;

        }
        foreach (var rig in AllRb)
        {
            GetComponent<Rigidbody>().useGravity = !isRagdoll;
            rig.useGravity = isRagdoll;//Stabil bir ragdoll fiziği için isRagdoll
        }
    }
    #region TrigDurumları
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("EngelYatay"))
        {
            Au.PlayOneShot(HitSfx);
            Debug.Log("Calıştı");
            DoRagdoll(true);
            GameObject YeniGirl = Instantiate(gameObject, SpawnPoint.position, Quaternion.identity);
            YeniGirl.name = gameObject.name;
            Destroy(gameObject,1f);


        }
        if (collision.gameObject.CompareTag("Engel"))
        {

            Au.PlayOneShot(HitSfx);
            DoRagdoll(true);
            //Instantiate(gameObject, SpawnPoint.position, Quaternion.identity);
            GameObject YeniGirl = Instantiate(gameObject, SpawnPoint.position, Quaternion.identity);
            YeniGirl.name = gameObject.name;
            Destroy(gameObject,1f);
        }
        if (collision.gameObject.CompareTag("Donut"))
        {
            Au.PlayOneShot(HitSfx);
            DoRagdoll(true);
            GameObject YeniGirl=Instantiate(gameObject, SpawnPoint.position, Quaternion.identity);
            YeniGirl.name = gameObject.name;
           
            Destroy(gameObject,1f);
        }
    }
    #endregion
    #region CollisionDurumları
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 direction = collision.transform.position - transform.position;
            direction.y = 0;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * CarpismaSiddet, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Rot"))
        {
            Sapma = true;
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            Sapma = false;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            NavKontrol = true;
            gameObject.GetComponent<NavMeshAgent>().obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
            
        }
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    NavKontrol = true;
        //    gameObject.GetComponent<NavMeshAgent>().obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
           
        //}
    }
    #endregion
}
