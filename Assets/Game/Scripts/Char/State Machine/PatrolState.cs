using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//State này dùng để tìm gạch
public class PatrolState : IState<Bot>
{
    public int targetBrick;                                             // Số lượng gạch muốn kiếm khi ở trong state này

    public void OnEnter(Bot t)
    {
        t.ChangeAnim(Character.runAnim);                                            // Đổi sang Animation Run
        targetBrick = Random.Range(2, 5);                               // Tạo ra số lượng viên gạch muốn kiếm random
        //Debug.Log(targetBrick);
        SeekTarget(t);                                                  // Bắt đầu tìm gạch
    }

    public void OnExcute(Bot t)
    {
        if(t.IsDestinnation)                                            // Kiểm tra xem đến vị trí cần đến hay chưa
        {
            if(t.BrickCount >= targetBrick)                             // Đạt đủ kpi gạch thì đổi sang Attack State, không đủ thì tìm tiếp
            {
                t.ChangeState(new AttackState());
            }
            else                                                        
            {
                SeekTarget(t);
            }
        }
    }

    public void OnExit(Bot t)
    {
        
    }
    private void SeekTarget(Bot t)
    {
        if (t.stage != null)
        {
            Brick brick = t.stage.SeekBrickPoint(t.colorType);          // Tìm đến điểm gạch có màu của bot
            if (brick == null)                                          // Nếu điểm gạch đấy bằng null thì chuyển sang Attack State, nếu có điểm gạch thì Bot đi đến đó
            {
                t.ChangeState(new AttackState());
            }
            else
            {
                t.SetDestination(brick.transform.position);
            }
        }
        else
        {
            t.SetDestination(t.transform.position);
        }
    }
}
