using UnityEngine;
using System.Collections;

public class ClockScript : MonoBehaviour {


    void Update()
    {
        FaceCamera();
    }

    void FaceCamera()
    {
        Vector3 targetPosition = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(targetPosition);
    }
}
