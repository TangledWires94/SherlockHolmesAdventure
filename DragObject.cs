using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    Transform objectTransform;
    bool mouseOver;
    Camera mainCamera;

    public enum DragState { Released, Held};
    public DragState dragState;

    public float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        objectTransform = gameObject.transform;
        mouseOver = false;
        mainCamera = Camera.main;
        dragState = DragState.Released;
    }

    // Update is called once per frame
    void Update()
    {
        switch (dragState)
        {
            case DragState.Released:
                //If mouse over object and left mouse has been pressed down this frame, set state to being held
                if (mouseOver && Input.GetMouseButtonDown(0) && !Manager<UIManager>.Instance.showingText && !Manager<UIManager>.Instance.awaitingResponse)
                {
                    dragState = DragState.Held;
                }
                break;

            case DragState.Held:
                //If object is held set position to mouse position (within bounds of area) above all other objects in area
                Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
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

    void OnMouseEnter()
    {
        mouseOver = true;
    }

    void OnMouseExit()
    {
        mouseOver = false;
    }

}
