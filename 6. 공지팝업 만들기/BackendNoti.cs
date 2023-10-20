using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using LitJson;
using UnityEngine.Networking;
using UnityEngine.UI;
public class BackendNoti : MonoBehaviour
{
    [SerializeField]
    Transform notiPop;

    public void OnClickNoticeList()
    {
        BackendReturnObject BRO = Backend.Notice.NoticeList(); //Backend.Notice.NoticeList(10); 공지 10개 추출
        if (BRO.IsSuccess())
        {
            //전체 공지 리스트 
            Debug.Log(BRO.GetReturnValue());
            JsonData jsonList = BRO.FlattenRows();

            UI_NotiPopup notiPopup = Managers.UI.ShowPopupUI<UI_NotiPopup>();

            for (int i = 0; i < jsonList.Count; i++)
            {
                notiPopup.m_title.Add(jsonList[i]["title"].ToString());
                notiPopup.m_info.Add(jsonList[i]["content"].ToString());
                notiPopup.m_date.Add(jsonList[i]["inDate"].ToString().Substring(0, 10)); 

                GameObject go = Managers.Resource.Instantiate("UI/UI_Item/UI_NotiItem", notiPopup.content.transform);
                notiPopup.m_NotiItem.Add(go.GetComponent<UI_NotiItem>());
            }

            notiPopup.SetUI();

        }
    }
}
