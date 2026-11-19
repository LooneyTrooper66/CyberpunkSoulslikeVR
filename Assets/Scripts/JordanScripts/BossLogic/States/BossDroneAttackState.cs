using UnityEngine;
using System.Collections.Generic;

// Jordan/Libby Script\\
public class BossDroneAttackState : BossState
{
    float numOfDrones = 6;
    float numDronesSpawned;
    float spawnInterval = 3;
    float spawnTimer;
    List<GameObject> drones = new List<GameObject>();


    public BossDroneAttackState(BossBase bossBase, BossStateMachineManager stateManager) : base(bossBase, stateManager)
    {
    }

    public override void EnterLogic()
    {
        base.EnterLogic();
        spawnTimer = 0; numDronesSpawned = 0;
        drones.Clear();
        bossBase.animManager.ChangeAnimation(AnimationManager.AnimationStates.droneAttack);
    }

    public override void FrameUpdate()
    {
        if (numDronesSpawned < numOfDrones)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                SpawnDrone();
                spawnTimer = 0;
            }
        }
    }

    void SpawnDrone()
    {
        GameObject drone = bossBase.pooler.SpawnFromPool("bossDrones", bossBase.droneSpawn.position, bossBase.droneSpawn.rotation);
        EnemyBase thisBase = drone.GetComponent<EnemyBase>();
        thisBase.player = bossBase.player;
        thisBase.pooler = bossBase.pooler;
        drone.GetComponent<DronePursuitLogic>().player = bossBase.player.transform;
        drone.GetComponent<CheckIfAllInactive>().thisState = this;
        drones.Add(drone);
        numDronesSpawned++;
    }

    public void CheckIfInactive()
    {
        if (CheckInactive()) ChangeToIdle();
    }

    bool CheckInactive()
    {
        foreach (GameObject d in drones)
        {
            if (d.activeSelf) return false;
        }
        return true;
    }
}
