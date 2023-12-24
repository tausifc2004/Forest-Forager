using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float timer;
    public float maxTimer = 10f;
    public GameObject[] enemies;
    public Vector3 spawnPosition;
    public int maxRadius = 3;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnPosition = transform.position + new Vector3(Random.Range(0, maxRadius), 0, Random.Range(0, maxRadius));
        timer += Time.deltaTime;
        if (timer > maxTimer)
        {
            timer = 0;
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition, transform.rotation);
        }
    }
}
