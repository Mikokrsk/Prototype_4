using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float powerupStrength = 15.0f;
    public float speed = 5.0f;
    public bool hasStrengthPowerup = false;
    // public bool hasRocketsPowerup = false;
    public GameObject powerupIndicator;
    public GameObject rocket;
    public GameObject smashRing;
    public float speedRocket = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal_Point");
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(smashRing,transform.position,smashRing.transform.rotation);
        }*/
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StrengthPowerup"))
        {
            hasStrengthPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
        if (other.CompareTag("RocketsPowerup"))
        {
            Destroy(other.gameObject);
            RocketsPowerup();
        }
        if(other.CompareTag("SmashAttackPowerup"))
        {
            Instantiate(smashRing, gameObject.transform.position,smashRing.transform.rotation);
            Destroy(other.gameObject);
        }
    }

    private void RocketsPowerup()
    {
            Instantiate(rocket, gameObject.transform.position,rocket.transform.rotation);
        
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasStrengthPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasStrengthPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("111");
        }
    }
}
