using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    float speed = 5.0f;
    float jumpForce = 10.0f;
    float gravityModifier = 2.0f;
    bool isOnGround;
    int deathPress;
    bool death = false;
    int health = 10;

    public Animator playerAnim;
    public Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        isOnGround = true;
        Physics.gravity *= gravityModifier;

        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (death == false)
        {
            //Foward Movement
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                playerAnim.SetBool("isMove", true);
            }
            //Backward Movement
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                playerAnim.SetBool("isMove", true);
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                playerAnim.SetBool("isMove", false);
            }

            //Left Movement
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                playerAnim.SetBool("isMove", true);
            }

            //Right Movement
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                playerAnim.SetBool("isMove", true);
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                playerAnim.SetBool("isMove", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerAnim.SetTrigger("trigFlip");
                isOnGround = false;
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                DeathPressed();
                Debug.Log("'K' key is pressed");
            }

            if (Input.GetKeyDown(KeyCode.K) && deathPress == 10)
            {
                playerAnim.SetTrigger("trigDeath");
                death = true;
            }
        }
    }

    private void DeathPressed()
    {
        health--;
        deathPress++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PlayPlane")
        {
            isOnGround = true;
        }
    }


}
