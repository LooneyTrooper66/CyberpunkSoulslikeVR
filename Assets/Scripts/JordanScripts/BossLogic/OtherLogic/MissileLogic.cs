using UnityEngine;

// Jordan/Libby Script\\
public class MissileLogic : MonoBehaviour
{
    public Transform targetTile;
    [SerializeField] ParticleSystem ps;


    private void OnEnable()
    {
        transform.LookAt(targetTile);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTile.position, Time.deltaTime * 5);
        Debug.Log(targetTile.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        ps.Play();
        targetTile.gameObject.GetComponent<TileLogic>().TileHit();
    }

    private void OnDisable()
    {
        ps.Stop();
        ps.Clear();
    }
}
