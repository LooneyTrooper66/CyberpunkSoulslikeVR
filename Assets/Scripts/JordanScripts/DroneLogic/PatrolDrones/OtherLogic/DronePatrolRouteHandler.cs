using UnityEngine;

public class DronePatrolRouteHandler : MonoBehaviour
{
    public GameObject parent;
    [Tooltip("drone MUST start at transform[0]")]
    [SerializeField] Transform[] patrolPoints;
    int nextPoint;
    [SerializeField] float lerpTime;
    float time;
    [SerializeField] AnimationCurve lerpCurve;
    [SerializeField] Animator thisAnimator;
    public bool moveToNextPoint;
    Vector3 startPoint;
    Quaternion startRotation;
    Quaternion goalRotation;


    private void Awake()
    {
        nextPoint = 1;
        this.enabled = false;
    }

    public void StartPatrol()
    {
        startPoint = parent.transform.position;
        startRotation = parent.transform.rotation;
        goalRotation = Quaternion.LookRotation(patrolPoints[nextPoint].position - parent.transform.position);
        moveToNextPoint = true;
        time = 0;
    }

    private void Update()
    {
        // if not at patrol point, lerp towards
        // if at patrol point, play hover anim before moving to next one

        if (moveToNextPoint) MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        time += Time.deltaTime;
        if (time < lerpTime)
        {
            parent.transform.position = Vector3.Lerp(startPoint, patrolPoints[nextPoint].position, lerpCurve.Evaluate(time));
            parent.transform.rotation = Quaternion.Lerp(startRotation, goalRotation, time);
        }
        else
        {
            if (nextPoint >= (patrolPoints.Length - 1)) nextPoint = 0;
            else nextPoint++;
            moveToNextPoint = false;
            HoverAtPoint();
        }
    }

    void HoverAtPoint()
    {
        thisAnimator.SetTrigger("DroneAtPoint");
    }

    public void ResetAnimationBool()
    {
        thisAnimator.SetTrigger("DroneHover");
        StartPatrol();
    }
}
