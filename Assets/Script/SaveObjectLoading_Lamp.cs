using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;
using UnityEngine.UI;

public class SaveObjectLoading_Lamp : MonoBehaviour
{
    public GameObject madeObject;
    string userID;
    public Text username;
    // int objectID;
    //private static int currentObjectID = 0;
    // private int n;
    public void Start()
    {      
        if (PlayerPrefsX.GetBool("login"))
        {
            userID = PlayerPrefs.GetString("UserID");
            StartCoroutine(generateItems());
        }
    }
    public void Login()
    {
        userID = username.text;
        StartCoroutine(generateItems());
    }
    IEnumerator generateItems()
    {

        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("ObjectName", "Lamp").WhereEqualTo("UserName", userID);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        GameObject clone;
        foreach (var result in task.Result)
        {
            clone = Instantiate(madeObject, new Vector3(result.Get<float>("PositionX"), 5f, result.Get<float>("PositionZ")), new Quaternion(0, 0, 0, 0)) as GameObject;
            clone.transform.Translate(new Vector3(0, 0f, 0));
        }

    }


}

