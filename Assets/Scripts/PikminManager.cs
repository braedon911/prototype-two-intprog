using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikminManager : MonoBehaviour
{
    List<GameObject> onField;
    List<GameObject> idle;
    List<GameObject> carrying;
    List<GameObject> following;

    void Start()
    {
        onField = new List<GameObject>();
        idle = new List<GameObject>();
        carrying = new List<GameObject>();
        following = new List<GameObject>();

        GameObject[] inScene = GameObject.FindGameObjectsWithTag("Pikmin");
        
        foreach (GameObject extant in inScene)
        {
            onField.Add(extant);
            following.Add(extant);
        }
    }
}
