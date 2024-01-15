using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dùng cho 1 cái chắn ở trước mỗi stage, bot/player đi qua thì stage sẽ thêm màu của bot/player đó vào danh sách màu có thể ren cho gạch
public class NewStageBox : MonoBehaviour
{
    #region Khai Báo
    public Stage stage;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if(character != null)
        {
            character.stage = stage;
            stage.InitColor(character.colorType);
        }    
    }
}
