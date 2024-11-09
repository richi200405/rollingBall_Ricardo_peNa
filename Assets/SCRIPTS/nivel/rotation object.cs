using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationobject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 90) *5 * Time.deltaTime);
    }
}
