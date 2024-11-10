using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class fire : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public Vector3 separationOffset1 = new Vector3(1, 0, 0); // Offset para el primer prefab
    public Vector3 separationOffset2 = new Vector3(-1, 0, 0); // Offset para el segundo prefab


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
       
        if (other.CompareTag("enemy"))
        {
            Vector3 targetPosition = other.transform.position;
            Instantiate(prefab1, targetPosition + separationOffset1, Quaternion.identity);
            Instantiate(prefab2, targetPosition + separationOffset2, Quaternion.identity);


            Destroy(other.gameObject);

            


            


        }

    }


   


}
