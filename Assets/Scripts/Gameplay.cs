using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    private int keyCount;
    public TextMeshProUGUI keyCountText;
    [SerializeField] private int playerHP = 100;
    public TextMeshProUGUI playerHPText;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door");
        SetCountText();
        SetHPText();
    }

    void SetCountText()
    {
        keyCountText.text = "Keys: " + keyCount.ToString() + "/5";
        if (keyCount == 5)
        {
            door.SetActive(false);
        }
    }

    void SetHPText()
    {
        playerHPText.text = "Health: " + playerHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // add "you win" screen when playerHP = 0
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
    }
}
