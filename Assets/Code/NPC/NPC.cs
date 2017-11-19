using UnityEngine;
using UnityEngine.AI;

public enum NPCStates
{
    Stay,
    Patrol,
    RunAway
}

[RequireComponent(typeof(Rigidbody),typeof(NavMeshAgent),typeof(Animator))]
public class NPC : MonoBehaviour, IInitable
{
    protected const float distanceToPointTreshhold = 2f;

    public float RunSpeed;
    public float WalkSpeed;
    public GameObject target;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private NPCStates currentState = NPCStates.Patrol;

    private bool havePatrolPoint;
    private Transform currentPatrolPoint;

    void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (!animator)
            animator = GetComponent<Animator>();
        if (!navMeshAgent)
            navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void DeInit()
    {
        
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case NPCStates.Stay:
                Stay();
                break;
            case NPCStates.Patrol:
                Patrol();
                break;
            case NPCStates.RunAway:
                RunAway();
                break;
        }
    }

    private void Stay()
    {
        
    }

    private void Patrol()
    {
        if (!havePatrolPoint || Vector3.Distance(transform.position, currentPatrolPoint.position) <=
            distanceToPointTreshhold)
        {
            currentPatrolPoint = PatrolManager.Instance.GetPatrolPoint();
            havePatrolPoint = true;
        }

        navMeshAgent.destination = currentPatrolPoint.position;
        ChangeMovementType(WalkSpeed, 0.1f);
    }

    private void RunAway()
    {
        
    }

    private void ChangeMovementType(float agentSpeed, float forward)
    {
            navMeshAgent.speed = agentSpeed;
            animator.SetFloat("Forward", forward);
    }
}