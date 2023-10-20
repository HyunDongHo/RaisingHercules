using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill300 : DefaultSkill
{


    //protected 
    public List<GameObject> MonsterList { get; set; }
    public List<int> MonsterIndex = new List<int>();
    int mi = 0;
    int FirstMonsterIndex = 0;
    bool AttackDone = false;
    protected override void Init()
    {
        base.Init();

        _skillNum = 300;
        transform.position = _ownerCc.transform.position + new Vector3(0, 0.1f, 0);

        StartCoroutine(CoDeleteSkill()); // 15초 뒤 제거 
        FirstMonsterIndex = FindFirstMonsterIndex(); // 첫번째로 이동할 몬스터 인덱스 찾기
        MonsterIndex.Add(FirstMonsterIndex);
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
        //transform.position = _ownerCc.transform.position + new Vector3(0, 0.1f, 0);

        // 다음 몬스터 찾기 
        if (AttackDone == true)
        {
            StartCoroutine(CoStartFindNextMonsterIndex()); // 다음 몬스터 인덱스 찾기
        }
        // 이동
        MoveToMonster(MonsterIndex[mi]);
    }

    IEnumerator CoDeleteSkill()
    {
        yield return new WaitForSeconds(15);

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
    IEnumerator CoStartFindNextMonsterIndex()
    {
        int index = FindMonsterIndex();
        MonsterIndex.Add(index);
        mi++;
        Debug.Log($"mi : {mi}");
        Debug.Log($"next monster index : {index}");

        yield return null;
    }
    public int FindFirstMonsterIndex()
    {
        int start_index = 0;
        float min_distance = 100.0f;
       
        for (int i = 0; i < MonsterList.Count; i++) // 최소 거리 찾고 
        {
            float j = (MonsterList[i].transform.position - transform.position).magnitude;
            if (min_distance > j)
            {
                min_distance = j;
            }
        }
        for (int i = 0; i < MonsterList.Count; i++) // 최소거리인 MonsterList index 찾고 
        {
            if ((MonsterList[i].transform.position - transform.position).magnitude == min_distance)
            {
                start_index = i;
            }
        }
        
        return start_index;
    }
    public int FindMonsterIndex()
    {
        int start_index = 0;
        float min_distance = 100.0f;

        for (int i = 0; i < MonsterList.Count; i++) // 최소 거리 찾고 
        {
            if (i == MonsterIndex[mi])
                continue;
            float j = (MonsterList[i].transform.position - transform.position).magnitude;
            if (min_distance > j)
            {
                min_distance = j;
            }
        }
        for (int i = 0; i < MonsterList.Count; i++) // 최소거리인 MonsterList index 찾고 
        {
            if (i == MonsterIndex[mi])
                continue;
            if ((MonsterList[i].transform.position - transform.position).magnitude == min_distance)
            {
                start_index = i;
            }
        }

        AttackDone = false;
        return start_index;
    }

    public void MoveToMonster(int index)
    {
        float speed = 0.0f;
        if (gameObject.name == "KnightSkill300")// 이펙트명 : KnightSkill300 : 회오리 
        {
            speed = 10.0f;
        }
        else if(gameObject.name == "KnightSkill301")// 이펙트명 : KnightSkill301 : 해골
        {
            speed = 8.0f;
        }
        
        Vector3 vel = Vector3.zero;
        transform.LookAt(MonsterList[index].transform);
        // [1. 첫번째 버전 : 느리게 나가는 버전 ]
        //transform.position = Vector3.Lerp(transform.position, MonsterList[index].transform.position, 0.08f);
        // [2. 두번째 버전 : 등속으로 나가는 버전 ]
        transform.position = Vector3.MoveTowards(transform.position, MonsterList[index].transform.position,
                                                speed * Time.deltaTime);
        if ((transform.position - MonsterList[index].transform.position).magnitude < 0.4f)
        {
            AttackDone = true;
        }
    }

}