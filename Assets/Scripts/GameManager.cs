using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    PlayerController playerScript;
    GameObject playerObj;

    public GameObject foodPrefab;
    public GameObject clockPrefab;

    public GameObject goPanel;

    bool isGameOverTime;
    bool isGoTime;
    public static int timeLeft;
    


    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerObj.GetComponent<PlayerController>();

        isGoTime = true;
        timeLeft = 100;
        StartCoroutine(GenerateFood(4f));
        StartCoroutine(TimeRoutine());
    }

    void Update()
    {
        if (timeLeft <= 0)
        {
            //pause physics
            //enable game over panel
            goPanel.SetActive(true);
            isGameOverTime = true;
        }

        if (isGameOverTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(1);
            }
        }
    }


        public void DropTimeBonus()
    {
        Instantiate(clockPrefab, new Vector3(Random.Range(-48, 48), 10, Random.Range(-48, 48)), Quaternion.identity);
    }
     
    IEnumerator GenerateFood(float waitTime)
    {
        
        while (isGoTime)
        {
            Instantiate(foodPrefab, new Vector3(Random.Range(-48, 48), 10, Random.Range(-48, 48)), Quaternion.identity);
            yield return new WaitForSeconds(waitTime); 
        }
    }

    IEnumerator TimeRoutine()
    {
        while (timeLeft > 0)
        {
            timeLeft -= 1;
            yield return new WaitForSeconds(1f);
        }
    }
}
