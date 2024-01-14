using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    #region Khai báo
    [SerializeField] private float speed = 2f;
    public FloatingJoystick variableJoystick;    
    #endregion

    //private void Start()
    //{
    //    ChangeColor(ColorType.Red);
    //}


    // Điều khiển di chuyển của nhân vật
    public void FixedUpdate()
    {
        if(GameManager.Instance.IsState(GameState.GamePlay))
        {
            float horizon = variableJoystick.Horizontal;
            float vertical = variableJoystick.Vertical;
            dir = new Vector3(horizon * speed, 0, vertical * speed);                    // Tạo một vector chỉ hướng dir từ joystick của người chơi, thông tin đã lấy bên trên
                                                                                        // Có thể đổi sang dùng "rb.velocity = dir;" nhưng nên hạn chế dùng rb để di chuyển
            transform.rotation = Quaternion.LookRotation(dir);                          // Đặt hướng quay của đối tượng phù hợp với hướng của vector dir ở trên
            Vector3 nextPoint = dir * speed * Time.deltaTime + transform.position;      // Tính toán điểm tiếp theo mà player sẽ di chuyển đến
            //Debug.Log(nextPoint);
            if (CanMove(nextPoint))
            {
                transform.position = CheckGround(nextPoint);
                if (dir != new Vector3(0, 0, 0)) // Nếu có input thì sẽ có hướng, không có input thì dir = 0,0,0, dựa vào đó thay đổi animation
                {
                    ChangeAnim("run");
                }
                else
                {
                    ChangeAnim("idle");
                }                
            }

        }    
    }   
}