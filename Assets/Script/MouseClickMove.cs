using UnityEngine;
using System.Collections;

public class MouseClickMove : MonoBehaviour
{

    public GameObject model;
    private bool moveState = false;
    private Vector3 target = new Vector3();
    public float speed = 1;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);////(1)
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {////(2)
            if (Input.GetMouseButtonDown(0) && hit.transform.gameObject.tag == "floor")
            {
                moveState = true;////(3)
                target = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
        }
        float step = speed * Time.deltaTime;////(4)
        Vector3 targetDir = target - model.transform.position;
        Vector3 newDir = Vector3.RotateTowards(model.transform.forward, targetDir, step * 10, 0.0F);
        model.transform.rotation = Quaternion.LookRotation(newDir);////(7)

        if (moveState)
        {////(5)
            if (Vector3.Distance(model.transform.position, target) < 0.1f)
            {
                moveState = false;
            }
            model.transform.position = Vector3.MoveTowards(model.transform.position, target, step);////(6)
        }
    }
}