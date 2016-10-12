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
    GameObject water;
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
        water = GameObject.Find("Fire_Hydrant");
        rtop = GameObject.Find("rtop");
        ltop = GameObject.Find("ltop");
        rdown = GameObject.Find("rdowm");
        ldown = GameObject.Find("ldown");
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
        Debug.Log("LV:" + alltype);
        model.transform.rotation = Quaternion.Euler(0, 0, 0);


        //Debug.Log (model.name + " : " + alltype);


        if (isfire == 0)
        {
            if (navMeshAgent.remainingDistance < 8f)
                GotoNext();
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

    void OnTriggerStay(Collider onfire)
    {
        if (onfire.gameObject.tag == "Fire")
        {
            isfire = 1;
            int alltype = GameObject.Find("Main Camera").GetComponent<Fight_Objectload>().lv;

            switch (alltype)
            {
                case 1://不躲火
                    Update();
                    break;

                case 2://躲到第一個火反方向的角落

                    if (isfire == 1)
                    {

                        if ((onfire.transform.position.x - model.transform.position.x) >= 0)
                        {
                            if ((onfire.transform.position.z - model.transform.position.z) >= 0)
                            {
                                //model.transform.Translate(-4.0f, 0, -4.0f);
                                navMeshAgent.destination = ldown.transform.position;

                            }
                            else
                            {
                                //model.transform.Translate(-4.0f, 0, 4.0f);
                                navMeshAgent.destination = ltop.transform.position;
                            }
                        }

                        if ((onfire.transform.position.x - model.transform.position.x) < 0)
                        {
                            if ((onfire.transform.position.z - model.transform.position.z) >= 0)
                            {
                                //model.transform.Translate(4.0f, 0, -4.0f);
                                navMeshAgent.destination = rtop.transform.position;
                            }
                            else
                            {
                                //model.transform.Translate(4.0f, 0, 4.0f);
                                navMeshAgent.destination = rdown.transform.position;
                            }
                        }


                    }


                    break;

                case 3://不怕火直奔出口
                    if (isfire == 1)
                    {
                        navMeshAgent.destination = target.transform.position;
                    }
                    break;



                default://扭來扭去躲火到出口

                    if (isfire == 1)
                    {


                        if ((onfire.transform.position.x - model.transform.position.x) >= 0)
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

                        navMeshAgent.destination = target.transform.position;
                        //model.transform.Translate (-directiontop*0.5f, 0, 0);


                    }




                    break;

            }


        }
    }

}