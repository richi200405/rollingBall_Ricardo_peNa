using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class enemy2 : MonoBehaviour
{

    private Transform player2;

    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {


        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        player2 = GameObject.Find("player2").transform;
        if (player2 != null)
        {
            navMeshAgent.SetDestination(player2.position);
        }
    }
}
