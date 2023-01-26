using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float attackRange = 1f;

    [SerializeField] private GameEvent boltMultiplerGameEvent;
    [SerializeField] private GameEvent resetBoltMultiplerGameEvent;

    private NavMeshAgent agent;
    private PlayerController target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<PlayerController>();
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

            // Return to object pool
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            this.gameObject.SetActive(false);
            OnDefeated();
        }
    }

    public void OnDefeated()
    {
        // Increase bolt multiplier
        boltMultiplerGameEvent.TriggerEvent();
    }
}