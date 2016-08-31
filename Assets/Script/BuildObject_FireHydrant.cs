using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class BuildObject_FireHydrant : MonoBehaviour
{
    public GameObject madeObject;
    int objectLimit;
    public int vendercounter = 0;
    private int objectID;
    private static int currentObjectID = 0;
    public Text levelnum;
    int levelnumber;
    GameObject levelNum;
    public int buildCost;
    PlayerMoney buildmoney;

    void Start()
    {
        buildmoney = GameObject.Find("Main Camera").GetComponent<PlayerMoney>();
        objectID = currentObjectID;
        currentObjectID++;
        vendercounter = Resources.FindObjectsOfTypeAll(typeof(BuildObject_FireHydrant)).Length - 3;
        levelNum = GameObject.Find("Main Camera");
        levelnumber = levelNum.GetComponent<NowLevel>().level;
        objectLimit = levelnumber;
    }
    void Update()
    {
        levelnumber = levelNum.GetComponent<NowLevel>().level;
        objectLimit = levelnumber;
        vendercounter = Resources.FindObjectsOfTypeAll(typeof(BuildObject_FireHydrant)).Length - 3;
    }
    public void makeObject()
    {
        if (buildmoney.money - buildCost > 0)
        {
            buildmoney.money -= buildCost;
            GameObject clone;
            if (vendercounter >= objectLimit)
            {
                CancelInvoke();
            }
            else
            {
                clone = Instantiate(madeObject, Input.mousePosition, Quaternion.identity) as GameObject;
                clone.transform.position = Vector3.Slerp(Input.mousePosition, new Vector3(-5.5f, 0, 4.7f), 1f);
                clone.transform.Rotate(new Vector3(-90, 0, 0));
            }
        }
        else { Debug.Log("money is not enough"); }
    }
    public void counterSave()
    {
        PlayerPrefs.SetInt("ObjectInt_FireHydrant" + objectID.ToString(), vendercounter);
    }

}