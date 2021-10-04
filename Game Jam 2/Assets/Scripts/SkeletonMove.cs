using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonMove : MonoBehaviour
{
    public bool canMove = false;
    private float timer;
    private NavMeshAgent skeleton;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        skeleton = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= 1f)
            {
                skeleton.destination = player.transform.position;
                timer = 0f;
            }
        }
    }

}
