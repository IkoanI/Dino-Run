using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndPhaseProgress : MonoBehaviour
{
    public Image fill;
    public TextMeshProUGUI timeLeft;
    private GameObject tm;
    private float tl;
    // Start is called before the first frame update
    void Start()
    {
        tm = GameObject.FindGameObjectWithTag("TerrainManager");
    }

    // Update is called once per frame
    void Update()
    {
        tl = tm.GetComponent<TerrainManager>().timeLeft;
        fill.fillAmount = tl / 15;
        timeLeft.text = ((int) tl).ToString();
    }
}
