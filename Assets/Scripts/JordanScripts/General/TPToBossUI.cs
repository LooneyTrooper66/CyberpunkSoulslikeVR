using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Jordan/Libby Script\\
public class TPToBossUI : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float timer = 10;
    [SerializeField] Transform playerCam;
    Quaternion ogRotation;

    [SerializeField] string uiText;
    [SerializeField] string nextScene;


    private void Start()
    {
        ogRotation = transform.rotation;
    }

    private void Update()
    {
        // make sure ui is always facing player
        if (playerCam != null) transform.LookAt(playerCam); //transform.rotation = playerCam.rotation * ogRotation;

        // display timer text and change scene
        timer -= Time.deltaTime;
        timerText.text = uiText + timer.ToString("0.00");

        if (timer <= 0) SceneManager.LoadScene(nextScene);
    }
}
