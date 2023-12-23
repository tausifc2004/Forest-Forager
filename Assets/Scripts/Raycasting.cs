using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    public GameObject torch;
    private GameObject torch2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = -Vector3.one;


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                clickPosition = hit.point;
                torch2 = Instantiate(torch);
                torch2.transform.position = clickPosition;
                Destroy(torch2, 1);

            }
        }
        
    }
}
