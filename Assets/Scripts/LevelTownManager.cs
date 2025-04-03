using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTownManager : MonoBehaviour
{
    // Static field which contains the single instance of the Singleton
    private static LevelTownManager instance;
    // Static property used to acces the Singleton
    public static LevelTownManager Instance
    {
        // Singleton instance assignation & LevelTownManager GO creation
        // in case they do not exist already when trying to acces to the instance.
        get 
        { 
            if (instance == null)
            {
                instance = FindAnyObjectByType<LevelTownManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("LevelTownManager");
                    instance = go.AddComponent<LevelTownManager>();
                }                    
            }
            return instance; 
        }
    }

    [SerializeField] private GameObject npc;

    private bool isChestOpen;
    public bool IsChestOpen => isChestOpen;

    #region Unity_API
    void Awake()
    {
        // Assignation of the LevelTownManager instance and assure
        // only a single LevelTownManager script & GO will exist
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        isChestOpen = false;
    }
    private void Update()
    {
        // Duplicates the timescale when the Shift button is pressed or not
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Time.timeScale = 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Time.timeScale = 1;
        }
    }

    #endregion

    #region Private Methods
    #endregion

    #region Public Methods
    public void OpenChest()
    {
        //Get the current position and add it one to the right
        npc.transform.position += npc.transform.right*2;
        isChestOpen = true;
    }
    #endregion
}
