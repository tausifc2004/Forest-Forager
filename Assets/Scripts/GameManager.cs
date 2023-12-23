using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject lostText;
    public GameObject winText;
    public GameObject retryText;
    public GameObject playerHPText;
    public GameObject keyCountText;
    [SerializeField] private GameObject gameOverMenu;

    public GameObject sun;
    private Light sunLightSource;
    private Animator sunAnimator;
    [SerializeField] private float sunXRotation;

    public float targetTime = 45.0f;

    void Start()
    {
        sunLightSource = sun.GetComponent<Light>();
        sunAnimator = sun.GetComponent<Animator>();

        sunXRotation = sun.transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = "Time Left: " + targetTime.ToString("N0");
        
        sunXRotation += 0.001f;
        sun.transform.localEulerAngles = new Vector3(sunXRotation, sun.transform.localEulerAngles.y, sun.transform.localEulerAngles.z);
        
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            timerText.text = "Time Left: 0";
            sunAnimator.SetBool("nuke", true);
            if (targetTime <= -1.75f)
            {
                gameOverMenu.SetActive(true);
                lostText.SetActive(true);
                retryText.SetActive(true);
                timerText.text = "";
                playerHPText.SetActive(false);
                keyCountText.SetActive(false);
                Time.timeScale = 0f;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Time.timeScale = 1f;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
}

