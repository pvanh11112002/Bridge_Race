using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    #region Khai báo
    //Tạo một List chứa các giá trị của ColorType, List này là biến kiểu chỉ đọc
    readonly List<ColorType> colorTypes = new List<ColorType>() { ColorType.Red, ColorType.Green, ColorType.Blue, ColorType.Yellow };   
    public Level[] levelPrefabs;
    public Bot botPrefab;
    public Player player;
    public Vector3 FinishPoint => currentLevel.finishPoint.position; // ký hiệu "=>" cũng là định nghĩa thuộc tính chỉ đọc
    public int CharAmount => currentLevel.botAmount + 1;
    private Level currentLevel;   
    private List<Bot> bots = new List<Bot>();
    #endregion


    private void Start()
    {
        LoadLevel(0);
        OnInit();
        UIManager.Instance.OpenUI<MainMenu>();                      // Gọi lên thằng main menu
    }
    public void OnInit()
    {
        // Khởi tạo các vị trí bắt đầu của game
        Vector3 index = currentLevel.startPoint.position;
        float space = 3f;       
        Vector3 firstLeftPoint = ((CharAmount / 2) + (CharAmount % 2) * 0.5f - 0.5f) * space * Vector3.left + index;
        List<Vector3> startPoints = new List<Vector3>();   
        for(int i = 0; i < CharAmount; i++)
        {
            startPoints.Add(firstLeftPoint + space * Vector3.right * i);           
        }
        
        // Tạo ra một anh sách mơi đã được sắp xếp từ colorTypes theo số lượng charamount
        // LinQ
        List<ColorType> colorDatas = Utilities.SortOrder(colorTypes, CharAmount);
        
        // Đặt vị trí của người chơi
        int rand = Random.Range(0, CharAmount);
        player.transform.position = startPoints[rand];       
        player.transform.rotation = Quaternion.identity;
        startPoints.RemoveAt(rand);

        // Tô màu cho người chơi và bot
        player.ChangeColor(colorDatas[rand]);
        colorDatas.RemoveAt(rand);
        player.OnInit();
        for (int i = 0; i < CharAmount - 1; i++)
        {          
            Bot bot = Instantiate(botPrefab, startPoints[i], Quaternion.identity);
            bot.ChangeColor(colorDatas[i]);
            bot.OnInit();
            bots.Add(bot);
        }

    }
    public void LoadLevel(int level)
    {
        if(currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
        if(level < levelPrefabs.Length)
        {
            currentLevel = Instantiate(levelPrefabs[level]);
            currentLevel.OnInit();
        }
        else
        {
            //level limit
        }
    }
    // Logic của các chức năng nút
    public void OnStartGame()
    {
        GameManager.Instance.ChangeState(GameState.GamePlay);
        for(int i = 0; i < bots.Count; i++)
        {
            bots[i].ChangeState(new PatrolState());
        }
    }
    public void OnFinishGame() 
    {
        for (int i = 0; i < bots.Count; i++)
        {
            bots[i].ChangeState(null);
            bots[i].MoveStop();
        }
    }
    public void OnReset()
    {
        for (int i = 0; i < bots.Count; i++)
        {
            Destroy(bots[i].gameObject);
        }
        bots.Clear();
    }

    internal void OnRetry()
    {
        OnReset();
        LoadLevel(0);
        OnInit();
        UIManager.Instance.OpenUI<MainMenu>();
    }

    internal void OnNextLevel()
    {
        OnReset();
        LoadLevel(0);
        OnInit();
        UIManager.Instance.OpenUI<MainMenu>();
    }
}
