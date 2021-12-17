using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Sprite[] digits;
    public Image[] characters;
    public static float scoreAmount;
    private int numberOfDigitsInScoreAmount;

    // Start is called before the first frame update
    void Start() 
    {
        for(int i = 0; i < 4; i++)
        {
            characters[i].sprite = digits[0];
        }
        scoreAmount = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        int[] scoreAmountByDigitsArray = getDigitArrayFromScoreAmount((int)scoreAmount);

        switch(scoreAmountByDigitsArray.Length)
        {
            case 1:
                characters[0].sprite = digits[0];
                characters[1].sprite = digits[0];
                characters[2].sprite = digits[0];
                characters[3].sprite = digits[scoreAmountByDigitsArray[0]];
                break;
            case 2:
                characters[0].sprite = digits[0];
                characters[1].sprite = digits[0];
                characters[2].sprite = digits[scoreAmountByDigitsArray[0]];
                characters[3].sprite = digits[scoreAmountByDigitsArray[1]];
                break;
            case 3:
                characters[0].sprite = digits[0];
                characters[1].sprite = digits[scoreAmountByDigitsArray[0]];
                characters[2].sprite = digits[scoreAmountByDigitsArray[1]];
                characters[3].sprite = digits[scoreAmountByDigitsArray[2]];
                break;
            case 4:
                characters[0].sprite = digits[scoreAmountByDigitsArray[0]];
                characters[1].sprite = digits[scoreAmountByDigitsArray[1]];
                characters[2].sprite = digits[scoreAmountByDigitsArray[2]];
                characters[3].sprite = digits[scoreAmountByDigitsArray[3]];
                break;
        }
    }

    private int[] getDigitArrayFromScoreAmount(int scoreAmount)
    {
        List<int> digitsList = new List<int>();
        if(scoreAmount == 0)
        {
            digitsList.Add(0);
            digitsList.Add(0);
            return digitsList.ToArray();
        }
        while(scoreAmount > 0)
        {
            digitsList.Add(scoreAmount % 10);
            scoreAmount = scoreAmount / 10;
        }
        digitsList.Reverse();
        return digitsList.ToArray();
    }

    public void gainScore()
    {
        scoreAmount++;
    }

    public void loseScore()
    {
        if(scoreAmount > 0)
        {
            scoreAmount--;
        }
    }

    public void gainFlatScore()
    {
        scoreAmount += 200f;
    }
}
