using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : Manager<InputManager>
{
    public UnityEvent ContinueClick;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Manager<UIManager>.Instance.showingText)
        {
            ContinueClick.Invoke();
            //Manager<UIManager>.Instance.textContinue = true;
        }
    }
}
