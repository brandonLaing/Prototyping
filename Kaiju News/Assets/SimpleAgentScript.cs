using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAgentScript : MonoBehaviour {
    public Transform target;
    public NavMeshAgent agent;
    public Vector3 targetPosition;


	void Start () {
        agent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
        targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z); 
        agent.SetDestination(targetPosition);

	}
}

