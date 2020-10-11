using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpenClose : MonoBehaviour
{
    Animator inventoryAnimator;

    // Start is called before the first frame update
    void Start()
    {
        inventoryAnimator = GameObject.Find("Inventory").GetComponent<Animator>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !Manager<UIManager>.Instance.showingText)
        {
            inventoryAnimator.SetTrigger("Toggle Inventory");
        }
    }

}
