using UnityEngine;
using System.Collections;

public class BuildObject_FireHydrant : MonoBehaviour
{
    public GameObject madeObject;
    public int objectLimit;
    private int counter = 0;
    private int objectID;
    private static int currentObjectID = 0;

    void Start()
    {
        objectID = currentObjectID;
        currentObjectID++;
        counter = PlayerPrefs.GetInt("ObjectInt_FireHydrant" + objectID.ToString());
    }
    public void makeObject()
    {
        GameObject clone;
        if (counter == objectLimit)
        {
            CancelInvoke();
        }
        else
        {
            clone = Instantiate(madeObject, Input.mousePosition, Quaternion.identity) as GameObject;
            clone.transform.position = Vector3.Slerp(Input.mousePosition, new Vector3(-5.5f, 0, 4.7f), 1f);
            clone.transform.Rotate(new Vector3(-90, 0, 0));
            counter = counter + 1;
        }
      
    }
    public void counterSave()
    {
        PlayerPrefs.SetInt("ObjectInt_FireHydrant" + objectID.ToString(), counter);
    }

}