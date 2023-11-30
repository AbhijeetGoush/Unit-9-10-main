using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public Transform asteroidTrans;
    Rigidbody2D asteroidRb;
    int randomRotation;
    public float asteroidSpeed;
    // Start is called before the first frame update
    void Start()
    {
        randomRotation = Random.Range(0, 360);
        asteroidPrefab.transform.rotation = Quaternion.Euler(0, 0, randomRotation);
        asteroidRb = GetComponent<Rigidbody2D>();
        asteroidRb.AddForce(transform.up * asteroidSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (asteroidTrans.position.x >= 10.788f)
        {
            asteroidTrans.transform.position = new Vector2(-10.683f, asteroidTrans.position.y);
        }
        if (asteroidTrans.position.x <= -10.788)
        {
            asteroidTrans.transform.position = new Vector2(10.683f, asteroidTrans.position.y);
        }
        if (asteroidTrans.position.y >= 6.4f)
        {
            asteroidTrans.transform.position = new Vector2(asteroidTrans.position.x, -6);
        }
        if (asteroidTrans.position.y <= -6.4f)
        {
            asteroidTrans.transform.position = new Vector2(asteroidTrans.position.x, 6);
        }
    }

    public void DestroyAsteroid()
    {
        Destroy(this.gameObject);
    }
}
