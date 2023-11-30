using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAsteroidSpawner : MonoBehaviour
{
    Transform leftSpawnerTrans;
    int randomY;
    float xPos = -12f;
    // Start is called before the first frame update
    void Start()
    {
        leftSpawnerTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        randomY = Random.Range(-9, 9);
        leftSpawnerTrans.transform.position = new Vector2(xPos, randomY);
    }
}
