using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	public GameObject firePrefab;
    public int gasSpawnNumber;

	private float lastSpawnTime = 0;


	public void Update(){
		if (Random.Range (0, 500) == 0&&Time.time>lastSpawnTime+1&&Controller.numberOfFires<Controller.maxNumberOfFires) {
			lastSpawnTime = Time.time;
			Vector2 randomPos = (Random.insideUnitCircle)*1.5f+new Vector2(transform.position.x, transform.position.y);
			// instantiate brain prefab at random position (the function takes a vector3, so we need to create one)
			Instantiate(firePrefab, new Vector3(randomPos.x, randomPos.y, 0), Quaternion.identity);
		}
	}

    public void Awake()
    {
        Controller.numberOfFires++;
        if (transform.position.x >= 5 * (16.0f / 9.0f) ||
            (transform.position.x <= -5 * (16.0f / 9.0f)))
        {
            Destroy(gameObject);
        }
        else if (transform.position.y >= 5 || (transform.position.y <= -5))
        {
            Destroy(gameObject);
        }
        print(Controller.numberOfFires);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SteelWall")
        {
            Destroy(this.gameObject);
            
        }
        if (other.tag == "WoodWall")
        {
            StartCoroutine(destroyAfterSeconds(other.gameObject, true));
        }
        if (other.tag == "Gas")
        {
            StartCoroutine(destroyAfterSeconds(other.gameObject, true));
            StartCoroutine(gas());
        }
    }

    void OnDestroy()
    {
        Controller.numberOfFires--;
        print(Controller.numberOfFires);
    }

    IEnumerator destroyAfterSeconds(GameObject toDestroy, bool darken = false, float seconds = 2)
    {
        yield return new WaitForSeconds(seconds/2);
        toDestroy.GetComponent<SpriteRenderer>().color = Color.grey;
        yield return new WaitForSeconds(seconds / 2);
        Destroy(toDestroy);
    }

    IEnumerator gas()
    {
        yield return new WaitForSeconds(2.3f);
        for (int i = 0; i < gasSpawnNumber; i++)
        {
            Vector2 randomPos = (Random.insideUnitCircle) * 1.5f + new Vector2(transform.position.x, transform.position.y);
            // instantiate brain prefab at random position (the function takes a vector3, so we need to create one)
            Instantiate(firePrefab, new Vector3(randomPos.x, randomPos.y, 0), Quaternion.identity);
        }
    }
}




