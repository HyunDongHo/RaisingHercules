using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material mtrlOrg; // 원래꺼 
    [SerializeField] private Material mtrlDissolve;
    [SerializeField] private float fadeTime = 1.5f; //지속시간     


    void Start()
    {
        _renderer.material = mtrlDissolve;
        DoFade(0.1f, 1.5f, fadeTime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))  // 나타나기
        {
            _renderer.material = mtrlDissolve;
            DoFade(0.1f, 1.5f, fadeTime);
        }
        else if (Input.GetKeyDown(KeyCode.O)) // 사라지기
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
