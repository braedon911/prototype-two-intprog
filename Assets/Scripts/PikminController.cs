using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zoey.StateMach;

public class PikminController : MonoBehaviour
{
    
    NavMeshAgent agent;
    StateMachine stateMachine;

    Transform playerFollowTarget;
    Transform home;


    void Awake()
    {
        stateMachine = new StateMachine(StateFollowPlayer);
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        if (playerFollowTarget == null)
        {
            playerFollowTarget = GameObject.Find("PikminFollowTarget").transform;
        }
        if (home == null)
        {
            home = GameObject.Find("Home").transform;
        }
    }
    public void SetWaypoints(Transform _playerFollowTarget, Transform _home)
    {
        playerFollowTarget = _playerFollowTarget;
        home = _home;
    }
    void Update()
    {
        stateMachine.Execute();
    }
    public string CheckState()
    {
        return stateMachine.state.name;
    }
    #region states
    void StateFollowPlayer()
    {
        agent.destination = playerFollowTarget.position;
    }
    void StateThrown()
    {
        
    }
    void StateIdle()
    {
        agent.destination = transform.position;
    }
    void StateCarry()
    {

    }
    #endregion
}
