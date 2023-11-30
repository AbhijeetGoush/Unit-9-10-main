using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomAsteroidSpawner : MonoBehaviour
{
    Transform bottomSpawnerTrans;
    public GameObject asteroidPrefab;
    bool spawnCooldown;
    int randomTimer;
    int randomX;
    float yPos = -5.5f;
    // Start is called before the first frame update
    void Start()
    {
        bottomSpawnerTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        randomTimer = Random.Range(1, 4);

        if (spawnCooldown == false)
        {
            Instantiate(asteroidPrefab, bottomSpawnerTrans.transform.position, Quaternion.identity);
            Invoke("ResetCooldown", randomTimer);
            spawnCooldown = true;
        }

        randomX = Random.Range(-9, 9);
        bottomSpawnerTrans.transform.position = new Vector2(randomX, yPos);
    }
    void ResetCooldown()
    {
        spawnCooldown = false;
    }
}
