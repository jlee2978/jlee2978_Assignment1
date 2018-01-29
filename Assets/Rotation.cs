using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    void OnMouseDown()
    {
        string objectName = transform.gameObject.name;

        if (objectName.IndexOf("Wall") >= 0)
        {
            // if Wall is clicked, get the parent gameObject (i.e. BoxBottom) first
            // then rotate the parent. We do it with one single statement
            transform.parent.gameObject.transform.Rotate(new Vector3(-5, 0, -5));
        }
        else
        {
            transform.Rotate(new Vector3(-5, 0, -5));
        }
    }
}
