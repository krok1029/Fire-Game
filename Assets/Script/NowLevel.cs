using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading.Tasks;
using Parse;

public class NowLevel : MonoBehaviour {
    int level=0;
    public Text lv;
    public GameObject lampButton;
    public GameObject fireHydrantButton;
    string userID;
    public Text username;
    public Text levelnum;
    int c;
    // Use this for initialization
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
    }
    public void Login () {

        userID = username.text;
        StartCoroutine(loadLv());
       
        if (level == 0)
        {
            level = 1;
        }
       
    }
    void Update()
    {

        switch (level)
        {
            case 1:
                lampButton.SetActive(false);
                fireHydrantButton.SetActive(false);
                break;
            case 2:
                lampButton.SetActive(false);
                fireHydrantButton.SetActive(true);
                break;
            case 3:
                lampButton.SetActive(true);
                fireHydrantButton.SetActive(true);
                break;
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
        levelnum.text= level.ToString();
    }
    public void Save()
    {
        StartCoroutine(generateItems());
    }
    IEnumerator generateItems()
    {
        ParseObject gameObject = new ParseObject("User");
        var query = ParseObject.GetQuery("User").WhereEqualTo("UserName", userID);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            result.DeleteAsync();
        }

        gameObject["UserName"] =userID;
        gameObject["Level"] = level;
        Debug.Log(level);
        Task saveTask = gameObject.SaveAsync();
        Debug.Log("SAVE OK"+c);
        c++;
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
}

