using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading.Tasks;
using Parse;
using System;

public class NowLevel : MonoBehaviour
{
    public int level;
    public GameObject lampButton;
    public GameObject fireHydrantButton;
  //  public GameObject WaterButton;
    public string userID;
    public Text username;
    public Text levelnum;
    public Text lv;
    GameObject userNum;
    public int userValue;
    DateTime loadtime;
    public TimeSpan timediffer;
    public int totaltime;
    PlayerMoney money;
    Scenemanager userNumber;
    int[] cost = new int[3];
    public Text consoleText;
    public GameObject console;

    void Start()
    {
        level = 0;
        money = GameObject.Find("Main Camera").GetComponent<PlayerMoney>();
        if (PlayerPrefsX.GetBool("login"))
        {
            userID = PlayerPrefs.GetString("UserID");
            StartCoroutine(getUserNum());
        }
    }
    public void Login()
    {
        userID = username.text;
        StartCoroutine(getUserNum());
    }
    public void levelUp()
    {
        cost[0] = 200;
        cost[1] = 300;
        cost[2] = 500;
        int fakeLv;
        fakeLv = level;
        if (level >= 3) { fakeLv = 3; }
        if (money.money - cost[fakeLv - 1] >= 0)
        {
            level = level + 1;
            money.money -= cost[fakeLv - 1];
            setlevelText();
        }
        else
        {
            consoleText.text = "Money is not enough";
            console.SetActive(true);
        }
    }
    void setlevelText()
    {
        if (level == 0)
        {
            level = 1;
        }
        if (level >= 2)
        {
            fireHydrantButton.SetActive(true);
        }
        if (level >= 3)
        {
            lampButton.SetActive(true);
        //    WaterButton.SetActive(true);
        }
        lv.text = "Lv. " + level.ToString()+"  " + userID ;
        levelnum.text = level.ToString();
    }
    public void Save()
    {
        if (userValue != 0)
        {
            Debug.Log("userValue=" + userValue);
            StartCoroutine(SaveUser());
        }
        else
        {
            userNum = GameObject.Find("Main Camera");
            userValue = userNum.GetComponent<userCounter>().counter + 1;
            StartCoroutine(SaveUser());
        }
    }
    public void MoneyCount()
    {
        timediffer = DateTime.Now.Subtract(loadtime);
        if (timediffer.Days <= 365)
        {
            totaltime = timediffer.Days * 1440 + timediffer.Hours * 60 + timediffer.Minutes;
        }
        else
        {
            totaltime = 0;
        }
    }
    IEnumerator SaveUser()
    {
        ParseObject gameObject = new ParseObject("User");
        var query = ParseObject.GetQuery("User").WhereEqualTo("UserName", userID);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            result.DeleteAsync();
        }
        gameObject["UserName"] = userID;
        gameObject["Level"] = level;
        gameObject["userNumber"] = userValue;
        gameObject["Money"] = money.money;
        gameObject["SaveTime"] = DateTime.Now;

        Task saveTask = gameObject.SaveAsync();
        Debug.Log("SAVE OK");
    }
    IEnumerator getUserNum()
    {
        int users;
        var query = ParseObject.GetQuery("User").WhereEqualTo("UserName", userID);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            level = result.Get<int>("Level");
            users = result.Get<int>("userNumber");
            money.money = result.Get<int>("Money");
            loadtime = result.Get<DateTime>("SaveTime");
            if (users != 0)
            {
                userValue = users;
            }
            MoneyCount();
        }
        setlevelText();
        PlayerPrefs.SetInt("userNumber", userValue);
    }
}

