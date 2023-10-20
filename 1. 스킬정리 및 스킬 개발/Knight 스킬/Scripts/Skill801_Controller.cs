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

    public void StartSkill800() // �ִϸ��̼� ��� �� Ư�� event���� StartSkill800 �Լ� ���� 
    {
        Debug.Log("StartSkill800");

        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill800_hit2"); // ������� ����Ʈ     
        Skill800_hit skill800 = gameObject.GetComponent<Skill800_hit>();
        skill800.SetOwnerPlayer(cc); // ���̴� �� 
        skill800.TargetPos = monsterList[2].transform.position;
        skill800.KnightInfo = transform.position;
        skill800.transform.position = transform.position;

    }
    public void StartSkill801() // �ִϸ��̼� ��� �� Ư�� event���� StartSkill801 �Լ� ���� 
    {
        Debug.Log("StartSkill801");

        animator = gameObject.GetComponent<Animator>();
        animator.speed = 0; // ���� 
        Debug.Log("����");


        StartCoroutine(RelaxTime());  
        
    }
    IEnumerator RelaxTime()
    {
        yield return new WaitForSeconds(0.55f);
        animator.speed = 1; // ����
        Debug.Log("����");
    }

    public void StartSkill930() // �ִϸ��̼� ��� �� Ư�� event���� StartSkill930 �Լ� ���� 
    {
        Debug.Log("StartSkill930");
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill931"); // ������� ����Ʈ          
        Skill931 skill931 = gameObject.GetComponent<Skill931>();
        skill931.SetOwnerPlayer(cc); // ���̴� �� 
        skill931.MonsterList = monsterList;
        skill931.TargetPos = monsterList[4].transform.position;
        skill931.KnightInfo = transform.position;
        skill931.transform.position = transform.position;

    }
}
