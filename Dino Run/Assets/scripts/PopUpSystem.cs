using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class PopUpSystem : MonoBehaviour
{
    public GameObject[] questionStorage;
    public Animator animator;
    private GameObject currentQuestion;
    private int nextQuestion;
    private bool currentQuestionAnswered = false;
    public int questionsAnswered = 0;
    private int[] answeredQuestions;
    private bool EndPhaseActive = false;

    private void Start()
    {
        answeredQuestions = new int[questionStorage.Length];
        for(int i = 0; i < answeredQuestions.Length; i++)
        {
            answeredQuestions[i] = questionStorage.Length;
        }
        nextQuestion = Random.Range(0, 4);
        currentQuestion = questionStorage[nextQuestion];
        animator = currentQuestion.GetComponent<Animator>();

    }

    private void Update()
    {
        if(questionsAnswered == questionStorage.Length && EndPhaseActive == false)
        {
            GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().EndPhase();
            EndPhaseActive = true;
        }
        else if(currentQuestionAnswered == true && questionsAnswered < questionStorage.Length)
        {
            currentQuestion = questionStorage[nextQuestion];
            currentQuestionAnswered = false;
            animator = currentQuestion.GetComponent<Animator>();
        }
    }

    public void PopUp()
    {
        currentQuestion.SetActive(true);
        animator.SetTrigger("pop");
    }

    public void Close()
    {
        currentQuestion.SetActive(false);
        animator.SetTrigger("close");
        TerrainManager tm = GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>();
        tm.ChangeLastPrefabIndex(0);
        currentQuestionAnswered = true;
        answeredQuestions[questionsAnswered] = nextQuestion;
        questionsAnswered++;
        if(questionsAnswered < 4  && questionsAnswered < questionStorage.Length)
        {
            while(answeredQuestions.Contains(nextQuestion))
            {
                nextQuestion = Random.Range(0, 4);
            }  
        }
        else if(questionsAnswered == 4  && questionsAnswered < questionStorage.Length)
        {
            while(answeredQuestions.Contains(nextQuestion))
            {
                nextQuestion = 4;
            } 
        }
        else if(questionsAnswered >= 5  && questionsAnswered < questionStorage.Length)
        {
            while(answeredQuestions.Contains(nextQuestion))
            {
                nextQuestion = Random.Range(4, questionStorage.Length);
            } 
        }
    }
}
