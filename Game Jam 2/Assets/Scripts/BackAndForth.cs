using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    [SerializeField] private float distance = 1f;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private bool moveOnX = false;
    [SerializeField] private bool moveOnY = true;
    [SerializeField] private bool moveOnZ = false;
    private Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveOnX)
        {
            float targetX = Mathf.Sin(Time.time * speed) * distance + startingPos.x;
            transform.position = new Vector3(targetX, startingPos.y, startingPos.z);
        }
        if (moveOnY)
        {
            float targetY = Mathf.Sin(Time.time * speed) * distance + startingPos.y;
            transform.position = new Vector3(startingPos.x, targetY, startingPos.z);
        }
        if (moveOnZ)
        {
            float targetZ = Mathf.Sin(Time.time * speed) * distance + startingPos.z;
            transform.position = new Vector3(startingPos.x, startingPos.y, targetZ);
        }
    }
}
