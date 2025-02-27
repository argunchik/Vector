using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed;
    private GameObject player;
    private Rigidbody _rbEnemy;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player");
        _rbEnemy=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction=(player.transform.position-gameObject.transform.position).normalized;
        _rbEnemy.AddForce(direction*speed);
    }
}
