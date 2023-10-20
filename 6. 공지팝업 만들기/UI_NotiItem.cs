using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_NotiItem : UI_Base
{
    public string title;
    public string info;
    public string date;

    [SerializeField]
    TextMeshProUGUI UpdateTitleText, InfomationText;

    [SerializeField]
    GameObject FrameSetActive;

    public Action PushAction;
    public override void Init()
    {
        SetUI();
    }

    public void SetUI()
    {

        UpdateTitleText.text = title;
        if(info.Length >= 48) // 3줄만 보여지게 
        {
            InfomationText.text = info.Substring(0, 48);
        }
        else
        {
            InfomationText.text = info;
        }
    }

    public void OnClickShowButton()
    {
        if (PushAction != null)
            PushAction.Invoke();
    }


}
