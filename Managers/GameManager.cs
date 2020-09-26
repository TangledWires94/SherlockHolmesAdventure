﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    [SerializeField]
    public enum GameDataKeys { hasBedroomKey, bedroomDoorUnlocked, readBook, wearingHat}
    [SerializeField]
    public Dictionary<GameDataKeys, bool> gameData = new Dictionary<GameDataKeys, bool>();

    void Start()
    {
        for(int i = 0; i < Enum.GetNames(typeof(GameDataKeys)).Length; i++)
        {
            gameData.Add((GameDataKeys)i, false);
        }
    }

    #region Game Data Functions

    public bool GetGameDataValue(GameDataKeys key)
    {
        bool dataValue;
        gameData.TryGetValue(key, out dataValue);
        return dataValue;
    }

    public void SetGameDataValue(GameDataKeys key, bool value)
    {
        gameData[key] = value;
    }

    #endregion

    #region Text Prompt Functions

    //Called by ShowText class when the object is clicked, triggers manager to handle new text prompt if the UI manager isn't waiting for a response in the current text prompt
    public void TextPromptClicked(ShowText showTextObject)
    {
        if (showTextObject.responseObject)
        {
            Manager<UIManager>.Instance.awaitingResponse = false;
        }

        //Ignore this click if the UI manager is waiting for a response and this isn't a response object
        if (!Manager<UIManager>.Instance.awaitingResponse || (Manager<UIManager>.Instance.awaitingResponse && showTextObject.responseObject))
        {
            //Check to see if the text prompt has an alternate version based on a game data check, if so do the check and if the values match run the alternate version, if not matching or no check run normal
            if (showTextObject.textPromptSO.gameDataCheck)
            {
                if (GetGameDataValue(showTextObject.textPromptSO.checkGameDataKey) == showTextObject.textPromptSO.checkGameDataValue)
                {
                    ShowPopupText(showTextObject.textPromptSO.alternateTextPromptSO);
                }
                else
                {
                    ShowPopupText(showTextObject.textPromptSO);
                }
            }
            else
            {
                ShowPopupText(showTextObject.textPromptSO);
            }
        }
    }

    void ShowPopupText(TextPromptSO textPromptSO)
    {
        Manager<UIManager>.Instance.ChangePopupText(textPromptSO);

        //Check if this text option sets a Game Data Key
        if (textPromptSO.gameDataUpdate)
        {
            SetGameDataValue(textPromptSO.updateGameDataKey, textPromptSO.updateGameDataValue);
        }

        //Check if text prompt triggers object to be swapped out
        if (textPromptSO.changeObject)
        {
            GameObject objectToDelete = GameObject.Find(textPromptSO.oldObjectName);
            Transform oldObjectParent = objectToDelete.transform.parent;
            Instantiate(textPromptSO.newObject, oldObjectParent);
            Destroy(objectToDelete);
        }

        //Check if this text prompt enables a popup window
        if (textPromptSO.openPopup)
        {
            GameObject popupObjectHolder = GameObject.Find(textPromptSO.popupObjectName + " Holder");
            GameObject popupObject = popupObjectHolder.transform.GetChild(0).gameObject;
            Debug.Log(popupObject.activeSelf);
            popupObject.SetActive(false);
            popupObject.SetActive(true);
        }

        //Check if this text prompt triggers scene change
        if (textPromptSO.sceneTransition)
        {
            Debug.LogFormat("Transition to scene {0}", textPromptSO.sceneIndex);
        }

        //Any other checks should be done before the delete check is done in case the object to be deleted is the one holding the text prompt

        //Check if item should be deleted
        if (textPromptSO.deleteObject)
        {
            GameObject objectToDelete = GameObject.Find(textPromptSO.objectToDelete);
            Destroy(objectToDelete);
        }
    }

    #endregion
}
