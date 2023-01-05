using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f; 
    public float xRange = 10;
    public GameObject projectilePrefab; 
    public float forwardInput;
    public float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        //Keep the player in bounds
        if (transform.position.x < -xRange){
            transform.position = new Vector3( -xRange,transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) {
             // Launch a projectile from the player
             Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
    }
}
