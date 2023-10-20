using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill503_ProjectileController : DefaultSkill
{
    public List<GameObject> MonsterList { get; set; }

    //protected 
    // 4방향 : 기준점에서 x,z 4방향 direction 증감
    public List<float> FourDirectionX = new List<float>() { 0, 1, 0, -1 };
    public List<float> FourDirectionZ = new List<float>() { 1, 0, -1, 0 };

    public Vector3 dir;
    public int li;
    float speed = 8.0f;
    public bool DirectionSettingDone = false;
    public int min_distance_index;
    public int LastMonsterIndex;
    protected override void Init()
    {
        base.Init();

        _skillNum = 501;

        dir = new Vector3(FourDirectionX[li], 0, FourDirectionZ[li]).normalized;
        //transform.position = _ownerCc.transform.position + new Vector3(0, 0.1f, 0);

        StartCoroutine(CoDeleteSkill()); // 15초 뒤 제거 
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
        if (DirectionSettingDone == false)
        {
            StartCoroutine(CoDirectionSetting());
        }
        //슛
        Shoot();


    }

    // 슛
    public void Shoot()
    {
        Vector3 addPosition = dir * Time.deltaTime * speed;
        transform.position += addPosition;
        DirectionSettingDone = false;
    }
    IEnumerator CoDirectionSetting()
    {
        Debug.Log($"LI : {li}");

        dir = new Vector3(FourDirectionX[li], 0, FourDirectionZ[li]).normalized;
        transform.LookAt(transform.position + dir);
        DirectionSettingDone = true;

        yield return null;
        //yield return null;

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