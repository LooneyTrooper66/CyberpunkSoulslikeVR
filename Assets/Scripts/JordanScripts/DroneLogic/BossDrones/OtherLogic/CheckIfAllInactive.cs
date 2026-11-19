using UnityEngine;

public class CheckIfAllInactive : MonoBehaviour
{
    public BossDroneAttackState thisState;


    private void OnDisable()
    {
        if (thisState != null) thisState.CheckIfInactive();
    }
}
