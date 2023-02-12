using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") == true)
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }

    }
}
