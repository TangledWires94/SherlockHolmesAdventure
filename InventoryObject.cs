using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    public Sprite inventorySprite, inventorySpriteHighlighted;
    public string inventoryObjectName;
    public TextPromptSO inventoryTextPrompt;
    SpriteRenderer sr;
    ShowText showText;
    HighlightSprite highlightSprite;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        showText = GetComponent<ShowText>();
        highlightSprite = GetComponent<HighlightSprite>();
        ClearInventoryObject();
    }

    //Public function used to set the variables for this InventoryObject and update the relevant components
    public void SetInventoryObject(Sprite inventorySprite, Sprite inventorySpriteHighlighted, string inventoryObjectName, TextPromptSO inventoryTextPrompt)
    {
        //Set variables
        this.inventorySprite = inventorySprite;
        this.inventorySpriteHighlighted = inventorySpriteHighlighted;
        this.inventoryObjectName = inventoryObjectName;
        this.inventoryTextPrompt = inventoryTextPrompt;

        //Update sprite renderer
        sr.sprite = inventorySprite;

        //Set highlight sprite script variables
        highlightSprite.normalSprite = inventorySprite;
        highlightSprite.highlightedSprite = inventorySpriteHighlighted;

        //Set show text script variables
        showText.textPromptSO = inventoryTextPrompt;
    }

    //Override for SetInventoryObject that allows InventoryObject to be used as input rather than individual components, mostly used by InventoryManager when shifting objects around
    public void SetInventoryObject(InventoryObject inventoryObject)
    {
        //Set variables
        inventorySprite = inventoryObject.inventorySprite;
        inventorySpriteHighlighted = inventoryObject.inventorySpriteHighlighted;
        inventoryObjectName = inventoryObject.inventoryObjectName;
        inventoryTextPrompt = inventoryObject.inventoryTextPrompt;

        //Update sprite renderer
        sr.sprite = inventorySprite;

        //Set highlight sprite script variables
        highlightSprite.normalSprite = inventorySprite;
        highlightSprite.highlightedSprite = inventorySpriteHighlighted;

        //Set show text script variables
        showText.textPromptSO = inventoryTextPrompt;
    }

    //Public function to allow inventory object to be cleared
    public void ClearInventoryObject()
    {
        //Clear variables
        inventorySprite = null;
        inventorySpriteHighlighted = null;
        inventoryObjectName = null;
        inventoryTextPrompt = null;

        //Update sprite renderer
        sr.sprite = null;

        //Set highlight sprite script variables
        highlightSprite.normalSprite = null;
        highlightSprite.highlightedSprite = null;

        //Set show text script variables
        showText.textPromptSO = null;
    }
}
