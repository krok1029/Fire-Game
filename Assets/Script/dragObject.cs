using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class dragObject : MonoBehaviour
{
    public float speed = 15;
    public Transform building ;
    public Button backbutton;
    public Button buildbutton;
    public GameObject buildlist;
    private bool i;
 
    void OnMouseDrag()
    {
        if (buildlist.activeInHierarchy)
        {
            i = true;
        }
        else
        {
            i = false;
        }


       // Debug.Log(buildlist.activeInHierarchy);
        if (i == true)
        {
            speed = 15;
        }
        else {
            speed = 0;
        }

        building.position += Vector3.right * Time.deltaTime * Input.GetAxis("Mouse X") * speed * 10;
        building.position += Vector3.forward * Time.deltaTime * Input.GetAxis("Mouse Y") * speed * 10;
    
    
    }
    
   
}
