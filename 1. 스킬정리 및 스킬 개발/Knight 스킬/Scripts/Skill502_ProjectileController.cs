using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill502_ProjectileController : DefaultSkill
{
    public List<GameObject> MonsterList { get; set; }

    //protected 
    // 8방향 : 기준점에서 x,z 8방향 direction 증감
    public List<float> EightDirectionX = new List<float>() { 0, 1, 1, 1, 0, -1, -1, -1 };
    public List<float> EightDirectionZ = new List<float>() { 1, 1, 0, -1, -1, -1, 0, 1 };

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

        dir = new Vector3(EightDirectionX[li], 0, EightDirectionZ[li]).normalized;
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

        for (int i = 0; i < MonsterList.Count; i++)
        {
            if (i == LastMonsterIndex)
                continue;
            if ((transform.position - MonsterList[i].transform.position).magnitude < 0.3f)
            {
                Debug.Log($"{i}번째 몬스터 HIT~!!!!!!!!");
                StartCoroutine(CoDirection_4(i));
            }
        }

        DirectionSettingDone = false;
    }
    IEnumerator CoDirectionSetting()
    {
        Debug.Log($"LI : {li}");

        dir = new Vector3(EightDirectionX[li], 0, EightDirectionZ[li]).normalized;
        transform.LookAt(transform.position + dir);
        DirectionSettingDone = true;

        yield return null;
        //yield return null;

    }

    IEnumerator CoDirection_4(int j)
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject go = Managers.Resource.Instantiate("Particles/Skill/Skill503_Projectile");
            Skill503_ProjectileController skill503 = go.GetComponent<Skill503_ProjectileController>();
            skill503.li = i;
            skill503.LastMonsterIndex = j;
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