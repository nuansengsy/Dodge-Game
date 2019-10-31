using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFirstPaths : MonoBehaviour
{
    public int firstPathsNumber;
    public Transform path;
    private float pathLength;
    private Vector3 pathPosition;

    void Start()
    {
        PlaceFirstPaths();
    }

    private void PlaceFirstPaths()
    {
        pathLength = path.GetComponent<Renderer>().bounds.size.z;
        //Debug.Log(pathLength);
        for (int i = 1; i <= firstPathsNumber; i++)
        {

            Instantiate(path, pathPosition, Quaternion.identity);
            pathPosition.z = pathLength * i;

        }
    }
}
