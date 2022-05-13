using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCamera : MonoBehaviour // *** attach this script to an object which stays active and destroys on load.
{
    // *** hard coded amount of cameras, could be transitioned to an array so it can very between scenes.
    public GameObject cam1; // player camera
    public GameObject cam2; // menu camera

    // *** use these to determine what camera sound should be coming from. it is not important for now as enabling/disabling the cameras does the same thing.
    private AudioListener al1;
    private AudioListener al2;

    public static SwapCamera Instance;

    private int currentCam = 1;
    // Start is called before the first frame update
    void Start()
    {
        al1 = cam1.GetComponent<AudioListener>();
        al2 = cam2.GetComponent<AudioListener>();
        swapCamera(0);

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {   // uncomment this while check key is active.
        //checkKey(); 
    }
    
    // *** use this to change cameras by using a key by putting the key code in GetKeyDown. it will then swap to the next camera in the chain.
    /*void checkKey()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            swapCamera();
        }
    }*/

    public void swapCamera() // *** swaps to the next camera in the chain, as dictated in the switch statement.
    {
        if(currentCam<1) { currentCam++; }
        else { currentCam = 0; }

        switch(currentCam)
        {
            case 0:
                cam1.SetActive(true);
                cam2.SetActive(false);
                break;
            case 1:
                cam2.SetActive(true);
                cam1.SetActive(false);
                break;
            default:
                cam1.SetActive(true);
                cam2.SetActive(false);
                break;
        }
    }

    public void swapCamera(int num) // *** overloaded camera swap statement, argument details what camera should be swapped to. the chain starts at 0 (player cam), defaulted to 0 as well.
    {
        currentCam = num;

        switch (currentCam)
        {
            case 0:
                cam1.SetActive(true);
                cam2.SetActive(false);
                break;
            case 1:
                cam2.SetActive(true);
                cam1.SetActive(false);
                break;
            default:
                cam1.SetActive(true);
                cam2.SetActive(false);
                break;
        }
    }
}
