using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTrigger : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        PopUpSystem pop = GameObject.FindGameObjectWithTag("QuestionManager").GetComponent<PopUpSystem>();
        pop.PopUp();

    }
}
