using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Cinemachine.DocumentationSortingAttribute;


public class enemy : MonoBehaviour
{

    private Transform player;

    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {



        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("player").transform;
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }

    }






    

}
