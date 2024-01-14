using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Tạo một ScriptableObject và lưu tên file Colordata, dùng để lưu trữ các màu. Chi tiết trong file ReadMe 2
[CreateAssetMenu(fileName = "ColorData", menuName ="ScriptableObjects/ColorData", order = 1)]
public class ColorData : ScriptableObject
{
    [SerializeField] Material[] colorMats;                  // Tạo một mảng các material có tên là colorMats
    public Material GetColorMat(ColorType colorType)        // Tạo hàm để trả về 1 giá trị kiểu Materials thuộc mảng colorMats
    {
        return colorMats[(int)colorType];
    }
}
