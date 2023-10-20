using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Skill702 : DefaultSkill
{
    public float SetPositionX;
    public float SetPositionZ;
    public Vector3 KnightPos;
    public Vector3 TargetPos;
    public List<GameObject> MonsterList { get; set; }

    public Vector3 dir;
    public int li;
    public int lj;
    //float speed = 8.0f;
    public bool DirectionSettingDone = false;

    public Vector3 p1;
    public Vector3 p2;
    public Vector3 p3;
    public Vector3 p4;
    public Vector3 p5;

    [Range(0, 1)]  
    public float value;
    //public float nextValue;

    protected override void Init()
    {
        base.Init();
          
        _skillNum = 702;

        int MonPositionX = (int)(TargetPos.x);
        int MonPositionZ = (int)(TargetPos.z);

        if (li == 0) // Left 구 
        {
            if (TargetPos.x < 0 && TargetPos.z > 0)  // - + 
            {
                SetPositionX = -Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ); 
                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
            }
            else if (TargetPos.x > 0 && TargetPos.z < 0) // + - 
            {
                SetPositionX = Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);
                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
            }

            if (TargetPos.x > 0 && TargetPos.z > 0) // + + 
            {
                SetPositionX = -Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);
                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
            }
            else if (TargetPos.x < 0 && TargetPos.z < 0)// - - 
            {
                SetPositionX = Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);

                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
            }
            
            if (TargetPos.x == 0 && TargetPos.z > 0) // 0 +
            {
                transform.position = _ownerCc.transform.position + new Vector3(-2.0f, 3.5f, 0);
            }
            else if (TargetPos.x == 0 && TargetPos.z < 0) // 0 -
            {
                transform.position = _ownerCc.transform.position + new Vector3(2.0f, 3.5f, 0);
            }
            
            if (TargetPos.x > 0 && TargetPos.z == 0) // + 0
            {
                transform.position = _ownerCc.transform.position + new Vector3(0, 3.5f, 2.0f);
            }
            else if (TargetPos.x < 0 && TargetPos.z == 0) // - 0
            {
                transform.position = _ownerCc.transform.position + new Vector3(0, 3.5f, -2.0f);
            }
        }
        else if (li == 1) // Center 구
        {
            transform.position = _ownerCc.transform.position + new Vector3(0, 3.5f, 0);
        }
        else  // Right 구 
        {
            if (TargetPos.x < 0 && TargetPos.z > 0)  // - + 
            {
                SetPositionX = Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);
                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
            }
            else if (TargetPos.x > 0 && TargetPos.z < 0) // + - 
            {
                SetPositionX = -Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);
                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
            }

            if (TargetPos.x > 0 && TargetPos.z > 0) // + + 
            {
                SetPositionX = Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);
                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
            }
            else if (TargetPos.x < 0 && TargetPos.z < 0)// - - 
            {
                SetPositionX = -Mathf.Sqrt((4 * Mathf.Pow(MonPositionZ, 2)) / (Mathf.Pow(MonPositionX, 2) + Mathf.Pow(MonPositionZ, 2)));
                SetPositionZ = -(MonPositionX * SetPositionX / MonPositionZ);
                transform.position = _ownerCc.transform.position + new Vector3(SetPositionX, 3.5f, SetPositionZ);
            }
            
            if (TargetPos.x == 0 && TargetPos.z > 0) // 0 +
            {
                transform.position = _ownerCc.transform.position + new Vector3(2.0f, 3.5f, 0);
            }
            else if (TargetPos.x == 0 && TargetPos.z < 0) // 0 -
            {
                transform.position = _ownerCc.transform.position + new Vector3(-2.0f, 3.5f, 0);
            }

            
            if (TargetPos.x > 0 && TargetPos.z == 0) // + 0
            {
                Debug.Log("ssssss");
                transform.position = _ownerCc.transform.position + new Vector3(0, 3.5f, -2.0f);
            }
            else if (TargetPos.x < 0 && TargetPos.z == 0) // - 0
            {
                Debug.Log("ddddd");
                transform.position = _ownerCc.transform.position + new Vector3(0, 3.5f, 2.0f);
            }
        }

        dir = (TargetPos - transform.position).normalized;  
        dir.y += 0.1f;

        if (li == 0) // 왼쪽 
        {
            if(lj == 0)
            {           
                p1 = transform.position;
                p5 = TargetPos;

                Vector3 knight = new Vector3(KnightPos.x, 0, KnightPos.z);
                Vector3 p1_new = new Vector3(p1.x, 0, p1.z);
                Vector3 dir_knight_p1 = (p1_new - knight).normalized;
                p2 = new Vector3(p1.x + dir_knight_p1.x * 1.5f , p1.y, p1.z + dir_knight_p1.z * 1.5f);

                Vector3 RightSquarePosition = new Vector3(-transform.position.x, 0, -transform.position.z);
                Vector3 center_p1_p5 = new Vector3((p1.x + p5.x) / 2, 0, (p1.z + p5.z) / 2);
                Vector3 dir_right_center = (center_p1_p5 - RightSquarePosition).normalized;
                p3 = new Vector3(center_p1_p5.x + (dir_right_center.x) * 2.5f, p1.y - 1 * Mathf.Abs(p1.y - p5.y) / 3, center_p1_p5.z + (dir_right_center.z) * 4.0f) ;

                p4 = new Vector3(p5.x + dir_knight_p1.x * 1.5f, p1.y - 2 * Mathf.Abs(p1.y - p5.y) / 3, p5.z + dir_knight_p1.x * 1.5f);

                //GameObject sphere1 = Managers.Resource.Instantiate("Particles/Skill/Skill700_point2");
                //sphere1.transform.position = p2;
                //GameObject sphere2 = Managers.Resource.Instantiate("Particles/Skill/Skill700_point2");
                //sphere2.transform.position = p3;
                //GameObject sphere3 = Managers.Resource.Instantiate("Particles/Skill/Skill700_point2");
                //sphere3.transform.position = p4;
            }
            else if (lj == 1)
            {
                p1 = transform.position;
                p5 = TargetPos;

                Vector3 knight = new Vector3(KnightPos.x, 0, KnightPos.z);
                Vector3 p1_new = new Vector3(p1.x, 0, p1.z);
                Vector3 dir_knight_p1 = (p1_new - knight).normalized;
                p2 = new Vector3(p1.x + dir_knight_p1.x * 1.5f, p1.y, p1.z + dir_knight_p1.z * 1.5f);

                Vector3 RightSquarePosition = new Vector3(-transform.position.x, 0, -transform.position.z);
                Vector3 center_p1_p5 = new Vector3((p1.x + p5.x) / 2, 0, (p1.z + p5.z) / 2);
                Vector3 dir_right_center = (center_p1_p5 - RightSquarePosition).normalized;
                p3 = new Vector3(center_p1_p5.x + (dir_right_center.x) * 3.5f, p1.y + 1 * Mathf.Abs(p1.y - p5.y) /3 , center_p1_p5.z + (dir_right_center.z) * 3.5f);

                p4 = new Vector3(p5.x + dir_knight_p1.x * 1.5f, p1.y - 2 * Mathf.Abs(p1.y - p5.y) / 3, p5.z + dir_knight_p1.x * 1.5f);

                //GameObject sphere2 = Managers.Resource.Instantiate("Particles/Skill/Skill700_point2");
                //sphere2.transform.position = p3;
            }
            else
            {
                p1 = transform.position;
                p5 = TargetPos;

                Vector3 knight = new Vector3(KnightPos.x, 0, KnightPos.z);
                Vector3 p1_new = new Vector3(p1.x, 0, p1.z);
                Vector3 dir_knight_p1 = (p1_new - knight).normalized;
                p2 = new Vector3(p1.x + dir_knight_p1.x * 1.5f, p1.y, p1.z + dir_knight_p1.z * 1.5f);

                Vector3 RightSquarePosition = new Vector3(-transform.position.x, 0, -transform.position.z);
                Vector3 center_p1_p5 = new Vector3((p1.x + p5.x) / 2, 0, (p1.z + p5.z) / 2);
                Vector3 dir_right_center = (center_p1_p5 - RightSquarePosition).normalized;
                p3 = new Vector3(center_p1_p5.x + (dir_right_center.x) * 3.5f, p1.y - 1 * Mathf.Abs(p1.y - p5.y)/2, center_p1_p5.z + (dir_right_center.z) * 3.5f);

                p4 = new Vector3(p5.x + dir_knight_p1.x * 1.5f, p1.y - 2 * Mathf.Abs(p1.y - p5.y) / 3, p5.z + dir_knight_p1.x * 1.5f);

                //GameObject sphere2 = Managers.Resource.Instantiate("Particles/Skill/Skill700_point2");
                //sphere2.transform.position = p3;
            }
        }
        else if(li ==1) // 중간 
        {
            p1 = transform.position;
            p5 = TargetPos;

            Vector3 dir_p1_p5 = (p5 - p1).normalized;
            p2 = new Vector3(p1.x, p1.y, p1.z );

            Vector3 center_p1_p5 = new Vector3((p1.x + p5.x) / 2, 0, (p1.z + p5.z) / 2);
            p3 = new Vector3(center_p1_p5.x , p1.y + 1 * Mathf.Abs(p1.y - p5.y) , center_p1_p5.z);

            Vector3 dir_p5_p1 = (p1 - p5).normalized;
            p4 = new Vector3(p5.x, p1.y - 2 * Mathf.Abs(p1.y - p5.y) / 3, p5.z );

        }
        else if (li == 2) // 오른쪽 
        {
            if (lj == 0)
            {
                p1 = transform.position;
                p5 = TargetPos;

                Vector3 knight = new Vector3(KnightPos.x, 0, KnightPos.z);
                Vector3 p1_new = new Vector3(p1.x, 0, p1.z);
                Vector3 dir_knight_p1 = (p1_new - knight).normalized;
                p2 = new Vector3(p1.x + dir_knight_p1.x * 1.5f, p1.y, p1.z + dir_knight_p1.z * 1.5f);

                Vector3 LeftSquarePosition = new Vector3(-transform.position.x, 0, -transform.position.z);
                Vector3 center_p1_p5 = new Vector3((p1.x + p5.x) / 2, 0, (p1.z + p5.z) / 2);
                Vector3 dir_left_center = (center_p1_p5 - LeftSquarePosition).normalized;
                p3 = new Vector3(center_p1_p5.x + (dir_left_center.x) * 4.0f, p1.y - 1 * Mathf.Abs(p1.y - p5.y) / 3, center_p1_p5.z + (dir_left_center.z) * 4.0f);
                p4 = new Vector3(p5.x + dir_knight_p1.x * 1.5f, p1.y - 2 * Mathf.Abs(p1.y - p5.y) / 3, p5.z + dir_knight_p1.x * 1.5f);

                //GameObject sphere1 = Managers.Resource.Instantiate("Particles/Skill/Skill700_point2");
                //sphere1.transform.position = p2;
                //GameObject sphere2 = Managers.Resource.Instantiate("Particles/Skill/Skill700_point2");
                //sphere2.transform.position = p3;
                //GameObject sphere3 = Managers.Resource.Instantiate("Particles/Skill/Skill700_point2");
                //sphere3.transform.position = p4;
            }
            else if (lj == 1)
            {
                p1 = transform.position;
                p5 = TargetPos;

                Vector3 knight = new Vector3(KnightPos.x, 0, KnightPos.z);
                Vector3 p1_new = new Vector3(p1.x, 0, p1.z);
                Vector3 dir_knight_p1 = (p1_new - knight).normalized;
                p2 = new Vector3(p1.x + dir_knight_p1.x * 1.5f, p1.y, p1.z + dir_knight_p1.z * 1.5f);

                Vector3 LeftSquarePosition = new Vector3(-transform.position.x, 0, -transform.position.z);
                Vector3 center_p1_p5 = new Vector3((p1.x + p5.x) / 2, 0, (p1.z + p5.z) / 2);
                Vector3 dir_left_center = (center_p1_p5 - LeftSquarePosition).normalized;
                p3 = new Vector3(center_p1_p5.x + (dir_left_center.x) * 3.5f, p1.y + 1 * Mathf.Abs(p1.y - p5.y)/3 , center_p1_p5.z + (dir_left_center.z) * 3.5f);
                p4 = new Vector3(p5.x + dir_knight_p1.x * 1.5f, p1.y - 2 * Mathf.Abs(p1.y - p5.y) / 3, p5.z + dir_knight_p1.x * 1.5f);

                //GameObject sphere2 = Managers.Resource.Instantiate("Particles/Skill/Skill700_point2");
                //sphere2.transform.position = p3;
            }
            else if(lj==2)
            {
                p1 = transform.position;
                p5 = TargetPos;
                Vector3 knight = new Vector3(KnightPos.x, 0, KnightPos.z);
                Vector3 p1_new = new Vector3(p1.x, 0, p1.z);
                Vector3 dir_knight_p1 = (p1_new - knight).normalized;
                p2 = new Vector3(p1.x + dir_knight_p1.x * 1.5f, p1.y, p1.z + dir_knight_p1.z * 1.5f);

                Vector3 LeftSquarePosition = new Vector3(-transform.position.x, 0, -transform.position.z);
                Vector3 center_p1_p5 = new Vector3((p1.x + p5.x) / 2, 0, (p1.z + p5.z) / 2);
                Vector3 dir_left_center = (center_p1_p5 - LeftSquarePosition).normalized;
                p3 = new Vector3(center_p1_p5.x + (dir_left_center.x) * 2.5f, p1.y - 1 * Mathf.Abs(p1.y - p5.y)/2, center_p1_p5.z + (dir_left_center.z) * 2.5f);
                p4 = new Vector3(p5.x + dir_knight_p1.x * 1.5f, p1.y - 2 * Mathf.Abs(p1.y - p5.y) / 3, p5.z + dir_knight_p1.x * 1.5f);

                //GameObject sphere2 = Managers.Resource.Instantiate("Particles/Skill/Skill700_point2");
                //sphere2.transform.position = p3;

            }
        }
        StartCoroutine(RelaxTime());
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

    IEnumerator CoDirectionSetting()
    {
        Debug.Log($"LI : {li}");


        dir = new Vector3(dir.x, dir.y, dir.z).normalized;
        transform.LookAt(transform.position + dir);

        DirectionSettingDone = true;


        yield return null;

    }

    // 슛
    public void Shoot()
    {
            
        if (li == 0 && (lj==0 || lj==1 || lj==2))
        {
            // TODO : 커브로 날라가는 버전            
            value += 0.045f;  // speed
            if (value > 1.0f)
            {
                Managers.Resource.Destroy(transform.gameObject);
                GameObject Hit = Managers.Resource.Instantiate("Particles/Skill/Skill700_hit5");
                Hit.transform.position = transform.position + new Vector3(0, 1f, 0);
                return;
            }

            transform.LookAt(BezierTest2(p1, p2, p3, p4,p5, value + 0.00001f));  
            transform.position = BezierTest2(p1, p2, p3, p4,p5, value);
        }
        else if (li == 1)
        {

            // TODO : VER 1.직선으로 날라가는 버전
            //Vector3 addPosition = dir * Time.deltaTime * speed;
            //transform.position += addPosition;

            //TODO : 
            // TODO : 커브로 날라가는 버전 
            value += 0.045f;
            if (value > 1.0f)
            {
                Managers.Resource.Destroy(transform.gameObject);
                GameObject Hit = Managers.Resource.Instantiate("Particles/Skill/Skill700_hit5");
                Hit.transform.position = transform.position + new Vector3(0, 1f, 0); 
                return;
            }

            transform.LookAt(BezierTest2(p1, p2, p3, p4, p5, value + 0.00001f));
            transform.position = BezierTest2(p1, p2, p3, p4, p5, value);

        }
        else if(li == 2 && (lj == 0 || lj == 1 || lj == 2))
        {
            // TODO : 커브로 날라가는 버전 
            value += 0.045f;
            if (value > 1.0f)
            {
                Managers.Resource.Destroy(transform.gameObject);
                GameObject Hit = Managers.Resource.Instantiate("Particles/Skill/Skill700_hit5");
                Hit.transform.position = transform.position + new Vector3(0, 1f, 0); 
                return;
            }

            transform.LookAt(BezierTest2(p1, p2, p3, p4, p5, value + 0.00001f));
            transform.position = BezierTest2(p1, p2, p3, p4, p5, value);

        }

        DirectionSettingDone = false;
    }

    public Vector3 BezierTest(Vector3 p_1, Vector3 p_2, Vector3 p_3, Vector3 p_4, float value)
    {
        //p1
        Vector3 A = Vector3.Lerp(p_1, p_2, value);
        Vector3 B = Vector3.Lerp(p_2, p_3, value);
        Vector3 C = Vector3.Lerp(p_3, p_4, value);

        Vector3 D = Vector3.Lerp(A, B, value);
        Vector3 E = Vector3.Lerp(B, C, value);

        Vector3 F = Vector3.Lerp(D, E, value);

        return F;  
    }
    public Vector3 BezierTest2(Vector3 p_1, Vector3 p_2, Vector3 p_3, Vector3 p_4, Vector3 p_5 , float value)
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


    IEnumerator RelaxTime()
    {
        yield return new WaitForSeconds(3);
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