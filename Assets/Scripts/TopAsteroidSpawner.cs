using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TopAsteroidSpawner : MonoBehaviour
{
    Transform topSpawnerTrans;
    public GameObject asteroidPrefab;
    bool spawnCooldown;
    int randomTimer;
    int randomX;
    float yPos = 5.5f;
    // Start is called before the first frame update
    void Start()
    {
        topSpawnerTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        randomTimer = Random.Range(1, 4);

        if (spawnCooldown == false)
        {
            Instantiate(asteroidPrefab, topSpawnerTrans.transform.position, Quaternion.identity);
            Invoke("ResetCooldown", randomTimer);
            spawnCooldown = true;
        }

        randomX = Random.Range(-9, 9);
        topSpawnerTrans.transform.position = new Vector2(randomX, yPos);
    }
    void ResetCooldown()
    {
        spawnCooldown = false;
    }
}
