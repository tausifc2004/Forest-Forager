using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float timer;
    public float maxTimer = 10f;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTimer)
        {
            timer = 0;
            Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, transform.rotation);
        }
    }
}
