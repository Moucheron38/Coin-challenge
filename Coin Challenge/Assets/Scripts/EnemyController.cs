using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IDamageable
{
    public enum PatrolBehaviour { PatrolLinear, PatrolRandom }
    private enum Behaviour { Idle, Patrol, Chase }
    public PatrolBehaviour patrolBehaviour;
    [SerializeField] NavMeshAgent agent;
    private Coroutine activeCoroutine;
    public bool activeOnStart = true;
    [SerializeField] private WaypointPath _waypointPath;

    [SerializeField] private float _speed;

    private Behaviour activeBehaviour;

    private GameObject playerGO;



    private int _targetWaypointIndex;


    private Transform _targetWaypoint;

    public Transform targetPoint { get { return transform; } }

    void Start()
    {
        if (activeOnStart) StartBehaviour(Behaviour.Patrol);

    }

    void StartBehaviour(Behaviour behaviour)
    {
        if (behaviour == activeBehaviour) return;
        if (activeCoroutine != null) StopCoroutine(activeCoroutine);

        activeBehaviour = behaviour;

        switch (behaviour)
        {
            case Behaviour.Chase:
                activeCoroutine = StartCoroutine(ChaseCorout());
                break;

            case Behaviour.Patrol:
                activeCoroutine = StartCoroutine(PatrolCorout());
                break;

            case Behaviour.Idle:
                activeCoroutine = null;
                break;


        }


    }


    private Vector3 GetNextWayPoint()
    {


        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);


        return _targetWaypoint.position;
    }


    public void OnDamage()
    {

    }

    public void OnDeath()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            playerGO = other.gameObject;
            StartBehaviour(Behaviour.Chase);

        }
    }

    IEnumerator ChaseCorout()
    {
        float dist = 0;
        do
        {
            agent.SetDestination(playerGO.transform.position);
            dist = Vector3.Distance(transform.position, playerGO.transform.position);

            if (dist < 0.5f)
            {
                LifeSystem lifeSystem = playerGO.gameObject.GetComponent<LifeSystem>();
                lifeSystem.SetDamage(1);
                agent.isStopped = true;
                yield return new WaitForSeconds(2);
                agent.isStopped = false;
            }

            yield return null;
        }

        while (dist < 10);

        StartBehaviour(Behaviour.Patrol);


    }

    IEnumerator PatrolCorout()
    {
        Vector3 target = Vector3.zero;

        while (true)
        {
            switch (patrolBehaviour)
            {
                case PatrolBehaviour.PatrolLinear:
                    target = GetNextWayPoint();
                    break;

                case PatrolBehaviour.PatrolRandom:
                    target = _waypointPath.GetRandWayPoint();
                    break;
            }
            agent.SetDestination(target);

            while (agent.pathPending) yield return null;

            if (agent.pathStatus == NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(GetNextWayPoint());
            }
            while (agent.remainingDistance > 0.5f)
                yield return null;


        }
    }
}

