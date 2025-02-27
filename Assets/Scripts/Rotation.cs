using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    private float horizontalIn;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalIn=Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up,horizontalIn*Time.deltaTime*speed);    
    }
}
