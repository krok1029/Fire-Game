using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;

public class SaveObjectLoading : MonoBehaviour {
    public GameObject madeObject;
    private int objectID;
    private static int currentObjectID = 0;
    private int n;
    public void Start()
    {
        objectID = currentObjectID;
        currentObjectID++;
        if (PlayerPrefs.HasKey(this.gameObject.name + objectID.ToString()))
        {
            for (n = 0; n < PlayerPrefs.GetInt("ObjectInt_BakerHouse" + objectID.ToString());n++)
            {
                //Instantiate(madeObject,new Vector3(0.1f,1f,2f), PlayerPrefsX.GetQuaternion(this.gameObject.name + objectID.ToString()));
                Instantiate(madeObject, PlayerPrefsX.GetVector3(this.gameObject.name + objectID.ToString()), PlayerPrefsX.GetQuaternion(this.gameObject.name + objectID.ToString()));

            }

        }
        

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
                Debug.Log(x);
                
            }
        });

        Instantiate(madeObject, new Vector3(1f, 1f, 1f), new Quaternion(0f, 0f, 0f, 0f));
        Instantiate(madeObject, new Vector3(2f, 2f, 2f), new Quaternion(0f, 0f, 0f, 0f));

    }



}
