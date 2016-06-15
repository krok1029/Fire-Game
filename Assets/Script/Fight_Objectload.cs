using UnityEngine;
using System.Collections;
using Parse;
using UnityEngine.UI;

public class Fight_Objectload : MonoBehaviour {


    public GameObject madeObject_fireHydrant;
    public GameObject madeObject_lamp;
    public GameObject madeObject_bakerHouse;
    string userID;
    int randomNumber;
    GameObject userNum;
    int userNumber;
    public Text EmeryNameText;
    public void Start()
    {
        random();
        userNum = GameObject.Find("SceneManager");
        userNumber = userNum.GetComponent<Scenemanager>().userNumber;
        Debug.Log("usernum ==  "+userNumber);
        Debug.Log("random ==" + randomNumber);
        StartCoroutine(getusername());
    }

    IEnumerator getusername()
    {
        var query = ParseObject.GetQuery("User").WhereEqualTo("userNumber", randomNumber);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            userID = result.Get<string>("UserName");
        }

        Debug.Log("username="+userID);
        StartBulid();
    }
        IEnumerator generateItems_firehydrant()
    {
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("ObjectName", "Fire_Hydrant").WhereEqualTo("UserName", userID);
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
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("ObjectName", "Baker_house").WhereEqualTo("UserName", userID);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        GameObject clone;
        foreach (var result in task.Result)
        {
            clone = Instantiate(madeObject_bakerHouse, new Vector3(result.Get<float>("PositionX"), result.Get<float>("PositionY"), result.Get<float>("PositionZ")), new Quaternion(0, 0, 0, 0)) as GameObject;
            clone.transform.Rotate(new Vector3(-90, 0, 0));
        }


    }
    IEnumerator generateItems_lamp()
    {
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("ObjectName", "Lamp").WhereEqualTo("UserName", userID);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        GameObject clone;
        foreach (var result in task.Result)
        {
            clone = Instantiate(madeObject_lamp, new Vector3(result.Get<float>("PositionX"), result.Get<float>("PositionY"), result.Get<float>("PositionZ")), new Quaternion(0, 0, 0, 0)) as GameObject;
            clone.transform.Rotate(new Vector3(0, 0, 0));
        }

    }
    void random()
    {
        var randomInt = Random.Range(1, 10);
        randomNumber = randomInt;

    }
    void StartBulid()
    {
        if (userNumber != randomNumber)
        {
            Debug.Log(randomNumber);
            StartCoroutine(generateItems_firehydrant());
            StartCoroutine(generateItems_bakerHouse());
            StartCoroutine(generateItems_lamp());
            EmeryNameText.text = userID;

        }
        else
        {
            random();
            StartBulid();
        }
    }

}
