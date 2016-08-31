using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Parse;
using System.Threading.Tasks;

public class ButtonController : MonoBehaviour {
    public GameObject build;
    public GameObject buildList;
    public GameObject buildbutton;
    public GameObject backbutton;
    public GameObject LogIn;
    public GameObject LogOutbutton;
    public GameObject fightbutton;
    public Text username;
    bool loginbool = false;
    public Text levelnum;
    NowLevel userID;


    void Awake() {

    }

    void Start()
    {
        userID = GameObject.Find("Main Camera").GetComponent<NowLevel>();
        if (PlayerPrefsX.GetBool("login"))
        {
            LogIn.SetActive(false);
        }
    }
  

    public void appear()
    {
        buildList.SetActive(true);
        build.SetActive(true);
        backbutton.SetActive(true);
        buildbutton.SetActive(false);
        fightbutton.SetActive(false);
        StartCoroutine(cannotFight());
    }


    public void disappear()
    {
        buildList.SetActive(false);
        build.SetActive(false);
        backbutton.SetActive(false);
        buildbutton.SetActive(true);
        fightbutton.SetActive(true);
        StartCoroutine(canFight());

    }
    public void login()
    {

        loginbool = true;
        PlayerPrefsX.SetBool("login", loginbool);
        PlayerPrefs.SetString("UserID", username.text);
        StartCoroutine(generateItems());
        Destroy(LogIn);
    }
    public void logout()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    public void surrdener() {
        Application.LoadLevel(0);
    }
    public void fightScene()
    {
        Application.LoadLevel(1);
    }
    IEnumerator generateItems()
    {
        ParseObject gameObject = new ParseObject("User");
        var query = ParseObject.GetQuery("User").WhereEqualTo("username",username.text);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            result.DeleteAsync();
        }
        gameObject["username"] = username.text;
        gameObject["Level"] = levelnum.text;
        Task saveTask = gameObject.SaveAsync();
    }
    IEnumerator cannotFight()
    {
        ParseObject gameObject = new ParseObject("User");
        var query = ParseObject.GetQuery("User").WhereEqualTo("UserName", userID.userID);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            result["AbleToFight"] = false;
            Task saveTask = result.SaveAsync();
        }
        
    }
    IEnumerator canFight()
    {
        ParseObject gameObject = new ParseObject("User");
        var query = ParseObject.GetQuery("User").WhereEqualTo("UserName", userID.userID);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            result["AbleToFight"] = true;
            Task saveTask = result.SaveAsync();
        }
    }
}



