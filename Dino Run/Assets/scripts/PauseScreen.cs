using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void setUnactive()
    {
        gameObject.SetActive(false);
    }
}
