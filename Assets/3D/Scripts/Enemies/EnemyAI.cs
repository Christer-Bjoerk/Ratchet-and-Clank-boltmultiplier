using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float attackRange = 1f;


    private NavMeshAgent agent;
    private PlayerController target;

    [SerializeField] private GameEvent gameEvent;

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
            // Reset bolt multiplier

            // Damage Player

            // Return to object pool
            this.gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            this.gameObject.SetActive(false);

            // Update Bolt multiplier
            gameEvent.TriggerEvent();
        }
    }
}