using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float lookRadius = 17f;
    [SerializeField] private Animator animator;
    [SerializeField]  private LayerMask layerMask;
    public bool seesPlayer = false;
    public float hitFrequency = 1.0f;
    private float hitDelta = 0.0f;
    private float TimeWalk = 0.0f;
    private float rotationSpeed = 0.9f;
    private float distanceWithPlayer;
    private Vector3 previousPosition;
    float curSpeed;
    private Transform target;
    private Scene scene;

    protected enum State
    {
        Idle,
        Chase,
        Attack
    }
    protected State currentState;


    // Start is called before the first frame update
    void Start()
    {
        target = player.transform;
        scene = SceneManager.GetActiveScene(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceWithPlayer = Vector3.Distance(target.position, transform.position);
        if (distanceWithPlayer <= lookRadius)
        {
            seesPlayer = true;
        }
        else
        {
            seesPlayer = false;
            currentState = State.Idle;
        }
        switch (currentState)
        {
            case State.Idle:
                IdleState();
                break;
            case State.Chase:
                ChaseState();
                break;
            case State.Attack:
                AttackState();
                break;
        }
    }

    private void FixedUpdate()
    {
        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;
    }

    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);

    }


    void IdleState()
    {
        TimeWalk += Time.deltaTime;
        if (TimeWalk <= 3)
        {
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);


        }
        else if (TimeWalk >= 4 && TimeWalk <= 5)
        {
            transform.Rotate(Vector3.up * Random.Range(90, 180) * rotationSpeed * Time.deltaTime);

        }
        else if (TimeWalk >= 6)
        {
            TimeWalk = 0.0f;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2))
        {
            transform.Rotate(Vector3.up * Random.Range(90, 220) * rotationSpeed * Time.deltaTime);
        }

        if (distanceWithPlayer <= lookRadius)
        {
            seesPlayer = true;
            currentState = State.Chase;

        }
    }

     void ChaseState()
    {
        if (seesPlayer == false)
        {
            currentState = State.Idle;
            return;
        }
        if (distanceWithPlayer <= navMeshAgent.stoppingDistance)
        {
            //attack the target
            currentState = State.Attack;

        }
        else
        {

            navMeshAgent.SetDestination(target.position);

            faceTarget();
        }
    }

    void AttackState()
    {
        //Check the player visibility
        if (seesPlayer == false)
        {
            currentState = State.Idle;
            return;
        }

        //check distance 
        if (distanceWithPlayer <= lookRadius && distanceWithPlayer >= navMeshAgent.stoppingDistance)
        {
            currentState = State.Chase;
        }

        faceTarget();

        //hit the player, accounting the frequency
        if (hitDelta > hitFrequency )
        {
            Hit();
            hitDelta = 0.0f;
        }
        else
        {
            hitDelta += Time.deltaTime;
        }
    }

    void Hit()
    {
        SceneManager.LoadScene(scene.name);

    }
}
