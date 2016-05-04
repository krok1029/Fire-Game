using UnityEngine;
using System.Collections;

public class SaveObjectLoading_FireHydrant : MonoBehaviour {
    public GameObject madeObject;
    private int objectID;
    private static int currentObjectID = 0;
    private int n;
    public void Start()
    {
        objectID = currentObjectID;
        currentObjectID++;
        if (PlayerPrefs.HasKey("ObjectPosition" + objectID.ToString()))
        {
            for (n = 0; n < PlayerPrefs.GetInt("ObjectInt_FireHydrant" + objectID.ToString()); n++)
            {
                Instantiate(madeObject, PlayerPrefsX.GetVector3("ObjectPosition" + objectID.ToString()), PlayerPrefsX.GetQuaternion("ObjectRotation" + objectID.ToString()));
                
            }
        }
    }



}
