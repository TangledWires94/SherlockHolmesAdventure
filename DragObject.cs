﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    Transform objectTransform;
    Camera mainCamera;

    public enum DragState { Released, Held};
    public DragState dragState;

    public float minX, maxX, minY, maxY;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        objectTransform = gameObject.transform;
        mainCamera = Camera.main;
        dragState = DragState.Released;
    }

    // Update is called once per frame
    void Update()
    {
        switch (dragState)
        {
            case DragState.Released:
                //Code here has moved to StartDrag function and ray cast section of Input Manager update function
                break;

            case DragState.Held:
                //If object is held set position to mouse position (within bounds of area) above all other objects in area
                Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition) + offset;
                Vector3 objectPosition = new Vector3(Mathf.Clamp(mousePosition.x, minX, maxX), Mathf.Clamp(mousePosition.y, minY, maxY), -1f);
                objectTransform.localPosition = objectPosition;

                //If left mouse is released set state to not being held
                if (Input.GetMouseButtonUp(0))
                {
                    objectTransform.localPosition = new Vector3(objectTransform.position.x, objectTransform.position.y, 0f);
                    dragState = DragState.Released;
                }
                break;

            default:
                break;
        }        
    }

    //Mouse is over object and left mouse has been clicked so set state to drag mode
    public void StartDrag()
    {
        Vector3 diff = objectTransform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = new Vector3(diff.x, diff.y, 0f);
        dragState = DragState.Held;
    }
}
