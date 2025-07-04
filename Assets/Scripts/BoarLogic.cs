using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarLogic : MonoBehaviour
{

    public GameObject playerObject;
    private bool canHear = true;
    private bool seesPlayer = false;
    public float secondsEntityCantHear = 2f;
    public float chaseCooldown = 2f;
    public float listeningRadius = 100f; //idk if this is a good number, beats me :')

    public Vector3 lastHeardLocation;
    enum BoarState
    {
        Patrolling,
        Investigating,
        Chasing,
        PathingBack
    }

    private BoarState currentState = BoarState.Patrolling;

    /*

    noise logic, all footsteps have a location in which they were made.
    feed current location of player if player makes sound.

    */

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case BoarState.Patrolling:
                HandlePatrol();
                break;
            case BoarState.Investigating:
                HandleInvestigate();
                break;
            case BoarState.Chasing:
                HandleChase();
                break;
            case BoarState.PathingBack:
                HandlePathingBack();
                break;
        }

        HandleSight();
        HandleHearing();
    }

    void HandleSight()
    {
        if (seesPlayer)
        {
            currentState = BoarState.Chasing;
        }

    }

    void HandleHearing()
    {
        if (!canHear)
        {
            return;
        }

        if (/*playerMadeNoise && playerLocation in listeningRadius && BoarState != BoarState.Chasing */ false) {

            lastHeardLocation = playerObject.transform.position;
            currentState = BoarState.Investigating;

        }
    }
    void HandlePatrol()
    {
        // define two points and move between those two points
    }

    void HandleInvestigate()
    {
        // path towards lastHeardLocation
    }

    void HandleChase()
    {
        // set movement speed up, trigger sound cues + music

        // if seesPlayer, get current player location and path to it.

        // if !seesPlayer, path towards last seen player location
            // start coroutine towards changing state to BoarState.PathingBack after chaseCooldown secs
            
            
    }

    void HandlePathingBack()
    {
        // get to initial starting location
    }
}
