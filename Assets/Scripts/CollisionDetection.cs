using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Torch"))
        //{
        //    Debug.Log("Collided");
        //    enemyHP -= 33;
        //}
        isColliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.CompareTag("Torch"))
        //{
        //    Debug.Log("Collided");
        //    enemyHP -= 33;
        //}
        isColliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
