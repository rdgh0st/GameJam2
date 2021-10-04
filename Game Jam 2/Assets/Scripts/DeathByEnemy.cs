using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DeathByEnemy : MonoBehaviour
{
    [SerializeField] private DigitalRuby.LightningBolt.LightningBoltScript lightning;
    [SerializeField] private Camera deathCam;
    [SerializeField] private Camera fpsCam;
    [SerializeField] private FirstPersonMovement fps;
    [SerializeField] private GameObject player;
    private GameObject zombie;
    private GameObject skeleton;
    [SerializeField] private AudioSource no;
    [SerializeField] private AudioSource thunder;
    [SerializeField] private AudioSource haha;
    private SkeletonMove sm;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (deathCam.enabled)
        {
            lightning.Trigger();
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                thunder.Stop();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                /*
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
                */
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
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                haha.Play();
            }
            else
            {
                no.Play();
            }
            thunder.Play();
        }
    }

}
