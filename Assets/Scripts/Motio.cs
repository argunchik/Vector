using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motio : MonoBehaviour
{
    private float vertIn;
    public float speed;
    private GameObject FocalPoint;
    public GameObject Borders;
    private GameObject _border;
    private Rigidbody rb;
    public bool hasPowerUp=false;
    // Start is called before the first frame update
    void Start()
    {
        FocalPoint=GameObject.Find("FocalPoint");
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vertIn=Input.GetAxis("Vertical");
        rb.AddForce(FocalPoint.transform.forward*speed*vertIn);
        // transform.Translate(FocalPoint.transform.forward*Time.deltaTime*speed*vertIn);
        // GameObject[] enemyMas=GameObject.FindGameObjectsWithTag("Enemy");
        // print(enemyMas);
        // GameObject enemy=FindObjectOfType<Enemy2>();
        int enemy=FindObjectsOfType<Enemy2>().Length;
        // print(enemy);
        if (transform.position.y<-30)
        {
            transform.position=Vector3.zero;
            rb.velocity=Vector3.zero;
            rb.angularVelocity=Vector3.zero;
        }
    }

    void Transparency(Renderer renObject, float transparency)
    {
        Material borderMaterial=renObject.material;
        Color oldColor=borderMaterial.color;
        Color newColor=new Color(oldColor.r,oldColor.g,oldColor.b,transparency);
        borderMaterial.SetColor("_Color",newColor);
    }

    IEnumerator PowerUpCoroutine()
    {
        //  yield return new WaitForSeconds(5);

        Renderer[] masBorRen=_border.GetComponentsInChildren<Renderer>();
        // _border.SetActive(false);
        for (float k=0;k<5;k+=1)
        {
            for (float j=0;j<1;j+=0.1f)
            {
                yield return new WaitForSeconds(0.1f);
                for (int i=0;i<masBorRen.Length;i++)
                {
                    Transparency(masBorRen[i],j);
                }
            }
            for (float j=1;j>0;j-=0.1f)
            {
                yield return new WaitForSeconds(0.1f);
                for (int i=0;i<masBorRen.Length;i++)
                {
                    Transparency(masBorRen[i],j);
                }
            }
        }
        
            

        transform.localScale=new Vector3(1,1,1);
        Destroy(_border);
        hasPowerUp=false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="PowerUp")
        {
            Destroy(other.gameObject);
            transform.localScale=new Vector3(5,5,5);
            hasPowerUp=true;
            _border=Instantiate(Borders,Borders.transform.position,Borders.transform.rotation);
            // print("PowerUp");
            StartCoroutine(PowerUpCoroutine());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Enemy" && hasPowerUp)
        {
            Rigidbody enemyRb=other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer=(other.gameObject.transform.position-transform.position).normalized;
            enemyRb.AddForce(awayFromPlayer*20,ForceMode.Impulse);
        }
    }
}
