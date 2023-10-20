using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill500 : DefaultSkill
{
    float floatingLen = 3;
    float createTime = 0.5f;
    float TotalCreateTime = 1.0f;
    bool _isFloating = false;

    public List<GameObject> MonsterList { get; set; }
    protected override void Init()
    {
        base.Init();

        _skillNum = 500;
        transform.position = _ownerCc.transform.position + new Vector3(0, 1f, 0);

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
        //transform.position = _ownerCc.transform.position + new Vector3(0, 0.1f, 0);

        if (_isFloating == false)
        {
            Vector3 len = Vector3.up * Time.deltaTime * 3;
            transform.position += len;

            floatingLen -= len.magnitude;

            if (floatingLen <= 0)
            {
                _isFloating = true;
                StartCoroutine(CoCreateProjectile());
            }
        }

    }

    IEnumerator CoCreateProjectile()
    {
        yield return new WaitForSeconds(0.5f);

        float accuTime = 0f;
        int index = 0;

        while (accuTime < TotalCreateTime)
        {
            int min_distance_index = FindFirstMonsterIndex();

            if (index < MonsterList.Count)
            {
                Debug.Log($"{index}번째 projectile !!!!");
                GameObject projObj = Managers.Resource.Instantiate("Particles/Skill/Skill500_Projectile");

                Skill500_ProjectileController projectile = projObj.GetComponent<Skill500_ProjectileController>();
                projectile.SetInitPos(transform.position);
                GameObject targetObj = MonsterList[min_distance_index];

                projectile.min_distance_index = min_distance_index;
                projectile.AllMonsterList = MonsterList;
                projectile.Target = targetObj;
                projectile.AttackLength = 20;
                yield return new WaitForSeconds(createTime);
                accuTime += createTime;
            }
            else
            {
                index = 0;
            }
        }
        //Debug.Log($"최종 index : {index}");
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