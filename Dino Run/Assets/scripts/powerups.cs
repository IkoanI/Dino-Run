using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerups : MonoBehaviour
{
    public float turnSpeed = 90.0f;
    private string objectName;
    private GameObject buffManager;
    public AudioClip powerupSound;

    void Start(){
        buffManager = GameObject.FindGameObjectWithTag("BuffManager");
	}

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
        if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, gameObject.transform.position) > 100f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(gameObject.name == "marketo(Clone)" && other.tag == "Player")
        {
            buffManager.GetComponent<BuffSystem>().MarketoBuff();
            AudioSource.PlayClipAtPoint(powerupSound, transform.position, 2f);
            Destroy(gameObject);
        }
        else if(gameObject.name == "integrate(Clone)" && other.tag == "Player")
        {
            buffManager.GetComponent<BuffSystem>().IntegrateBuff();
            AudioSource.PlayClipAtPoint(powerupSound, transform.position, 2f);
            Destroy(gameObject);
        }
        else if(gameObject.name == "oktopost(Clone)" && other.tag == "Player")
        {
            buffManager.GetComponent<BuffSystem>().OktopostBuff();
            AudioSource.PlayClipAtPoint(powerupSound, transform.position, 2f);
            Destroy(gameObject);
        }
        else if(gameObject.name == "meiro(Clone)" && other.tag == "Player")
        {
            buffManager.GetComponent<BuffSystem>().MeiroBuff();
            AudioSource.PlayClipAtPoint(powerupSound, transform.position, 2f);
            Destroy(gameObject);
        }
        else if(gameObject.name == "saleswhale(Clone)" && other.tag == "Player")
        {
            buffManager.GetComponent<BuffSystem>().SaleswhaleBuff();
            AudioSource.PlayClipAtPoint(powerupSound, transform.position, 2f);
            Destroy(gameObject);
        }
        else if(other.tag == "Obstacle(Clone)")
        {
            Destroy(gameObject);
            return;
        }
    }
}
