using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikminSpawner : MonoBehaviour
{
    Transform home;
    Transform playerFollowTarget;

    [SerializeField]
    GameObject pikmin;

    private void Awake()
    {
        home = GameObject.Find("Home").transform;
        playerFollowTarget = GameObject.Find("PikminFollowTarget").transform;
    }
    GameObject Spawn(Vector3 position)
    {
        GameObject newPikmin = Instantiate(pikmin, position, Quaternion.identity);
        newPikmin.GetComponent<PikminController>().SetWaypoints(home, playerFollowTarget);
        return newPikmin;
    }
}
