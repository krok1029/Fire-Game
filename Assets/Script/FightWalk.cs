using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using UnityEngine;
using System.Collections;

public class FightWalk : MonoBehaviour
{


    GameObject model;
    public const int Obstacle_DISTANCE = 13;
    //public Transform target;
    private NavMeshAgent navMeshAgent;
    GameObject target;
    GameObject model1;
    public Transform[] points;
    private int destpoint = 0;
    public int walktype = 1;
    private FightWalk walkscript;
    public GameObject fire;
    int isfire = 0;
    int directiontop = 0;
    int direction = 1;
    GameObject rtop;
    GameObject ltop;
    GameObject rdown;
    GameObject ldown;


    void Awake()
    {
        model = this.gameObject;
        target = GameObject.Find("Fire Exit");
        
    }

    void Start()
    {

        //direction = Random.Range (0, 4);

        //Debug.Log ("time");
        navMeshAgent = GetComponent<NavMeshAgent>();

        walkscript = GameObject.Find("Player").GetComponent<FightWalk>();




        if (walkscript.walktype == 1)
        {

            destpoint = Random.Range(0, 6);
            navMeshAgent.autoBraking = false;
            //model.GetComponent<NavMeshAgent> ().acceleration = 600;
            //model.GetComponent<NavMeshAgent> ().speed = 300;
            GotoNext();

        }

    }
    
    void Update()
    {
        int alltype = GameObject.Find("Main Camera").GetComponent<Fight_Objectload>().lv;
        model.transform.rotation = Quaternion.Euler(0, 0, 0);
        model.transform.position = new Vector3(model.transform.position.x, 0, model.transform.position.z);


        //Debug.Log (model.name + " : " + alltype);
        switch (alltype)
        {

            case 1:
                if (navMeshAgent.remainingDistance < 6f)

                    GotoNext();

                break;

            case 2:
                float firedis = (fire.transform.position - model.transform.position).magnitude;

                if (firedis <= 20)
                {
                    isfire = 1;
                }
                if (isfire == 1)
                {

                    if ((fire.transform.position.x - model.transform.position.x) >= 0)
                    {
                        if ((fire.transform.position.z - model.transform.position.z) >= 0)
                        {
                            model.transform.Translate(-4.0f, 0, -4.0f);
                            //navMeshAgent.destination =ldown.transform.position;

                        }
                        else
                        {
                            model.transform.Translate(-4.0f, 0, 4.0f);
                            //navMeshAgent.destination =ltop.transform.position;
                        }
                    }

                    if ((fire.transform.position.x - model.transform.position.x) < 0)
                    {
                        if ((fire.transform.position.z - model.transform.position.z) >= 0)
                        {
                            model.transform.Translate(4.0f, 0, -4.0f);
                            //navMeshAgent.destination =rtop.transform.position;
                        }
                        else
                        {
                            model.transform.Translate(4.0f, 0, 4.0f);
                            //navMeshAgent.destination =rdown.transform.position;
                        }
                    }


                }
                else
                {
                    if (navMeshAgent.remainingDistance < 6f)
                        GotoNext();
                }

                break;

            case 3:
                float firedist = (fire.transform.position - model.transform.position).magnitude;
                if (firedist <= 20)
                {
                    isfire = 1;
                }

                if (isfire == 1)
                {


                    if ((fire.transform.position.x - model.transform.position.x) >= 0)
                    {

                        directiontop = -1;

                    }
                    else
                    {
                        directiontop = 1;

                    }






                    if (direction == 1)
                    {
                        model.transform.Translate(directiontop * 0.5f, 0, 0);
                        if (model.transform.position.x <= -48 || model.transform.position.x >= 48)
                        {
                            direction = 2;
                        }
                    }
                    if (direction == 2)
                    {
                        model.transform.Translate(0, 0, 0.5f);
                        if (model.transform.position.z >= 48)
                        {
                            direction = 3;
                        }
                    }
                    if (direction == 3)
                    {
                        navMeshAgent.destination = target.transform.position;
                        //model.transform.Translate (-directiontop*0.5f, 0, 0);
                    }


                }

                else
                {
                    if (navMeshAgent.remainingDistance < 6f)
                        GotoNext();
                }


                break;











            default:
                if (navMeshAgent.remainingDistance < 6f)
                    GotoNext();

                break;

        }
    }

    void GotoNext()
    {
        if (walkscript.points.Length == 0)
        {
            return;
        }
        navMeshAgent.destination = walkscript.points[destpoint].position;
        destpoint = (destpoint + 1) % (walkscript.points.Length);

    }


    void OnTriggerEnter(Collider exit)
    {

        if (exit.gameObject.name == "Fire Exit")
        {
            if (isfire == 1)
            {
                Destroy(model);
            }
        }
    }


}

