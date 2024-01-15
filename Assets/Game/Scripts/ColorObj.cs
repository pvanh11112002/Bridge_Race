using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObj : MonoBehaviour
{
    #region Khai báo
    [HideInInspector] public ColorType colorType;
    [SerializeField] private Renderer render;
    [SerializeField] private ColorData colorData;
    #endregion
    public void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        render.material = colorData.GetColorMat(colorType);
    }

    
}
