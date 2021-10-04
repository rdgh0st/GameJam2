using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathPlane : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ghost;
    [SerializeField] private Camera deathCam;
    [SerializeField] private Camera fpsCam;
    [SerializeField] private AudioSource scream;
    private bool playerDies = false;
    private float startTime;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDies)
        {
            timer += Time.deltaTime;
            if (timer >= startTime + 5)
            {
                playerDies = false;
                player.transform.position = new Vector3(0.2114614f, 0f, 2.68536f);
                ghost.transform.position = new Vector3(1.258324f, 0f, -3.483544f);
                deathCam.enabled = false;
                fpsCam.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            playerDies = true;
            deathCam.transform.position = new Vector3(player.transform.position.x, deathCam.transform.position.y, player.transform.position.z);
            deathCam.enabled = true;
            fpsCam.enabled = false;
            scream.Play();
            startTime = Time.deltaTime;
            timer = 0;
        }
    }

}
