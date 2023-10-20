using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill941 : DefaultSkill
{

    public List<GameObject> MonsterList { get; set; }
    public Vector3 KnightInfo;
    public Vector3 TargetPos;
    protected override void Init()
    {
        base.Init();

        _skillNum = 941;
        //transform.position = _ownerCc.transform.position + new Vector3(0, 0, 0);
        //transform.position = TargetPos;
        
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
        transform.Rotate(Vector3.down * 540.0f * Time.deltaTime);  
        //StartCoroutine(rotate360());
    }

    IEnumerator rotate360()
    {
        for(int i = 0; i < 30; i++)
        {
            if (i == 29)
            {
                Managers.Resource.Destroy(transform.gameObject);
            }
            transform.Rotate(Vector3.down * Time.deltaTime * i * 10);
        }
        yield return null;
    }
    IEnumerator CoDeleteSkill()
    {
        yield return new WaitForSeconds(1);

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