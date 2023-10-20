using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill600 : DefaultSkill
{
    public float GoingLen = 6;
    public float BackGoingLen = 6;
    public bool _isGoing = false;
    public bool _isBackGoing = false;
    public Vector3 KnightInfo;

    public Vector3 dir;
    public Vector3 backDir;
    //public Vector3 direction;
    //public float rot;
    public float speed = 12;
    public float backSpeed = 8;
    public int li ;
    public bool DirectionSettingDone = false;
    public bool GoBackSettingDone = false;
    public bool ReadyGoBack = false;

    public List<float> FourDirectionX = new List<float>() { 0, 1, 0, -1 };
    public List<float> FourDirectionZ = new List<float>() { 1, 0, -1, 0 };

    public List<float> EightDirectionX = new List<float>() { 0, 1, 1, 1, 0, -1, -1, -1 };
    public List<float> EightDirectionZ = new List<float>() { 1, 1, 0, -1, -1, -1, 0, 1 };

    public List<float> DirectionX = new List<float>() { Mathf.Cos(90 * Mathf.Deg2Rad), Mathf.Cos(60 * Mathf.Deg2Rad), Mathf.Cos(30 * Mathf.Deg2Rad),Mathf.Cos(0 * Mathf.Deg2Rad),
            Mathf.Cos(330 * Mathf.Deg2Rad),  Mathf.Cos(300 * Mathf.Deg2Rad), Mathf.Cos(270 * Mathf.Deg2Rad),  Mathf.Cos(240 * Mathf.Deg2Rad),
            Mathf.Cos(210 * Mathf.Deg2Rad),  Mathf.Cos(180 * Mathf.Deg2Rad), Mathf.Cos(150 * Mathf.Deg2Rad), Mathf.Cos(120 * Mathf.Deg2Rad) };
    public List<float> DirectionZ = new List<float>() { Mathf.Sin(90 * Mathf.Deg2Rad), Mathf.Sin(60 * Mathf.Deg2Rad), Mathf.Sin(30 * Mathf.Deg2Rad),Mathf.Sin(0 * Mathf.Deg2Rad),
            Mathf.Sin(330 * Mathf.Deg2Rad),  Mathf.Sin(300 * Mathf.Deg2Rad), Mathf.Sin(270 * Mathf.Deg2Rad),  Mathf.Sin(240 * Mathf.Deg2Rad),
            Mathf.Sin(210 * Mathf.Deg2Rad),  Mathf.Sin(180 * Mathf.Deg2Rad), Mathf.Sin(150 * Mathf.Deg2Rad), Mathf.Sin(120 * Mathf.Deg2Rad) };
    public List<GameObject> MonsterList { get; set; }
    
    protected override void Init()
    {
        base.Init();

        _skillNum = 600;
        if (li == 0)
        {
            transform.position = _ownerCc.transform.position + new Vector3(0, 2.0f, 0.5f);
        }
        else if (li == 1)
        {
            transform.position = _ownerCc.transform.position + new Vector3(0.5f, 2.0f, 0);
        }
        else if (li == 2)
        {
            transform.position = _ownerCc.transform.position + new Vector3(0, 2.0f, -0.5f);
        }
        else
        {
            transform.position = _ownerCc.transform.position + new Vector3(-0.5f, 2.0f, 0);
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
        if (DirectionSettingDone == false)
        {
            StartCoroutine(CoDirectionSetting());
        }
        else
        {
            //슛
            Shoot();
        }
        
        //if(GoBackSettingDone == true)
        //{
        //    GoBackMoving();
        //}


    }
    IEnumerator CoDirectionSetting()
    {
        Debug.Log($"LI : {li}");

        dir = new Vector3(FourDirectionX[li], 0, FourDirectionZ[li]).normalized;
        transform.LookAt(transform.position + dir);
        DirectionSettingDone = true;

        yield return null;
        //yield return null;

    }
    public void Shoot()
    {

        if (_isGoing == false)  // 앞으로 이동하는 코드 
        {
            Vector3 len = dir * Time.deltaTime * speed;
            transform.position += len;
            GoingLen -= len.magnitude;

            if (GoingLen <= 0)
            {
                _isGoing = true;
                Debug.Log(" 다왔땅~~");
                GoBackSettingDone = true;
                //StartCoroutine(SetBackDirectionSetting());

            }
        }
        else
        {
            //=============================================================
            //TODO : (버전1) 뒤로 이동하는 코드 
            //GoBackGoingVer1();

            //TODO : (버전2) 시계반대방향으로 회전하는 코드 
            //transform.RotateAround(KnightInfo, Vector3.up, 120 * Time.deltaTime);

            //TODO : (버전3) 시계반대방향으로 90도회전하고 난 뒤 다시 돌아오는 코드 
            transform.RotateAround(KnightInfo, Vector3.up, 120 * Time.deltaTime);
            if (li == 0 && transform.position.z < 0.001)
            {
                ReadyGoBack = true;
            }
            else if (li == 1 && transform.position.x < 0.001)
            {
                ReadyGoBack = true;
            }
            else if (li == 2 && transform.position.z > 0.001)
            {
                ReadyGoBack = true;

            }
            else if (li == 3 && transform.position.x > 0.001)
            {
                ReadyGoBack = true;
            }

            if (ReadyGoBack == true)
            {
                GoBackGoingVer3();
            }

            //=========================================================
        }
        //else
        //{
        //    RotateAndReturn();
        //}

        DirectionSettingDone = false;
    }
    public void GoBackGoingVer1()
    {
        if (_isBackGoing == false)
        {
            if (li >= 2)
            {
                backDir = new Vector3(FourDirectionX[li - 2], 0, FourDirectionZ[li - 2]).normalized;
            }
            else
            {
                backDir = new Vector3(FourDirectionX[li + 2], 0, FourDirectionZ[li + 2]).normalized;
            }

            Vector3 len = backDir * Time.deltaTime * backSpeed;
            transform.position += len;
            BackGoingLen -= len.magnitude;

            if (BackGoingLen <= 0)
            {
                _isBackGoing = true;
                Debug.Log(" 끝났는데~!");
                GoBackSettingDone = true;
                Managers.Resource.Destroy(transform.gameObject);
                //StartCoroutine(SetBackDirectionSetting());

            }
        }
    }

    public void  GoBackGoingVer3()
    {
        Debug.Log("GoBackGoingVer3");
        if (_isBackGoing == false)
        {
            backDir = (KnightInfo - transform.position).normalized;

            Vector3 len = backDir * Time.deltaTime * backSpeed;
            transform.position += len;
            BackGoingLen -= len.magnitude;

            if (BackGoingLen <= 0)
            {
                _isBackGoing = true;
                Debug.Log(" 끝났는데~!");
                GoBackSettingDone = true;
                Managers.Resource.Destroy(transform.gameObject);
                //StartCoroutine(SetBackDirectionSetting());

            }
        }

    }

    //IEnumerator SetBackDirectionSetting()
    //{
    //    Debug.Log($"LI+6 : {li+6}");

    //    dir = new Vector3(DirectionX[li+6], 0, DirectionZ[li+6]).normalized;
    //    transform.LookAt(transform.position + dir);
    //    DirectionSettingDone = true;

    //    yield return null;
    //    //yield return null;

    //}

    //public void RotateAndReturn() // 끝에 도달했을 때 방향 바꾸는 함수 
    //{

    //    if (li < 7)
    //    {
    //        direction = new Vector3(DirectionX[li+6], 0, DirectionZ[li+6]).normalized;  
    //        //float turnAmount = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    //        //rot = Mathf.LerpAngle(transform.eulerAngles.y, turnAmount, Time.deltaTime * 10.0f);
    //        //transform.eulerAngles = new Vector3(0, rot, 0);
    //        //StartCoroutine(CoActionSword());
    //        Quaternion targetRot = Quaternion.LookRotation(direction);
    //        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 30.0f);    

    //    }
    //    else
    //    {
    //        direction = new Vector3(DirectionX[li - 6], 0, DirectionZ[li - 6]).normalized;  
    //        transform.LookAt(transform.position + direction);  
    //    }

    //    //yield return null;

    //}

    IEnumerator CoDeleteSkill()
    {
        yield return new WaitForSeconds(10);

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