using UnityEngine;
using System.Collections;

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
                Instantiate(madeObject, PlayerPrefsX.GetVector3(this.gameObject.name + objectID.ToString()), PlayerPrefsX.GetQuaternion(this.gameObject.name + objectID.ToString()));

            }

        }
    }

   
    
}
