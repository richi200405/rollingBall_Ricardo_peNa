using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llavefinal : MonoBehaviour
{

    public bool isActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            isActivated = true;
          
        }

    }

}
