using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    bool mouseOver;
    public GameObject objectToClose;


    // Start is called before the first frame update
    void Start()
    {
        mouseOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseOver && Input.GetMouseButtonDown(0) && !Manager<UIManager>.Instance.showingText && !Manager<UIManager>.Instance.awaitingResponse)
        {
            objectToClose.SetActive(false);
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
