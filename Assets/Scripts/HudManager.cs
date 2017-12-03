using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HudManager : MonoBehaviour {

    PlayerController playerScript;
    GameObject playerObj;

    public Text timeTxt;
    public Text weightTxt;

   
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerObj.GetComponent<PlayerController>();
    }

    void Update()
    {
        //timeLeft = GameManager.timeLeft;
        timeTxt.text = GameManager.timeLeft.ToString();
        weightTxt.text = "Weight: " + playerScript.weight.ToString();
    }

}
