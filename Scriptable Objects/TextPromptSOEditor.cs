using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if (UNITY_EDITOR) 

[CustomEditor(typeof(TextPromptSO))]
[CanEditMultipleObjects]
public class TextPromptSOEditor : Editor
{
    SerializedProperty responseFlagProp, gameDataCheckProp, gameDataUpdateProp, addToInventoryProp, objectChangeProp, removeFromInventoryProp, popupProp, spawnProp, animProp, sceneTransitionProp, deleteObjectProp;

    void OnEnable()
    {
        //Set up serialized properties
        responseFlagProp = serializedObject.FindProperty("hasResponse");
        gameDataCheckProp = serializedObject.FindProperty("gameDataCheck");
        gameDataUpdateProp = serializedObject.FindProperty("gameDataUpdate");
        addToInventoryProp = serializedObject.FindProperty("addToInventory");
        removeFromInventoryProp = serializedObject.FindProperty("removeFromInventory");
        objectChangeProp = serializedObject.FindProperty("changeObject");
        popupProp = serializedObject.FindProperty("openPopup");
        spawnProp = serializedObject.FindProperty("spawnObject");
        animProp = serializedObject.FindProperty("triggerAnimation");
        sceneTransitionProp = serializedObject.FindProperty("sceneTransition");
        deleteObjectProp = serializedObject.FindProperty("deleteObject");
    }

    public override void OnInspectorGUI()
    {
        List<string> propertiesToExcludeList = new List<string>();

        if (!responseFlagProp.boolValue)
        {
            propertiesToExcludeList.Add("responseObjects");
        }

        if (!gameDataCheckProp.boolValue)
        {
            propertiesToExcludeList.Add("checkGameDataKey");
            propertiesToExcludeList.Add("checkGameDataValue");
            propertiesToExcludeList.Add("alternateTextPromptSO");
        }

        if (!gameDataUpdateProp.boolValue)
        {
            propertiesToExcludeList.Add("updateGameDataKey");
            propertiesToExcludeList.Add("updateGameDataValue");
            
        }

        if (!addToInventoryProp.boolValue)
        {
            propertiesToExcludeList.Add("inventorySprite");
            propertiesToExcludeList.Add("inventorySpriteHighlighted");
            propertiesToExcludeList.Add("inventoryObjectAddName");
            propertiesToExcludeList.Add("inventoryTextPrompt");
        }


        if (!removeFromInventoryProp.boolValue)
        {
            propertiesToExcludeList.Add("inventoryObjectRemoveName");
        }

        if (!objectChangeProp.boolValue)
        {
            propertiesToExcludeList.Add("oldObjectName");
            propertiesToExcludeList.Add("newObject");
        }

        if (!popupProp.boolValue)
        {
            propertiesToExcludeList.Add("popupObjectName");
        }

        if (!spawnProp.boolValue)
        {
            propertiesToExcludeList.Add("spawnedObject");
            propertiesToExcludeList.Add("spawnTransform");
        }

        if (!animProp.boolValue)
        {
            propertiesToExcludeList.Add("triggerAnimatorName");
            propertiesToExcludeList.Add("triggerString");
        }

        if (!sceneTransitionProp.boolValue)
        {
            propertiesToExcludeList.Add("sceneIndex");
        }

        if (!deleteObjectProp.boolValue)
        {
            propertiesToExcludeList.Add("objectToDelete");
        }

        string[] propertiesToExcludeArray = new string[propertiesToExcludeList.Count];
        for(int i = 0; i < propertiesToExcludeArray.Length; i++)
        {
            propertiesToExcludeArray[i] = propertiesToExcludeList[i];
        }

        DrawPropertiesExcluding(serializedObject, propertiesToExcludeArray);

        serializedObject.ApplyModifiedProperties();
    }
}

#endif
