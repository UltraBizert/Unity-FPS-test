using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPC : HitEntity
{
    private NPCConfig config { get; set; }
    private NavMeshAgent navMeshAgent { get; set; }
    private HitEntity target { get; set; }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Initialize(NPCConfig config, HitEntity target)
    {
        this.config = config;
        this.target = target;
        navMeshAgent.speed = config.MoveSpeed;
        SetUpHealth(config.Health);
    }

    public void Resurrect()
    {
        SetUpHealth(config.Health);
        gameObject.SetActive(true);
    }

    public void UpdateTick()
    {
        if (IsDied) return;

        MovementTick();
        AttackTick();
    }

    private void MovementTick()
    {
        UpdateTarget();
    }

    private void UpdateTarget()
    {
        navMeshAgent.SetDestination(target.transform.position);
    }

    private float attackCooldown;

    private void AttackTick()
    {
        attackCooldown -= Time.deltaTime;

        if (CanAttack())
            Attack();
    }

    private bool CanAttack() =>
        Vector3.Distance(target.transform.position, transform.position) < config.AttackRange &&
        attackCooldown <= 0;

    private void Attack()
    {
        target.OnHit(config.Damage);
        attackCooldown = config.AttackDelay;
    }

}
