using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : ColorObj
{
    #region Khai B�o
    [HideInInspector] public Stage stage;
    #endregion

    //private void Start()
    //{
    //    ChangeColor((ColorType)Random.Range(1, 5));
    //}

    public void OnDespawn()
    {
        stage.RemoveBrick(this);
    }
}
