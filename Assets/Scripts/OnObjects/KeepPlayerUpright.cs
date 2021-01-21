using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayerUpright : MonoBehaviour
{
    void FixedUpdate()
    {
        Debug.Log(transform.rotation);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
