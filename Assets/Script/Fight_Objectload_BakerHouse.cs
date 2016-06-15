using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;
using UnityEngine.UI;


public class Fight_Objectload_BakerHouse : MonoBehaviour {

    public GameObject madeObject;
    string userID;

    public void Start()
    {

        StartCoroutine(generateItems());
        
    }


    IEnumerator generateItems()
    {
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("ObjectName", "Baker_house").WhereEqualTo("UserName", userID);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        GameObject clone;
        foreach (var result in task.Result)
        {
            clone = Instantiate(madeObject, new Vector3(result.Get<float>("PositionX"), result.Get<float>("PositionY"), result.Get<float>("PositionZ")), new Quaternion(0, 0, 0, 0)) as GameObject;
            clone.transform.Rotate(new Vector3(-90, 0, 0));
        }

    }

}
