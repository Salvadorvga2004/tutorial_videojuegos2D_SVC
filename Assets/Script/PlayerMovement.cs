using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalMove = 0;
    float verticalMove = 0;

    public float runSpeedVertical = 6;
    public float runSpeedHorizontal = 3;
    public float runSpeed = 1;

    private Rigidbody2D rb2D;

    public Joystick joystick;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalMove = joystick.Vertical * runSpeedVertical;
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;

        transform.position += new Vector3(horizontalMove, verticalMove, 0) * Time.deltaTime * runSpeed;


    }
}
