using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PageSystem : MonoBehaviour
{
    public GameObject[] pages;
    private Animator animator;
    private GameObject page;
    private int pageNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        page = pages[pageNumber];
        page.SetActive(true);
    }

    public void Close()
    {
        page.SetActive(false);
        pageNumber++;
        page = pages[pageNumber];
        page.SetActive(true);
    }

    public void Back()
    {
        page.SetActive(false);
        pageNumber--;
        page = pages[pageNumber];
        page.SetActive(true);
    }

    /*IEnumerator Wait()
    {
	    yield return new WaitForSeconds(2);
        PopUp();
    }*/
}
