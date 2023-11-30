using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public GameObject cameraObject;
    Joystick joystickScr;
    float angle;
    public Transform playerImage;
    public Transform centreJoystick;

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        joystickScr = cameraObject.GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(joystickScr.directionV.y, joystickScr.directionV.x) * Mathf.Rad2Deg + 90;
        playerImage.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
