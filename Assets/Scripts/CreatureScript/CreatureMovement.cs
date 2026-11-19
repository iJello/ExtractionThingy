using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class CreatureMovement : MonoBehaviour
{
    [SerializeField] private float wanderRadius = 10f;
    [SerializeField] private float minWaitTime = 1f;
    [SerializeField] private float maxWaitTime = 4f;
    
    [SerializeField] private float detectionRadius = 10f;

    private NavMeshAgent navMesh;
    private Vector3 center;
    private float waitTimer;
    
    private Transform player;
    private bool isChasing;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        center = transform.position; 
        NewDestination();
        
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            player = p.transform;
        }

    }

    void Update()
    {
        if (player != null)
        {
            float distToPlayer = Vector3.Distance(transform.position, player.position);
            isChasing = distToPlayer <= detectionRadius;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Wander();
        }
    }

    void NewDestination()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * wanderRadius;
            randomPoint.y = center.y;

            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, wanderRadius, NavMesh.AllAreas))
            {
                navMesh.SetDestination(hit.position);
                return;
            }
        }
    }

    void ChasePlayer()
    {
        navMesh.SetDestination(player.position);
    }

    void Wander()
    {
        if (waitTimer > 0f)
        {
            waitTimer -= Time.deltaTime;
            return;
        }

        if (!navMesh.pathPending && navMesh.remainingDistance <= navMesh.stoppingDistance + 0.1f)
        {
            NewDestination();
            waitTimer = Random.Range(minWaitTime, maxWaitTime);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Test");
            SceneManager.LoadScene("BattleScene");
        }
    }
}