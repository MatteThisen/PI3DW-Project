using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    private GameObject player; // Reference to the player's Transform
    private NavMeshAgent agent;
    private Animator animator;
    private int zombieAnim;
    public float health = 100f;
    private GameObject enemyManager;
    private int upperDamageBound = 20;
    private int lowerDamageBound = 10;

    void Start()
    {
        player = GameObject.Find("Player");
        enemyManager = GameObject.Find("EnemyManager");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        zombieAnim = Random.Range(0, 2);
        animator.SetInteger("zombieAnim", zombieAnim);
    }

    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Collision");
            int damage = Random.Range(lowerDamageBound, upperDamageBound);
            player.GetComponent<PlayerMovement>().PlayerTakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            enemyManager.GetComponent<EnemyManager>().EnemyDeath(gameObject);
        }
    }
}
