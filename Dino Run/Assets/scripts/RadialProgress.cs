using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RadialProgress : MonoBehaviour
{
    public Image fill;
    public TextMeshProUGUI questionsAnswered;
    private GameObject qm;
    private int qa;
    // Start is called before the first frame update
    void Start()
    {
        qm = GameObject.FindGameObjectWithTag("QuestionManager");
    }

    // Update is called once per frame
    void Update()
    {
        qa = qm.GetComponent<PopUpSystem>().questionsAnswered;
        fill.fillAmount = (float) qa / 10;
        questionsAnswered.text = qa.ToString();
    }
}
