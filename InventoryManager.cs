using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Manager<InventoryManager>
{
    public List<InventoryObject> inventoryObjects = new List<InventoryObject>();

    void Start()
    {
        //Build list of all inventory objects in scene
        InventoryObject[] inventoryObjectsArray = FindObjectsOfType<InventoryObject>();
        for(int i = 1; i < inventoryObjectsArray.Length + 1; i++)
        {
            Debug.Log("Inventory Object " + i.ToString());
            inventoryObjects.Add(GameObject.Find("Inventory Object " + i.ToString()).GetComponent<InventoryObject>());
        }
    }

    //Add new inventory object to inventory list
    public void AddNewInventoryObject(Sprite inventorySprite, Sprite inventorySpriteHighlighted, string inventoryObjectName, TextPromptSO inventoryTextPrompt)
    {
        for (int i = 0; i < inventoryObjects.Count; i++)
        {
            if(inventoryObjects[i].inventoryObjectName == null)
            {
                inventoryObjects[i].SetInventoryObject(inventorySprite, inventorySpriteHighlighted, inventoryObjectName, inventoryTextPrompt);
                break;
            }
        }
    }

    //Remove object at given index from inventory list
    public void RemoveInventoryObjectByIndex(int index)
    {
        //If the index is valid clear the object at that index
        if(index >= inventoryObjects.Count || index < 0)
        {
            Debug.Log("Index of remove outside of objects in list");
        } else
        {   
            //Clear object at index, if the object cleared wasn't the last one in the list, shift all the others up one to fill in the gap
            if (index < inventoryObjects.Count - 1)
            {
                for(int i = index; i < inventoryObjects.Count; i++)
                {
                    inventoryObjects[i].ClearInventoryObject();
                    if(i < inventoryObjects.Count - 1)
                    {
                        inventoryObjects[i].SetInventoryObject(inventoryObjects[i + 1]);
                    }
                }
            }
        }
    }

    //Remove object of given name from inventory list
    public void RemoveInventoryObjectByName(string inventoryObjectName)
    {
        //Search through list of the inventory objects to find one with the given name, if it is found remove it from the list
        bool foundObject = false;
        for(int i = 0; i < inventoryObjects.Count; i++)
        {
            if (inventoryObjects[i].inventoryObjectName == inventoryObjectName)
            {
                RemoveInventoryObjectByIndex(i);
                foundObject = true;
                break;
            }
        }

        //If the object wasn't found write to log
        if (!foundObject)
        {
            Debug.LogFormat("No inventory object with name {0} is in the inventory list", inventoryObjectName);
        }
    }

}
