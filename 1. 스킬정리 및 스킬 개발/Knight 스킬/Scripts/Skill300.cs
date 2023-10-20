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

        StartCoroutine(CoDeleteSkill()); // 15�� �� ���� 
        FirstMonsterIndex = FindFirstMonsterIndex(); // ù��°�� �̵��� ���� �ε��� ã��
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

        // ���� ���� ã�� 
        if (AttackDone == true)
        {
            StartCoroutine(CoStartFindNextMonsterIndex()); // ���� ���� �ε��� ã��
        }
        // �̵�
        MoveToMonster(MonsterIndex[mi]);
    }

    IEnumerator CoDeleteSkill()
    {
        yield return new WaitForSeconds(15);

        Managers.Resource.Destroy(transform.gameObject);
    }

    //// ���� ��ȭ
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
       
        for (int i = 0; i < MonsterList.Count; i++) // �ּ� �Ÿ� ã�� 
        {
            float j = (MonsterList[i].transform.position - transform.position).magnitude;
            if (min_distance > j)
            {
                min_distance = j;
            }
        }
        for (int i = 0; i < MonsterList.Count; i++) // �ּҰŸ��� MonsterList index ã�� 
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

        for (int i = 0; i < MonsterList.Count; i++) // �ּ� �Ÿ� ã�� 
        {
            if (i == MonsterIndex[mi])
                continue;
            float j = (MonsterList[i].transform.position - transform.position).magnitude;
            if (min_distance > j)
            {
                min_distance = j;
            }
        }
        for (int i = 0; i < MonsterList.Count; i++) // �ּҰŸ��� MonsterList index ã�� 
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
        if (gameObject.name == "KnightSkill300")// ����Ʈ�� : KnightSkill300 : ȸ���� 
        {
            speed = 10.0f;
        }
        else if(gameObject.name == "KnightSkill301")// ����Ʈ�� : KnightSkill301 : �ذ�
        {
            speed = 8.0f;
        }
        
        Vector3 vel = Vector3.zero;
        transform.LookAt(MonsterList[index].transform);
        // [1. ù��° ���� : ������ ������ ���� ]
        //transform.position = Vector3.Lerp(transform.position, MonsterList[index].transform.position, 0.08f);
        // [2. �ι�° ���� : ������� ������ ���� ]
        transform.position = Vector3.MoveTowards(transform.position, MonsterList[index].transform.position,
                                                speed * Time.deltaTime);
        if ((transform.position - MonsterList[index].transform.position).magnitude < 0.4f)
        {
            AttackDone = true;
        }
    }

}