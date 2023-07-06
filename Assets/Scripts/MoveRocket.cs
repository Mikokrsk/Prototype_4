using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocket : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rocketRb;
    private GameObject enemy;
    private Collider rocketCollider;
    // Start is called before the first frame update
    void Start()
    {
        rocketCollider = gameObject.GetComponent<Collider>();
        rocketRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindWithTag("Enemy");
        Vector3 lookDirection = (enemy.transform.position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(lookDirection, transform.up);
        transform.rotation = rot;
        rocketRb.AddForce(transform.forward * speed);
        if (transform.position.x < -20 || transform.position.x > 20 || transform.position.z < -20 || transform.position.z > 20)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        rocketCollider.enabled = true;
    }
}
