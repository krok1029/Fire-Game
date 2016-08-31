using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NavWalk : MonoBehaviour
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
    private NavWalk walkscript;
    GameObject fire;
    int isfire = 0;
    int directiontop = 0;
    int directiondown = 0;
    public Button editbutton;
    public Button savebutton;


    void Awake()
    {
        model = this.gameObject;
        target = GameObject.Find("Fire Exit");
        fire = GameObject.Find("Cube");
    }

    void Start()
    {
        editbutton.onClick.AddListener(kill2);
        savebutton.onClick.AddListener(kill3);
        //direction = Random.Range (0, 4);

        //Debug.Log ("time");
        navMeshAgent = GetComponent<NavMeshAgent>();

        walkscript = GameObject.Find("Player").GetComponent<NavWalk>();




        if (walkscript.walktype == 1)
        {

            destpoint = Random.Range(0, 6);
            navMeshAgent.autoBraking = false;
            //model.GetComponent<NavMeshAgent> ().acceleration = 600;
            //model.GetComponent<NavMeshAgent> ().speed = 300;
            GotoNext();

        }

    }


    void awake()
    {

    }


    void Update()
    {
        int alltype = GameObject.Find("Main Camera").GetComponent<NowLevel>().level;
        model.transform.rotation = Quaternion.Euler(0, 0, 0);



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
                        }
                        else
                        {
                            model.transform.Translate(-4.0f, 0, 4.0f);
                        }
                    }

                    if ((fire.transform.position.x - model.transform.position.x) < 0)
                    {
                        if ((fire.transform.position.z - model.transform.position.z) >= 0)
                        {
                            model.transform.Translate(4.0f, 0, -4.0f);
                        }
                        else
                        {
                            model.transform.Translate(4.0f, 0, 4.0f);
                        }
                    }


                }
                else
                {
                    if (navMeshAgent.remainingDistance < 6f)
                        GotoNext();
                }

                break;

            /*case 3:

                if (firedis <= 20) {
                    isfire = 1;
                }

                if (isfire == 1) {

                    if ((fire.transform.position.x - model.transform.position.x) >= 0) {
                        if ((fire.transform.position.z - model.transform.position.z) >= 0) {
                            directiontop = 0;
                            //model.transform.Translate (-4.0f, 0, -4.0f);
                        } else {
                            directiondown = 1;
                            //model.transform.Translate (-4.0f, 0, 4.0f);
                        }

                    }

                    if ((fire.transform.position.x - model.transform.position.x) < 0) {

                        if ((fire.transform.position.z - model.transform.position.z) >= 0) {
                            directiontop = 2;
                            //model.transform.Translate (4.0f, 0, -4.0f);
                        } else {
                            directiondown = 3;
                            //model.transform.Translate (4.0f, 0, 4.0f);
                        }
                    }

                    switch (directiontop) {


                    }

                    switch (directiondown) {


                    }

                }





                float dis = (model.transform.position - target.transform.position).magnitude;
                if (dis < 8.0) {
                    Destroy (model);
                } else {
                    if (navMeshAgent.remainingDistance < 6f)
                        GotoNext ();
                }

                break;*/












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
    public void kill2()
    {
        model.GetComponent<Renderer>().enabled = false;
    }

    public void kill3()
    {
        model.GetComponent<Renderer>().enabled = true;
    }
}

