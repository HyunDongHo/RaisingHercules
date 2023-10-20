using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Skill200_ProjectileController : BaseController
{
    [SerializeField]
    public float MoveSpeed { get; set; } = 8f;

    public float AttackLength { get; set; }

    public float Damage { get; set; }
    public Vector3 Dir;

    public GameObject Owner { get; set; }
    public GameObject Target { get; set; }

    public bool IsPierce = false;

    protected Action<Vector3> _triggerEnterAction = null;
    protected Action<GameObject, Vector3> _triggerEnterActionByGameObject = null;

    public bool IsPlayerTarget = false;
    public Define.ProjectileType ProjectileType { get; set; } = Define.ProjectileType.Attack;

    [SerializeField]
    public ParticleSystem hitParticle;

    [SerializeField]
    Collider Collider;

    bool IsInit = false;

    /* TODO : 3D 포물선 운동하게 만들기 (변수 선언)*/
    public Transform Projectile;   // 포물체
    public float tx;
    public float ty;
    public float tz;
    public float v;
    public float g = 9.8f;
    public float elapsed_time;
    public float max_height;
    public float t;
    public Vector3 start_pos;
    public Vector3 end_pos;
    public float start_pos_dx; // target 까지의 xz 평면상의 직선 거리에서의 미소한 x 
    public float start_pos_dz;  // target 까지의 xz 평면상의 직선 거리에서의 미소한 z
    public float dat;  //도착점 도달 시간 

    protected override void Init()
    {
        InitStat();
        //StartCoroutine(CoDeleteSkill()); //지정한 초뒤에 destroy
    }

    private void OnDisable()
    {
        IsInit = false;
        if(Collider != null)
            Collider.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (gameObject.GetComponentInParent<Poolable>() == false)
            return;

        InitStat();
    }

    private void InitStat()
    {
        State = Define.State.Moving;
        gameObject.transform.position = new Vector3(_InitPosition.x, _InitPosition.y, _InitPosition.z);

        //gameObject.transform.LookAt(Dir);
        ObjectType = Define.ObejctType.Projectile;
        //Dir = Target.transform.position - _InitPosition;
        ParticleSystem ps = gameObject.GetComponentInChildren<ParticleSystem>();
        Dir = Dir.normalized;
        ps.Play();
        IsInit = true;
        if (Collider != null)
            Collider.gameObject.SetActive(true);

        //transform.gameObject.GetComponentInParent<Poolable>().IsInit = true;
        Poolable p = transform.gameObject.GetComponentInParent<Poolable>();
        if (p != null)
        {
            p.IsInit = true;
        }

        /* TODO : 3D 포물선 운동하게 만들기*/
        Projectile = gameObject.transform;
        if (Projectile != null)
        {
            Projectile.position = _InitPosition + new Vector3(0, 0.0f, 0);
            //transform.position = _InitPosition;
            //Debug.Log($"Projectile.position.y :  {Projectile.position.y}");
        }

        //float maxHeight = Projectile.transform.position.y;
        //Debug.Log($"maxHeight : {maxHeight}");
        //Shoot(Transform bullet, Vector3 startPos, Vector3 endPos, float g, float max_height) // 함수 선언부 
        Shoot(Projectile, Projectile.position, Target.transform.position, g, 4.0f);

    }

    protected override void UpdateMoving()
    {
        if (IsInit == false)
            return;

        if ((transform.position - _InitPosition).magnitude >= AttackLength)
        {
            Managers.Resource.Destroy(transform.gameObject);
            return;
        }

        //hitParticle.transform.rotation.eulerAngles = 
        //gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(Dir.x, 0, Dir.z));
        //Vector3 addPosition = new Vector3(Dir.normalized.x, Dir.normalized.y, Dir.normalized.z) * Time.deltaTime * MoveSpeed;
        //transform.position += addPosition;
    }

    /* TODO : 3D 포물선 운동하게 만들기*/
    public void Shoot(Transform Pj, Vector3 startPos, Vector3 endPos, float gravity, float maxheight)
    {

        //Debug.Log($"target.x : {endPos.x}");
        //Debug.Log($"target.y : {endPos.y}");
        //Debug.Log($"target.z : {endPos.z}");

        start_pos = startPos;
        end_pos = endPos;

        g = gravity;
        max_height = maxheight;

        float dh = endPos.y - startPos.y;
        float mh = Mathf.Abs(maxheight - startPos.y);

        ty = Mathf.Sqrt(2 * g * mh);

        float a = g;
        float b = -2 * ty;
        float c = 2 * dh;

        //dat = (-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a) + 4.0f;
        dat = (-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);

        tx = -(startPos.x - endPos.x) / dat;
        tz = -(startPos.z - endPos.z) / dat;

        /* 포물선 쏠 때 시작위치 지정 */
        if (Mathf.Abs(endPos.x) < 10.0f && Mathf.Abs(endPos.y)<10.0f) // target의 x,y 좌표가 10m 보다 작으면
        {
            start_pos_dx = (endPos.x / 10);
            start_pos_dz = (tz / tx) * start_pos_dx;
        }
        else
        {
            //StartCoroutine(CoDeleteSkill());
            return;
        }

        elapsed_time = 0;

        StartCoroutine(ShootImpl());
    }

    IEnumerator ShootImpl()
    {
        while (true)
        {
            elapsed_time += Time.deltaTime;

            tx = start_pos_dx + (tx * elapsed_time);  
            ty = start_pos.y + ty * elapsed_time - 0.5f * g * elapsed_time * elapsed_time;
            tz = start_pos_dz + (tz * elapsed_time);

            Vector3 tpos = new Vector3(tx, ty, tz);

            //Projectile.transform.rotation = Quaternion.LookRotation(Target.transform.position - Projectile.transform.position);
            Projectile.transform.LookAt(tpos);
            Projectile.transform.position = tpos;

            if (elapsed_time >= dat) // elapsed_time >= dat
            {
                Debug.Log($"attack");
                /* TODO: projectile destroy 후 맞는 effect 적용*/
                StartCoroutine(CoDeleteSkill());
                GameObject go = Managers.Resource.Instantiate("Particles/Skill/Skill200_end3");
                if (go != null)
                {
                    Debug.Log("effect end !!");
                }
                go.transform.position = Target.transform.position;
                break;
            }


            yield return null;
        }

        //onComplete();
    }

    public void SetTarget(GameObject target)
    {
        Target = target;
    }

    public void SetOwner(GameObject owner)
    {
        Owner = owner;
    }


    public void TriggerEnterActionInvoke(Vector3 eventPosition)
    {
        if (_triggerEnterAction != null)
            _triggerEnterAction.Invoke(eventPosition);
    }

    public void TriggerEnterActionByGameObjectInvoke(GameObject go, Vector3 eventPosition)
    {
        if (_triggerEnterActionByGameObject != null)
            _triggerEnterActionByGameObject.Invoke(go, eventPosition);
    }

    IEnumerator CoDeleteSkill()
    {
        yield return null;
        Managers.Resource.Destroy(transform.gameObject);
    }
}

