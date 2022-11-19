using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Takes and handles input and movement for a player character
public class PlayerMovement : MonoBehaviour
{
   public float speed;
   private Rigidbody2D myRigidBody;
   private Vector3 change;

   void Start() {
    myRigidBody = GetComponent<Rigidbody2D>();
   }

   void Update() {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (change != Vector3.zero) MoveCharacter();
   }

   void MoveCharacter() {
        myRigidBody.MovePosition(transform.position + change * speed * Time.fixedDeltaTime); 
   }
}
