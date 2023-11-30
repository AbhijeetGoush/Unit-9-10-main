using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Joystick joystickScr;
    Score scoreScr;
    public GameObject scoreManager;
    public int speed;
    public GameObject fireballPrefab;
    public Transform fireballTrans;
    public GameObject cameraObj;
    Rigidbody2D fireballRb;
    // Start is called before the first frame update
    void Start()
    {
        cameraObj = GameObject.FindWithTag("MainCamera");
        scoreManager = GameObject.FindWithTag("ScoreManager");
        joystickScr = cameraObj.GetComponent<Joystick>();
        fireballRb = GetComponent<Rigidbody2D>();
        float angle = Mathf.Atan2(joystickScr.directionV.y, joystickScr.directionV.x) * Mathf.Rad2Deg + 90;
        fireballPrefab.transform.rotation = Quaternion.Euler(0, 0, angle);
        scoreScr = scoreManager.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        fireballRb.AddForce(-transform.up * speed);
        if (fireballTrans.position.x >= 10.788f)
        {
            Destroy(this.gameObject);
        }
        if (fireballTrans.position.x <= -10.788)
        {
            Destroy(this.gameObject);
        }
        if (fireballTrans.position.y >= 6.4f)
        {
            Destroy(this.gameObject);
        }
        if (fireballTrans.position.y <= -6.4f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            var asteroid = collision.GetComponent<AsteroidScript>();
            asteroid.DestroyAsteroid();
            Destroy(this.gameObject);
            
            int addToScore = Random.Range(0, 200);
            scoreScr.score += addToScore;
        }
    }
}
