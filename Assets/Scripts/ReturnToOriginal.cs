using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToOriginal : MonoBehaviour
{
    public GameObject instanceObject = null;    // falling object should be bound to this instanceObject
    public float maxCheckingDistance;  // max distance the ray should check for collisions;

    private Vector3 originalPosition;

    // Use this for initialization
    void Start()
    {
        // Store the original position of each instance of falling objects
        originalPosition = instanceObject.transform.position;

        if (maxCheckingDistance <= 200)
        {
            maxCheckingDistance = 200.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if it is a right mouse click
        if (Input.GetMouseButtonDown(1))
        {
            // Since this script is shared by all the falling objects,
            // we need to identify the specific object being clicked.
            GameObject gameObjectGetClicked = GetClickedGameObject();

            // if instanceObject is bound to falling object, gameObjectGetClicked is identified
            // and theire names are equal, then we can restore to the original position
            // for this specific object.
            if (instanceObject != null && gameObjectGetClicked != null && instanceObject.name == gameObjectGetClicked.name)
            {
                gameObjectGetClicked.transform.position = originalPosition;
            }
        }
    }

    GameObject GetClickedGameObject()
    {
        // Get the clicked object, if any
        // Builds a ray from camera point of view to the mouse position
        // when a clicking takes place
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Casts the ray and get the first game object hit
        if (Physics.Raycast(ray, out hit, (float)maxCheckingDistance))
        {
            return hit.transform.gameObject;
        }
        else
        {
            return null;
        }
    }
}