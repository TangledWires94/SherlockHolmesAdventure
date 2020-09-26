using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TextPromptSO))]
[CanEditMultipleObjects]
public class TextPromptSOEditor : Editor
{
    SerializedProperty responseFlagProp, gameDataCheckProp, gameDataUpdateProp, objectChangeProp,  popupProp, sceneTransitionProp, deleteObjectProp;

    void OnEnable()
    {
        //Set up serialized properties
        responseFlagProp = serializedObject.FindProperty("hasResponse");
        gameDataCheckProp = serializedObject.FindProperty("gameDataCheck");
        gameDataUpdateProp = serializedObject.FindProperty("gameDataUpdate");
        objectChangeProp = serializedObject.FindProperty("changeObject");
        popupProp = serializedObject.FindProperty("openPopup");
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

        if (!objectChangeProp.boolValue)
        {
            propertiesToExcludeList.Add("oldObjectName");
            propertiesToExcludeList.Add("newObject");
        }

        if (!popupProp.boolValue)
        {
            propertiesToExcludeList.Add("popupObjectName");
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
