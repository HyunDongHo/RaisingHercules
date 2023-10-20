using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill940 : DefaultSkill
{

    public List<GameObject> MonsterList { get; set; }
    public Vector3 KnightInfo;
    public Vector3 TargetPos;

    public Vector3 p1;
    public Vector3 p2;
    public Vector3 p3;
    public Vector3 p4;
    public Vector3 p5;

    [Range(0, 1)]
    public float value;
    protected override void Init()
    {
        base.Init();

        _skillNum = 940;
        transform.position = _ownerCc.transform.position + new Vector3(0, 2.5f, 0);


        p1 = transform.position;
        p5 = TargetPos;

        p2 = new Vector3(p1.x, p1.y, p1.z);

        Vector3 center_p1_p5 = new Vector3((p1.x + p5.x) / 2, 0, (p1.z + p5.z) / 2);
        p3 = new Vector3(center_p1_p5.x, p1.y + 1 * Mathf.Abs(p1.y - p5.y), center_p1_p5.z);
        p4 = new Vector3(p5.x, p1.y - 2 * Mathf.Abs(p1.y - p5.y) / 3, p5.z);



        //float angle = Mathf.Atan2((TargetPos.x - KnightInfo.x), (TargetPos.z - KnightInfo.z)) * (360 / (Mathf.PI * 2));
        //Debug.Log($"angle : {angle}");
        //transform.RotateAround(KnightInfo, Vector3.up, angle);
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
        shooting();
    }

    public void shooting()
    {
        value += 0.045f;
        if (value > 0.95f)
        {
            //Managers.Resource.Destroy(transform.gameObject);

            GameObject fire = Managers.Resource.Instantiate("Particles/Skill/Skill941");
            Skill941 skill941 = fire.GetComponent<Skill941>();
            skill941.MonsterList = MonsterList;
            skill941.KnightInfo = transform.position;
            skill941.TargetPos = MonsterList[2].transform.position;
            skill941.transform.position = transform.position;
            return;
        }

        transform.LookAt(BezierTest2(p1, p2, p3, p4, p5, value + 0.00001f));
        transform.position = BezierTest2(p1, p2, p3, p4, p5, value);
    }

    public Vector3 BezierTest2(Vector3 p_1, Vector3 p_2, Vector3 p_3, Vector3 p_4, Vector3 p_5, float value)
    {
        //p1
        Vector3 A = Vector3.Lerp(p_1, p_2, value);
        Vector3 B = Vector3.Lerp(p_2, p_3, value);
        Vector3 C = Vector3.Lerp(p_3, p_4, value);
        Vector3 D = Vector3.Lerp(p_4, p_5, value);

        Vector3 E = Vector3.Lerp(A, B, value);
        Vector3 F = Vector3.Lerp(B, C, value);
        Vector3 G = Vector3.Lerp(C, D, value);
        Vector3 H = Vector3.Lerp(E, F, value);
        Vector3 I = Vector3.Lerp(F, G, value);

        Vector3 J = Vector3.Lerp(H, I, value);

        return J;
    }
    IEnumerator CoDeleteSkill()
    {
        yield return new WaitForSeconds(3);

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