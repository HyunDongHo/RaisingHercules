using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill950 : DefaultSkill
{

    public List<GameObject> MonsterList { get; set; }
    public Vector3 KnightInfo;
    public Vector3 TargetPos;
    public float angle;
    protected override void Init()
    {
        base.Init();

        _skillNum = 950;
        transform.position = _ownerCc.transform.position + new Vector3(0, 1.5f, 0);

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
        //angle = Mathf.Atan2((MonsterList[2].transform.position.x - KnightInfo.x), (MonsterList[2].transform.position.z - KnightInfo.z)) * (360 / (Mathf.PI * 2));
        //Debug.Log($"angle : {angle}");
        //transform.RotateAround(KnightInfo, Vector3.up, angle);
        transform.LookAt(MonsterList[2].transform.position);
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