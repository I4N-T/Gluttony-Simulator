using UnityEngine;
using System.Collections;

public class foodScript : MonoBehaviour {

    public Sprite[] foodSpriteArray;
    SpriteRenderer spriteRend;

   // public GameObject playerObj;

    void Start()
    {
        //playerObj = GameObject.FindGameObjectWithTag("Player");
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        SetSprite();

    }

    void Update()
    {
        FaceCamera();
    }

    void SetSprite()
    {
        int rand = Random.Range(0, foodSpriteArray.Length);
        spriteRend.sprite = foodSpriteArray[rand];
    }

    void FaceCamera()
    {
        Vector3 targetPosition = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(targetPosition);
    }

}
