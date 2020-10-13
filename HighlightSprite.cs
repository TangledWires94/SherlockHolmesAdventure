using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSprite : MonoBehaviour
{
    public Sprite normalSprite, highlightedSprite;
    SpriteRenderer sr;
    bool highlightOverride, mouseOver;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = normalSprite;
        Manager<InputManager>.Instance.StartHighlightOverride.AddListener(StartHighlightOverride);
        Manager<InputManager>.Instance.StopHighlightOverride.AddListener(StopHighlightOverride);
        mouseOver = false;
        highlightOverride = false;
    }

    /*
    void OnMouseEnter()
    {
        if (!Manager<UIManager>.Instance.showingText && !Manager<UIManager>.Instance.awaitingResponse)
        {
            mouseOver = true;
            sr.sprite = highlightedSprite;
        }
    }

    void OnMouseExit()
    {
        mouseOver = false;
        if (!highlightOverride)
        {
            sr.sprite = normalSprite;
        }
    }
    */

    public void MouseOver()
    {
        if (!Manager<UIManager>.Instance.showingText && !Manager<UIManager>.Instance.awaitingResponse)
        {
            mouseOver = true;
            sr.sprite = highlightedSprite;
        }
    }

    public void MouseLeave()
    {
        mouseOver = false;
        if (!highlightOverride)
        {
            sr.sprite = normalSprite;
        }
    }

    void StartHighlightOverride()
    {
        highlightOverride = true;
        sr.sprite = highlightedSprite;
    }

    void StopHighlightOverride()
    {
        highlightOverride = false;
        if (!mouseOver)
        {
            sr.sprite = normalSprite;
        }
    }
}
