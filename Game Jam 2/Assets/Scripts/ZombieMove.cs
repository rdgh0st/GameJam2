using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour
{
    private NavMeshAgent zombie;
    private float timer;
    private float groanTimer;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource groan;
    // Start is called before the first frame update
    void Start()
    {
        zombie = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        groanTimer += Time.fixedDeltaTime;
        if (timer >= 1f)
        {
            zombie.destination = player.transform.position;
            timer = 0f;
        }
        if (groanTimer >= 5f && groan != null)
        {
            groan.Play();
            groanTimer = 0f;
        }
    }
}
