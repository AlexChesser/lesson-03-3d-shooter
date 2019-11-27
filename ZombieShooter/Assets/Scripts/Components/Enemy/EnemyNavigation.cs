using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshPath path;
    private GameObject cube;

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        path = new NavMeshPath();
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        var targetPosition = playerTransform.position;

        bool foundPath = NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
        if (foundPath) {
            Vector3 nextDestination = path.corners[1];
            cube.transform.position = nextDestination;
            Vector3 directionToTarget = nextDestination - transform.position;
            Vector3 flatDirection = new Vector3(directionToTarget.x, 0, directionToTarget.z);
            directionToTarget = Vector3.Normalize(flatDirection);
            var desiredRotation = Quaternion.LookRotation(directionToTarget);
            var finalRotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime);
            transform.rotation = finalRotation;
        }
    }
}
