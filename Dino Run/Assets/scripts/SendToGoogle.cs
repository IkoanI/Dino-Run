using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Linq;

public class SendToGoogle : MonoBehaviour
{
    public static string Name;
    private string Email;
    private string Score;
    public GameObject errorMessage;
    public TMPro.TextMeshProUGUI errorText;
    private Animator animator;
    public const string MatchEmailPattern =
		@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
		+ @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
		+ @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
		+ @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSehKuvOfuA88LHRe3h5wpXIkN4xkk1TJOzg7nJpe9ybMdjoZw/formResponse";

    IEnumerator Post(string name, string email, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.527661480", name);
        form.AddField("entry.1462628877", email);
        form.AddField("entry.1959048935", score.ToString());
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
    }

    public void ReadInputName(string s)
    {
        Name = s;
    }

    public void ReadInputEmail(string s)
    {
        Email = s;
    }

    public void Send()
    {
        if(Email.Contains("gmail.") || Email.Contains("yahoo.") || Email.Contains("ymail.") || Email.Contains("hotmail.") || Email.Contains("outlook."))
        {
            animator = errorMessage.GetComponent<Animator>();
            errorText.text = "Please enter your business email!";
            errorMessage.SetActive(true);
            animator.SetTrigger("pop");
        }
        else if(validateName(Name) && validateEmail(Email))
        {
            StartCoroutine(Post(Name, Email, (int)ScoreCounter.scoreAmount));
            HighScores.UploadScore(Name, (int)ScoreCounter.scoreAmount);
            gameObject.GetComponent<ToggleScenes>().ToLeaderboard();
        }
        else if(validateEmail(Email) == false)
        {
            animator = errorMessage.GetComponent<Animator>();
            errorText.text = "Please enter a valid email";
            errorMessage.SetActive(true);
            animator.SetTrigger("pop");
        }
    }

    public bool validateName(string name)
	{
		if (name.Any(char.IsWhiteSpace) || name.Contains("*"))
        {
            animator = errorMessage.GetComponent<Animator>();
            errorText.text = "Name cannot contain spaces or asterisk!";
            errorMessage.SetActive(true);
            animator.SetTrigger("pop");
            return false;
        }
        else if(name == "" || name == null)
        {
            animator = errorMessage.GetComponent<Animator>();
            errorText.text = "Please enter a valid name!";
            errorMessage.SetActive(true);
            animator.SetTrigger("pop");
            return false;
        }
		else
			return true;
	}

    public static bool validateEmail (string email)
	{
		if (email != null)
			return Regex.IsMatch(email, MatchEmailPattern);
		else
			return false;
	}
}
