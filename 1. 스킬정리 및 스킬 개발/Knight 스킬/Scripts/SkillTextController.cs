using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTextController : CreatureController
{
    // Start is called before the first frame update

    // Update is called once per frame
    CreatureController cc = null;

    [SerializeField]
    List<GameObject> monsterList;
    public float accumTime = 0.0f;
    protected override void Init()
    {
        cc = gameObject.GetComponent<CreatureController>();   
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Animator animator = gameObject.GetComponent<Animator>();
            animator.Play("SKILL99"); // animation ��� 
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            //Animator animator = gameObject.GetComponent<Animator>();
            //animator.Play("SKILL98");
            StartSkill200(); 
        }else if (Input.GetKeyDown(KeyCode.E)) // ȸ���� ��ų 
        {
            Debug.Log("E Ű�� �Է� �Ǿ����ϴ�.");
            StartSkill300();
        }else if (Input.GetKeyDown(KeyCode.R)) // ȭ�콺ų  (targeting)
        {
            Debug.Log("R Ű�� �Է� �Ǿ����ϴ�.");
            StartSkill500();
        }else if (Input.GetKeyDown(KeyCode.T)) // ȸ���� ������ ��ų (����3�� ����)
        {
            Debug.Log("T Ű�� �Է� �Ǿ����ϴ�.");
            StartSkill600();
        }else if (Input.GetKeyDown(KeyCode.A)) // ���� Ŀ�� ��ų (targeting)
        {
            Debug.Log("A Ű�� �Է� �Ǿ����ϴ�.");
            StartSkill700();
        }else if (Input.GetKeyDown(KeyCode.S)) // �׸��� �Ҳ� (ver1)
        {
            Debug.Log("S Ű�� �ԷµǾ����ϴ�.");
            StartSkill800();
        }else if (Input.GetKeyDown(KeyCode.D)) // �׸��� ���� (ver2)
        {
            Debug.Log("D Ű�� �ԷµǾ����ϴ�.");  
            StartSkill801();
        }else if (Input.GetKeyDown(KeyCode.F)) // dragon siriyu ��ų (targeting) (�Ӽ� : ����)
        {
            Debug.Log("F Ű�� �ԷµǾ����ϴ�.");
            transform.LookAt(monsterList[2].transform.position);
            Animator anim = gameObject.GetComponent<Animator>();
            anim.Play("SKILL900"); // animation ���   
            Debug.Log("Skill900 ���");
            //StartSkill901();
        }else if (Input.GetKeyDown(KeyCode.G)) //[������ ��ų]
        {
            Debug.Log("G Ű�� �ԷµǾ����ϴ�.");
            StartSkill910();
        }else if (Input.GetKeyDown(KeyCode.H)) //[�һ罿 ��ų] (�Ӽ� : ��)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log("H Ű�� �ԷµǾ����ϴ�.");
            StartSkill920();
        }else if (Input.GetKeyDown(KeyCode.J)) //[�׸��� �ĵ� ver3] (�Ӽ� : ��)
        {
            transform.LookAt(monsterList[4].transform.position);
            Debug.Log("J Ű�� �ԷµǾ����ϴ�.");
            StartSkill930();
        }else if (Input.GetKeyDown(KeyCode.K)) //[�ұ��� ��ų] (�Ӽ� : ��)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log("K Ű�� �ԷµǾ����ϴ�.");
            StartSkill940();
        }else if (Input.GetKeyDown(KeyCode.L)) //[�Һθ޶� ��ų] (�Ӽ� : ��)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log("L Ű�� �ԷµǾ����ϴ�.");
            StartSkill950();
        }else if (Input.GetKeyDown(KeyCode.Z)) //[����ȣ�� ��ų] (�Ӽ� : ��)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log("Z Ű�� �ԷµǾ����ϴ�.");
            StartSkill960();
        }else if (Input.GetKeyDown(KeyCode.X))  //[ȸ���� ��ų] (�Ӽ� : �ٶ�)
        {
            Debug.Log("X Ű�� �ԷµǾ����ϴ�.");
            StartSkill970();
        }
        else if (Input.GetKeyDown(KeyCode.C)) //[�񳻸��� ��] (�Ӽ� : ��)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log("C Ű�� �ԷµǾ����ϴ�.");
            StartSkill980();
        }else if (Input.GetKeyDown(KeyCode.V)) //[������� ��] (�Ӽ� : ����)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log(" V Ű�� �ԷµǾ����ϴ�.");
            StartSkill990();
        }else if (Input.GetKeyDown(KeyCode.B)) //[����� ����] ( �Ӽ� : ��)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log(" B Ű�� �ԷµǾ����ϴ�.");
            StartSkill1000();
        }else if (Input.GetKeyDown(KeyCode.N)) //[�巡��] ( �Ӽ� : ��)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log(" N Ű�� �ԷµǾ����ϴ�.");
            StartSkill1010();
        }else if (Input.GetKeyDown(KeyCode.M)) //[õ�չ���] ( �Ӽ� : ����)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log(" M Ű�� �ԷµǾ����ϴ�.");
            StartSkill1020();
        }else if(Input.GetKeyDown(KeyCode.Y)) //[���� �޾ƶ�~(���� ����)] ( �Ӽ� : ����)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log(" Y Ű�� �ԷµǾ����ϴ�.");
            StartSkill1030();
        }else if (Input.GetKeyDown(KeyCode.U))//[���� �޾ƶ�~(��� ����)] ( �Ӽ� : ����)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log(" U Ű�� �ԷµǾ����ϴ�.");
            StartSkill1040();
        }
    }
    //[���� �޾ƶ�~(���� ����) : ���� ]
    public void StartSkill1030()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill1041");
        Skill1040 skill1040 = gameObject.GetComponent<Skill1040>();
        skill1040.SetOwnerPlayer(cc); // ���̴� ��       
        skill1040.MonsterList = monsterList;
        skill1040.KnightInfo = transform.position;
        skill1040.TargetPos = monsterList[2].transform.position;
        skill1040.transform.position = transform.position;  
    }

    //[���� �޾ƶ�~(��� ����) : ���� ]
    public void StartSkill1040()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill1040");
        Skill1040 skill1040 = gameObject.GetComponent<Skill1040>();  
        skill1040.SetOwnerPlayer(cc); // ���̴� ��       
        skill1040.MonsterList = monsterList;
        skill1040.KnightInfo = transform.position;
        skill1040.TargetPos = monsterList[2].transform.position;
        skill1040.transform.position = transform.position;
    }

    //[õ�չ��� ]
    public void StartSkill1020()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill1020");
            Skill1020 skill1020 = gameObject.GetComponent<Skill1020>();
            skill1020.SetOwnerPlayer(cc); // ���̴� ��       
            skill1020.MonsterList = monsterList;
            skill1020.KnightInfo = transform.position;
            skill1020.TargetPos = monsterList[2].transform.position;
            skill1020.transform.position = transform.position;
        }
        
    }
    //[�巡��]
    public void StartSkill1010()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill1010");
            Skill1010 skill1010 = gameObject.GetComponent<Skill1010>();
            skill1010.SetOwnerPlayer(cc); // ���̴� ��   
            skill1010.li = i;
            skill1010.MonsterList = monsterList;
            skill1010.KnightInfo = transform.position;
            skill1010.TargetPos = monsterList[2].transform.position;
            skill1010.transform.position = transform.position;
        }
        
    }

    //[����� ����]
    public void StartSkill1000()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill1000");
        Skill1000 skill1000 = gameObject.GetComponent<Skill1000>();
        skill1000.SetOwnerPlayer(cc); // ���̴� ��   
        skill1000.MonsterList = monsterList;
        skill1000.KnightInfo = transform.position;
        skill1000.TargetPos = monsterList[2].transform.position;
        skill1000.transform.position = transform.position;
    }

    //[������� ��]
    public void StartSkill990()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill990");
        Skill990 skill990 = gameObject.GetComponent<Skill990>();
        skill990.SetOwnerPlayer(cc); // ���̴� ��   
        skill990.MonsterList = monsterList;
        skill990.KnightInfo = transform.position;
        skill990.TargetPos = monsterList[2].transform.position;
        skill990.transform.position = transform.position;  
    }

    //[�񳻸��� ��]
    public void StartSkill980()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill980");
        Skill980 skill980 = gameObject.GetComponent<Skill980>();
        skill980.SetOwnerPlayer(cc); // ���̴� ��   
        skill980.MonsterList = monsterList;
        skill980.KnightInfo = transform.position;
        skill980.TargetPos = monsterList[2].transform.position;
        skill980.transform.position = transform.position;
    }

    // [Knight ȸ���� ��ų ]
    public void StartSkill970()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill970"); //Skill970 : (�Ӽ� �ٶ�) ȸ���� ,KnightSkill300 : ȸ����1 , KnightSkill301 : �ذ�
        Skill300 skill300 = gameObject.GetComponent<Skill300>();
        skill300.SetOwnerPlayer(cc); // ���̴� �� 
        skill300.MonsterList = monsterList;
        gameObject.transform.position = gameObject.transform.position;
    }
    //[����ȣ�� ��ų]
    public void StartSkill960()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill961");    
        Skill960 skill960 = gameObject.GetComponent<Skill960>();
        skill960.SetOwnerPlayer(cc); // ���̴� �� 
        skill960.MonsterList = monsterList;
        skill960.KnightInfo = transform.position;
        skill960.TargetPos = monsterList[2].transform.position;
        skill960.transform.position = transform.position;
    }

    //[�Һθ޶� ��ų]
    public void StartSkill950()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill950");
        Skill950 skill950 = gameObject.GetComponent<Skill950>();
        skill950.SetOwnerPlayer(cc); // ���̴� �� 
        skill950.MonsterList = monsterList;
        skill950.KnightInfo = transform.position;
        skill950.TargetPos = monsterList[2].transform.position;
        skill950.transform.position = transform.position;
    }

    //[�ұ��� ��ų]
    public void StartSkill940()
    {
        Vector3 result = new Vector3(0, 0, 0);
        for(int i = 0; i < monsterList.Count; i++)
        {
            result += monsterList[i].transform.position;
        }
        result = result / monsterList.Count;

        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill940");
        Skill940 skill940 = gameObject.GetComponent<Skill940>();
        skill940.SetOwnerPlayer(cc); // ���̴� �� 
        skill940.MonsterList = monsterList;
        skill940.KnightInfo = transform.position;
        skill940.TargetPos = result;
        skill940.transform.position = transform.position;
    }

    //[�׸��� �ĵ� ver3]
    public void StartSkill930()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill930"); 
        Skill930 skill930 = gameObject.GetComponent<Skill930>();
        skill930.SetOwnerPlayer(cc); // ���̴� �� 
        skill930.MonsterList = monsterList;
        skill930.KnightInfo = transform.position;
        skill930.TargetPos = monsterList[4].transform.position;  
        skill930.transform.position = transform.position; 
    }

    //[�һ罿 ��ų]
    public void StartSkill920()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill920"); // �һ罿 
            Skill920 skill920 = gameObject.GetComponent<Skill920>();
            skill920.SetOwnerPlayer(cc); // ���̴� �� 
            skill920.MonsterList = monsterList;
            skill920.KnightInfo = transform.position;
            skill920.li = i;
            skill920.TargetPos = monsterList[2].transform.position;
            skill920.transform.position = transform.position;
        }
        
        GameObject gameObject2 = Managers.Resource.Instantiate("Particles/Skill/Skill921"); // ����  
        Skill921 skill921 = gameObject2.GetComponent<Skill921>();
        skill921.SetOwnerPlayer(cc); // ���̴� �� 
        skill921.MonsterList = monsterList;
        skill921.KnightInfo = transform.position;
        skill921.TargetPos = monsterList[2].transform.position;
        skill921.transform.position = transform.position;
    }

    //[������ ��ų]
    public void StartSkill910()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill910"); 
        Skill910 skill910 = gameObject.GetComponent<Skill910>();
        skill910.SetOwnerPlayer(cc); // ���̴� �� 
        skill910.MonsterList = monsterList;
        skill910.KnightInfo = transform.position;
        skill910.TargetPos = monsterList[3].transform.position;
        skill910.transform.position = transform.position;
    }
    //[dragon siriyu ��ų]
    public void StartSkill900()
    {  
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill900");   
        Skill900 skill900 = gameObject.GetComponent<Skill900>();
        skill900.SetOwnerPlayer(cc); // ���̴� �� 
        skill900.MonsterList = monsterList;
        skill900.KnightInfo = transform.position;
        skill900.TargetPos = monsterList[2].transform.position;
        skill900.transform.position = transform.position;
    }
    public void StartSkill901()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill901");  
        Skill901 skill901 = gameObject.GetComponent<Skill901>();
        skill901.SetOwnerPlayer(cc); // ���̴� �� 
        skill901.MonsterList = monsterList;
        skill901.KnightInfo = transform.position;
        skill901.transform.position = transform.position;
    }

    //[�׸��� ���� ���� ��ų ver2]
    public void StartSkill801()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill801"); // �׸��� 
        Skill801 skill801 = gameObject.GetComponent<Skill801>();
        skill801.SetOwnerPlayer(cc); // ���̴� �� 
        skill801.MonsterList = monsterList;
        skill801.TargetPos = monsterList[2].transform.position;
        skill801.KnightInfo = transform.position;
        skill801.transform.position = transform.position;  

        //StartCoroutine(MoveAfter());

    }

    //[�׸��� ���� ��� ��ų ver1]
    public void StartSkill800()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill800"); // �׸��� 
        Skill800 skill800 = gameObject.GetComponent<Skill800>();
        skill800.SetOwnerPlayer(cc); // ���̴� �� 
        skill800.MonsterList = monsterList;
        skill800.KnightInfo = transform.position;
        skill800.TargetPos = monsterList[2].transform.position;
        skill800.transform.position = transform.position;
     
    }

    //[���� Ŀ�� ��ų]
    public void StartSkill700()
    {
        transform.LookAt(monsterList[2].transform.position);
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill700"); // ���� ���� 
        if (gameObject != null)
        {
            Debug.Log("Instantiate Skill700 complete");
        }
        else
        {
            Debug.Log(" Skill700 NULL!!!!!!!!!!!!!!");
        }

        Skill700 skill700 = gameObject.GetComponent<Skill700>();
        skill700.SetOwnerPlayer(cc); // ���̴� �� 
        skill700.MonsterList = monsterList;
        skill700.KnightInfo = transform.position;
        skill700.transform.position = transform.position;
        skill700.TargetPos = monsterList[2].transform.position;

        for (int i = 0; i < 3; i++)
        {
            GameObject projObj = Managers.Resource.Instantiate("Particles/Skill/Skill701_1"); // �� 3�� ����
            Skill701 sphere = projObj.GetComponent<Skill701>();
            sphere.li = i;
            sphere.SetOwnerPlayer(cc); // ���̴� �� 
            sphere.MonsterList = monsterList;
            sphere.KnightInfo = transform.position;
            sphere.TargetPos = monsterList[2].transform.position;
            sphere.transform.position = transform.position;
        }

        for (int i = 0; i < 3; i++)  // projectile 9�� ���� 
        {
            accumTime = 0.0f;
            for(int j = 0; j < 3; j++)
            {
                accumTime += 0.5f;
                StartCoroutine(CreateArrows(i, j, accumTime));  
                Debug.Log($"accumTime : {accumTime}");
            }
        }

    }

    //[Ż�н�ų(�� ������ ȸ����)]
    public void StartSkill600()  
    {
        
        for(int i = 0; i < 4; i++)
        {
            GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill604");
            if (gameObject != null)
            {
                Debug.Log("Instantiate Skill604 complete");
            }
            else
            {
                Debug.Log(" Skill604 NULL!!!!!!!!!!!!!!");
            }

            Skill600 skill600 = gameObject.GetComponent<Skill600>();
            skill600.SetOwnerPlayer(cc); // ���̴� �� 
            skill600.MonsterList = monsterList;
            skill600.li = i;
            skill600.KnightInfo = transform.position;
            skill600.transform.position = transform.position;
        }
         
    }


    //[ȭ�콺ų1����]
    public void StartSkill500()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill500"); 
        if (gameObject != null)
        {
            Debug.Log("Instantiate Skill500 complete");
        }
        else
        {
            Debug.Log(" Skill500 NULL!!!!!!!!!!!!!!");
        }

        Skill500 skill500 = gameObject.GetComponent<Skill500>();
        skill500.SetOwnerPlayer(cc); // ���̴� �� 
        skill500.MonsterList = monsterList;
        gameObject.transform.position = gameObject.transform.position;
    }


    // [Knight tank ��ų ] 
    //public void StartSkill400()
    //{
    //    GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/KnightSkill400_tank"); //KnightSkill300 : ȸ���� , KnightSkill301 : �ذ�
    //    if (gameObject != null)
    //    {
    //        Debug.Log("Instantiate KnightSkill400_tank complete");
    //    }
    //    else
    //    {
    //        Debug.Log(" KnightSkill400_tank NULL!!!!!!!!!!!!!!");
    //    }
    //    KnightSkill400 skill400 = gameObject.GetComponent<KnightSkill400>();
    //    skill400.SetOwnerPlayer(cc); // ���̴� �� 
    //    skill400.MonsterList = monsterList;
    //    gameObject.transform.position = gameObject.transform.position;
    //}

    // [Knight ȸ���� ��ų ]
    public void StartSkill300()    
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/KnightSkill300"); //KnightSkill300 : ȸ���� , KnightSkill301 : �ذ�
        if (gameObject != null)
        {
            Debug.Log("Instantiate KnightSkill300 complete");
        }
        else
        {
            Debug.Log(" KnightSkill300 NULL!!!!!!!!!!!!!!"); 
        }
        Skill300 skill300 = gameObject.GetComponent<Skill300>();
        skill300.SetOwnerPlayer(cc); // ���̴� �� 
        skill300.MonsterList = monsterList;
        gameObject.transform.position = gameObject.transform.position;
    }


    public void StartSkill99() // �ִϸ��̼� ��� �� Ư�� event���� StartSkill99 �Լ� ���� 
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill99"); // �ؿ� ��ų����Ʈ(��) ���� 
        Debug.Log("Instantiate skill99 complete");
        Skill99 skill99 = gameObject.GetComponent<Skill99>();
        skill99.SetOwnerPlayer(cc); // ���̴� �� 
        gameObject.transform.position = gameObject.transform.position; 
    }

    public void StartSkill98()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill98");
        Skill98 skill98 = gameObject.GetComponent<Skill98>();
        skill98.SetOwnerPlayer(cc); // ���̴� �� 
        skill98.MonsterList = monsterList;
        gameObject.transform.position = gameObject.transform.position;
    }

    // [������� ���� �� Skill �����]
    public void StartSkill200()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill200");
        Skill200 skill200 = gameObject.GetComponent<Skill200>();
        skill200.SetOwnerPlayer(cc); // ���̴� �� 
        skill200.MonsterList = monsterList;
        gameObject.transform.position = gameObject.transform.position;
    }

    IEnumerator CreateArrows(int i, int j, float time)
    {
        yield return new WaitForSeconds(time);

        GameObject projObj = Managers.Resource.Instantiate("Particles/Skill/Skill702_4"); // projectile 3�� ����  
        Skill702 arrow = projObj.GetComponent<Skill702>();
        arrow.li = i;
        arrow.lj = j;
        arrow.SetOwnerPlayer(cc); // ���̴� �� 
        arrow.MonsterList = monsterList;
        arrow.transform.position = transform.position;
        arrow.KnightPos = transform.position;  
        arrow.TargetPos = monsterList[2].transform.position;

    }


}
