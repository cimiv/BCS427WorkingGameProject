using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public float move_Speed = 0.1f;
	public float gravity = -0.8f;
	CharacterController controller;
	public GameObject player;
	private Vector3 vel;
	private int jumpNum = 60;
	public bool isJump = false;
	
    // Start is called before the first frame update
    void Start()
    {
		controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movZ = Input.GetAxis("Vertical") * Vector3.forward * move_Speed;
		
        Vector3 movX = Input.GetAxis("Horizontal") * Vector3.right * move_Speed;
		
        Vector3 mov = transform.TransformDirection(movX + movZ);
		
		controller.Move(mov);
		
		if(Input.GetKeyDown("space") && isJump == false)
		{
			isJump = true;
			vel.y += Mathf.Sqrt(jumpNum * -1 * gravity);
		}
		if(controller.isGrounded == true)
		{
			isJump = false;
		}
		
		vel.y += gravity * Time.deltaTime;
		controller.Move(vel * Time.deltaTime);
    }
}
