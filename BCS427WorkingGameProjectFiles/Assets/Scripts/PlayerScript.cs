using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public float move_Speed = 0.1f;
	public float gravity = -0.8f;
	CharacterController controller;
	public GameObject player;
	
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
		
		if(Input.GetKeyDown("space"))
		{
			Vector3 moveY = Vector3.up * 2;
			controller.Move(moveY);
		}
		
    }
}
