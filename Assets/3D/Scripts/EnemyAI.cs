using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float attackRange = 1f;

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
            // Damage Player

            // Destroy itself
            Destroy(this.gameObject);
        }
    }
}