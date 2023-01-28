using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(ReturnObject))]
public class EnemyAI : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float attackRange = 1f;

    [Header("Events")]
    [SerializeField] private GameEvent multiplierEvent;
    [SerializeField] private GameEvent resetMultiplierEvent;

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

    /// <summary>
    /// Attacks by kamikazing the player
    /// </summary>
    public void AttackTarget()
    {
        agent.destination = target.transform.position;

        if (Vector3.Distance(transform.position, target.transform.position) <= attackRange)
        {
            // Reset bolt multiplier
            resetMultiplierEvent.TriggerEvent();

            // Damage Player

            // Return to object pool
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // Return to object pool
            this.gameObject.SetActive(false);

            // Update Bolt multiplier
            multiplierEvent.TriggerEvent();
        }
    }
}