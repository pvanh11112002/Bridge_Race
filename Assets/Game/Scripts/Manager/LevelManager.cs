using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    readonly List<ColorType> colorTypes = new List<ColorType>() { ColorType.Red, ColorType.Green, ColorType.Blue, ColorType.Yellow };
    public Level[] levelPrefabs;
    public Bot botPrefab;
    public Player player;

    private Level currentLevel;
    public Vector3 FinishPoint => currentLevel.finishPoint.position;
    public int CharAmount => currentLevel.botAmount + 1;


    private List<Bot> bots = new List<Bot>();
    private void Start()
    {
        LoadLevel(0);
        OnInit();
        UIManager.Instance.OpenUI<MainMenu>();// Gọi lên thằng main menu
    }
    public void OnInit()
    {
        //Khoi tao vi tri bat dau game
        Vector3 index = currentLevel.startPoint.position;
        float space = 3f;       
        Vector3 firstLeftPoint = ((CharAmount / 2) + (CharAmount % 2) * 0.5f - 0.5f) * space * Vector3.left + index;
        List<Vector3> startPoints = new List<Vector3>();   
        for(int i = 0; i < CharAmount; i++)
        {
            startPoints.Add(firstLeftPoint + space * Vector3.right * i);           
        }
        
        //Random Color
        //LinQ
        List<ColorType> colorDatas = Utilities.SortOrder(colorTypes, CharAmount);
        
        //Set player's position
        int rand = Random.Range(0, CharAmount);
        player.transform.position = startPoints[rand];       
        player.transform.rotation = Quaternion.identity;
        startPoints.RemoveAt(rand);

        //Set player's color
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
