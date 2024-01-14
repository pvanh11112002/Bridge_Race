﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : UICanvas
{
    public override void Open()
    {
        Time.timeScale = 0;
        base.Open();
    }
    public override void Close(float delayTime)
    {
        //Hàm này đang sai logic
        Time.timeScale = 1;
        base.Close(delayTime);
    }
    public void ContinueButton()
    {
        Close(0.1f);
    }
    public void RetryButton()
    {
        LevelManager.Instance.OnRetry();
        Close(1);
    }
}
