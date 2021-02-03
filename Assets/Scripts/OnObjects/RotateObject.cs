using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 10;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeed, Space.Self);
    }

    public void SetRotateZ(int rotationZ)
    {
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
