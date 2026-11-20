using UnityEngine;

// Jordan/Libby Script\\
public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] Transform playerModel;
    Vector3 dirToPlayer;
    Quaternion targetDir;
    float timeCount;


    private void OnEnable()
    {
        timeCount = 0;
    }

    private void Update()
    {
        dirToPlayer = Vector3.Normalize(playerModel.position - gameObject.transform.position);
        dirToPlayer = new Vector3(dirToPlayer.x, gameObject.transform.position.y, dirToPlayer.z);
        targetDir = Quaternion.LookRotation(dirToPlayer);
        timeCount += Time.deltaTime;
        transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, targetDir, timeCount * 0.001f);
    }
}
