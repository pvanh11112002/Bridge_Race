using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;


public class LevelManager : MonoBehaviour
{
    #region Singleton
    public static LevelManager instance;
    public static LevelManager Instance
    {
        get { return instance; }
    }
    #endregion

    public GameObject[] bricksArr;
    public Transform[] planeArr;
    public GameObject bridgeBricks;
    public Transform bridge1, bridge2, bridge3;

    [SerializeField] private Vector3 rootPos1 = new Vector3(0, 0, 0);
    [SerializeField] private Vector3 rootPos2 = new Vector3(0, 5, 54);
    List<Vector3> takenBrickList = new List<Vector3>();
    List<int> takenColor = new List<int>();
    public Transform bridgeHolder;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        List<int> myList = GenerateArray();
        BrickRender(rootPos1, planeArr[0], myList);
        BrickRender(rootPos2, planeArr[1], myList);
        SpawnBridge(bridge1.position);
        SpawnBridge(bridge2.position);
        SpawnBridge(bridge3.position);
    }

    private void SpawnBridge(Vector3 pos)
    {
        bridgeHolder = new GameObject().transform;
        for (int i = 0; i < 20; i++)
        {
            Instantiate(bridgeBricks, pos, Quaternion.identity, bridgeHolder);
            pos.y += 1;
            pos.z += 2;
        }
    }

    private void BrickRender(Vector3 roootPos, Transform Parent, List<int> myList)
    {
        int brickCount = 0;
        int colorIndex = 0;
        Vector3 tempPos;
       
        for (int i = 0; i < 15; i++)
        {
            tempPos = roootPos;
            tempPos.z += 2 * i;
            for(int j = 0; j < 15; j++)
            {
                tempPos.x += 2;
                if (colorIndex < 80)
                {
                    Instantiate(bricksArr[myList[colorIndex]], tempPos, Quaternion.identity, Parent);
                    brickCount++;
                    colorIndex++;
                }                                  
                if(brickCount == 80 || colorIndex == 80)
                {
                    break;
                }    
            }
        }
    }
    private List<int> GenerateArray() 
    {
        List<int> myList = new List<int>();
        int inx = 0;
        //Tao ra mang chua index cac mau 
        // 0 = Red;
        // 1 = Green;
        // 2 = Blue;
        // 3 = Yellow;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                myList.Add(0);
            }
        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                myList[inx] = i;
                inx++;
            }
        }

        System.Random rng = new System.Random();
        int n = myList.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int value = myList[k];
            myList[k] = myList[n];
            myList[n] = value;
        }
        return myList;
    }
}
