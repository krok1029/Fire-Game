using UnityEngine;
using System.Collections;
using Parse;
using UnityEngine.UI;

public class Fight_Objectload : MonoBehaviour {
    public GameObject madeObject_fireHydrant;
    public GameObject madeObject_lamp;
    public GameObject madeObject_bakerHouse;
    public string userID;//對手的ID
    int randomNumber;
    GameObject userNum;
    public int userNumber;//玩家ID
    public string PlayerId;
    public Text EmeryNameText;
    GameObject user;
    int[] allUser;
    public int mon;
    SelfSavingTimer money;
    ArrayList users = new ArrayList();
    public int lv;
    public GameObject Player;
    public Transform[] spawnPoints;
    GameObject[] Players = new GameObject[5];

    public void Start()
    {
        userNumber = PlayerPrefs.GetInt("userNumber");
        StartCoroutine(getallUserValue());
    }
    IEnumerator getallUserValue()
    {
        var query = ParseObject.GetQuery("User").WhereNotEqualTo("AbleToFight",false).WhereNotEqualTo("userNumber",userNumber);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        /* int result ;
        query.CountAsync().ContinueWith(t =>
         {
             result = t.Result;
             Debug.Log("count=" + result);
         });*/

        foreach (var result in task.Result)
        {
            users.Add(result.Get<string>("UserName"));
        }
        Debug.Log(users.Count);
        random();
        StartBulid();
    }
    IEnumerator getusername()
    {
        var query = ParseObject.GetQuery("User").WhereEqualTo("UserName", users[randomNumber]);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            mon = result.Get<int>("Money");
            lv = result.Get<int>("Level");
        }

    }
    IEnumerator generateItems_firehydrant()
    {
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("ObjectName", "Fire_Hydrant").WhereEqualTo("UserName", users[randomNumber]);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        GameObject clone;
        foreach (var result in task.Result)
        {
            clone = Instantiate(madeObject_fireHydrant, new Vector3(result.Get<float>("PositionX"), result.Get<float>("PositionY"), result.Get<float>("PositionZ")), new Quaternion(0, 0, 0, 0)) as GameObject;
            clone.transform.Rotate(new Vector3(-90, 0, 0));
        }

    }
    IEnumerator generateItems_bakerHouse()
    {
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("ObjectName", "Baker_house").WhereEqualTo("UserName", users[randomNumber]);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        GameObject clone;
        foreach (var result in task.Result)
        {
            clone = Instantiate(madeObject_bakerHouse, new Vector3(result.Get<float>("PositionX"), result.Get<float>("PositionY"), result.Get<float>("PositionZ")), new Quaternion(0, 0, 0, 0)) as GameObject;
            clone.transform.Rotate(new Vector3(-90, 0, 0));

            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Players = GameObject.FindGameObjectsWithTag("Man");
            int random = Random.Range(0, 4);
            clone = Instantiate(Players[random], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
        }


    }
    IEnumerator generateItems_lamp()
    {
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("ObjectName", "Lamp").WhereEqualTo("UserName", users[randomNumber]);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        GameObject clone;
        foreach (var result in task.Result)
        {
            clone = Instantiate(madeObject_lamp, new Vector3(result.Get<float>("PositionX"), result.Get<float>("PositionY"), result.Get<float>("PositionZ")), new Quaternion(0, 0, 0, 0)) as GameObject;
            clone.transform.Rotate(new Vector3(-65, 0, 0));

            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Players = GameObject.FindGameObjectsWithTag("Man");
            int random = Random.Range(0, 4);
            clone = Instantiate(Players[random], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
        }

    }
    void random()
    {
        var randomInt = Random.Range(0, users.Count);
        randomNumber = randomInt;
        Debug.Log(users[randomNumber]);
    }
    void StartBulid()
    {
        StartCoroutine(generateItems_firehydrant());
        StartCoroutine(generateItems_bakerHouse());
        StartCoroutine(generateItems_lamp());
        EmeryNameText.text = users[randomNumber].ToString();
        StartCoroutine(getusername());
    }

}
