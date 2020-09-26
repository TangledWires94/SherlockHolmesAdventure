using UnityEngine;

[CreateAssetMenu(fileName = "Text Prompt", menuName = "ScriptableObjects/Text Prompt", order = 1)]
public class TextPromptSO : ScriptableObject
{
    [Header("Dialog Text")]
    public string[] dialogueText; //Script that will play out when ShowText is triggered one dialog box at a time.
    public string responseLabel; //String that will show in response options if this object is used as a response object

    [Header("Response")]
    public bool hasResponse; //Flag that tells UI manager if this text prompt requires a response from the player
    public TextPromptSO[] responseObjects; //The list of responses to use, hidden in inspector if response = false;

    [Header("Game Data Check")]
    public bool gameDataCheck; //Flag that tells UI manager to check a player pref entry and use an alternate TextPromptSO if the value matches the required value
    public GameManager.GameDataKeys checkGameDataKey;
    public bool checkGameDataValue;
    [SerializeField]
    public TextPromptSO alternateTextPromptSO; //Alternate object to use if there is a player pref to check

    [Header("Game Data Update")]
    public bool gameDataUpdate; //Flag that tells UI manager to update a player pref to a set value if this is clicked
    public GameManager.GameDataKeys updateGameDataKey;
    public bool updateGameDataValue;

    [Header("Change Object")] 
    public bool changeObject; //Flag that tells UI manager to swap the object selected out for another object
    public string oldObjectName;
    public GameObject newObject;

    [Header("Open Popup")]
    public bool openPopup; //Flag that tells UI manager to show a popup window
    public string popupObjectName;

    [Header("Scene Transition")]
    public bool sceneTransition; //Flag that tells manager to transition to next scene when this is clicked
    public int sceneIndex;

    [Header("Delete Object")]
    public bool deleteObject; //If this is ticked delete the object that triggered this text prompt
    public string objectToDelete;
}
