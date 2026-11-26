using UnityEngine;

// Jordan/Libby Script\\
public class MissileLogic : MonoBehaviour
{
    public BossTileAttackState thisTileState;
    Vector3 center = new Vector3(0, 40, 0);
    [SerializeField] Vector3 startPos;
    public Transform targetTile;
    [SerializeField] float missileSpeed;
    [SerializeField] float maxLerpTime;
    float lerpTime;
    [SerializeField] ParticleSystem ps;
    Vector3 newStartPos;
    Vector3 newTargetPos;
    bool explodePlayed;



    private void OnEnable()
    {
        ps.Stop();
        ps.Clear();
    }

    public void SpawnMissile(Transform thisTargetTile, BossTileAttackState state)
    {
        targetTile = thisTargetTile;
        thisTileState = state;

        newStartPos = startPos - center;
        newTargetPos = targetTile.position - center;
        lerpTime = 0; explodePlayed = false;
    }

    private void Update()
    {
        lerpTime += Time.deltaTime;
        transform.position = Vector3.Slerp(newStartPos, newTargetPos, lerpTime * missileSpeed);
        transform.position += center;
        transform.LookAt(targetTile);

        if (lerpTime >= maxLerpTime && !explodePlayed) Explode();
    }

    void Explode()
    {
        ps.Play();
        targetTile.gameObject.GetComponent<TileLogic>().TileHit();
        explodePlayed = true;
        Invoke("DeactivateThis", 1);
    }
    void DeactivateThis()
    {
        gameObject.SetActive(false);
        thisTileState.CheckAllMissilesUsed();
    }
}
