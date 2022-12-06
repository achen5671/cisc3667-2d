using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Takes and handles input and movement for a player character
public class PlayerMovement : MonoBehaviour
{
  public float speed;
  private Rigidbody2D myRigidBody;
  private Vector3 change;
  //private Vector3 motion;
  private Animator animator;
  const int idle = 0;
  const int walk_down = 1;
  const int walk_up = 2;
  const int walk_side = 3;
  public bool isFacingRight = true;
  
  void Start() {
    myRigidBody = GetComponent<Rigidbody2D>();
    
    if(animator == null) {
        animator = GetComponent<Animator>();
    }

  }

  void Update() {
      change = Vector3.zero;
      change.x = Input.GetAxisRaw("Horizontal");
      change.y = Input.GetAxisRaw("Vertical");
  }

  void FixedUpdate() {
    MoveCharacter();
    //animate();

    /*if (change != Vector3.zero) {
      MoveCharacter(); 
    }

    else {
      animate(motion);
      animator.SetInteger("Motion", idle);
    }*/

    if(Input.GetKey("down")) {
      animator.SetInteger("Motion", walk_down); //Play Walk Down Animation
    }

    else if(Input.GetKey("up")) {
      animator.SetInteger("Motion", walk_up); //Play Walk Up Animation
    }

    // note: commenting this out for now because it's not working properly
    // else if(change.x < 0 && isFacingRight || change.x > 0 && !isFacingRight) {
    //   animator.SetInteger("Motion", walk_side); //Play Walk Side Animation Flipped
    //   Flip();
    // }

    else {
      animator.SetInteger("Motion", idle); //Play Idle Animation
    }
  }

  void MoveCharacter() {
      myRigidBody.MovePosition(transform.position + change * speed * Time.fixedDeltaTime); 
  }

  // flip player facing direction
  // void Flip()
	// {
	// 	transform.Rotate(0, 180, 0);
  //   isFacingRight = !isFacingRight; 
	// }

  // unsed
  /*void animate() {
    switch(change) {
        case change.y < 0:
              animator.SetInteger("Motion", walk_down); //Play Walk Down Animation
              MoveCharacter(); 
              break;

        case change.y > 0:
              animator.SetInteger("Motion", walk_up); //Play Walk Up Animation
              MoveCharacter(); 
              break;

        case change.x > 0:
              animator.SetInteger("Motion", walk_side); //Play Walk Side Animation
              MoveCharacter(); 
              break;

        case change.x < 0:
              animator.SetInteger("Motion", walk_side); //Play Walk Side Animation Flipped
              MoveCharacter(); 
              break;

        default:
              animator.SetInteger("Motion", idle); //Play Walk Down Animation
              break;
    }
  }*/
}
