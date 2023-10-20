using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill801 : DefaultSkill
{

    public List<GameObject> MonsterList { get; set; }
    public Vector3 KnightInfo;
    public Vector3 TargetPos;
    public int li;

    public Vector3 dir;
    public float GoingLen = 10;   
    public float BackGoingLen = 5;  
    public float LeftGoingLen = 8;

    public bool _isRightGoing = false;
    public bool _isBackGoing = false;
    public bool _isLeftGoing = false;
    public bool DirectionSettingDone = false;

    public Vector3 InitPosition;
    public Vector3 LatePosition;
    public GameObject light;
    public Vector3 movingScale = new Vector3(1f, 1f, 0);
    float scale = 0;
    Skill801_MoveAfter skill801_ma;
    protected override void Init()  
    {
        base.Init();

        _skillNum = 801;
        //transform.position = _ownerCc.transform.position + new Vector3(-2.0f, 0, 0);
        transform.position = ((TargetPos + _ownerCc.transform.position) / 5)*4+ new Vector3(-0.2f,0,-0.2f);


        float angle = Mathf.Atan2((TargetPos.x - KnightInfo.x), (TargetPos.z - KnightInfo.z)) * (360 / (Mathf.PI * 2));
        Debug.Log($"angle : {angle}");
        transform.RotateAround(KnightInfo, Vector3.up, angle);

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

        GoMovingFast();
    }

    public void GoMovingFast()
    {
        if (_isRightGoing == false)  // 대각선 오른쪽으로 이동하는 코드
        {
            dir = (KnightInfo + new Vector3(2, 0, 4)).normalized;
            transform.LookAt(transform.position + dir);
            // 방향 전환 
            //if (GoingLen <10.0f && GoingLen > 2)
            //{
            //    transform.LookAt(transform.position + dir);
            //}
            //else if (GoingLen <= 2 && GoingLen > 0)
            //{
            //    Quaternion QTtargetrot = Quaternion.LookRotation((KnightInfo + new Vector3(0, 0, -3)));
            //    transform.rotation = Quaternion.Slerp(transform.rotation, QTtargetrot, Time.deltaTime * 40);    
            //}
            
            Vector3 len = dir * Time.deltaTime * 15.0f;
      
            // scale 조정 
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if(child.name == "moving")
                {
                    child.localScale = movingScale + new Vector3(0, 0, scale);
                    Debug.Log($"scale : {scale}");
                    //Debug.Log($"child.localScale : {child.localScale}");
                }
            }

            if (GoingLen < 10.0f && GoingLen >= 4.0f)
            {
                scale += 0.22f;
            }
            else if (GoingLen < 4.0f && GoingLen > 0)
            {
                if (scale < 0)
                {  
                    scale = 0;
                }
                Debug.Log("-----------");
                scale -= 0.15f;
            }

            transform.position += len;
            GoingLen -= len.magnitude;

            
            if (GoingLen <= 0)
            {
                _isRightGoing = true;
                Transform[] allChildrens = GetComponentsInChildren<Transform>();
                foreach (Transform child in allChildrens)
                {
                    if (child.name == "moving")
                    {
                        child.localScale = new Vector3(0, 0, 0);
                        //Debug.Log($"child.localScale : {child.localScale}");
                    }
                }

                Debug.Log(" 다왔땅~~1");
            }
        }
        else
        {
            if (_isBackGoing == false)
            {
                dir = (KnightInfo + new Vector3(0, 0, -3)).normalized;
                transform.LookAt(transform.position + dir);
                // 방향 전환 
                //if (BackGoingLen < 5.0f && BackGoingLen >= 4.0)
                //{
                //    Quaternion QTtargetrot = Quaternion.LookRotation((KnightInfo + new Vector3(0, 0, -3)));
                //    transform.rotation = Quaternion.Slerp(transform.rotation, QTtargetrot, Time.deltaTime * 20);

                //}
                //else if (BackGoingLen < 4.0 && BackGoingLen >= 1.0)
                //{
                //    transform.LookAt(transform.position + dir);
                //}else if(BackGoingLen < 1.0 && BackGoingLen > 0)
                //{
                //    Quaternion QTtargetrot = Quaternion.LookRotation((KnightInfo + new Vector3(-3, 0, 3)));
                //    transform.rotation = Quaternion.Slerp(transform.rotation, QTtargetrot, Time.deltaTime * 20);  
                //}

                Vector3 len2 = dir * Time.deltaTime * 15.0f;
          
                Transform[] allChildren = GetComponentsInChildren<Transform>();
                foreach (Transform child in allChildren)
                {
                    if (child.name == "moving")
                    {
                        child.localScale = movingScale + new Vector3(0, 0, scale);
                    }
                }
                // scale 조정 
                if (BackGoingLen < 5 && BackGoingLen >= 2.5f)
                {
                    scale += 0.22f;
                }
                else if (BackGoingLen < 2.5f && BackGoingLen > 0)
                {
                    if (scale < 0)
                    {
                        scale = 0;
                    }
                    scale -= 0.15f;
                }

                transform.position += len2;
                BackGoingLen -= len2.magnitude;

                if (BackGoingLen <= 0)
                {
                    Transform[] allChildrens = GetComponentsInChildren<Transform>();
                    foreach (Transform child in allChildrens)
                    {
                        if (child.name == "moving")
                        {
                            child.localScale = new Vector3(0, 0, 0);
                            //Debug.Log($"child.localScale : {child.localScale}");
                        }
                    }

                    _isBackGoing = true;
                    Debug.Log(" 다왔땅~~2");
                }
            }
            else
            {
                if (_isLeftGoing == false)
                {
                    dir = (KnightInfo + new Vector3(-3, 0, 3)).normalized;
                    transform.LookAt(transform.position + dir);

                    Vector3 len3 = dir * Time.deltaTime * 15.0f;

                    // scale 조정 
                    Transform[] allChildren = GetComponentsInChildren<Transform>();
                    foreach (Transform child in allChildren)
                    {
                        if (child.name == "moving")
                        {
                            child.localScale = movingScale + new Vector3(0, 0, scale);
                            Debug.Log($"child.localScale : {child.localScale}");

                        }
                    }
                    if (LeftGoingLen < 8 && LeftGoingLen >= 4)
                    {
                        scale += 0.3f;
                    }
                    else if (LeftGoingLen < 4 && LeftGoingLen > 0)
                    {
                        if (scale < 0)
                        {
                            scale = 0;
                        }
                        scale -= 0.2f;
                    }

                    transform.position += len3;
                    LeftGoingLen -= len3.magnitude;
                    if (LeftGoingLen <= 0)
                    {
                        Transform[] allChildrens = GetComponentsInChildren<Transform>();
                        foreach (Transform child in allChildrens)
                        {
                            if (child.name == "moving")
                            {
                                child.localScale = new Vector3(0, 0, 0);
                            }
                        }

                        _isLeftGoing = true;
                        Debug.Log(" 다왔땅~~3");
                        StartCoroutine(CoDeleteSkill2());

                    }
                }
            }
        }



    }


    IEnumerator CoDeleteSkill2()
    {
        yield return new WaitForSeconds(0.3f);

        Managers.Resource.Destroy(transform.gameObject);
    }
    IEnumerator CoDeleteSkill()
    {
        yield return new WaitForSeconds(4);

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