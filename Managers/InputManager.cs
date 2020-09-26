using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : Manager<InputManager>
{
    public UnityEvent ContinueClick;
    public int lawyerLevel;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Manager<UIManager>.Instance.showingText)
        {
            ContinueClick.Invoke();
            //Manager<UIManager>.Instance.textContinue = true;
        }

        //Debug code to test lawyer hand movement
        if (Input.GetKeyDown(KeyCode.L))
        {
            Manager<GameManager>.Instance.UpdateLawyerLevel(lawyerLevel);
        }
    }
}
