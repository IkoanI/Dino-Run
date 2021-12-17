using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuffSystem : MonoBehaviour
{
    public GameObject buff;
    public TMPro.TextMeshProUGUI buffText;
    private Animator animator;
    public GameObject companyBuff;
    public TMPro.TextMeshProUGUI companyBuffText;
    private Animator companyAnimator;
    public Sprite[] companies;
    public Image companyEmbed;
    

    void Start()
    {
        animator = buff.GetComponent<Animator>();
        companyAnimator = companyBuff.GetComponent<Animator>();
    }

    public void IncreaseValue()
    {
        buffText.text = "Value of leads increased!";
        buff.SetActive(true);
        animator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().IncreaseValue();
    }

    public void IncreaseValueGreatly()
    {
        buffText.text = "Value of leads increased greatly!";
        buff.SetActive(true);
        animator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().IncreaseValueGreatly();
    }


    public void FrequencyDecrease()
    {
        buffText.text = "Frequency of leads decreased!";
        buff.SetActive(true);
        animator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().DecreaseFrequency();
    }


    public void FrequencyDecreaseGreatly()
    {
        buffText.text = "Frequency of leads decreased greatly!";
        buff.SetActive(true);
        animator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().DecreaseFrequencyGreatly();
    }


    public void EndPhaseLeadIncreaseFrequency()
    {
        buffText.text = "Frequency of leads increased in the endphase!";
        buff.SetActive(true);
        animator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().IncreaseEndPhaseLeadFrequency();
    }

    public void EndPhaseLeadGreatlyIncreaseFrequency()
    {
        buffText.text = "Frequency of leads greatly increased in the endphase!";
        buff.SetActive(true);
        animator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().GreatlyIncreaseEndPhaseLeadFrequency();
    }

    public void EndPhaseLeadGreatlyDecreaseFrequency()
    {
        buffText.text = "Frequency of leads greatly decreased in the endphase!";
        buff.SetActive(true);
        animator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().GreatlyDecreaseEndPhaseLeadFrequency();
    }

    public void FrequencyIncrease()
    {
        buffText.text = "Frequency of leads increased!";
        buff.SetActive(true);
        animator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().IncreaseFrequency();
    }

    public void FrequencyIncreaseGreatly()
    {
        buffText.text = "Frequency of leads increased greatly!";
        buff.SetActive(true);
        animator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().IncreaseFrequencyGreatly();
    }


    public void FrequencyIncreaseSlightly()
    {
        buffText.text = "Frequency of leads increased slightly!";
        buff.SetActive(true);
        animator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().IncreaseFrequencySlightly();
    }


    public void FrequencyDecreaseAndEndPhaseLeadGreatlyIncreaseFrequency()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        FrequencyDecrease();
	    yield return new WaitForSeconds(2);
        EndPhaseLeadGreatlyIncreaseFrequency();
    }

    public void FrequencyIncreaseAndEndPhaseLeadGreatlyDecreaseFrequency()
    {
        StartCoroutine(Wait2());
    }

    IEnumerator Wait2()
    {
        FrequencyIncrease();
	    yield return new WaitForSeconds(2);
        EndPhaseLeadGreatlyDecreaseFrequency();
    }

    public void ScoreIncrease()
    {
        buffText.text = "200 leads gained!";
        buff.SetActive(true);
        animator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreCounter>().gainFlatScore();
    }

    public void MarketoBuff()
    {
        companyBuffText.text = "Marketing automation with Marketo activated! Frequency of leads increased!";
        companyEmbed.sprite = companies[0];
        companyBuff.SetActive(true);
        companyAnimator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().IncreaseFrequency();
        StartCoroutine(Wait1());
    }

    public void IntegrateBuff()
    {
        companyBuffText.text = "Integrate's Demand Acceleration Platform activated! Frequency of leads increased!";
        companyEmbed.sprite = companies[1];
        companyBuff.SetActive(true);
        companyAnimator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().IncreaseFrequency();
        StartCoroutine(Wait1());
    }

    public void OktopostBuff()
    {
        companyBuffText.text = "Oktopost's B2B Social Media Tool activated! Frequency of leads increased!";
        companyEmbed.sprite = companies[2];
        companyBuff.SetActive(true);
        companyAnimator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().IncreaseFrequency();
        StartCoroutine(Wait1());
    }

    public void MeiroBuff()
    {
        companyBuffText.text = "Meiro's B2B Customer Data Platform activated! Frequency of leads increased!";
        companyEmbed.sprite = companies[3];
        companyBuff.SetActive(true);
        companyAnimator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().IncreaseFrequency();
        StartCoroutine(Wait1());
    }

    public void SaleswhaleBuff()
    {
        companyBuffText.text = "Saleswhale's B2B Virtual SDR activated! 200 leads gained!";
        companyEmbed.sprite = companies[4];
        companyBuff.SetActive(true);
        companyAnimator.SetTrigger("pop");
        GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreCounter>().gainFlatScore();
        StartCoroutine(Wait1());
    }

    IEnumerator Wait1()
    {
	    yield return new WaitForSeconds(0.29f);
        Time.timeScale = 0;
    }
}
