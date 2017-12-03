using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameManager gmScript;

    Rigidbody rb;
    BoxCollider bc;
    public float weight;

    //MOVEMENT STUFF
    public float movespeed;
    public float jumpForce;
    public float gravityFactor;
    bool isGrounded;

    Vector2 mouseLook;
    Vector2 smoothVector;
    Vector2 md;
    public float sensitivity;
    public float smoothing;

    public float lastMass;
    public bool isTimeToDrop;

    
    public UnityEvent clockDropEvent;

    //AUDIO STUFF
    public AudioSource audioSource;
    public AudioClip pickupFoodClip;
    public AudioClip pickupTimeClip;
    public AudioClip jumpClip;


void Start ()
    {
        //locks cursor on screen
        Cursor.lockState = CursorLockMode.Locked;

        //camera stuff
        sensitivity = 3f;
        smoothing = 2f;

        rb = this.GetComponent<Rigidbody>();

        Physics.gravity = new Vector3(Physics.gravity.x, -50f, Physics.gravity.z);
        //Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y * gravityFactor, Physics.gravity.z);

        lastMass = 70f;
    }
	

	void Update ()
    {
        CameraMethod();
        MovementMethod();
        JumpMethod();
        DropTimeBonus();

        weight = rb.mass * 2.2f;
    }

    void CameraMethod()
    {
        md = new Vector2(Input.GetAxisRaw("Mouse X"), 0);

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothVector.x = Mathf.Lerp(smoothVector.x, md.x, 1f / smoothing);
        mouseLook += smoothVector;

        gameObject.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, gameObject.transform.up);
    }

    void MovementMethod()
    {
        float translation = Input.GetAxis("Vertical") * movespeed;
        float strafe = Input.GetAxis("Horizontal") * movespeed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);
    }

    void JumpMethod()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(this.transform.up * jumpForce, ForceMode.Impulse);
            audioSource.clip = jumpClip;
            audioSource.Play();
        }
    }

    void DropTimeBonus()
    {
        
        float currentMass = rb.mass;
        print("currentmass: " + currentMass);
        print("lasMass: " + lastMass);

        if (currentMass - lastMass == 5f)
        {
            //isTimeToDrop = true;
            clockDropEvent.Invoke();
            lastMass = currentMass;
        }
        else if (currentMass - lastMass != 5f)
        {
            isTimeToDrop = false;
        }
    }

    //COLLIDERS

    //Jumping
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Food")
        {
            rb.mass += 1.0f;
            gameObject.transform.localScale += new Vector3(.1f, 0, 0);
            movespeed -= 0.2f;
            Destroy(col.gameObject);
            audioSource.clip = pickupFoodClip;
            audioSource.Play();
        }
        else if (col.gameObject.tag == "Time")
        {
            GameManager.timeLeft += 12;
            Destroy(col.gameObject);
            audioSource.clip = pickupTimeClip;
            audioSource.Play();
        }
    }
}
