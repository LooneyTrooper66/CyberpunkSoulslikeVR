using UnityEngine;

// Jordan/Libby Script\\
public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    public enum AnimationStates
    {
        Idle,
        gunAttack,
        tileAttack,
        droneAttack,
        Destroyed
    }


    public void ChangeAnimation(AnimationStates state)
    {
        switch (state)
        {
            case AnimationStates.Idle: animator.SetTrigger("ToIdle"); break;
            case AnimationStates.gunAttack: animator.SetTrigger("ToGunAttack"); break;
            case AnimationStates.tileAttack: animator.SetTrigger("ToIdle"); break;
            case AnimationStates.droneAttack: animator.SetTrigger("ToDroneAttack"); break;
            case AnimationStates.Destroyed: animator.SetTrigger("ToDestroyed"); break;
            default: animator.SetTrigger("ToIdle"); break;
        }
    }
}
