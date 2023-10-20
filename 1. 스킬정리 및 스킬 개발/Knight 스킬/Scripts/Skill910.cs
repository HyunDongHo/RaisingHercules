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
        
        if(findMonsterDone == false) // ������ ���� Ȯ�� 
        {
            StartCoroutine(FindMonsterInCircle());  
        }

        if (movePossible0 == true) // �̵� ���� �ϴٸ� 
        {
            Debug.Log("0�� ���� �̵���");           
            MoveMonsterPosition(0);
        }
        if (movePossible1 == true) // �̵� ���� �ϴٸ� 
        {
            Debug.Log("1�� ���� �̵���");
            MoveMonsterPosition(1);
        }
        if (movePossible2 == true) // �̵� ���� �ϴٸ� 
        {
            Debug.Log("2�� ���� �̵���");
            MoveMonsterPosition(2);
        }
        if (movePossible3 == true) // �̵� ���� �ϴٸ� 
        {
            Debug.Log("3�� ���� �̵���");
            MoveMonsterPosition(3);
        }
        if (movePossible4 == true) // �̵� ���� �ϴٸ� 
        {
            Debug.Log("4�� ���� �̵���");
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

    IEnumerator FindMonsterInCircle() // �� �ȿ� ���� ã�� 
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

    IEnumerator FindStandardP2(int circleInMonsterIndex) // ������ �Ǵ� p2�� ã��  
    {
        
        countMonsterIndex[circleInMonsterIndex] += 1; // ī��Ʈ �� 
        
        if(countMonsterIndex[circleInMonsterIndex] < 2)
        {
            Debug.Log($"MonsterInCircleList.count : {MonsterInCircleList.Count}");

            MonsterInCircleList.Add(circleInMonsterIndex);
            Debug.Log($"{circleInMonsterIndex}���� ���� �����ȿ� ����");

            //TODO : Ŀ�� ���� �׳� dir ����ؼ� �߽����� ��ƺ���.

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

    //// ���� ��ȭ
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