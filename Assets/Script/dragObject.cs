using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class dragObject : MonoBehaviour
{
    public float speed = 20;
    public Transform building ;
    public Button backbutton;
    public Button buildbutton;
    public GameObject buildlist;
    private bool i;
    RaycastHit rayHit;

    void OnMouseDrag()
    {
       
        if (buildlist.activeInHierarchy)
        {
            if (building.position.x <= 50 && building.position.x >= -50 && building.position.z <= 50 && building.position.z >= -50)
            {
                building.position += Vector3.right * Time.deltaTime * Input.GetAxis("Mouse X") * 200;
                building.position += Vector3.forward * Time.deltaTime * Input.GetAxis("Mouse Y") * 200;
            }
            else
            {
                if (building.position.x > 50)
                {
                    building.position=new Vector3(45,building.position.y,building.position.z);
                    Debug.Log("a");
                }
                if (building.position.x < -50)
                {
                    building.position = new Vector3(-45, building.position.y, building.position.z);
                    Debug.Log("b");
                }
                if (building.position.z > 50)
                {
                    building.position = new Vector3(building.position.x, building.position.y, 45);
                    Debug.Log("c");
                }
                if (building.position.z < -50)
                {
                    building.position = new Vector3(building.position.x, building.position.y, -45);
                    Debug.Log("d");
                }
            }
            /* Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out rayHit))
             {
                 if (rayHit.transform.tag == "Building")
                 {
                     building.transform.position = new Vector3(rayHit.point.x, 4, rayHit.point.z);
                 }
             }*/

        }
      
    }
    void OnMouseDown()
    {
        if (buildlist.activeInHierarchy)
        {
            building.position += new Vector3(0, 4, 0);
        }
    }

    void OnMouseUp()
    {

        if (buildlist.activeInHierarchy)
        {
            building.position += new Vector3(0, -4, 0);
        }
       
    }
}
