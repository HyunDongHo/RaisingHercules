using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material mtrlOrg; // ������ 
    [SerializeField] private Material mtrlDissolve;
    [SerializeField] private float fadeTime = 1.5f; //���ӽð�     


    void Start()
    {
        _renderer.material = mtrlDissolve;
        DoFade(0.1f, 1.5f, fadeTime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))  // ��Ÿ����
        {
            _renderer.material = mtrlDissolve;
            DoFade(0.1f, 1.5f, fadeTime);
        }
        else if (Input.GetKeyDown(KeyCode.O)) // �������
        {
            _renderer.material = mtrlDissolve;  
            DoFade(1.5f, 0, fadeTime);
        }
    }
    void DoFade(float start, float dest, float time)    
    {
        iTween.ValueTo(gameObject, iTween.Hash("from", start, "to", dest,
           "time", time, "onupdatetarget", gameObject, "onupdate", "TweenOnUpdate", "oncomplete", "TweenOnComplte",
           "easetype", iTween.EaseType.easeInOutCubic));  
    }

    void TweenOnUpdate(float value)
    {
        _renderer.material.SetFloat(name = "_SplitValue", value);
 
    }
    void TweenOnComplte()
    {
        Debug.Log("comp");  
        _renderer.material = mtrlOrg;
    }
}
