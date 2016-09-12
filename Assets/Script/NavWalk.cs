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
    

    void Update()
    {
        int alltype = GameObject.Find("Main Camera").GetComponent<NowLevel>().level;
        model.transform.rotation = Quaternion.Euler(-15, 180, 0);
        model.transform.position = new Vector3(model.transform.position.x, 0, model.transform.position.z);


        if (navMeshAgent.remainingDistance < 6f)

            GotoNext();
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
        model.GetComponentInChildren<Renderer>().enabled = false;
    }

    public void kill3()
    {
        model.GetComponentInChildren<Renderer>().enabled = true;
    }
}

