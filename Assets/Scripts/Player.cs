using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 newPosition;
    float speed = 0.25f;
    int stepDiscance = 3;
    float x, z;
    void Start()
    {
        gameObject.transform.position = new Vector3(0, 1.1f, 0);
    }

    void Update()
    {
        z = gameObject.transform.position.z + speed;
        x = gameObject.transform.position.x;

        if (Input.GetKeyDown(KeyCode.A) && x > -stepDiscance)
        {
            x = gameObject.transform.position.x - stepDiscance;
        }

        if (Input.GetKeyDown(KeyCode.D) && x < stepDiscance)
        {
            x = gameObject.transform.position.x + stepDiscance;
        }

        newPosition = new Vector3(x, gameObject.transform.position.y, z);
        gameObject.transform.position = newPosition;
    }
}
