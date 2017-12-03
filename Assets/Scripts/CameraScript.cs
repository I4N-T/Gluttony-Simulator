using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothVector;
    Vector2 md;
    public float sensitivity;
    public float smoothing;

    // Use this for initialization
    void Start ()
    {
        //camera stuff
        sensitivity = 7f;
        smoothing = 2f;

    }
	
	// Update is called once per frame
	void Update ()
    {
        CameraMethod();
	
	}

    void CameraMethod()
    {
        md = new Vector2(Input.GetAxisRaw("Mouse X"), 0);

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothVector.x = Mathf.Lerp(smoothVector.x, md.x, 1f / smoothing);
        mouseLook += smoothVector;

        gameObject.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, gameObject.transform.up);
    }
}
