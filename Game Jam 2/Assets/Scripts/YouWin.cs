using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class YouWin : MonoBehaviour
{
    [SerializeField] private GameObject win;
    [SerializeField] private AudioSource mus;
    private FirstPersonMovement fps;
    private CapsuleCollider cap;
    private Rigidbody rb;
    [SerializeField] private Text winText;

    // Start is called before the first frame update
    void Start()
    {
        fps = GetComponent<FirstPersonMovement>();
        cap = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == win)
        {
            mus.Play();
            fps.enabled = false;
            cap.enabled = false;
            Destroy(rb);
            winText.text = "YOU WIN!";
        }
    }

}
