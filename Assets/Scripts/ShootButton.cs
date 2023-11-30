using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletShooter;
    public float raycastDistance = 2f;
    Ray ray;
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

                Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red, 1.0f);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.name == "Shoot button")
                    {
                        Instantiate(bulletPrefab, bulletShooter.transform.position, Quaternion.identity);
                    }
                }
            }
        }

        /* This code worked but it is not efficent for a mobile game
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.name == "Shoot button")
                {
                    Instantiate(bulletPrefab, bulletShooter.transform.position, Quaternion.identity);
                }
                
            }
        }*/
    }
    

}
