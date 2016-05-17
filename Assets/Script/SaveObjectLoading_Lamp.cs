using UnityEngine;
using System.Collections;

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
        if (PlayerPrefs.HasKey("LampPosition" + objectID.ToString()))
        {
            for (n = 0; n < PlayerPrefs.GetInt("ObjectInt_Lamp" + objectID.ToString()); n++)
            {

                Instantiate(madeObject, PlayerPrefsX.GetVector3("LampPosition" + objectID.ToString()), new Quaternion(-90, 0, 0, 0));

            }

        }

        /*

        var query = ParseObject.GetQuery("GameObject")
            .WhereEqualTo("UserName", "user1");

        query.FindAsync().ContinueWith(t =>
        {
            IEnumerable<ParseObject> results = t.Result;
            foreach (var result in results)
            {
                float x, y, z;
                x = result.Get<float>("PositionX");
                y = result.Get<float>("PositionY");
                z = result.Get<float>("PositionZ");
                //   Debug.Log(x);

            }
        });



    }


    */
    }
}
