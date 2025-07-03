using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isTeleporter;
    public GameObject otherTeleporter;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // Only teleport if this object is marked as a teleport trigger
        if (!isTeleporter) return;

        // Check if the object entering is the player
        if (other.CompareTag("Player")) // Make sure your player GameObject is tagged as "Player"
        {
            Transform playerTransform = other.transform;

            // Step 1: Get player's local position relative to this teleporter
            Vector3 localOffset = transform.InverseTransformPoint(playerTransform.position);

            // Step 2: Transform that local offset to world position in other teleporter's space
            Vector3 targetPosition = otherTeleporter.transform.TransformPoint(localOffset);

            // Step 3: Move player to new position (rotation is preserved automatically)
            playerTransform.position = targetPosition;
        }
    }
}