using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill703 : DefaultSkill
{
    public Vector3 Arrow;
    public Vector3 Monster;
    Vector3[] point = new Vector3[4];
    bool hit = false;

    [SerializeField] [Range(0, 1)] private float t = 0;
    [SerializeField] public float spd = 8;
    [SerializeField] public float posA = 0.55f;
    [SerializeField] public float posB = 0.45f;

    //public GameObject master;
    //public GameObject enemy;


    protected override void Init()
    {
        base.Init();

        _skillNum = 703;

        point[0] = Arrow; // P0
        point[1] = PointSetting(Arrow); // P1
        point[2] = PointSetting(Monster); // P2
        point[3] = Monster; // P3


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
        if (t > 1) return;
        if (hit) return;
        t += Time.deltaTime * spd;

        Debug.Log($"transform.position.y : {transform.position.y}");
        
        
        DrawTrajectory();

    }
    Vector3 PointSetting(Vector3 origin)
    {
        float x, z;

        if (origin.x < 0)
        {
            x = -posA * Mathf.Cos(UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad)
           + origin.x;
        }
        else
        {
            x = posA * Mathf.Cos(UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad)
           + origin.x;
        }

        if (origin.z < 0)
        {
            z = -posB * Mathf.Sin(UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad)
            + origin.z;
        }
        else
        {
            z = posB * Mathf.Sin(UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad)
            + origin.z;
        }
        //x = posA * Mathf.Cos(UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad)
        //    + origin.x;
        //z = posB * Mathf.Sin(UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad)
        //    + origin.z;

        //Debug.Log($"origin.x : {x}");
        //Debug.Log($"origin.y : {origin.y}");
        //Debug.Log($"origin.z : {z}");
        return new Vector3(x, origin.y, z);  
    }

    void DrawTrajectory()
    {
        float y = Arrow.y + (Monster - Arrow).normalized.y * t;
        //transform.position += new Vector3(0, y, 0);

        transform.position = new Vector3(
            FourPointBezier(point[0].x, point[1].x, point[2].x, point[3].x),
            y,
            FourPointBezier(point[0].z, point[1].z, point[2].z, point[3].z)
        );
    }

    private float FourPointBezier(float a, float b, float c, float d)
    {
        return Mathf.Pow((1 - t), 3) * a
            + Mathf.Pow((1 - t), 2) * 3 * t * b
            + Mathf.Pow(t, 2) * 3 * (1 - t) * c
            + Mathf.Pow(t, 3) * d;
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