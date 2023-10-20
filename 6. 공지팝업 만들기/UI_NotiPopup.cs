using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_NotiPopup : UI_Popup
{
    public GameObject content;
    public List<UI_NotiItem> m_NotiItem;
    public List<string> m_title;
    public List<string> m_info;
    public List<string> m_date;

    [SerializeField]
    TextMeshProUGUI DetailText, TitleText, DateText; //DetailPanel 안에 있는 title, info

    [SerializeField]
    GameObject DetailPanel; // 상세창
    public override void Init()
    {
        base.Init();
        SetUI();

    }
    public void SetUI()
    {
        Debug.Log($" here count  : {m_NotiItem.Count}");
        if(m_NotiItem.Count != 0)
        {
            for (int i = 0; i < m_NotiItem.Count; i++)
            {
                m_NotiItem[i].title = m_title[i];
                m_NotiItem[i].info = m_info[i];
                m_NotiItem[i].date = m_date[i];
                m_NotiItem[i].SetUI();

                string title = m_NotiItem[i].title;
                string info = m_NotiItem[i].info;
                string date = m_NotiItem[i].date;
                m_NotiItem[i].PushAction = () =>
                {
                    DetailPanel.SetActive(true); // 상세창이 열림
                    TitleText.text = title;
                    DetailText.text = info;
                    DateText.text = date;
                };
            }
        }        
    }
    public void DetailPanelOff()
    {
        DetailPanel.SetActive(false);
    }
    public void CloseNotiPopupUI()
    {
        m_NotiItem.Clear();
        m_title.Clear();
        m_info.Clear();

        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
        gameObject.SetActive(false);
    }
}
