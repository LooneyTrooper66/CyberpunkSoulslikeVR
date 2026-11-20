using UnityEngine;
using System.Collections.Generic;

// Jordan/Libby Script\\
public class BossTileAttackState : BossState
{
    List<TileLogic> tilesUsingThisAttack = new List<TileLogic>();
    //float timeBetweenAttacks = 1f;
    //bool startAttack;
    // need a way to check if all missiles exploded


    public BossTileAttackState(BossBase bossBase, BossStateMachineManager stateManager) : base(bossBase, stateManager)
    {
    }

    public override void EnterLogic()
    {
        //startAttack = false;
        ChooseRandomAttack();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    void ChooseRandomAttack()
    {
        // will choose a random number and use that to choose attack function
        TowerAttack();
    }

    void TowerAttack()
    {
        string towerToAttack = bossBase.player.GetComponent<TestMovement>().towerCurrentlyOn; // will need to update this when make proper player script

        // to catch potential null error
        if (towerToAttack == null) RandomAttack();

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
        Debug.Log(tilesUsingThisAttack.Count);
        StartAttack();
    }
    void RandomAttack()
    {

    }

    void StartAttack()
    {
        foreach (TileLogic tile in tilesUsingThisAttack)
        {
            tile.LerpColourToRed();
            GameObject missile = bossBase.pooler.SpawnFromPool("bossMissile", bossBase.missileSpawn.position, bossBase.missileSpawn.rotation);
            missile.GetComponent<MissileLogic>().targetTile = tile.gameObject.transform;
        }
    }
}
