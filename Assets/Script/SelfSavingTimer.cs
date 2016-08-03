using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelfSavingTimer : MonoBehaviour
{
    public float time;
    public Text emeryname;
    public Text timerCountDown;
    public Text GameOver;
    public GameObject BackButton;
    public GameObject BackImage;
    public Text brokenRateReport;
    float totalhealth;
    public float brokenRate=0;
    bool n = false;
    GameObject[] health;
    GameObject[] manhealth;
    int[] hurt = new int[5];
    public Text manHurt;
    public int enemymoney;
    public int getmoney;
    public Text getMoney;
    Fight_Objectload enemyID;//對手的ID

    void Start()
    {
        time = 30.0f;
    }

    void Update()
    {
        
        if (emeryname.text.ToString() != "Searching...")
        {
            if (GameObject.Find("Lamp(Clone)") != null || GameObject.Find("Baker_house (Clone)") != null || GameObject.Find("Fire_Hydrant(Clone)") != null)
            {
                if (time > 0)
                {
                    time -= Time.deltaTime;
                }
                else
                {
                    time = 0;
                }
                if (time == 0 && n==false)
                {
                    GameOver.text = "time's up \n    GameOver!!";
                    BackButton.SetActive(true);
                    BackImage.SetActive(true);
                    buildBreak();
                    manCount();
                    moneyget();
                }
            }
            if (GameObject.Find("Lamp(Clone)") == null && GameObject.Find("Baker_house (Clone)") == null && GameObject.Find("Fire_Hydrant(Clone)") == null && time < 30f && n==false)
            {
                GameOver.text = "You Win!!";
                BackButton.SetActive(true);
                BackImage.SetActive(true);
                buildBreak();
                manCount();
                moneyget();
            }
        }
        timerCountDown.text = time.ToString();

    }
    void buildBreak()
    {
        health = GameObject.FindGameObjectsWithTag("Building");
        for (int i = 3; i < health.Length; i++)
        {
          totalhealth += health[i].GetComponent<Object_Health>().ObjectHealth;
        }
        brokenRate = 1 - (totalhealth / (250 * (health.Length-3)));
        brokenRateReport.text = "  建築損壞度 : " + brokenRate*100 + "% ";
        n = true;
    }
    void manCount()
    {
        enemyID= GameObject.Find("Main Camera").GetComponent<Fight_Objectload>();
        manhealth = GameObject.FindGameObjectsWithTag("Man");
        for (int i = 0; i < manhealth.Length; i++)
        {
            if (manhealth[i].GetComponent<Object_Health>().ObjectHealth == 100)
            { hurt[0] += 1; }
            else if (50 < manhealth[i].GetComponent<Object_Health>().ObjectHealth && manhealth[i].GetComponent<Object_Health>().ObjectHealth <= 100)
            { hurt[1] += 1; }
            else if (20 < manhealth[i].GetComponent<Object_Health>().ObjectHealth && manhealth[i].GetComponent<Object_Health>().ObjectHealth <= 50)
            { hurt[2] += 1; }
            else if (0 < manhealth[i].GetComponent<Object_Health>().ObjectHealth && manhealth[i].GetComponent<Object_Health>().ObjectHealth <= 20)
            { hurt[3] += 1; }
            else if (0 == manhealth[i].GetComponent<Object_Health>().ObjectHealth )
            { hurt[4] += 1; }
        }
        manHurt.text = "  無傷 " + hurt[0] + " 人\n" + "  輕度傷害 " + hurt[1] + " 人\n" + "  中度傷害 " + hurt[2] + " 人\n" + "  重度傷害 " + hurt[3] + " 人 \n" + "  死亡 " + hurt[4] + " 人";
    }
    void moneyget()//得到金錢公式==對手現在金錢X(2%輕傷人數+4%中度人數+5%重度人數+10%死亡人數)/2
    {
        enemymoney = GameObject.Find("Main Camera").GetComponent<Fight_Objectload>().mon;
        getmoney = enemymoney * (2 * hurt[1] + 4 * hurt[2] + 5 * hurt[3] + 1 * hurt[4]+(int)brokenRate*100 ) / 200;
        getMoney.text = "得到金錢 : " + getmoney;
        
    }
}