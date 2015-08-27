using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 2.0f;
	public float gravity = 2.0f;
	public float jumpSpeed = 20.0f;

	private CharacterController controller;
	private KeyboardInput input;
	private Vector3 moveDirection;

	private bool goingLeft;
	private bool goingRight;
	private bool isJumping;


	void Start(){
		controller = GetComponent<CharacterController> ();
		input = GetComponent<KeyboardInput> ();
		moveDirection = new Vector3 (0.0f, 0.0f, 0.0f);

		goingLeft = false;
		goingRight = false;
		isJumping = false;
	}

	void Update(){

		moveDirection.x = input.XAxis * speed;

		if (input.JumpButtonPressedThisFrame) {
			moveDirection.y = jumpSpeed;
			this.isJumping = true;
		}

		if (!controller.isGrounded) {
			moveDirection.y -= gravity;
		}
		else {
			moveDirection.y = 0;
			this.isJumping = false;
		}

		controller.Move (moveDirection * Time.deltaTime);
}

    /*
     * TO DO:
     * Movement
     *      -Should use the CharacterController which is already attached to this GameObject-
     *      -Be able to move left and right-
     *      -Collide with/be stopped by walls-
     *      -Not move too quickly or slowly-
     *          -Remember that movement happens every frame-
     * Jumping/Falling
     *      -Fall to the ground, and not through it-
     *      -Able to jump-
     *      -Can reach platforms to the right, but not the one on the left-
     *      -Only able to jump while standing on the ground-
     * Input
     *      Ideally, use the KeyboardInput script which is already attached to this GameObject
     *      -A & D for left and right movement-
     *      -Space for jumping-
     * Moving Platform
     *      When standing on the platform, the character should stay on it/move relative to the moving platform
     *      When not standing on the platform, revert to normal behavior
     * Enemy
     *      If the character touches the enemy, he should "die"
     *      
     * 
     * 
     * 
     * Variables you might want:
     *      References to the CharacterController and Keyboard input classes
     *      Speed values for moving, falling, and jumping
     *      A value to keep track of the player's movement speed and direction
     *      You will probably need to use the Update function as well as create functions for moving platforms and enemies
     */

}