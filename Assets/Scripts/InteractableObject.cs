using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private bool playerInside;

    [SerializeField] private bool interactable;

    [Header("Sprite")]
    [SerializeField] private Sprite openChestSprite;    // Sprite to be changed

    private SpriteRenderer spriteRenderer;              // SpriteRenderer Component of the GO
                                                        // which is attached to this script
    
    private AudioSource audioSource;

    void Start()
    {
        playerInside = false;
        interactable = true;   
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInside && interactable)
        {
            Action();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    private void Action()
    {
        Debug.Log("The chest has been opened");
        LevelTownManager.Instance.OpenChest();

        interactable = false;
        // Set the new Opened Chest Sprite
        spriteRenderer.sprite = openChestSprite;

        // Play the Audio Source
        audioSource.Play();
    }
}
