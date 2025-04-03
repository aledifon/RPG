using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private List<TextAsset> inkJSON;
    private int idxTargetJSON;

    private bool playerInRange;

    #region Unity_API
    // Start is called before the first frame update
    void Awake()
    {
        playerInRange = false;
        idxTargetJSON = 0;
    }

    // Update is called once per frame
    void Update()
    {        
        Dialogue(inkJSON, idxTargetJSON);
        SetIdxJSONToRead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
    #endregion

    #region PrivateMethods
    private void Dialogue(List<TextAsset> inkFile, int idx)
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {            
            DialogueManager.DialgManager.EnterDialogMode(inkFile[idx]);  // Insert the JSON for the dialogues                        
            DialogueManager.DialgManager.ContinueStory();
        }
    }
    private void SetIdxJSONToRead()
    {
        if (!LevelTownManager.Instance.IsChestOpen)
            idxTargetJSON = 0;
        else
            idxTargetJSON = 1;
    }
    #endregion
}
