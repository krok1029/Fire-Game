using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading.Tasks;
using Parse;

public class NowLevel : MonoBehaviour
{
    public int level = 0;
    public GameObject lampButton;
    public GameObject fireHydrantButton;
    string userID;
    public Text username;
    public Text levelnum;
    public Text lv;
    GameObject userNum;
    public int userValue;

    void Start()
    {

        if (PlayerPrefsX.GetBool("login"))
        {
            userID = PlayerPrefs.GetString("UserID");
            StartCoroutine(loadLv());
        }
        if (level == 0)
        {
            level = 1;
        }
        setlevelText();
        StartCoroutine(getUserNum());
    }
    public void Login()
    {

        userID = username.text;
        StartCoroutine(loadLv());

        if (level == 0)
        {
            level = 1;
        }
        StartCoroutine(getUserNum());
    }
    void Update()
    {
        if (level >= 2)
        {
            fireHydrantButton.SetActive(true);
        }
        if (level >= 3)
        {
            lampButton.SetActive(true);
        }

    }
    public void levelUp()
    {
        level = level + 1;
        setlevelText();

    }
    void setlevelText()
    {
        lv.text = "Lv. " + level.ToString();
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
        Task saveTask = gameObject.SaveAsync();
        Debug.Log("SAVE OK");
    }


    IEnumerator loadLv()
    {
        var query = ParseObject.GetQuery("User").WhereEqualTo("UserName", userID);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            level = result.Get<int>("Level");

        }
        setlevelText();
    }

    IEnumerator getUserNum()
    {
        int users;
        var query = ParseObject.GetQuery("User").WhereEqualTo("UserName", userID);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            users= result.Get<int>("userNumber");
            if (users != 0)
            {
                userValue = users;
            }
        }
    }
}

