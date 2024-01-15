using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    #region Khai báo
    public NavMeshAgent agent;
    //Kiểm tra xem bot đến đích hay chưa
    public bool IsDestinnation => Vector3.Distance(destination, Vector3.right * transform.position.x + Vector3.forward * transform.position.z) < 1f;
    private Vector3 destination;                                        // Điểm đến của bot
    IState<Bot> currentState;                                           // Trạng thái hiện tại caruar bot  
    #endregion


    //Dùng để khởi động con bot, cho nó di chuyển
    //Ghi đè phương thức Start của Char
    //protected override void Start()
    //{
    //    skin.rotation = Quaternion.identity;
    //    base.Start();
    //    ChangeState(new PatrolState()); //Khởi động thì đổi sang Patrol State - Tìm gạch
    //}


    public override void OnInit()
    {
        base.OnInit();
        ChangeAnim(idleAnim);
    }    


    //Set điểm đến theo NavMesh
    public void SetDestination(Vector3 position)
    {
        agent.enabled = true;
        destination = position;
        destination.y = 0;
        agent.SetDestination(position);        
    }
    
    private void Update()
    {
        if (GameManager.Instance.IsState(GameState.GamePlay) && currentState != null)
        {
            currentState.OnExcute(this);
            CanMove(transform.position);
        }
    }
    public void ChangeState(IState<Bot> state)
    {
        if(currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = state;
        if(currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    internal void MoveStop()
    {
        agent.enabled = false;
    }
}
