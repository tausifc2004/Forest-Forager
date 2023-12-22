using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDay : MonoBehaviour
{
    [SerializeField] private float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        xRotation = transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        xRotation += 0.001f;
        transform.localEulerAngles = new Vector3(xRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
