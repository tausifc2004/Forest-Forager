using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject lostText;
    public GameObject retryText;
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
        sunXRotation += 0.001f;
        sun.transform.localEulerAngles = new Vector3(sunXRotation, sun.transform.localEulerAngles.y, sun.transform.localEulerAngles.z);
        //timerText.text = "Timer: " + targetTime.ToString("N0");
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            sunAnimator.SetBool("nuke", true);
        }
    }
}

