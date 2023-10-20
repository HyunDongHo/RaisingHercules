using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill1010 : DefaultSkill
{

    public List<GameObject> MonsterList { get; set; }
    public Vector3 KnightInfo;
    public Vector3 TargetPos;
    public float angle;
    public int li;
    protected override void Init()
    {
        base.Init();

        _skillNum = 1010;
        transform.position = _ownerCc.transform.position + new Vector3(0, 1.5f, 0);

        if (li == 1)
        {
            float angle = Mathf.Atan2((TargetPos.x - KnightInfo.x), (TargetPos.z - KnightInfo.z)) * (360 / (Mathf.PI * 2));
            Debug.Log($"angle1 : {angle + 20}");
            transform.RotateAround(KnightInfo, Vector3.up, angle + 25);
        }
        else if (li == 0)
        {
            float angle = Mathf.Atan2((TargetPos.x - KnightInfo.x), (TargetPos.z - KnightInfo.z)) * (360 / (Mathf.PI * 2));
            Debug.Log($"angle : {angle}");
            transform.RotateAround(KnightInfo, Vector3.up, angle);
        }
        else if (li == 2)
        {
            float angle = Mathf.Atan2((TargetPos.x - KnightInfo.x), (TargetPos.z - KnightInfo.z)) * (360 / (Mathf.PI * 2));
            Debug.Log($"angle2 : {angle - 20}");  
            transform.RotateAround(KnightInfo, Vector3.up, angle - 25);
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
        //if(li == 1)
        //{  
        //    //TODO : 몬스터가 25도 이동 했을때의 position


        //}else if (li == 0)
        //{
        //    transform.LookAt(MonsterList[2].transform.position);
        //}
        //else if (li == 2)
        //{
        //    //TODO : 몬스터가 -25도 이동 했을때의 position

        //}

    }

    IEnumerator CoDeleteSkill()
    {
        yield return new WaitForSeconds(2);

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