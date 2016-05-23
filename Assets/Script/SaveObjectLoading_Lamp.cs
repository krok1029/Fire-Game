using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;

public class SaveObjectLoading_Lamp : MonoBehaviour
{
    public GameObject madeObject;
    private int objectID;
    private static int currentObjectID = 0;
    private int n;
    public void Start()
    {

        objectID = currentObjectID;
        currentObjectID++;
        /*  if (PlayerPrefs.HasKey("LampPosition" + objectID.ToString()))
          {
              for (n = 0; n < PlayerPrefs.GetInt("ObjectInt_Lamp" + objectID.ToString()); n++)
              {

                  Instantiate(madeObject, PlayerPrefsX.GetVector3("LampPosition" + objectID.ToString()), new Quaternion(-90, 0, 0, 0));

              }

          }*/
        StartCoroutine(generateItems());
    }

    IEnumerator generateItems()
    {

        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("UserName", "user1").WhereEqualTo("ObjectName", "Lamp(Clone)");
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        GameObject clone;
        foreach (var result in task.Result)
        {
            clone = Instantiate(madeObject, new Vector3(result.Get<float>("PositionX"), result.Get<float>("PositionY"), result.Get<float>("PositionZ")), new Quaternion(0, 0, 0, 0)) as GameObject;
            clone.transform.Translate(new Vector3(0, 4.6f, 0));
        }

    }


}

