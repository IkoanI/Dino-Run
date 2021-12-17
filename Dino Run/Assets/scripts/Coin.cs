using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90.0f;
    public AudioClip coinSound;

    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
        if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, gameObject.transform.position) > 100f)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreCounter>().gainScore();
            AudioSource.PlayClipAtPoint(coinSound, transform.position, 0.5f);
            Destroy(gameObject);
        }
        else if(other.tag == "Obstacle")
        {
            Destroy(gameObject);
            return;
        }
    }
}
