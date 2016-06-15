using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class BuildObject : MonoBehaviour
{
    public GameObject madeObject;
    int objectLimit;
    private int counter = 0;
    private int objectID;
    private int currentObjectID = 0;
    public Text levelnum;
    int levelnumber;
    GameObject levelNum;

    void Start()
    {
        objectID = currentObjectID;
        currentObjectID++;
        counter = PlayerPrefs.GetInt("ObjectInt_Lamp" + objectID.ToString());
        levelNum = GameObject.Find("Main Camera");
        levelnumber = levelNum.GetComponent<NowLevel>().level;
        objectLimit = levelnumber;

    }
    void Update()
    {
        levelnumber = levelNum.GetComponent<NowLevel>().level;
        objectLimit = levelnumber;
    }
    public void makeObject()
    {
        GameObject clone;
        if (counter >= objectLimit)
        {
            CancelInvoke();
        }
        else
        {
            clone = Instantiate(madeObject, Input.mousePosition, Quaternion.identity) as GameObject;
            clone.transform.position = Vector3.Slerp(Input.mousePosition, new Vector3(-5.5f, 5.0f, 4.7f), 1f);
            clone.transform.Rotate(new Vector3(0, 0, 0));
            counter = counter + 1;
        }
        
    }
    public void counterSave()
    {
        PlayerPrefs.SetInt("ObjectInt_Lamp" + objectID.ToString(), counter);
    }


}