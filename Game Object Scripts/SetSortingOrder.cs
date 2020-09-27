using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSortingOrder : MonoBehaviour
{
    //This class allows you to set the sorting layer for objects with renderers that do not expose that property to the inspector (e.g. Text Mesh objects with mesh renderers)

    public string sortingLayerName;
    public int sortingOrder;

    void Start()
    {
        Renderer textRenderer = this.GetComponent<Renderer>();
        textRenderer.sortingLayerName = sortingLayerName;
        textRenderer.sortingOrder = sortingOrder;
    }
}
