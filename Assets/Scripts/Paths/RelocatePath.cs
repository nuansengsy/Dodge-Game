using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelocatePath : MonoBehaviour
{
    [SerializeField]
    public SpawnObstacles spawnObstacles;

    public Transform parentObject;
    private float pathLength;
    private Vector3 nextPathPosition;

    public int pathsNumber;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RelocatePathTrigger")
        {
            DisableObstacles();
            Relocate();

            spawnObstacles.GetSpawnPositions();
            spawnObstacles.ExcludeFreePath();
            spawnObstacles.PlaceObjects();

        }
    }

    private void DisableObstacles()
    {
        int childsNumber = parentObject.transform.childCount;
        for (int i = 1; i < childsNumber; i++)
        {
            parentObject.transform.GetChild(1).gameObject.SetActive(false);
            parentObject.transform.GetChild(1).SetParent(null);
                
        }

    }

    private void Relocate()
    {
        pathLength = parentObject.GetComponent<Renderer>().bounds.size.z;
        nextPathPosition = transform.parent.position;
        nextPathPosition.z += pathLength * pathsNumber;
        parentObject.transform.position = nextPathPosition;
    }
}
