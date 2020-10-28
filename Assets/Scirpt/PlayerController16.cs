using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController16 : MonoBehaviour
{
    float speed = 10.0f;
    float maxLimit = 10.0f;
    float planeBz = 20.0f;
    float planeBx = 5.0f;
    float jumpforce = 15.0f;
    bool Plane;
    float gravityModifier = 5.5f;
    Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * VerticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * HorizontalInput * speed);
       


        if (Plane == true )
        {
            Debug.Log("PlaneA");
           
            if (transform.position.z < -maxLimit )
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -maxLimit);
            }
            if (transform.position.z > maxLimit && transform.position.x > planeBx)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, maxLimit);     
            }
            if (transform.position.z > maxLimit && transform.position.x < -planeBx)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, maxLimit);

            }
            if (transform.position.x < -maxLimit)
            {
                transform.position = new Vector3(-maxLimit, transform.position.y, transform.position.z);
            }
            if (transform.position.x > maxLimit)
            {
                transform.position = new Vector3(maxLimit, transform.position.y, transform.position.z);
            }
        }
        if (Plane == false)
        {
            Debug.Log("PlaneB");
            if (transform.position.x < -planeBx)
            { transform.position = new Vector3(-planeBx, transform.position.y, transform.position.z); }
            if (transform.position.x > planeBx)
            { transform.position = new Vector3(planeBx, transform.position.y, transform.position.z); }
            if (transform.position.z < -maxLimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -maxLimit);
            }
            if ( transform.position.z > planeBz)
            {
               
                transform.position = new Vector3(transform.position.x, transform.position.y, planeBz);
            }
        }
        jumpPlayer();
    }
    private void jumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }
   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlaneA"))
        {
            Debug.Log("Plane A");
            Plane = true;
            
        }
        if(collision.gameObject.CompareTag("PlaneB"))
        {
            Debug.Log("Plane B");
            
            Plane = false;
        }

    }
}
