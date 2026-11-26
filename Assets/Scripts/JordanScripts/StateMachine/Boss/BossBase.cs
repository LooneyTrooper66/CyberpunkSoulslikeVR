using UnityEngine;
using System.Collections.Generic;
using System;

// Jordan/Libby Script\\
public class BossBase : MonoBehaviour, IDamageable
{
    public BossStateMachineManager stateManager { get; set; }

    public BossIdleState idleState;
    public BossGunAttackState gunAttackState;
    public BossTileAttackState tileAttackState;
    public BossDroneAttackState droneAttackState;
    public BossDeathState deathState;

    public enum AnimationTriggers { shootGun, returnToIdle, deathAnimEnded }

    public float maxHealth;
    [HideInInspector] public float currentHealth;

    [Header("General")]
    public AnimationManager animManager;
    public GameObject player;
    public Pooler pooler;
    [Header("Gun Attack")]
    public Transform[] shootPoints;
    [Header("Tile Attack")]
    public Transform missileSpawn;
    [System.Serializable]
    public class TowerTileHolder
    {
        public string tower;
        public TileLogic[] tiles;
    }
    public List<TowerTileHolder> towerTiles;
    [Header("Drone Attack")]
    public Transform droneSpawn;
    public GameObject[] drones;

    [Header("UI")]
    public GameObject healthBar;
    public GameObject winUI;


    private void Awake()
    {
        stateManager = new BossStateMachineManager();

        idleState = new BossIdleState(this, stateManager);
        gunAttackState = new BossGunAttackState(this, stateManager);
        tileAttackState = new BossTileAttackState(this, stateManager);
        droneAttackState = new BossDroneAttackState(this, stateManager);
        deathState = new BossDeathState(this, stateManager);
    }

    private void Start()
    {
        stateManager.Initialize(idleState);

        currentHealth = maxHealth;
    }

    private void Update()
    {
        stateManager.currentState.FrameUpdate();
    }
    private void FixedUpdate()
    {
        stateManager.currentState.PhysicsUpdate();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            stateManager.ChangeState(deathState);
        }
    }

    // animation handler \\
    public void AnimationTriggerEvent(AnimationTriggers trigger)
    {
        stateManager.currentState.AnimationTriggerEvent(trigger);
    }
}
