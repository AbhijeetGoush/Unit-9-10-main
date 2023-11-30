using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletShooter;

    public GameObject playerLifeOne;
    public GameObject playerLifeTwo;
    public GameObject playerLifeThree;

    private bool playerLifeThreeDestroyed = false;
    private bool playerLifeTwoDestroyed = false;
    private bool playerLifeOneDestroyed = false;

    public int playerHealth = 3;
    Transform playerTrans;
    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTrans.position.x >= 10.788f)
        {
            playerTrans.transform.position = new Vector2(-10.683f, playerTrans.position.y);
        }
        if(playerTrans.position.x <= -10.788)
        {
            playerTrans.transform.position = new Vector2(10.683f, playerTrans.position.y);
        }
        if(playerTrans.position.y >= 6.4f)
        {
            playerTrans.transform.position = new Vector2(playerTrans.position.x, -6);
        }
        if (playerTrans.position.y <= -6.4f)
        {
            playerTrans.transform.position = new Vector2(playerTrans.position.x, 6);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(bulletPrefab, bulletShooter.transform.position, Quaternion.identity);
        }
        if(Input.GetMouseButtonDown(1))
        {
            Instantiate(bulletPrefab, bulletShooter.transform.position, Quaternion.identity);
        }
        if(playerHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if(playerHealth == 2 && playerLifeThreeDestroyed == false)
        {
            Destroy(playerLifeThree);
            playerLifeThreeDestroyed = true;
            print("Player life three destroyed");
        }
        if (playerHealth == 1 && playerLifeTwoDestroyed == false)
        {
            Destroy(playerLifeTwo);
            playerLifeTwoDestroyed = true;
        }
        if (playerHealth == 0 && playerLifeOneDestroyed == false)
        {
            Destroy(playerLifeOne);
            playerLifeOneDestroyed = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(collision.gameObject);
            playerHealth -= 1;
        }
    }
}
