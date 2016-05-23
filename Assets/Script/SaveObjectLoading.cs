using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;

public class SaveObjectLoading : MonoBehaviour {
    public GameObject madeObject;
    private int objectID;
    private static int currentObjectID = 0;
    private int n;
    private int i=0;

    public void Start()
    {

        objectID = currentObjectID;
        currentObjectID++;
        /*  if (PlayerPrefs.HasKey("Baker_HousePosition" + objectID.ToString()))
          {
              for (n = 0; n < PlayerPrefs.GetInt("ObjectInt_BakerHouse" + objectID.ToString());n++)
              {

                  Instantiate(madeObject, PlayerPrefsX.GetVector3("Baker_HousePosition" + objectID.ToString()), new Quaternion(-90, 0, 0, 0));

              }

          }


      */
        StartCoroutine(generateItems());

    }
    IEnumerator generateItems()
    {
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("UserName", "user1").WhereEqualTo("ObjectName", "Baker_house (Clone)");
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        GameObject clone;
        foreach (var result in task.Result)
        {
          clone=  Instantiate(madeObject, new Vector3(result.Get<float>("PositionX"), result.Get<float>("PositionY"), result.Get<float>("PositionZ")), new Quaternion(0,0,0,0)) as GameObject;
          clone.transform.Rotate(new Vector3(-90, 0, 0));
        }

    }

}
