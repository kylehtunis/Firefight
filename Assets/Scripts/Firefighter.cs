using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Firefighter : MonoBehaviour
{

    public float speed;
    public GameObject waterPrefab;
    public float waterDistance;
    public int fireRate;

    private float timeSinceLastWater = 0;
    //Rigidbody2D rb;
    Vector3 pos;
    Quaternion rot;

    // Use this for initialization
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        pos = transform.position;
        rot = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > timeSinceLastWater + fireRate)
        {
            timeSinceLastWater = Time.time;
            Vector3 pos = transform.position;
            Instantiate(waterPrefab, new Vector3(pos.x, pos.y, 0), transform.rotation);

        }


        if (Input.GetAxisRaw("Horizontal")<0 && transform.position == pos)
        {        // Left
            pos += Vector3.left;
            rot = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        if (Input.GetAxisRaw("Horizontal")>0 && transform.position == pos)
        {        // Right
            pos += Vector3.right;
            rot = Quaternion.Euler(new Vector3(0, 0, -90));
        }
        if (Input.GetAxisRaw("Vertical")>0 && transform.position == pos)
        {        // Up
            pos += Vector3.up;
            rot = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (Input.GetAxisRaw("Vertical")<0 && transform.position == pos)
        {        // Down
            pos += Vector3.down;
            rot = Quaternion.Euler(new Vector3(0, 0, -180));
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
        transform.rotation = rot;

        //Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        ////CharacterController control = GetComponent<CharacterController>();

        //Vector3 movement = new Vector3(0, 0, 0);
        //if (((transform.position.x <= 5 * (16.0f / 9.0f)) || input.x <= 0) &&
        //    ((transform.position.x >= -5 * (16.0f / 9.0f)) || input.x >= 0))
        //{
        //    movement += Vector3.right * Input.GetAxis("Horizontal");
        //}
        //if (((transform.position.y <= 5) || input.y <= 0) && ((transform.position.y >= -5) || input.y >= 0))
        //{
        //    movement += Vector3.up * Input.GetAxis("Vertical");
        //}
        //if (movement.magnitude > 1)
        //{
        //    movement.Normalize();
        //}
        ////transform.position += movement * speed * Time.deltaTime;
        //rb.velocity = movement * speed;
        //control.Move(movement * speed * Time.deltaTime);


        //if (Input.GetAxisRaw("Vertical")!=0|| Input.GetAxisRaw("Horizontal") != 0)
        //{
        //    transform.rotation = Quaternion.Euler
        //        (new Vector3(0, 0, (Mathf.Atan2(input.y, input.x) - Mathf.PI / 2) * Mathf.Rad2Deg));
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fire")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(Controller.level);
        }
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class Firefighter : MonoBehaviour {

//    public float speed;
//    public GameObject waterPrefab;
//    public float waterDistance;
//    public int fireRate;

//	bool facingRight = true;
//	bool facingLeft = false;
//	bool facingUp = false;
//	bool facingDown = false;

//    private float timeSinceLastWater = 0;
//	private Rigidbody2D rb;
//	public Sprite up;
//	public Sprite down;
//	public Sprite left;
//	public Sprite right;
//	public Sprite[] upFrames;
//	public Sprite[] downFrames;
//	public Sprite[] leftFrames;
//	public Sprite[] rightFrames;
//	public float framesPerSecond;
//	private SpriteRenderer sr;


//	// Use this for initialization
//	void Start () {
//        rb = GetComponent<Rigidbody2D>();
//		sr = GetComponent<SpriteRenderer> ();
//	}

//    // Update is called once per frame
//    void Update()
//    {
//		float horizontal = Input.GetAxis ("Horizontal");
//		float vertical = Input.GetAxis ("Vertical");

//		if (vertical <= -0.9) {
//			sr.sprite = down;
//			facingDown = true;
//			facingUp = false;
//			facingLeft = false;
//			facingRight = false;
//			StartCoroutine (PlayAnimation (downFrames));
//		} else if (vertical >= 0.9) {
//			sr.sprite = up;
//			facingUp = true;
//			facingDown = false;
//			facingLeft = false;
//			facingRight = false;
//			StartCoroutine (PlayAnimation (upFrames));
//		} 

//		if (horizontal <= -0.9) {
//			sr.sprite = left;
//			facingLeft = true;
//			facingRight = false;
//			facingUp = false;
//			facingDown = false;
//			StartCoroutine (PlayAnimation (leftFrames));
//		} else if (horizontal >= 0.9) {
//			sr.sprite = right;
//			facingRight = true;
//			facingLeft = false;
//			facingUp = false;
//			facingDown = false;
//			StartCoroutine (PlayAnimation (rightFrames));
//		}

//		HandleMovement (horizontal, vertical);
			
//		if (Input.GetKeyDown (KeyCode.Space) && Time.time > timeSinceLastWater + fireRate) {
//			timeSinceLastWater = Time.time;
//			Vector3 pos = transform.position;
//			if (facingRight) {
//				Instantiate (waterPrefab, new Vector3 (pos.x, pos.y, 0), Quaternion.Euler (new Vector3 (0,0,-90)));
//			} else if (facingLeft) {
//				Instantiate (waterPrefab, new Vector3 (pos.x, pos.y, 0), Quaternion.Euler (new Vector3 (0, 0, 90)));
//			} else if (facingUp) {
//				Instantiate (waterPrefab, new Vector3 (pos.x, pos.y, 0), Quaternion.Euler (new Vector3 (0, 0, 0)));
//			} else if (facingDown) {
//				Instantiate (waterPrefab, new Vector3 (pos.x, pos.y, 0), Quaternion.Euler (new Vector3 (0, 0, 180)));
//			}
//		}

////        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
////        //CharacterController control = GetComponent<CharacterController>();
////
////        Vector3 movement = new Vector3(0, 0, 0);
////        if (((transform.position.x <= 5 * (16.0f / 9.0f)) || input.x <= 0) &&
////            ((transform.position.x >= -5 * (16.0f / 9.0f)) || input.x >= 0))
////        {
////            movement += Vector3.right * Input.GetAxis("Horizontal");
////        }
////        if (((transform.position.y <= 5) || input.y <= 0) && ((transform.position.y >= -5) || input.y >= 0))
////        {
////            movement += Vector3.up * Input.GetAxis("Vertical");
////        }
////        if (movement.magnitude > 1)
////        {
////            movement.Normalize();
////        }
////        //transform.position += movement * speed * Time.deltaTime;
////        rb.velocity = movement * speed;
////        //control.Move(movement * speed * Time.deltaTime);
////
////
////        if (input.x != 0 || input.y != 0)
////        {
////            transform.rotation = Quaternion.Euler
////                (new Vector3(0, 0, (Mathf.Atan2(input.y, input.x) - Mathf.PI / 2) * Mathf.Rad2Deg));
////        }


//    }

//	void HandleMovement(float horizontal, float vertical)
//	{
//		rb.velocity = new Vector2 (horizontal * speed, vertical * speed);
//	}

//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.tag == "Fire")
//        {
//            Destroy(gameObject);
//            SceneManager.LoadScene(Controller.level);
//        }
//    }

//	IEnumerator PlayAnimation(Sprite[] frames)
//	{
//		int currentFrameIndex = 0;
//		while (currentFrameIndex < frames.Length) {
//			sr.sprite = frames [currentFrameIndex];
//			yield return new WaitForSeconds(5f/framesPerSecond); // this halts the functions execution for x seconds. Can only be used in coroutines.
//			currentFrameIndex++;
//		}
//	}
//}

