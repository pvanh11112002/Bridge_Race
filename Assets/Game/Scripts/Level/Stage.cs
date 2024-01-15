using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enum này dùng để định nghĩa các giá trị của ColorType. Chi tiết có trong ReadMe2.Txt
public enum ColorType
{
    Default,
    Red,
    Green,
    Blue,
    Yellow
}
public class Stage : MonoBehaviour
{
    #region Khai báo
    [SerializeField] Brick brickPrefab;                                         // Prefab của viên gạch
    public Transform[] brickPoints;                                             // Những điểm đặt gạch trong stage
    public List<Vector3> emptyPoint = new List<Vector3>();                      // Những tọa độ gạch đã bị mất
    public List<Brick> bricks = new List<Brick>();                              // Số gạch còn lại trên stage
    #endregion

    internal void OnInit()
    {
        for (int i = 0; i < brickPoints.Length; i++)
        {
            emptyPoint.Add(brickPoints[i].position);
        }
    }
    public void InitColor(ColorType colorType)
    {
        int amount = brickPoints.Length / LevelManager.Instance.CharAmount;
        for (int i = 0; i < amount; i++)
        {
            NewBrick(colorType);
        }    
    }
    public void NewBrick(ColorType colorType)
    {
        if(emptyPoint.Count > 0)
        {
            int rand = Random.Range(0, emptyPoint.Count);
            Brick brick = Instantiate(brickPrefab, emptyPoint[rand], Quaternion.identity);
            brick.stage = this;
            brick.ChangeColor(colorType);
            emptyPoint.RemoveAt(rand);
            bricks.Add(brick);
        }    
    }

    internal void RemoveBrick(Brick brick)
    {
        emptyPoint.Add(brick.transform.position);
        bricks.Remove(brick);
    }

    internal Brick SeekBrickPoint(ColorType colorType)
    {
        Brick brick = null;
        for (int i = 0; i < bricks.Count; i++)
        {
            if (bricks[i].colorType == colorType)
            {
                brick = bricks[i];
                break;
            }
        }
        return brick;
    }
}
