using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : ColorObj
{
    //private void Start()
    //{
    //    ChangeColor((ColorType)Random.Range(1, 5));
    //}
    [HideInInspector] public Stage stage;
    public void OnDespawn()
    {
        stage.RemoveBrick(this);
    }
}
