using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathByEnemy : MonoBehaviour
{
    [SerializeField] private Camera deathCam;
    [SerializeField] private Camera fpsCam;
    [SerializeField] private FirstPersonMovement fps;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject zombie;
    [SerializeField] private GameObject skeleton;
    [SerializeField] private AudioSource no;
    [SerializeField] private AudioSource thunder;
    private SkeletonMove sm;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        sm = skeleton.GetComponent<SkeletonMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathCam.enabled)
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                thunder.Stop();
                sm.canMove = false;
                zombie.GetComponent<NavMeshAgent>().enabled = false;
                zombie.transform.position = new Vector3(10.3989f, 0.75f, -6.243885f);
                skeleton.transform.position = new Vector3(8.291924f, 0.75f, -42.89217f);
                player.transform.position = new Vector3(11.592f, 0.7933149f, -0.224f);
                fpsCam.enabled = true;
                fps.enabled = true;
                deathCam.enabled = false;
                timer = 0f;
                zombie.GetComponent<NavMeshAgent>().enabled = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7 && fpsCam.enabled)
        {
            deathCam.enabled = true;
            fpsCam.enabled = false;
            fps.enabled = false;
            no.Play();
            thunder.Play();
        }
    }

}
