using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    private int keyCount;
    public TextMeshProUGUI keyCountText;
    [SerializeField] private int playerHP = 100;
    public TextMeshProUGUI playerHPText;

    public GameObject doorCollider;
    public MeshRenderer doorRenderer;

    public GameObject timerText;
    public GameObject lostText;
    public GameObject winText;
    public GameObject retryText;

    [SerializeField] private GameObject gameOverMenu;


    // Start is called before the first frame update
    void Start()
    {
        doorCollider = GameObject.FindGameObjectWithTag("Door");
        SetCountText();
        SetHPText();
    }

    void SetCountText()
    {
        keyCountText.text = "Keys: " + keyCount.ToString() + "/5";
        if (keyCount == 5)
        {
            doorCollider.GetComponent<Collider>().isTrigger = true;
            doorRenderer.enabled = false;
        }
    }

    void SetHPText()
    {
        playerHPText.text = "Health: " + playerHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // add "you lost" screen when playerHP = 0
        if (playerHP == 0)
        {
            gameOverMenu.SetActive(true);
            lostText.SetActive(true);
            retryText.SetActive(true);
            timerText.SetActive(false);
            playerHPText.text = "";
            keyCountText.text = "";
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            keyCount += 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            playerHP -= 10;
            SetHPText();
        }

        // add "you win" screen when player collides with house
        if (other.gameObject.CompareTag("Door"))
        {
            if (keyCount == 5)
            {
                gameOverMenu.SetActive(true);
                winText.SetActive(true);
                //retryText.SetActive(true);
                timerText.SetActive(false);
                playerHPText.text = "";
                keyCountText.text = "";
                Time.timeScale = 0f;
                //if (Input.GetKeyDown(KeyCode.R))
                //{
                //    Time.timeScale = 1f;
                //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //}
            }
        }
    }
}
