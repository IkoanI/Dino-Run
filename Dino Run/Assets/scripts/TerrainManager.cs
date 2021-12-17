using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;

public class TerrainManager : MonoBehaviour
{
    public GameObject[] terrainPrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float terrainLength = 40.0f;
    private int amtTerrainOnScreen = 3;
    private List<GameObject> activeTiles;
    private float safeZone = 40.0f;
    private int lastPrefabIndex = 0;
    private bool endPhase = false;
    private float endPhaseLeadsFrequencyMultiplier = 1f;
    private float frequencyMultiplier = 1f;
    public float timeLeft;
    
    public GameObject coinPrefab;
    private int maxLeadsPerTerrain;

    public GameObject gemPrefab;
    private bool canSpawnGems = false;
    
    public GameObject diamondPrefab;
    private bool canSpawnDiamonds = false;

    public GameObject[] companyPrefabs;
    private List<int> spawnedCompanies;
    private int companyIndex;

    public GameObject endPhasePopUp;
    private Animator endPhasePopUpAnimator;

    private GameObject popUp;
    private int qa;
    
    public GameObject progressBar;
    public GameObject endPhaseProgressBar;

    private int prefabsToNextQuestion = 2;


    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        spawnedCompanies = new List<int>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        popUp = GameObject.FindGameObjectWithTag("QuestionManager");

        for(int i = 0; i < amtTerrainOnScreen; i++)
        {
            SpawnTerrain();
        }
    }

    // Update is called once per frame
    void Update()
    {
        qa = popUp.GetComponent<PopUpSystem>().questionsAnswered;
        if(canSpawnGems)
        {
            maxLeadsPerTerrain = 3;
            maxLeadsPerTerrain = (int)System.Math.Round(maxLeadsPerTerrain * frequencyMultiplier);
        }
        else if(canSpawnDiamonds)
        {
            maxLeadsPerTerrain = 2;
            maxLeadsPerTerrain = (int)System.Math.Round(maxLeadsPerTerrain * frequencyMultiplier);
        }
        else
        {
            maxLeadsPerTerrain = 5;
            maxLeadsPerTerrain = (int)System.Math.Round(maxLeadsPerTerrain * frequencyMultiplier);
        }


        if(playerTransform.position.z - safeZone > (spawnZ - amtTerrainOnScreen * terrainLength))
        {
            SpawnTerrain();
            DeleteTerrain();
        }

        if(endPhase)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0f)
            {
                GameObject.FindGameObjectWithTag("SceneManager").GetComponent<ToggleScenes>().ToEnd();
            }

        }
    }



    private void SpawnTerrain(int prefabIndex = -1)
    {
        int terrainToSpawn = RandomPrefabIndex();
        GameObject go;
        go = Instantiate(terrainPrefabs[terrainToSpawn]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(-29.0f, 12.9f, spawnZ);
        spawnZ += terrainLength;
        activeTiles.Add(go);
        
        if(go.name != "terrain0(Clone)" && go.name != "triggerTerrain0(Clone)")
        {
            if(canSpawnDiamonds)
            {
                SpawnDiamond(go);
            }
            else if(canSpawnGems)
            {
                SpawnGem(go);
            }
            else
            {
                SpawnCoin(go);
            }
        }

        if(go.name != "terrain0(Clone)" && go.name != "triggerTerrain0(Clone)" && prefabsToNextQuestion == 1 && spawnedCompanies.Count < companyPrefabs.Length && qa % 2 != 0)
        {
            SpawnCompany(go);
        }
    }



    private void DeleteTerrain()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    } 



    private int RandomPrefabIndex()
    {
        if(terrainPrefabs.Length <= 1 || activeTiles.Count <= 1 || lastPrefabIndex == 1)
        {
            return 0;
        }

        if(endPhase != true)
        {
            if(prefabsToNextQuestion == 0)
            {
                lastPrefabIndex = 1;
                prefabsToNextQuestion = 2;
                return 1;
            }
        }

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(2, terrainPrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        
        if(endPhase != true)
        {
           prefabsToNextQuestion -= 1;
        }
        
        return randomIndex;
    }



    public void ChangeLastPrefabIndex(int changedValue)
    {
        lastPrefabIndex = changedValue;
    }



    private void SpawnCoin(GameObject go)
    {
        for(int i = 0; i < maxLeadsPerTerrain; i++)
        {
            GameObject temp = Instantiate(coinPrefab);
            temp.transform.position = GetRandomPoint(go);
        }
    }



    private void SpawnGem(GameObject go)
    {
        for(int i = 0; i < maxLeadsPerTerrain; i++)
        {
            GameObject temp = Instantiate(gemPrefab);
            temp.transform.position = GetRandomPoint(go);
        }
    }



    private void SpawnDiamond(GameObject go)
    {
        for(int i = 0; i < maxLeadsPerTerrain; i++)
        {
            GameObject temp = Instantiate(diamondPrefab);
            temp.transform.position = GetRandomPoint(go);
        }
    }

    private void SpawnCompany(GameObject go)
    {
        if(spawnedCompanies.Count() == 0)
        {
            companyIndex = 0;
        }
        else
        {
            companyIndex = Random.Range(0, companyPrefabs.Length);
            while(spawnedCompanies.Contains(companyIndex))
            {
                companyIndex = Random.Range(0, companyPrefabs.Length);
            }
        }
        GameObject company;
        company = Instantiate(companyPrefabs[companyIndex]) as GameObject;
        company.transform.SetParent(transform);
        company.transform.position = GetRandomPoint(go);
        spawnedCompanies.Add(companyIndex);
    }


    public void IncreaseValue()
    {
        canSpawnGems = true;
    }


    public void IncreaseValueGreatly()
    {
        canSpawnGems = false;
        canSpawnDiamonds = true;
    }


    public void DecreaseFrequency()
    {
        frequencyMultiplier -= 0.25f;
    }

    public void DecreaseFrequencyGreatly()
    {
        frequencyMultiplier -= 0.5f;
    }

    public void IncreaseFrequency()
    {
        frequencyMultiplier += 0.25f;
    }

    public void IncreaseFrequencyGreatly()
    {
        frequencyMultiplier += 0.5f;
    }

    public void IncreaseFrequencySlightly()
    {
        frequencyMultiplier += 0.1f;
    }

    public void IncreaseEndPhaseLeadFrequency()
    {
        endPhaseLeadsFrequencyMultiplier += 0.5f;
    }

    public void GreatlyIncreaseEndPhaseLeadFrequency()
    {
        endPhaseLeadsFrequencyMultiplier += 2f;
    }

    public void GreatlyDecreaseEndPhaseLeadFrequency()
    {
        endPhaseLeadsFrequencyMultiplier -= 1f;
    }


    private Vector3 GetRandomPoint(GameObject go)
    {
        Vector3 point = new Vector3(
            Random.Range(-1.5f, 1.5f),
            1,
            Random.Range(go.transform.position.z - 20f, go.transform.position.z + 20f));

        return point;
    }


    public void EndPhase()
    {
        endPhase = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>().IncreaseSpeed();
        frequencyMultiplier *= endPhaseLeadsFrequencyMultiplier;
        timeLeft = 15.0f;
        endPhasePopUp.SetActive(true);
        endPhasePopUpAnimator = endPhasePopUp.GetComponent<Animator>();
        progressBar.SetActive(false);
        endPhaseProgressBar.SetActive(true);
        StartCoroutine(Wait());

    }
    IEnumerator Wait()
    {
	    yield return new WaitForSeconds(2);
        endPhasePopUpAnimator.SetTrigger("pop");
    }
}
