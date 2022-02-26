using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{

    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider slider;
    [SerializeField] Text progressText;

    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    
    [SerializeField] private float lookRadius = 17f;
    [SerializeField] private Animator animator;
    [SerializeField]  private LayerMask layerMask;
    public bool seesPlayer = false;
    private float TimeWalk = 0.0f;
    private float rotationSpeed = 0.9f;
    private float distanceWithPlayer;
    private Vector3 previousPosition;
    float curSpeed;
    private Transform target;
    private Scene scene;

    //Audio
    [SerializeField] private AudioSource audioSource;
    [SerializeField] AudioClip[] attackClips;
    [SerializeField] AudioClip[] footClips;
    private float footStepTimer = 0;

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
        IdleState();
        
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
        animator.Play("Idle");
            Invoke("ChaseState", 1.0f);
    }

     void ChaseState()
    {
        animator.Play("Crawl");
        navMeshAgent.SetDestination(target.position);
        faceTarget();
        //check distance 
        if (distanceWithPlayer <= lookRadius && distanceWithPlayer >= navMeshAgent.stoppingDistance)
        {
            currentState = State.Chase;
        }

        //faceTarget();
        else { Hit(); }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
    }


    void AttackState()
    {
        //Check the player visibility

    }

    void Hit()
    {
        StartCoroutine(LoadAsync(scene.name));
        SceneManager.LoadScene(scene.name);

    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            progressText.text = progress * 100 + "%";
            yield return null;
        }
    }
}
