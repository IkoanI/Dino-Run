using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disablePopUp : MonoBehaviour
{
    public void disable()
    {
        gameObject.SetActive(false);
    }

    public void resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
