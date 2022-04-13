using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakFloorScript : MonoBehaviour
{
	public bool breaking = false;
	public GameObject breakobject;
	public Material BreakingMat;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(breaking == true)
		{
			breakobject.GetComponent<MeshRenderer>().material = BreakingMat; 
		}
    }
	
	private void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.CompareTag("Player"))
		{
			breaking = true;
		}
    }
	
	private void OnTriggerExit(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			breakobject.SetActive(false);
		}
	}
}
