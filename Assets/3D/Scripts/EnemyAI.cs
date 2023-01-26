using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float attackRange = 1f;

    [SerializeField] private GameEvent boltMultiplerGameEvent;
    [SerializeField] private GameEvent resetBoltMultiplerGameEvent;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        AttackTarget();
    }

    public void AttackTarget()
    {
        agent.destination = target.transform.position;

        if (Vector3.Distance(transform.position, target.transform.position) <= attackRange)
        {
            // Reset Bolt Multiplier
            resetBoltMultiplerGameEvent.TriggerEvent();

            // Damage Player

            // Destroy itself
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            OnDefeated();
        }
    }

    public void OnDefeated()
    {
        // Increase bolt multiplier
        boltMultiplerGameEvent.TriggerEvent();
    }
}