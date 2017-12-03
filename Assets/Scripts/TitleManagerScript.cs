using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleManagerScript : MonoBehaviour {

	void Update()
    {
        if (Input.anyKeyDown)
        {
            //only do it for any KEY, not mouse clicks
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            {
                //do nothing
                return;
            }
            SceneManager.LoadScene(1);
        }
    }
}
