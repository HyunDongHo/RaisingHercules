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
            animator.Play("SKILL99"); // animation 재생 
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            //Animator animator = gameObject.GetComponent<Animator>();
            //animator.Play("SKILL98");
            StartSkill200(); 
        }else if (Input.GetKeyDown(KeyCode.E)) // 회오리 스킬 
        {
            Debug.Log("E 키가 입력 되었습니다.");
            StartSkill300();
        }else if (Input.GetKeyDown(KeyCode.R)) // 화살스킬  (targeting)
        {
            Debug.Log("R 키가 입력 되었습니다.");
            StartSkill500();
        }else if (Input.GetKeyDown(KeyCode.T)) // 회오리 눈덩이 스킬 (버전3개 있음)
        {
            Debug.Log("T 키가 입력 되었습니다.");
            StartSkill600();
        }else if (Input.GetKeyDown(KeyCode.A)) // 날개 커브 스킬 (targeting)
        {
            Debug.Log("A 키가 입력 되었습니다.");
            StartSkill700();
        }else if (Input.GetKeyDown(KeyCode.S)) // 그림자 불꽃 (ver1)
        {
            Debug.Log("S 키가 입력되었습니다.");
            StartSkill800();
        }else if (Input.GetKeyDown(KeyCode.D)) // 그림자 번개 (ver2)
        {
            Debug.Log("D 키가 입력되었습니다.");  
            StartSkill801();
        }else if (Input.GetKeyDown(KeyCode.F)) // dragon siriyu 스킬 (targeting) (속성 : 물리)
        {
            Debug.Log("F 키가 입력되었습니다.");
            transform.LookAt(monsterList[2].transform.position);
            Animator anim = gameObject.GetComponent<Animator>();
            anim.Play("SKILL900"); // animation 재생   
            Debug.Log("Skill900 재생");
            //StartSkill901();
        }else if (Input.GetKeyDown(KeyCode.G)) //[모으는 스킬]
        {
            Debug.Log("G 키가 입력되었습니다.");
            StartSkill910();
        }else if (Input.GetKeyDown(KeyCode.H)) //[불사슴 스킬] (속성 : 불)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log("H 키가 입력되었습니다.");
            StartSkill920();
        }else if (Input.GetKeyDown(KeyCode.J)) //[그림자 파도 ver3] (속성 : 물)
        {
            transform.LookAt(monsterList[4].transform.position);
            Debug.Log("J 키가 입력되었습니다.");
            StartSkill930();
        }else if (Input.GetKeyDown(KeyCode.K)) //[불구슬 스킬] (속성 : 불)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log("K 키가 입력되었습니다.");
            StartSkill940();
        }else if (Input.GetKeyDown(KeyCode.L)) //[불부메랑 스킬] (속성 : 불)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log("L 키가 입력되었습니다.");
            StartSkill950();
        }else if (Input.GetKeyDown(KeyCode.Z)) //[물보호막 스킬] (속성 : 물)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log("Z 키가 입력되었습니다.");
            StartSkill960();
        }else if (Input.GetKeyDown(KeyCode.X))  //[회오리 스킬] (속성 : 바람)
        {
            Debug.Log("X 키가 입력되었습니다.");
            StartSkill970();
        }
        else if (Input.GetKeyDown(KeyCode.C)) //[비내리는 검] (속성 : 물)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log("C 키가 입력되었습니다.");
            StartSkill980();
        }else if (Input.GetKeyDown(KeyCode.V)) //[쏟아지는 검] (속성 : 물리)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log(" V 키가 입력되었습니다.");
            StartSkill990();
        }else if (Input.GetKeyDown(KeyCode.B)) //[물방울 슈팅] ( 속성 : 물)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log(" B 키가 입력되었습니다.");
            StartSkill1000();
        }else if (Input.GetKeyDown(KeyCode.N)) //[드래곤] ( 속성 : 불)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log(" N 키가 입력되었습니다.");
            StartSkill1010();
        }else if (Input.GetKeyDown(KeyCode.M)) //[천둥번개] ( 속성 : 전기)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log(" M 키가 입력되었습니다.");
            StartSkill1020();
        }else if(Input.GetKeyDown(KeyCode.Y)) //[에랏 받아라~(번개 버전)] ( 속성 : 번개)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log(" Y 키가 입력되었습니다.");
            StartSkill1030();
        }else if (Input.GetKeyDown(KeyCode.U))//[에랏 받아라~(사과 버전)] ( 속성 : 물리)
        {
            transform.LookAt(monsterList[2].transform.position);
            Debug.Log(" U 키가 입력되었습니다.");
            StartSkill1040();
        }
    }
    //[에랏 받아라~(번개 버전) : 번개 ]
    public void StartSkill1030()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill1041");
        Skill1040 skill1040 = gameObject.GetComponent<Skill1040>();
        skill1040.SetOwnerPlayer(cc); // 붙이는 거       
        skill1040.MonsterList = monsterList;
        skill1040.KnightInfo = transform.position;
        skill1040.TargetPos = monsterList[2].transform.position;
        skill1040.transform.position = transform.position;  
    }

    //[에랏 받아라~(사과 버전) : 물리 ]
    public void StartSkill1040()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill1040");
        Skill1040 skill1040 = gameObject.GetComponent<Skill1040>();  
        skill1040.SetOwnerPlayer(cc); // 붙이는 거       
        skill1040.MonsterList = monsterList;
        skill1040.KnightInfo = transform.position;
        skill1040.TargetPos = monsterList[2].transform.position;
        skill1040.transform.position = transform.position;
    }

    //[천둥번개 ]
    public void StartSkill1020()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill1020");
            Skill1020 skill1020 = gameObject.GetComponent<Skill1020>();
            skill1020.SetOwnerPlayer(cc); // 붙이는 거       
            skill1020.MonsterList = monsterList;
            skill1020.KnightInfo = transform.position;
            skill1020.TargetPos = monsterList[2].transform.position;
            skill1020.transform.position = transform.position;
        }
        
    }
    //[드래곤]
    public void StartSkill1010()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill1010");
            Skill1010 skill1010 = gameObject.GetComponent<Skill1010>();
            skill1010.SetOwnerPlayer(cc); // 붙이는 거   
            skill1010.li = i;
            skill1010.MonsterList = monsterList;
            skill1010.KnightInfo = transform.position;
            skill1010.TargetPos = monsterList[2].transform.position;
            skill1010.transform.position = transform.position;
        }
        
    }

    //[물방울 슈팅]
    public void StartSkill1000()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill1000");
        Skill1000 skill1000 = gameObject.GetComponent<Skill1000>();
        skill1000.SetOwnerPlayer(cc); // 붙이는 거   
        skill1000.MonsterList = monsterList;
        skill1000.KnightInfo = transform.position;
        skill1000.TargetPos = monsterList[2].transform.position;
        skill1000.transform.position = transform.position;
    }

    //[쏟아지는 검]
    public void StartSkill990()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill990");
        Skill990 skill990 = gameObject.GetComponent<Skill990>();
        skill990.SetOwnerPlayer(cc); // 붙이는 거   
        skill990.MonsterList = monsterList;
        skill990.KnightInfo = transform.position;
        skill990.TargetPos = monsterList[2].transform.position;
        skill990.transform.position = transform.position;  
    }

    //[비내리는 검]
    public void StartSkill980()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill980");
        Skill980 skill980 = gameObject.GetComponent<Skill980>();
        skill980.SetOwnerPlayer(cc); // 붙이는 거   
        skill980.MonsterList = monsterList;
        skill980.KnightInfo = transform.position;
        skill980.TargetPos = monsterList[2].transform.position;
        skill980.transform.position = transform.position;
    }

    // [Knight 회오리 스킬 ]
    public void StartSkill970()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill970"); //Skill970 : (속성 바람) 회오리 ,KnightSkill300 : 회오리1 , KnightSkill301 : 해골
        Skill300 skill300 = gameObject.GetComponent<Skill300>();
        skill300.SetOwnerPlayer(cc); // 붙이는 거 
        skill300.MonsterList = monsterList;
        gameObject.transform.position = gameObject.transform.position;
    }
    //[물보호막 스킬]
    public void StartSkill960()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill961");    
        Skill960 skill960 = gameObject.GetComponent<Skill960>();
        skill960.SetOwnerPlayer(cc); // 붙이는 거 
        skill960.MonsterList = monsterList;
        skill960.KnightInfo = transform.position;
        skill960.TargetPos = monsterList[2].transform.position;
        skill960.transform.position = transform.position;
    }

    //[불부메랑 스킬]
    public void StartSkill950()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill950");
        Skill950 skill950 = gameObject.GetComponent<Skill950>();
        skill950.SetOwnerPlayer(cc); // 붙이는 거 
        skill950.MonsterList = monsterList;
        skill950.KnightInfo = transform.position;
        skill950.TargetPos = monsterList[2].transform.position;
        skill950.transform.position = transform.position;
    }

    //[불구슬 스킬]
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
        skill940.SetOwnerPlayer(cc); // 붙이는 거 
        skill940.MonsterList = monsterList;
        skill940.KnightInfo = transform.position;
        skill940.TargetPos = result;
        skill940.transform.position = transform.position;
    }

    //[그림자 파도 ver3]
    public void StartSkill930()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill930"); 
        Skill930 skill930 = gameObject.GetComponent<Skill930>();
        skill930.SetOwnerPlayer(cc); // 붙이는 거 
        skill930.MonsterList = monsterList;
        skill930.KnightInfo = transform.position;
        skill930.TargetPos = monsterList[4].transform.position;  
        skill930.transform.position = transform.position; 
    }

    //[불사슴 스킬]
    public void StartSkill920()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill920"); // 불사슴 
            Skill920 skill920 = gameObject.GetComponent<Skill920>();
            skill920.SetOwnerPlayer(cc); // 붙이는 거 
            skill920.MonsterList = monsterList;
            skill920.KnightInfo = transform.position;
            skill920.li = i;
            skill920.TargetPos = monsterList[2].transform.position;
            skill920.transform.position = transform.position;
        }
        
        GameObject gameObject2 = Managers.Resource.Instantiate("Particles/Skill/Skill921"); // 스팰  
        Skill921 skill921 = gameObject2.GetComponent<Skill921>();
        skill921.SetOwnerPlayer(cc); // 붙이는 거 
        skill921.MonsterList = monsterList;
        skill921.KnightInfo = transform.position;
        skill921.TargetPos = monsterList[2].transform.position;
        skill921.transform.position = transform.position;
    }

    //[모으는 스킬]
    public void StartSkill910()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill910"); 
        Skill910 skill910 = gameObject.GetComponent<Skill910>();
        skill910.SetOwnerPlayer(cc); // 붙이는 거 
        skill910.MonsterList = monsterList;
        skill910.KnightInfo = transform.position;
        skill910.TargetPos = monsterList[3].transform.position;
        skill910.transform.position = transform.position;
    }
    //[dragon siriyu 스킬]
    public void StartSkill900()
    {  
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill900");   
        Skill900 skill900 = gameObject.GetComponent<Skill900>();
        skill900.SetOwnerPlayer(cc); // 붙이는 거 
        skill900.MonsterList = monsterList;
        skill900.KnightInfo = transform.position;
        skill900.TargetPos = monsterList[2].transform.position;
        skill900.transform.position = transform.position;
    }
    public void StartSkill901()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill901");  
        Skill901 skill901 = gameObject.GetComponent<Skill901>();
        skill901.SetOwnerPlayer(cc); // 붙이는 거 
        skill901.MonsterList = monsterList;
        skill901.KnightInfo = transform.position;
        skill901.transform.position = transform.position;
    }

    //[그림자 근접 번개 스킬 ver2]
    public void StartSkill801()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill801"); // 그림자 
        Skill801 skill801 = gameObject.GetComponent<Skill801>();
        skill801.SetOwnerPlayer(cc); // 붙이는 거 
        skill801.MonsterList = monsterList;
        skill801.TargetPos = monsterList[2].transform.position;
        skill801.KnightInfo = transform.position;
        skill801.transform.position = transform.position;  

        //StartCoroutine(MoveAfter());

    }

    //[그림자 근접 헤머 스킬 ver1]
    public void StartSkill800()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill800"); // 그림자 
        Skill800 skill800 = gameObject.GetComponent<Skill800>();
        skill800.SetOwnerPlayer(cc); // 붙이는 거 
        skill800.MonsterList = monsterList;
        skill800.KnightInfo = transform.position;
        skill800.TargetPos = monsterList[2].transform.position;
        skill800.transform.position = transform.position;
     
    }

    //[날개 커브 스킬]
    public void StartSkill700()
    {
        transform.LookAt(monsterList[2].transform.position);
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill700"); // 날개 생성 
        if (gameObject != null)
        {
            Debug.Log("Instantiate Skill700 complete");
        }
        else
        {
            Debug.Log(" Skill700 NULL!!!!!!!!!!!!!!");
        }

        Skill700 skill700 = gameObject.GetComponent<Skill700>();
        skill700.SetOwnerPlayer(cc); // 붙이는 거 
        skill700.MonsterList = monsterList;
        skill700.KnightInfo = transform.position;
        skill700.transform.position = transform.position;
        skill700.TargetPos = monsterList[2].transform.position;

        for (int i = 0; i < 3; i++)
        {
            GameObject projObj = Managers.Resource.Instantiate("Particles/Skill/Skill701_1"); // 구 3개 생성
            Skill701 sphere = projObj.GetComponent<Skill701>();
            sphere.li = i;
            sphere.SetOwnerPlayer(cc); // 붙이는 거 
            sphere.MonsterList = monsterList;
            sphere.KnightInfo = transform.position;
            sphere.TargetPos = monsterList[2].transform.position;
            sphere.transform.position = transform.position;
        }

        for (int i = 0; i < 3; i++)  // projectile 9개 생성 
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

    //[탈론스킬(눈 돌덩이 회오리)]
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
            skill600.SetOwnerPlayer(cc); // 붙이는 거 
            skill600.MonsterList = monsterList;
            skill600.li = i;
            skill600.KnightInfo = transform.position;
            skill600.transform.position = transform.position;
        }
         
    }


    //[화살스킬1버전]
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
        skill500.SetOwnerPlayer(cc); // 붙이는 거 
        skill500.MonsterList = monsterList;
        gameObject.transform.position = gameObject.transform.position;
    }


    // [Knight tank 스킬 ] 
    //public void StartSkill400()
    //{
    //    GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/KnightSkill400_tank"); //KnightSkill300 : 회오리 , KnightSkill301 : 해골
    //    if (gameObject != null)
    //    {
    //        Debug.Log("Instantiate KnightSkill400_tank complete");
    //    }
    //    else
    //    {
    //        Debug.Log(" KnightSkill400_tank NULL!!!!!!!!!!!!!!");
    //    }
    //    KnightSkill400 skill400 = gameObject.GetComponent<KnightSkill400>();
    //    skill400.SetOwnerPlayer(cc); // 붙이는 거 
    //    skill400.MonsterList = monsterList;
    //    gameObject.transform.position = gameObject.transform.position;
    //}

    // [Knight 회오리 스킬 ]
    public void StartSkill300()    
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/KnightSkill300"); //KnightSkill300 : 회오리 , KnightSkill301 : 해골
        if (gameObject != null)
        {
            Debug.Log("Instantiate KnightSkill300 complete");
        }
        else
        {
            Debug.Log(" KnightSkill300 NULL!!!!!!!!!!!!!!"); 
        }
        Skill300 skill300 = gameObject.GetComponent<Skill300>();
        skill300.SetOwnerPlayer(cc); // 붙이는 거 
        skill300.MonsterList = monsterList;
        gameObject.transform.position = gameObject.transform.position;
    }


    public void StartSkill99() // 애니메이션 재생 시 특정 event에서 StartSkill99 함수 실행 
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill99"); // 밑에 스킬이펙트(룬) 생성 
        Debug.Log("Instantiate skill99 complete");
        Skill99 skill99 = gameObject.GetComponent<Skill99>();
        skill99.SetOwnerPlayer(cc); // 붙이는 거 
        gameObject.transform.position = gameObject.transform.position; 
    }

    public void StartSkill98()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill98");
        Skill98 skill98 = gameObject.GetComponent<Skill98>();
        skill98.SetOwnerPlayer(cc); // 붙이는 거 
        skill98.MonsterList = monsterList;
        gameObject.transform.position = gameObject.transform.position;
    }

    // [포물선운동 구현 후 Skill 만들기]
    public void StartSkill200()
    {
        GameObject gameObject = Managers.Resource.Instantiate("Particles/Skill/Skill200");
        Skill200 skill200 = gameObject.GetComponent<Skill200>();
        skill200.SetOwnerPlayer(cc); // 붙이는 거 
        skill200.MonsterList = monsterList;
        gameObject.transform.position = gameObject.transform.position;
    }

    IEnumerator CreateArrows(int i, int j, float time)
    {
        yield return new WaitForSeconds(time);

        GameObject projObj = Managers.Resource.Instantiate("Particles/Skill/Skill702_4"); // projectile 3개 생성  
        Skill702 arrow = projObj.GetComponent<Skill702>();
        arrow.li = i;
        arrow.lj = j;
        arrow.SetOwnerPlayer(cc); // 붙이는 거 
        arrow.MonsterList = monsterList;
        arrow.transform.position = transform.position;
        arrow.KnightPos = transform.position;  
        arrow.TargetPos = monsterList[2].transform.position;

    }


}
