using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class dragObject_lamp : MonoBehaviour {

    public float speed = 20;
    public Transform building;
    public Button backbutton;
    public Button buildbutton;
    public GameObject buildlist;
    private bool i;
    RaycastHit rayHit;

    void OnMouseDrag()
    {
        Debug.Log("pos" + building.position);
        if (buildlist.activeInHierarchy)
        {
            if (building.position.x <= 50 && building.position.x >= -50 && building.position.z <= 50 && building.position.z >= -50)
            {
                building.position += Vector3.right * Time.deltaTime * Input.GetAxis("Mouse X") * 150;
                building.position += Vector3.forward * Time.deltaTime * Input.GetAxis("Mouse Y") * 150;
            }
            else
            {
                if (building.position.x > 50)
                {
                    building.position = new Vector3(45, building.position.y, building.position.z);
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

            int x = (int)(Mathf.Round(building.position.x / 5)) * 5;
            if (x > 0) { x = (x / 10) * 10 + 5; }
            if (x < 0) x = (x / 10) * 10 - 5;
            if (x > 45) x = 45;
            if (x < -45) x = -45;
            //Debug.Log("x=" + x);
            int z = (int)(Mathf.Round(building.position.z / 5)) * 5;
            if (z > 0) z = (z / 10) * 10 + 5;
            if (z < 0) z = (z / 10) * 10 - 5;
            if (z > 45) z = 45;
            if (z < -45) z = -45;
            //Debug.Log("z=" + z);
            building.position = new Vector3(x, 0, z);
        }

    }
}
