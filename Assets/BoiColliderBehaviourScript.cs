using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoiColliderBehaviourScript : MonoBehaviour {


    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 0.1F;

    private bool isGrounded = false;

    new private Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    private Collider2D colider;
    private bool IsGrounded;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren < SpriteRenderer>();
        colider = GetComponent<Collider2D>();
    }
    
    void Update()
    {
        IsGrounded =  FloorTouching();
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    }

    bool FloorTouching()
    {
        return false;
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    
    void OnCollisionEnter(Collision colision)
    {
        Debug.Log(colision.collider.name);
        Debug.Log(colision.gameObject.name);
    }

}