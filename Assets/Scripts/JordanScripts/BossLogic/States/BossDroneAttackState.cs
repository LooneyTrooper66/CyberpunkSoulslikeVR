using UnityEngine;
using System.Collections.Generic;

// Jordan/Libby Script\\
public class BossDroneAttackState : BossState
{
    int numDronesSpawned;
    float spawnInterval = 1;
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
        if (numDronesSpawned < bossBase.drones.Length)
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
        GameObject drone = bossBase.drones[numDronesSpawned];
        drone.transform.position = bossBase.droneSpawn.position;
        drone.transform.rotation = bossBase.droneSpawn.rotation;
        drone.GetComponent<CheckIfAllInactive>().thisState = this;
        drone.SetActive(true);
        drones.Add(drone);
        numDronesSpawned++;
    }

    // called by each drone on disable (when they 'die')
    public void CheckIfInactive()
    {
        // if all drones are inactive, return to idle state
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
