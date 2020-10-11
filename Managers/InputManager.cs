using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : Manager<InputManager>
{
    public UnityEvent ContinueClick;
    public int lawyerLevel;

    public UnityEvent StartHighlightOverride;
    public UnityEvent StopHighlightOverride;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Manager<UIManager>.Instance.showingText)
        {
            ContinueClick.Invoke();
            //Manager<UIManager>.Instance.textContinue = true;
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
    }
}
