using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill501_ProjectileController : DefaultSkill
{
    public List<GameObject> MonsterList { get; set; }

    //protected 
    // 8방향 : 기준점에서 x,z 8방향 direction 증감
    public List<float> EightDirectionX = new List<float>() { 0, 1, 1, 1, 0, -1, -1, -1 };
    public List<float> EightDirectionZ = new List<float>() { 1, 1, 0, -1, -1, -1, 0, 1 };
    // 12방향 : 기준점에서 x,z방향 direction 증감 
    public List<float> DirectionX = new List<float>() { Mathf.Cos(90 * Mathf.Deg2Rad), Mathf.Cos(60 * Mathf.Deg2Rad), Mathf.Cos(30 * Mathf.Deg2Rad),Mathf.Cos(0 * Mathf.Deg2Rad),
            Mathf.Cos(330 * Mathf.Deg2Rad),  Mathf.Cos(300 * Mathf.Deg2Rad), Mathf.Cos(270 * Mathf.Deg2Rad),  Mathf.Cos(240 * Mathf.Deg2Rad), 
            Mathf.Cos(210 * Mathf.Deg2Rad),  Mathf.Cos(180 * Mathf.Deg2Rad), Mathf.Cos(150 * Mathf.Deg2Rad), Mathf.Cos(120 * Mathf.Deg2Rad) };
    public List<float> DirectionZ = new List<float>() { Mathf.Sin(90 * Mathf.Deg2Rad), Mathf.Sin(60 * Mathf.Deg2Rad), Mathf.Sin(30 * Mathf.Deg2Rad),Mathf.Sin(0 * Mathf.Deg2Rad),
            Mathf.Sin(330 * Mathf.Deg2Rad),  Mathf.Sin(300 * Mathf.Deg2Rad), Mathf.Sin(270 * Mathf.Deg2Rad),  Mathf.Sin(240 * Mathf.Deg2Rad),
            Mathf.Sin(210 * Mathf.Deg2Rad),  Mathf.Sin(180 * Mathf.Deg2Rad), Mathf.Sin(150 * Mathf.Deg2Rad), Mathf.Sin(120 * Mathf.Deg2Rad) };
    public List<float> Speed = new List<float>() { 2, 4, 6, 8, 9, 10, 12, 10, 8, 6, 4, 2};

    public Vector3 dir;
    public int li ;    
    float speed = 8.0f;
    public bool DirectionSettingDone = false;
    public int min_distance_index;
    protected override void Init()
    {
        base.Init();

        _skillNum = 501;

        dir = new Vector3(DirectionX[li], 0, DirectionZ[li]).normalized;
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
        if(DirectionSettingDone == false)
        {
            StartCoroutine(CoDirectionSetting());
        }  
        //슛
        Shoot();   

        
    }
    
    // 슛
    public void Shoot()
    {
        Vector3 addPosition = dir * Time.deltaTime * speed ;
        transform.position += addPosition;

        for (int i = 0; i < MonsterList.Count; i++)
        {
            if (i == min_distance_index)
                continue;
            if ((transform.position - MonsterList[i].transform.position).magnitude < 0.3f)
            {
                Debug.Log($"{i}번째 몬스터 HIT~!!!!!!!!");
                StartCoroutine(CoDirection_8(i));
            }
        }

        DirectionSettingDone = false;
    }
    IEnumerator CoDirectionSetting()
    {
        Debug.Log($"LI : {li}");
        
        dir = new Vector3(DirectionX[li], 0, DirectionZ[li]).normalized;
        transform.LookAt(transform.position + dir);
        DirectionSettingDone = true;

        yield return null;
        //yield return null;

    }

    IEnumerator CoDirection_8(int j)
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject go = Managers.Resource.Instantiate("Particles/Skill/Skill502_Projectile");
            Skill502_ProjectileController skill502 = go.GetComponent<Skill502_ProjectileController>();
            skill502.li = i;
            skill502.min_distance_index = min_distance_index; // 처음 맞은 몬스터 인덱스 
            skill502.MonsterList = MonsterList;
            skill502.LastMonsterIndex = j;      // 지금 맞은 몬스터 인덱스
            //go.transform.position = MonsterList[j].transform.position;
            go.transform.position = transform.position;

        }
        yield return new WaitForSeconds(0.5f);
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