using UnityEngine;
using System.Collections;

public class BuildObject : MonoBehaviour
{
    public GameObject madeObject;
    public int objectLimit;
    private int counter=0;
    GameObject clone;

    private GameObject Object;
    
    public void makeObject()
    {
        
        if (counter == objectLimit)
        {
            CancelInvoke();
        }
        else
        {
            clone = Instantiate(madeObject, Input.mousePosition, Quaternion.identity) as GameObject;
            clone.transform.position = Vector3.Slerp(Input.mousePosition, new Vector3(5, 4.793643f, 3), 1f);
            counter = counter + 1;           
        }
        
        
    }

}