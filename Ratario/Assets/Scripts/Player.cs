using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    // player movement speed
    [SerializeField]
    [Range(0.1f,30.0f)]private float _speed = 10f;
    [SerializeField]
    [Range(0.1f,10.0f)]private float _jumpPower = 2f;
    private float horizontalInput;
    private Rigidbody _playerRB;
    // Start is called before the first frame update
    void Start()
    {
        _playerRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        // Moves the player right and left by the horizontal input.
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime); 
        
        // if player presses space jumpes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerRB.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }

        // if player presses c it coruches
        if (Input.GetKeyDown(KeyCode.C) & Input.GetKey(KeyCode.C))
        {
            Vector3 crouchScale = new Vector3(transform.localScale.x,0.35f,transform.localScale.z);
            transform.localScale = crouchScale;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Vector3 afterCrouchScale = new Vector3(transform.localScale.x,0.50f,transform.localScale.z);
            transform.localScale = afterCrouchScale;
        }
    }
}
