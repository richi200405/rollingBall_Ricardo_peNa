using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticEnemy : MonoBehaviour
{
    public float speed = 0;
    public List<Transform> waypoints;


    public Collider object1Collider; // Arrastra el collider del primer objeto aquí
    public Collider object2Collider; // Arrastra el collider del segundo objeto aquí
    public Collider object3Collider; // Arrastra el collider del segundo objeto aquí

    private int waypointIndex;
    private float range;

    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        range = 1.0f;

        Physics.IgnoreCollision(object1Collider, object2Collider, object3Collider);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() 
    {
        transform.LookAt(waypoints[waypointIndex]);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < range) 
        {
            waypointIndex++;
            if(waypointIndex >= waypoints.Count) 
            {
                waypointIndex = 0;
            }
        }
    }

   

}
