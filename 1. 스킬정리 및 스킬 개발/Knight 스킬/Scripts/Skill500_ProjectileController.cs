using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Skill500_ProjectileController : BaseController
{
    [SerializeField]
    public float MoveSpeed { get; set; } = 14.0f;

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

    public List<GameObject> AllMonsterList;
    public int min_distance_index;
    protected override void Init()
    {
        InitStat();
        //StartCoroutine(CoDeleteSkill()); //지정한 초뒤에 destroy
    }

    private void OnDisable()
    {
        IsInit = false;
        if (Collider != null)
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
        Dir = (Target.transform.position + new Vector3(0,0.4f,0) - gameObject.transform.position).normalized;

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

        //TODO : 12방향으로 나가는 화살
        if ((transform.position - Target.transform.position).magnitude < 0.40f)
        {
            StartCoroutine(CoDirection_12());
            Debug.Log($"sssss");
        }

        gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(Dir.x, Dir.y, Dir.z));
        Vector3 addPosition = new Vector3(Dir.normalized.x, Dir.normalized.y, Dir.normalized.z) * Time.deltaTime * MoveSpeed ;
        transform.position += addPosition;

        
    }
    IEnumerator CoDirection_12()    
    {
        for (int i = 0; i < 12; i++)      
        {
            GameObject go = Managers.Resource.Instantiate("Particles/Skill/Skill501_Projectile");
            Skill501_ProjectileController skill501 = go.GetComponent<Skill501_ProjectileController>();
            skill501.li = i;
            skill501.min_distance_index = min_distance_index;
            skill501.MonsterList = AllMonsterList;
            go.transform.position = transform.position;
            StartCoroutine(CoShootSetting());
        }
        yield return new WaitForSeconds(0.2f);
    }
    IEnumerator CoShootSetting()
    {
        yield return new WaitForSeconds(0.5f);
        //yield return null;
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

