using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill910 : DefaultSkill
{

    public List<GameObject> MonsterList { get; set; }
    public Vector3 KnightInfo;
    public Vector3 TargetPos;
    public float radius = 3.3f;

    public List<int> MonsterInCircleList = new List<int>();
    public List<float> MinDistance = new List<float>();
    public List<int> countMonsterIndex = new List<int>() {0,0,0,0,0};
    public bool findMonsterDone = false;
    public bool movePossible0 = false;
    public bool movePossible1 = false;
    public bool movePossible2 = false;
    public bool movePossible3 = false;
    public bool movePossible4 = false;
    public int result ;
    protected override void Init()
    {
        base.Init();

        _skillNum = 910;
        //transform.position = _ownerCc.transform.position + new Vector3(0, 0, 3.3f);
        transform.position = TargetPos;

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
        
        if(findMonsterDone == false) // 범위내 몬스터 확인 
        {
            StartCoroutine(FindMonsterInCircle());  
        }

        if (movePossible0 == true) // 이동 가능 하다면 
        {
            Debug.Log("0번 몬스터 이동중");           
            MoveMonsterPosition(0);
        }
        if (movePossible1 == true) // 이동 가능 하다면 
        {
            Debug.Log("1번 몬스터 이동중");
            MoveMonsterPosition(1);
        }
        if (movePossible2 == true) // 이동 가능 하다면 
        {
            Debug.Log("2번 몬스터 이동중");
            MoveMonsterPosition(2);
        }
        if (movePossible3 == true) // 이동 가능 하다면 
        {
            Debug.Log("3번 몬스터 이동중");
            MoveMonsterPosition(3);
        }
        if (movePossible4 == true) // 이동 가능 하다면 
        {
            Debug.Log("4번 몬스터 이동중");
            MoveMonsterPosition(4);
        }

    }
    public void MoveMonsterPosition(int i)
    {
        if (i == 0)
        {
            Vector3 dir = (TargetPos - MonsterList[i].transform.position ).normalized;
            if((TargetPos - MonsterList[i].transform.position).magnitude > 0.7f)
            {
                MonsterList[i].transform.position += dir * Time.deltaTime * 3.0f;
            }  
        }
        else if (i == 1)
        {
            Vector3 dir = (TargetPos - MonsterList[i].transform.position).normalized;
            if ((TargetPos - MonsterList[i].transform.position).magnitude > 0.7f)
            {
                MonsterList[i].transform.position += dir * Time.deltaTime * 3.0f;
            }
        }
        else if (i == 2)
        {
            Vector3 dir = (TargetPos - MonsterList[i].transform.position).normalized;
            if ((TargetPos - MonsterList[i].transform.position).magnitude > 0.7f)
            {
                MonsterList[i].transform.position += dir * Time.deltaTime * 3.0f;
            }
        }
        else if (i == 3)
        {
            Vector3 dir = (TargetPos - MonsterList[i].transform.position).normalized;
            if ((TargetPos - MonsterList[i].transform.position).magnitude > 0.7f)
            {
                MonsterList[i].transform.position += dir * Time.deltaTime * 3.0f;
            }
        }
        else if (i == 4)
        {
            Vector3 dir = (TargetPos - MonsterList[i].transform.position).normalized;
            if ((TargetPos - MonsterList[i].transform.position).magnitude > 0.7f)
            {
                MonsterList[i].transform.position += dir * Time.deltaTime * 3.0f;
            }
        }
        
    }

    IEnumerator FindMonsterInCircle() // 원 안에 몬스터 찾기 
    {

        for (int i = 0; i < MonsterList.Count; i++)
        {
            if (MonsterList[i].transform.position == TargetPos )
                continue;
            if ((transform.position - MonsterList[i].transform.position).magnitude < radius)
            {             
                StartCoroutine(FindStandardP2(i));
            }
        }

        yield return null;
    }

    IEnumerator FindStandardP2(int circleInMonsterIndex) // 기준이 되는 p2값 찾기  
    {
        
        countMonsterIndex[circleInMonsterIndex] += 1; // 카운트 셈 
        
        if(countMonsterIndex[circleInMonsterIndex] < 2)
        {
            Debug.Log($"MonsterInCircleList.count : {MonsterInCircleList.Count}");

            MonsterInCircleList.Add(circleInMonsterIndex);
            Debug.Log($"{circleInMonsterIndex}번쨰 몬스터 범위안에 들어옴");

            //TODO : 커브 말고 그냥 dir 사용해서 중심으로 모아보자.

            if(circleInMonsterIndex == 0)
            {
                movePossible0 = true;
            }
            else if(circleInMonsterIndex == 1)
            {
                movePossible1 = true;
            }
            else if (circleInMonsterIndex == 2)
            {
                movePossible2 = true;
            }
            else if (circleInMonsterIndex == 3)
            {
                movePossible3 = true;
            }
            else if (circleInMonsterIndex == 4)
            {
                movePossible4 = true;
            }
        }
        yield return null;
    }
    IEnumerator CoDeleteSkill()
    {
        yield return new WaitForSeconds(7);

        Managers.Resource.Destroy(transform.gameObject);
    }

    //// 방어력 약화
    //public override void ProcessSkill(GameObject monsterObj)s
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