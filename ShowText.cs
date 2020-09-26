using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    [Header("Basic Info")]
    [SerializeField]
    public TextPromptSO textPromptSO;
    public bool responseObject;

    void OnMouseOver()
    {
        //If left mouse is clicked send game manager class reference to handle the assigned text prompt
        if (Input.GetMouseButtonDown(0))
        {
            Manager<GameManager>.Instance.TextPromptClicked(this);
        }
    }
}
