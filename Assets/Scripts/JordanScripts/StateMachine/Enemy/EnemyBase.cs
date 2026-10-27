using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    public EnemyStateMachineManager stateManager { get; set; }
    public Pooler pooler;
    public Transform shootPoint;
    public GameObject player;

    // Concrete States \\
    public DronePatrolState patrolState;
    public DroneChaseState chaseState;
    public DroneAttackState attackState;

    // Scriptable Object States \\
    [SerializeField] EnemyPatrolSOBase patrolBase;
    [SerializeField] EnemyChaseSOBase chaseBase;
    [SerializeField] EnemyAttackSOBase attackBase;
    public EnemyPatrolSOBase patrolBaseInstance { get; set; }
    public EnemyChaseSOBase chaseBaseInstance { get; set; }
    public EnemyAttackSOBase attackBaseInstance { get; set; }

    // Aggro Bools \\
    public bool IsAggroed { get; set; }
    public bool IsWithinAttackDist { get; set; }

    // Stats \\
    [SerializeField] float maxHealth;
    float currentHealth;


    private void Awake()
    {
        stateManager = new EnemyStateMachineManager();
        patrolBaseInstance = Instantiate(patrolBase);
        chaseBaseInstance = Instantiate(chaseBase);
        attackBaseInstance = Instantiate(attackBase);

        patrolState = new DronePatrolState(this, stateManager);
        chaseState = new DroneChaseState(this, stateManager);
        attackState = new DroneAttackState(this, stateManager);

        currentHealth = maxHealth;
    }
    private void Start()
    {
        patrolBaseInstance.Initialize(this, gameObject);
        chaseBaseInstance.Initialize(this, gameObject);
        attackBaseInstance.Initialize(this, gameObject);

        stateManager.Initialize(patrolState);
    }

    #region // State Updates \\
    private void Update()
    {
        stateManager.currentState.FrameUpdate();
    }
    private void FixedUpdate()
    {
        stateManager.currentState.PhysicsUpdate();
    }
    #endregion

    #region For states to know internally when to switch
    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }
    public void SetAttackDistBool(bool isWithinAttackDist)
    {
        IsWithinAttackDist = isWithinAttackDist;
    }
    #endregion

    // Enemy Stats Stuff \\
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        Debug.Log("ded");
    }
}
