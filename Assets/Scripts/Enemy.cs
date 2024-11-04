using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform playerPos;
    public float speed = 3f;
    private Rigidbody enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerPos = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (playerPos.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection* speed);
    }
}
