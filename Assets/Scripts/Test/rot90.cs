//ORG: ghostyii & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class rot90 : MonoBehaviour
{

    Quaternion rot = Quaternion.identity, saveRot = Quaternion.identity;
    float speed = 100.0f, c = 1.0f, deg = 90.0f;
    bool moving = false;

    void Update()
    {
        if (Quaternion.Angle(transform.rotation, rot) > c && !moving)
        {
            moving = true;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, Time.deltaTime * speed);

        }
        else if (!moving)
        {
            transform.rotation = rot;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                saveRot = transform.rotation;
                transform.RotateAround(transform.position, Vector3.right, deg);
                rot = transform.rotation;
                transform.rotation = saveRot;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                saveRot = transform.rotation;
                transform.RotateAround(transform.position, Vector3.left, deg);
                rot = transform.rotation;
                transform.rotation = saveRot;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                saveRot = transform.rotation;
                transform.RotateAround(transform.position, Vector3.up, deg);
                rot = transform.rotation;
                transform.rotation = saveRot;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                saveRot = transform.rotation;
                transform.RotateAround(transform.position, Vector3.down, deg);
                rot = transform.rotation;
                transform.rotation = saveRot;
            }
        }
        moving = false;
    }
}