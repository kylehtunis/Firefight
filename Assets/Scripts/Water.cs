using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    public float lifetime;
    public int waterSpeed;
    public GameObject bigWater;

	// Use this for initialization
	void Start () {
		
	}

    void Awake()
    {
        StartCoroutine(destroyAfterSeconds(gameObject, lifetime));
    }
	
	// Update is called once per frame
	void Update () {
        float theta = (transform.rotation.eulerAngles.z+90)*Mathf.Deg2Rad;
        Vector3 movement = new Vector2();
        movement.x = Mathf.Cos(theta) * waterSpeed;
        movement.y = Mathf.Sin(theta) * waterSpeed;
        transform.position += movement * Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fire")
        {
            Destroy(other.gameObject);
            
            print(Controller.numberOfFires);
        }
        else if (other.tag == "SteelWall" || other.tag == "WoodWall")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Sprinkler")
        {
            Instantiate(bigWater, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
        }
    }

    IEnumerator destroyAfterSeconds(GameObject toDestroy, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(toDestroy);
    }
}
