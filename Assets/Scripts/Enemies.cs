using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
    private float lookRadius = 10f;
    [SerializeField] private int enemyHP = 99;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Torch"))
        {
            Debug.Log("Collided");
            enemyHP -= 33;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(player.transform.position);

        }

        if (enemyHP == 0)
        {
            Debug.Log("Dead");
            gameObject.SetActive(false);
        }
        
    }
}
