using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObj : MonoBehaviour
{
    [HideInInspector] public ColorType colorType;
    [SerializeField] private Renderer render;
    [SerializeField] private ColorData colorData;
    
    public void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        render.material = colorData.GetColorMat(colorType);
    }

    
}
