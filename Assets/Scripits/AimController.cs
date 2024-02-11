using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public GameObject target;
    public Joystick joystick;
    public float aimSpeed = 10;
    private void Update()
    {
        CorrectTargetPosition();
        target.transform.position += new Vector3(joystick.Horizontal,joystick.Vertical,0f)*Time.deltaTime*aimSpeed;
    }
    private void CorrectTargetPosition()
    {
        if (target.transform.position.x<-9.4f)
        {
            target.transform.position = new Vector3(-9.39f, target.transform.position.y, target.transform.position.z);
        }
        if (target.transform.position.x > 8)
        {
            target.transform.position = new Vector3(7.99f, target.transform.position.y, target.transform.position.z);
        }
        if (target.transform.position.y > 18)
        {
            target.transform.position = new Vector3(target.transform.position.x, 17.99f, target.transform.position.z);
        }
        if (target.transform.position.y < -13)
        {
            target.transform.position = new Vector3(target.transform.position.x, -12.99f, target.transform.position.z);
        }
    }
}
