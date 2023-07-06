using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashAttack : MonoBehaviour
{
    public float scaleRing = 3;
    public float splashRange = 30;
    public float speed = 30f;
    public float strength = 5f;
    float newScale = 3f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(3f, transform.localScale.y, 3f);
        newScale = 3f;
        Debug.Log("111");
    }

    // Update is called once per frame
    void Update()
    {
        newScale += Time.deltaTime * speed;

        if (newScale <= splashRange)
        {
            transform.localScale = new Vector3(newScale, transform.localScale.y, newScale);
        }
        else
        {
            //  transform.localScale = new Vector3(3f, 14f, 3f);
            Destroy(gameObject);
        }

    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 lookDirection = collision.transform.position - transform.position;
            enemyRb.AddForce(lookDirection * strength, ForceMode.Impulse);
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 lookDirection = other.transform.position - transform.position;
            enemyRb.AddForce(lookDirection * strength, ForceMode.Impulse);
        }
    }
}
