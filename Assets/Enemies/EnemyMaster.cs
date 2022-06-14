using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMaster : MonoBehaviour
{
    private GameObject _player;
    private float Distance;

    private bool angry;
    public float angryDistance;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(_player.transform.position, gameObject.transform.position);

        if (Distance <= angryDistance)
        {
            angry = true;
        }
        else
        {
            angry = false;
        }

        if (angry)
        {
            agent.isStopped = false;
            agent.SetDestination(_player.transform.position);
        }
        else
        {
            agent.isStopped = true;
        }
    }
}
