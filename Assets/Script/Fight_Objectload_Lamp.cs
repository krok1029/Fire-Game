using UnityEngine;
using System.Collections;
using Parse;

public class Fight_Objectload_Lamp : MonoBehaviour {

    public GameObject madeObject;
    string userID;
    int randomNumber;
    GameObject userNum;
    int userNumber;

    public void Start()
    {
        random();
        userNum = GameObject.Find("SceneManager");
        userNumber = userNum.GetComponent<Scenemanager>().userNumber;
        StartCoroutine(getusername());

    }


    IEnumerator generateItems()
    {
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("ObjectName", "Fire_Hydrant").WhereEqualTo("UserName", userID);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        GameObject clone;
        foreach (var result in task.Result)
        {
            clone = Instantiate(madeObject, new Vector3(result.Get<float>("PositionX"), result.Get<float>("PositionY"), result.Get<float>("PositionZ")), new Quaternion(0, 0, 0, 0)) as GameObject;
            clone.transform.Rotate(new Vector3(-90, 0, 0));
        }

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
        StartBulid();
    }
    void random()
    {
        var randomInt = Random.Range(1, 6);
        randomNumber = randomInt;
    
    }
    void StartBulid()
    {
        if (userNumber != randomNumber)
        {
            Debug.Log("Lamp"+randomNumber);
            StartCoroutine(generateItems());
        }
        else
        {
            random();
            StartBulid();

        }
    }

}
