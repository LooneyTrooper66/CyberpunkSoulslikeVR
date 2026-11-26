using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Jordan/Libby Script\\
public class BossTileAttackState : BossState
{
    List<TileLogic> tilesUsingThisAttack = new List<TileLogic>();
    List<GameObject> missilesUsingThisAttack = new List<GameObject>();
    float timeBetweenAttacks = 0.2f;
    float timeSinceLastAttack;
    bool startAttack;
    int currentAttack;
    int totalAttacks;
    // need a way to check if all missiles exploded


    public BossTileAttackState(BossBase bossBase, BossStateMachineManager stateManager) : base(bossBase, stateManager)
    {
    }

    public override void EnterLogic()
    {
        missilesUsingThisAttack.Clear();
        tilesUsingThisAttack.Clear();
        timeSinceLastAttack = 0;
        startAttack = false;
        currentAttack = 0;
        ChooseRandomAttack();
    }

    public override void FrameUpdate()
    {
        if (startAttack)
        {
            timeSinceLastAttack += Time.deltaTime;
            if (timeSinceLastAttack >= timeBetweenAttacks)
            {
                timeSinceLastAttack = 0;
                SpawnMissile(currentAttack);
                currentAttack++;
                if (currentAttack >= totalAttacks) startAttack = false;
            }
        }
    }

    void ChooseRandomAttack()
    {
        // choose a random number and use that to choose attack function
        //float attack = Random.Range(0, 2);
        float attack = 2;
        switch (attack)
        {
            case 0: SingleTowersTiles(); break;
            case 1: AllTowersTilesRandom(); break;
            case 2: SingleTowersTilesRandom(); break;
        }
            
    }

    void SingleTowersTiles()
    {
        string towerToAttack = bossBase.player.GetComponent<TestMovement>().towerCurrentlyOn; // will need to update this when make proper player script

        // to catch potential null error
        if (towerToAttack == null) AllTowersTilesRandom();

        foreach (BossBase.TowerTileHolder holder in bossBase.towerTiles)
        {
            if (holder.tower == towerToAttack)
            {
                for (int i = 0; i < holder.tiles.Length; i++)
                {
                    tilesUsingThisAttack.Add(holder.tiles[i]);
                }
            }
        }
        totalAttacks = tilesUsingThisAttack.Count;
        startAttack = true;
    }
    void AllTowersTilesRandom()
    {
        foreach (BossBase.TowerTileHolder holder in bossBase.towerTiles)
        {
            for (int i = 0; i < holder.tiles.Length; i++)
            {
                int use = Random.Range(0, 2);
                if (use >= 1)
                {
                    Debug.Log("added " + holder.tower + holder.tiles[i]);
                    tilesUsingThisAttack.Add(holder.tiles[i]);
                }
            }
        }
        totalAttacks = tilesUsingThisAttack.Count;
        startAttack = true;
    }
    void SingleTowersTilesRandom()
    {
        Debug.Log("single random");
        string towerToAttack = bossBase.player.GetComponent<TestMovement>().towerCurrentlyOn; // will need to update this when make proper player script

        // to catch potential null error
        if (towerToAttack == null) AllTowersTilesRandom();

        foreach (BossBase.TowerTileHolder holder in bossBase.towerTiles)
        {
            if (holder.tower == towerToAttack)
            {
                for (int i = 0; i < holder.tiles.Length; i++)
                {
                    int use = Random.Range(0, 2);
                    if (use >= 1)
                    {
                        Debug.Log("added " + holder.tower + holder.tiles[i]);
                        tilesUsingThisAttack.Add(holder.tiles[i]);
                    }
                }
            }
        }
        totalAttacks = tilesUsingThisAttack.Count;
        startAttack = true;
    }

    void SpawnMissile(int tile)
    {
        tilesUsingThisAttack[tile].LerpColourToRed();
        GameObject missile = bossBase.pooler.SpawnFromPool("bossMissile", bossBase.missileSpawn.position, bossBase.missileSpawn.rotation);
        missilesUsingThisAttack.Add(missile);
        missile.GetComponent<MissileLogic>().SpawnMissile(tilesUsingThisAttack[tile].transform, this);
    }

    public void CheckAllMissilesUsed()
    {
        int inactive = 0;
        foreach (GameObject m in missilesUsingThisAttack)
        {
            if (m.activeSelf == false) inactive++;
        }
        //Debug.Log(inactive + " " + missilesUsingThisAttack.Count);

        if (inactive >= missilesUsingThisAttack.Count) ChangeToIdle();
    }
}
