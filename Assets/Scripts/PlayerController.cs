using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jampPower = 5.0f;
    int jumpCount = 0;

    public AudioClip pickUpSound;
    public AudioClip jumpSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right") == true)
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("left") == true)
        {
            this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown("space") == true && jumpCount < 2)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, jampPower, 0);
            audioSource.clip = jumpSound;
            audioSource.Play();
            jumpCount++;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            jumpCount = 0;
        }
        if (col.gameObject.tag == "Coin")
        {
            audioSource.clip = pickUpSound;
            audioSource.Play();
            Destroy(col.gameObject);
        }
    }
}
