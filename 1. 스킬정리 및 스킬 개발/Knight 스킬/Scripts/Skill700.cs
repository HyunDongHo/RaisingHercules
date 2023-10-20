using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill700 : DefaultSkill
{
    
    public List<GameObject> MonsterList { get; set; }
    public Vector3 KnightInfo;
    public Vector3 TargetPos;
    protected override void Init()
    {
        base.Init();

        _skillNum = 700;
        transform.position = _ownerCc.transform.position + new Vector3(0, 0, -0.2f);
        transform.LookAt(TargetPos);
        StartCoroutine(CoWings());
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
    IEnumerator CoWings()
    {
        yield return new WaitForSeconds(1.0f);
        Animator animator = gameObject.GetComponent<Animator>();
        if(animator == null)
        {
            Debug.Log("animator 없땅~");
        }
        else
        {
            animator.Play("SKILL100");
        }

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