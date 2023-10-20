using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill801_Controller : CreatureController
{
    CreatureController cc = null;
    Animator animator;

    [SerializeField]
    List<GameObject> monsterList;
    protected override void Init()
    {
        cc = gameObject.GetComponent<CreatureController>();
    }

    void Update()
    {

    }

    public void StartSkill800() // 애니메이션 재생 시 특정 event에서 StartSkill800 함수 실행 
    {
        Debug.Log("StartSkill800");

        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill800_hit2"); // 내려찍는 이팩트     
        Skill800_hit skill800 = gameObject.GetComponent<Skill800_hit>();
        skill800.SetOwnerPlayer(cc); // 붙이는 거 
        skill800.TargetPos = monsterList[2].transform.position;
        skill800.KnightInfo = transform.position;
        skill800.transform.position = transform.position;

    }
    public void StartSkill801() // 애니메이션 재생 시 특정 event에서 StartSkill801 함수 실행 
    {
        Debug.Log("StartSkill801");

        animator = gameObject.GetComponent<Animator>();
        animator.speed = 0; // 정지 
        Debug.Log("정지");


        StartCoroutine(RelaxTime());  
        
    }
    IEnumerator RelaxTime()
    {
        yield return new WaitForSeconds(0.55f);
        animator.speed = 1; // 동작
        Debug.Log("동작");
    }

    public void StartSkill930() // 애니메이션 재생 시 특정 event에서 StartSkill930 함수 실행 
    {
        Debug.Log("StartSkill930");
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill931"); // 내려찍는 이팩트          
        Skill931 skill931 = gameObject.GetComponent<Skill931>();
        skill931.SetOwnerPlayer(cc); // 붙이는 거 
        skill931.MonsterList = monsterList;
        skill931.TargetPos = monsterList[4].transform.position;
        skill931.KnightInfo = transform.position;
        skill931.transform.position = transform.position;

    }
}
