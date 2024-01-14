using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPlace : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();                              //Check xem thằng nào lên trước thì hiện UI tương ứng trường hợp
        if (character != null)
        {
            LevelManager.Instance.OnFinishGame();
            if(character is Player)
            {
                UIManager.Instance.OpenUI<Victory>();
            }
            else if(character is Bot) 
            {
                UIManager.Instance.OpenUI<Fail>();
            }
            UIManager.Instance.CloseUI<GamePlay>();
            character.OnInit();
            GameManager.Instance.ChangeState(GameState.Pause); 
            
        }
    }
}
