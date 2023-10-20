using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill701 : DefaultSkill
{

    public List<GameObject> MonsterList { get; set; }
    public Vector3 KnightInfo;
    public Vector3 TargetPos;
    public int li;
    protected override void Init()
    {
        base.Init();
        _skillNum = 701;
        int MonPositionX = (int)(TargetPos.x);
        int MonPositionZ = (int)(TargetPos.z);

        float SetPositionX ;
        float SetPositionZ ;

        /* 동그란 구1 : y : -0.7f  , 동그란 구2 : y : 3.5f*/
        if (li == 0 ) // Left 구 
        {
            if (TargetPos.x < 0 && TargetPos.z > 0)  // - + 
            {
                SetPositionX = -Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);
                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
                transform.LookAt(TargetPos);
            }
            else if (TargetPos.x > 0 && TargetPos.z < 0) // + - 
            {
                SetPositionX = Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);
                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
                transform.LookAt(TargetPos);
            }

            if (TargetPos.x > 0 && TargetPos.z > 0) // + +   
            {
                SetPositionX = -Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);
                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
                transform.LookAt(TargetPos);
            }
            else if (TargetPos.x < 0 && TargetPos.z < 0)// - - 
            {
                SetPositionX = Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);

                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
                transform.LookAt(TargetPos);
            }

            if(TargetPos.x == 0 && TargetPos.z > 0) // 0 +
            {
                transform.position = _ownerCc.transform.position + new Vector3(-2.0f, 3.5f, 0);
                transform.LookAt(TargetPos);
            }
            else if(TargetPos.x == 0 && TargetPos.z < 0) // 0 -
            {
                transform.position = _ownerCc.transform.position + new Vector3(2.0f, 3.5f, 0);
                transform.LookAt(TargetPos);
            }
            
            // 이건 왜 안되는 겨!!! 왜 Nan 이 들어가는 거지?????
            if(TargetPos.x > 0 && TargetPos.z == 0) // + 0
            {
                transform.position = _ownerCc.transform.position + new Vector3(0, 3.5f, 2.0f);
                transform.LookAt(TargetPos);
            }
            else if(TargetPos.x < 0 && TargetPos.z == 0) // - 0
            {
                transform.position = _ownerCc.transform.position + new Vector3(0, 3.5f, -2.0f);
                transform.LookAt(TargetPos);
            }

        }
        else if (li == 1) // Center 구
        {
            transform.position = _ownerCc.transform.position + new Vector3(0, 3.5f, 0);
            transform.LookAt(TargetPos);
        }
        else  // Right 구 
        {
            if (TargetPos.x < 0 && TargetPos.z > 0)  // - + 
            {
                SetPositionX = Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);
                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
                transform.LookAt(TargetPos);
            }
            else if (TargetPos.x > 0 && TargetPos.z < 0) // + - 
            {
                SetPositionX = -Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);
                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
                transform.LookAt(TargetPos);
            }

            if (TargetPos.x > 0 && TargetPos.z > 0) // + + 
            {
                SetPositionX = Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);
                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
                transform.LookAt(TargetPos);
            }
            else if (TargetPos.x < 0 && TargetPos.z < 0)// - - 
            {
                SetPositionX = -Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);
                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
                transform.LookAt(TargetPos);
            }
            
            if (TargetPos.x == 0 && TargetPos.z > 0) // 0 +
            {
                Debug.Log("ssss");
                transform.position = _ownerCc.transform.position + new Vector3(2.0f, 3.5f, 0);
                transform.LookAt(TargetPos);
            }
            else if (TargetPos.x == 0 && TargetPos.z < 0) // 0 -
            {
                transform.position = _ownerCc.transform.position + new Vector3(-2.0f, 3.5f, 0);
                transform.LookAt(TargetPos);
            }
            
            if (TargetPos.x > 0 && TargetPos.z == 0) // + 0
            {
                transform.position = _ownerCc.transform.position + new Vector3(0, 3.5f, -2.0f);
                transform.LookAt(TargetPos);
            }
            else if (TargetPos.x < 0 && TargetPos.z == 0) // - 0
            {
                transform.position = _ownerCc.transform.position + new Vector3(0, 3.5f, 2.0f);
                transform.LookAt(TargetPos);
            }
        }

        StartCoroutine(CoDeleteSkill());

        //SetParent(Managers.Scene.StageScene.m_SkillParent.transform);
    }

    private void OnEnable()
    {
        StartCoroutine(CoDeleteSkill());

        //SetParent(Managers.Scene.StageScene.m_SkillParent.transform);
    }

    private void OnDisable()
    {

    }

    private void FixedUpdate()
    {
        
        
    }

    
    IEnumerator CoDeleteSkill()
    {
        yield return new WaitForSeconds(2.0f);

        Managers.Resource.Destroy(transform.gameObject);  
    }

    //// 방어력 약화
    //public override void ProcessSkill(GameObject monsterObj)
    //{
    //    foreach (GameObject checkObj in _targetList)
    //    {
    //        if (checkObj == monsterObj)
    //            return;
    //    }

    //    _targetList.Add(monsterObj);

    //    CreatureController mc = monsterObj.GetComponentInParent<CreatureController>();

    //    if (mc == null || mc.State == Define.State.Die)
    //        return;

    //    mc.Stat.Defense = 0;

    //    ((StageScene)Managers.Scene.CurrentScene).DamageTextManager.CreateWeakness(mc.EffectPosition.position);
    //}

}