using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 7.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    public Vector2 directionV;
    public Transform circle;
    public Transform outerCircle;
    public GameObject playerFlame;
    // Update is called once per frame
    void Update()
    {
        float leftSideThreshold = Screen.width * 0.5f;
        
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < leftSideThreshold)
                {
                    pointA = new Vector3(-8, -3, Camera.main.transform.position.z);

                    outerCircle.transform.position = new Vector2(-8, -3);
                    circle.GetComponent<SpriteRenderer>().enabled = true;
                    outerCircle.GetComponent<SpriteRenderer>().enabled = true;
                    playerFlame.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    touchStart = false;
                }
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                if(touch.position.x < leftSideThreshold)
                {
                    touchStart = true;
                    pointB = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.transform.position.z));
                    circle.GetComponent<SpriteRenderer>().enabled = true;
                    outerCircle.GetComponent<SpriteRenderer>().enabled = true;
                    playerFlame.GetComponent <SpriteRenderer>().enabled = true;
                }
            }
            else
            {
                touchStart = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction);

            circle.transform.position = new Vector2(outerCircle.transform.position.x + direction.x, outerCircle.transform.position.y + direction.y);

        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
            playerFlame.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
    public void moveCharacter(Vector2 direction)
    {
        directionV = direction;
        player.Translate(direction * speed * Time.deltaTime);
    }
}
