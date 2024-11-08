using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class firespawn : MonoBehaviour
{

    public PressurePlatePlayer plateplayer1;
    public GameObject fire;
    private bool isfire = false;
    // Start is called before the first frame update
    void Start()
    {
        fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (plateplayer1.isActivated) 
        {
            isfire = true;
            spawnFire();
        }
        else
        {
            isfire = false;
            erraseFire();
        }
    }


    void spawnFire()
    {
        if (isfire == true)
        {
            fire.SetActive (true);
        }
    }

    void erraseFire()
    {
        if (isfire == false)
        {
            fire.SetActive(false);
        }
    }
}
