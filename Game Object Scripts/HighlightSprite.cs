using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSprite : MonoBehaviour
{
    public Sprite normalSprite, highlightedSprite;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = normalSprite;
    }

    void OnMouseEnter()
    {
        if (!Manager<UIManager>.Instance.showingText)
        {
            sr.sprite = highlightedSprite;
        }
    }

    void OnMouseExit()
    {
        sr.sprite = normalSprite;
    }
}
