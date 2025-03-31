using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    private FirstPersonController _player;
    private NavMeshAgent _agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        _player = FindFirstObjectByType<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_player.transform.position);
    }
}
