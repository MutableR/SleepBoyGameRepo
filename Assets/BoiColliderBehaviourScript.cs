using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoiColliderBehaviourScript : MonoBehaviour {


    private float speed = 3.0F;
    private float jumpForce = 5F;
    
    new private Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    private Collider2D colider;
    private bool IsGrounded = false;
    private Collider2D FloorCollider;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren < SpriteRenderer>();
        colider = GetComponent<Collider2D>();
        FloorCollider = GameObject.Find("Floor").GetComponent<Collider2D>();
    }
    
    void Update()
    {
        IsGrounded = FloorTouching();
        if (Input.GetButton("Horizontal")) Run();
        if (IsGrounded && Input.GetButtonDown("Jump")) Jump();
    }

    bool FloorTouching()
    {
        return colider.IsTouching(FloorCollider);
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void Jump()
    {
        Debug.Log("Jump");
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    
    void OnCollisionEnter(Collision colision)
    {
        Debug.Log(colision.collider.name);
        Debug.Log(colision.gameObject.name);
    }

}