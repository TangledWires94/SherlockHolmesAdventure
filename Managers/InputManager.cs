using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : Manager<InputManager>
{
    public UnityEvent ContinueClick;
    public int lawyerLevel;
    public Camera cameraMain;

    public HighlightSprite currentHighlightSprite;

    public UnityEvent StartHighlightOverride;
    public UnityEvent StopHighlightOverride;

    void Start()
    {
        cameraMain = Camera.main;
        currentHighlightSprite = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Manager<UIManager>.Instance.showingText)
        {
            ContinueClick.Invoke();
        }

        //Debug code to removing inventory objects
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Manager<InventoryManager>.Instance.RemoveInventoryObjectByIndex(0);
        }

        //Allow player to hold button to show all objects that can be interacted with
        if (Input.GetKey(KeyCode.Return) && !Manager<UIManager>.Instance.showingText && !Manager<UIManager>.Instance.awaitingResponse)
        {
            //Trigger event that all clickable objects subscribe to turn them highlighted
            StartHighlightOverride.Invoke();
        } 
        else if (Input.GetKeyUp(KeyCode.Return))
        {
            //Trigger event that tells all hightable objects to go back to normal
            StopHighlightOverride.Invoke();
        }

        #region Raycasting

        //Perform raycast to mouse position along Z axis
        Vector3 mousePos = cameraMain.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D raycastHit = Physics2D.Raycast(mousePos + new Vector3(0,0,-10), mousePos - cameraMain.transform.position);

        //If raycast hits check if the object has an highlight sprite or show text component
        if (raycastHit)
        {
            GameObject objectHit = raycastHit.collider.gameObject;

            //Check if mouse has entered or left an object with a highlight sprite component
            HighlightSprite highlightSprite = objectHit.GetComponent<HighlightSprite>();
            if (highlightSprite == null)
            {
                //another object is at top but does not have a highlight sprite component so tell currently highlighted object to be un-highlighted
                if(currentHighlightSprite != null)
                {
                    currentHighlightSprite.MouseLeave();
                    currentHighlightSprite = null;
                }
            }
            else
            {
                //Object on top has a highlight sprite component so un-highlight any currently highlighted object, highlight new one and store it for future reference
                if(currentHighlightSprite != null)
                {
                    currentHighlightSprite.MouseLeave();
                }
                highlightSprite.MouseOver();
                currentHighlightSprite = highlightSprite;
            }

            //Check if mouse has entered an object with a show text component and if the left mouse button is clicked
            ShowText showText = objectHit.GetComponent<ShowText>();
            if(showText != null && Input.GetMouseButtonDown(0))
            {
                showText.ShowTextClicked();
            }

            //Check if mouse has entered an object with a Drag Object component, left mouse has been clicked this frame and UI manager isn't busy set state ofdrag object to being dragged
            DragObject dragObject = objectHit.GetComponent<DragObject>();
            if (dragObject != null && Input.GetMouseButtonDown(0) && !Manager<UIManager>.Instance.showingText && !Manager<UIManager>.Instance.awaitingResponse)
            {
                dragObject.StartDrag();
            }
        } else
        {
            //If raycast doesn't hit tell current highlighted object to un-highlight
            if (currentHighlightSprite != null)
            {
                currentHighlightSprite.MouseLeave();
                currentHighlightSprite = null;
            }
        }

        #endregion

    }
}
