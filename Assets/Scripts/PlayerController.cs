using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private float powerupStrength = 10f;
    public float speed = 10;
    public GameObject focalPoint;
    public bool hasPowerUp = false;
    public Transform powerupIndicator;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerupIndicator.transform.position = transform.position + new Vector3(0f, -.5f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        powerupIndicator.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
