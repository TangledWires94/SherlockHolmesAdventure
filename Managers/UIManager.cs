using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Manager<UIManager>
{
    TextMesh textDisplay;
    GameObject continueArrow;
    GameObject responseBox;
    GameObject[] responseText = new GameObject[3];
    public bool showingText;
    public bool textContinue;
    public bool awaitingResponse;
    //public bool handlingPrompt;

   // Start is called before the first frame update
   void Start()
   {
        textDisplay = GameObject.Find("Popup Text").GetComponent<TextMesh>();
        continueArrow = GameObject.Find("Continue Arrow");
        continueArrow.GetComponent<SpriteRenderer>().enabled = false;
        responseBox = GameObject.Find("Response Box");
        responseText[0] = GameObject.Find("Response Text 1");
        responseText[0].GetComponent<TextMesh>().text = "";
        responseText[0].GetComponent<BoxCollider2D>().enabled = false;
        responseText[1] = GameObject.Find("Response Text 2");
        responseText[1].GetComponent<TextMesh>().text = "";
        responseText[1].GetComponent<BoxCollider2D>().enabled = false;
        responseText[2] = GameObject.Find("Response Text 3");
        responseText[2].GetComponent<TextMesh>().text = "";
        responseText[2].GetComponent<BoxCollider2D>().enabled = false;
        responseBox.GetComponent<SpriteRenderer>().enabled = false;
        showingText = false;
        awaitingResponse = false;
        //handlingPrompt = false;
        Manager<InputManager>.Instance.ContinueClick.AddListener(ContinueClick);
   }

    public void ChangePopupText(TextPromptSO textObject)
    {
        if (!showingText)
        {
            string[] editedText = new string[textObject.dialogueText.Length];
            for(int i = 0; i < textObject.dialogueText.Length; i++)
            {
                editedText[i] = textObject.dialogueText[i].Replace("*", "\n");
            }
            textObject.dialogueText = editedText;
            StartCoroutine(UITextPopup(textObject));
        }
    }

    IEnumerator UITextPopup(TextPromptSO textObject)
    {
        //Tell other classes that a text prompt is actively being handled


        //Make sure response box is hidden
        responseBox.GetComponent<SpriteRenderer>().enabled = false;
        foreach(GameObject responseObject in responseText)
        {
            responseObject.GetComponent<TextMesh>().text = "";
            responseObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        //Loop through each line of the popup text
        for (int i = 0; i < textObject.dialogueText.Length; i++)
        {
            textDisplay.text = textObject.dialogueText[i];
            if (i < textObject.dialogueText.Length - 1)
            {
                continueArrow.GetComponent<SpriteRenderer>().enabled = true;
                yield return new WaitForEndOfFrame();
                showingText = true;
                textContinue = false;
                while (!textContinue)
                {
                    yield return new WaitForEndOfFrame();
                }
            }
        }
        continueArrow.GetComponent<SpriteRenderer>().enabled = false;

        //If there is a response to this text show the options and wait for a response
        if (textObject.hasResponse)
        {
            responseBox.GetComponent<SpriteRenderer>().enabled = true;
            for(int i = 0; i < textObject.responseObjects.Length; i++)
            {
                responseText[i].GetComponent<TextMesh>().text = "- " + textObject.responseObjects[i].responseLabel;
                responseText[i].GetComponent<ShowText>().textPromptSO = textObject.responseObjects[i];
                responseText[i].GetComponent<BoxCollider2D>().enabled = true;
            }
            awaitingResponse = true;
        }
        
        //Finish off the coroutine
        showingText = false;
    }

    void ContinueClick()
    {
        textContinue = true;
    }
}
