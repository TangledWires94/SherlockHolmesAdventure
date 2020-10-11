using UnityEngine;

[CreateAssetMenu(fileName = "Text Prompt", menuName = "ScriptableObjects/Text Prompt", order = 1)]
public class TextPromptSO : ScriptableObject
{
    [Header("Dialog Text")]
    public string[] dialogueText; //Script that will play out when ShowText is triggered one dialog box at a time.
    public string responseLabel; //String that will show in response options if this object is used as a response object

    [Header("Response")]
    public bool hasResponse; //Flag that tells Game Manager if this text prompt requires a response from the player
    public TextPromptSO[] responseObjects; //The list of responses to use, hidden in inspector if response = false;

    [Header("Game Data Check")]
    public bool gameDataCheck; //Flag that tells Game Manager to check a player pref entry and use an alternate TextPromptSO if the value matches the required value
    public GameManager.GameDataKeys checkGameDataKey;
    public bool checkGameDataValue;
    [SerializeField]
    public TextPromptSO alternateTextPromptSO; //Alternate object to use if there is a player pref to check

    [Header("Game Data Update")]
    public bool gameDataUpdate; //Flag that tells Game Manager to update a player pref to a set value if this is clicked
    public GameManager.GameDataKeys updateGameDataKey;
    public bool updateGameDataValue;

    [Header("Add To Inventory")]
    public bool addToInventory; //Flag that tells Game manager to add new object to inventory list
    public Sprite inventorySprite;
    public Sprite inventorySpriteHighlighted;
    public string inventoryObjectAddName;
    public TextPromptSO inventoryTextPrompt;

    [Header("Remove From Inventory")]
    public bool removeFromInventory; //Flag that tells game manager to check for object in inventory and remove it if it exists
    public string inventoryObjectRemoveName;

    [Header("Change Object")] 
    public bool changeObject; //Flag that tells Game Manager to swap the object selected out for another object
    public string oldObjectName;
    public GameObject newObject;

    [Header("Open Popup")]
    public bool openPopup; //Flag that tells Game Manager to show a popup window
    public string popupObjectName;

    [Header("Spawn Object")]
    public bool spawnObject; //Flag that tells Game Manager to spawn new object in scene
    public GameObject spawnedObject;
    public Transform spawnTransform;

    [Header("Increase Lawyer Level")]
    public bool increaseLawyerLevel; //Flag that tells Game Manager to increase lawyer level

    [Header("Trigger Animation")]
    public bool triggerAnimation;
    public string triggerAnimatorName;
    public string triggerString;

    [Header("Scene Transition")]
    public bool sceneTransition; //Flag that tells manager to transition to next scene when this is clicked
    public int sceneIndex;

    [Header("Delete Object")]
    public bool deleteObject; //If this is ticked delete the object that triggered this text prompt
    public string objectToDelete;
}
