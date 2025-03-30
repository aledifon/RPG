using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform heroPosition;

    // Limit values taken from the Screen Center as a Reference
    [SerializeField] Vector2 limitUp;
    [SerializeField] Vector2 limitDown;

    Vector2 cameraPosition;
    
    void Update()
    {
        // Call the method that will follow the player
        CameraLimit();
    }

    private void CameraLimit()
    {
        // The player will be always placed on the center of the Camera Screen

        if (heroPosition.position.x < limitUp.x && heroPosition.position.x > limitDown.x)
        {
            // Position the camera on the player x-coordinate
            cameraPosition.x = heroPosition.position.x;            

        }

        if (heroPosition.position.y < limitUp.y && heroPosition.position.y > limitDown.y)
        {
            // Position the camera on the player y-coordinates
            cameraPosition.y = heroPosition.position.y;
        }

        // This assures the camera will be at -10 uds from the Tilemap on the Z-Axis
        transform.position = (Vector3) cameraPosition + Vector3.back * 10;
    }
}
