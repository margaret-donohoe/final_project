using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public RectTransform northArrow; // Reference to the RectTransform of the north arrow image

    void Update()
    {
        if (player != null && northArrow != null)
        {
            //Calculate direction from player to North (assuming positive Z axis is north)
            Vector3 direction = Vector3.ProjectOnPlane(player.forward, Vector3.up).normalized;

            //Calculate angle between direction vector and world north vector
            float angle = Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);

            //Rotate compass UI element to point towards Nsorth
            northArrow.rotation = Quaternion.Euler(0f, 0f, -angle);
        }
    }
}
