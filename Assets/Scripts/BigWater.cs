using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWater : MonoBehaviour
{

    public float lifetime;
    public int waterSpeed;

    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        StartCoroutine(destroyAfterSeconds(gameObject, lifetime));
    }

    // Update is called once per frame
    void Update()
    {
        float theta = (transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad;
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
    }

    IEnumerator destroyAfterSeconds(GameObject toDestroy, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(toDestroy);
    }
}
