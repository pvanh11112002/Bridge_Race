using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform startPoint;                                            // Điểm bắt đầu
    public Transform finishPoint;                                           // Điểm kết thúc
    public int botAmount;                                                   // số lượng bot
    public Stage[] stages;                                                  // Các Stage
    public void OnInit()
    {
        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].OnInit();
        }
    }
}
