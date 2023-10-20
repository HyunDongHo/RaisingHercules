using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sword_Test : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI LevelText;

    /* Particle System*/
    // 수정전 
    //List<float> FireData = new List<float>() {0.3f, 0.35f, 0.4f, 0.45f, 0.5f,
    //                                            0.6f, 0.7f, 0.8f, 0.9f, 1.0f};
    //List<float> BrightData = new List<float>() {0.15f, 0.2f, 0.25f, 0.3f, 0.35f,
    //                                            0.4f, 0.5f, 0.6f, 0.7f, 0.9f};
    // 수정후 
    List<float> FireData = new List<float>() {0.05f, 0.1f, 0.15f, 0.2f, 0.25f,
                                                0.3f, 0.35f, 0.4f, 0.45f, 0.5f};
    List<float> BrightData = new List<float>() {0.05f, 0.1f, 0.15f, 0.2f, 0.25f,
                                                0.3f, 0.35f, 0.4f, 0.45f, 0.5f};

    /* Shader property */
    List<float> DistortionAmountData = new List<float>() {0.015f, 0.03f, 0.045f , 0.06f, 0.075f,
                                                          0.09f, 0.105f, 0.12f, 0.135f, 0.15f};
    List<int> GradientNoiseScale = new List<int>() {1,2,3,4,5,6,7,8,9,10};
    int level;
    // Start is called before the first frame update
    void Start()
    {
        ResetButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSwordButtonClicked()
    {
        Debug.Log("OnSwordButtonClicked");
        if(level <= 10)
        {
            GameObject go = GameObject.Find("weapon04_red");
            if (go != null)
            {
                level += 1;
                Debug.Log("weapon04_red is not null");
                GameObject Sword_Effect_red = go.transform.Find("Sword_Effect_red").gameObject;
                GameObject fire = Sword_Effect_red.transform.Find("fire").gameObject;
                //TODO : 파티클 시스템 start size 조절 
                ParticleSystem.MainModule main = fire.GetComponent<ParticleSystem>().main;
                main.startSize = new ParticleSystem.MinMaxCurve(FireData[level - 1], FireData[level - 1] + 0.2f); ;

                GameObject bright = Sword_Effect_red.transform.Find("Fx_Skill_HF_RS_2_1").Find("Fx_Skill_HF_RS_2_2").gameObject;
                ParticleSystem.MainModule main2 = bright.GetComponent<ParticleSystem>().main;
                main2.startSize = BrightData[level - 1] ;

                //TODO : 머트리얼 shader property 값 조절 
                Material mat = go.GetComponent<Renderer>().material;
                mat.SetFloat("Vector1_E6782A57", DistortionAmountData[level - 1]); // DistortionAmount = Vector1_E6782A57
                mat.SetFloat("Vector1_B1BD7CBA", GradientNoiseScale[level - 1]);  //  GradientNoiseScale = Vector1_B1BD7CBA

                LevelText.text = $"Lv.{level}";
                Sword_Effect_red.SetActive(true);
            }
            else
            {
                Debug.Log("weapon04_red is null");  
            }
        }
        
    }

    public void OnSwordLevelDown()
    {
        if (level > 1)
        {
            GameObject go = GameObject.Find("weapon04_red");
            if (go != null)
            {
                level -= 1;
                Debug.Log("weapon04_red is not null");
                GameObject Sword_Effect_red = go.transform.Find("Sword_Effect_red").gameObject;
                GameObject fire = Sword_Effect_red.transform.Find("fire").gameObject;
                //TODO : 파티클 시스템 start size 조절 
                ParticleSystem.MainModule main = fire.GetComponent<ParticleSystem>().main;
                main.startSize = new ParticleSystem.MinMaxCurve(FireData[level - 1], FireData[level - 1] + 0.2f); ;

                GameObject bright = Sword_Effect_red.transform.Find("Fx_Skill_HF_RS_2_1").Find("Fx_Skill_HF_RS_2_2").gameObject;
                ParticleSystem.MainModule main2 = bright.GetComponent<ParticleSystem>().main;
                main2.startSize = BrightData[level - 1];

                Material mat = go.GetComponent<Renderer>().material;
                mat.SetFloat("Vector1_E6782A57", DistortionAmountData[level - 1]); 
                mat.SetFloat("Vector1_B1BD7CBA", GradientNoiseScale[level - 1]);

                LevelText.text = $"Lv.{level}";
                Sword_Effect_red.SetActive(true);
            }
            else
            {
                Debug.Log("weapon04_red is null");
            }
        }

    }
    public void ResetButton()
    {
        Debug.Log("Reset");

        level = 0;
        LevelText.text = $"Lv.{level}";

        GameObject go = GameObject.Find("weapon04_red");
        if (go != null)
        {
            GameObject Sword_Effect_red = go.transform.Find("Sword_Effect_red").gameObject;
            GameObject fire = Sword_Effect_red.transform.Find("fire").gameObject;
            //TODO : 파티클 시스템 start size 조절 
            ParticleSystem.MainModule main = fire.GetComponent<ParticleSystem>().main;
            main.startSize = 0;

            GameObject bright = Sword_Effect_red.transform.Find("Fx_Skill_HF_RS_2_1").Find("Fx_Skill_HF_RS_2_2").gameObject;
            ParticleSystem.MainModule main2 = bright.GetComponent<ParticleSystem>().main;
            main2.startSize = 0;

            //go.GetComponent<Renderer>().material.SetFloat("DistortionAmount", 0);
            Material mat = go.GetComponent<Renderer>().material;
            if(mat != null)
            {
                Debug.Log($"material is exist{mat.name}");
                //for(int i = 0; i < material1.shader.GetPropertyCount(); i++)
                //{
                //    Debug.Log($"{material1.shader.GetPropertyName(i)}");  
                //}
                mat.SetFloat("Vector1_E6782A57", 0);
                mat.SetFloat("Vector1_B1BD7CBA", 0);
            }

            

            Sword_Effect_red.SetActive(false);
        }
        else
        {
            Debug.Log("weapon04_red is null");
        }
    }


}
