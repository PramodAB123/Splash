using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem parti;
    public GameObject thrownup;
    private Rigidbody rb;
    public float minspeed=12.0f;
    public float maxspeed=25.0f;
    public float torquer=10.0f;
    public int pointvalue;
    private GameManager gm;
    
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.AddForce(force(),ForceMode.Impulse);
        rb.AddTorque(randomt(),randomt(),randomt(),ForceMode.Impulse);
        transform.position=spawning();
        gm=GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    Vector3 force(){
       return Vector3.up*(Random.Range(minspeed, maxspeed));
    }
    float randomt(){
        return Random.Range(-torquer,torquer);
    }
    Vector3 spawning(){
        return new Vector3(Random.Range(-4,4),-6);
    }
    private void OnMouseDown() {
        if(gm.isgameactive){
        Debug.Log("Object clicked: " + gameObject.name);
        Destroy(gameObject);
        gm.updatescore(pointvalue);
        Instantiate(parti,transform.position,transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        gm.updatescore(-pointvalue);
        if(!gameObject.CompareTag("Bad")){
            gm.check();
            
        }
        
    }
        void Update()
    {
        
    }
}
