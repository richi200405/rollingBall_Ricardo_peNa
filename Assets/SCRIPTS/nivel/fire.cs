using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class fire : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        // Elimina el objeto que entra en el Trigger
        Debug.Log(1);
        if (other.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
        }
            
    }


   


}
