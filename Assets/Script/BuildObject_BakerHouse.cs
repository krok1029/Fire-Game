using UnityEngine;
using System.Collections;

public class BuildObject_BakerHouse : MonoBehaviour
{
    public GameObject madeObject;
    public int objectLimit;
    private int counter = 0;


   
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
      //  Debug.Log(counter);
    }

}