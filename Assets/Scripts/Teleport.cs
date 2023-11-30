using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform playerTrans;
    public float raycastDistance = 2f;
    private Vector2 destination;

    private bool cooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, raycastDistance);

                if (hit.collider != null)
                {
                    if(hit.collider.gameObject.name == "Teleport button")
                    {
                        if (cooldown == false)
                        {
                            destination = new Vector2(Random.Range(-10, 10), Random.Range(-4, 4));
                            playerTrans.position = new Vector2(destination.x, destination.y);
                            Invoke("ResetCooldown", 1.0f);
                            cooldown = true;
                        }
                    }
                }
            }
        }

        /* this script worked but is not efficent for a mobile game
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name == "Teleport button")
                {
                    if(cooldown == false)
                    {
                        destination = new Vector2(Random.Range(-10, 10), Random.Range(-4, 4));
                        playerTrans.position = new Vector2(destination.x, destination.y);
                        Invoke("ResetCooldown", 1.0f);
                        cooldown = true;
                    }
                }

            }
        }*/
    }
    void ResetCooldown()
    {
        cooldown = false;
    }
}
