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
        if (!isTeleporter) return;

        if (other.CompareTag("Player"))
        {
            // Get the root player object
            GameObject player = other.gameObject;

            // Find the truePosition child object
            Transform truePos = player.transform.Find("truePosition");
            if (truePos == null)
            {
                Debug.LogWarning("truePosition object not found on player.");
                return;
            }

            // Step 1: Get truePosition's offset relative to this teleporter
            Vector3 localOffset = transform.InverseTransformPoint(truePos.position);

            // Step 2: Convert that to world space using the other teleporter
            Vector3 targetTruePosWorld = otherTeleporter.transform.TransformPoint(localOffset);

            // Step 3: Offset the entire player so that truePosition ends up at the right spot
            Vector3 playerOffset = player.transform.position - truePos.position;
            player.transform.position = targetTruePosWorld + playerOffset;
        }
    }
}