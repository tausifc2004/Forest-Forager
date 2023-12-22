using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    private int keyCount;
    public TextMeshProUGUI keyCountText;


    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
    }

    void SetCountText()
    {
        keyCountText.text = "Keys: " + keyCount.ToString() + "/5";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            keyCount += 1;
            SetCountText();
        }
    }
}
