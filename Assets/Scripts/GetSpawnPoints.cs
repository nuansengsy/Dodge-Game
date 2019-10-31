using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpawnPoints : MonoBehaviour
{

    [Header("GameObgects")]
    public GameObject emptyChild;
    public GameObject newParent;

    [Header("Rows & Columns")]
    public int rowsNumber;
    public int columnsNumber;
    private int columnIndex; // i
    private int rowIndex; // j

    [Header("Positioning")]
    private float localX;
    private float localY;
    private float localZ;
    private Vector3[,] spawnPointsPositions;
    public Vector3[] playerPathPositions;

    GameObject point;
    public Transform smallCube;

    void Start()
    {
        GetSpawnPositions();
    }

    private void GetSpawnPositions()
    {
        spawnPointsPositions = new Vector3[columnsNumber, rowsNumber];

        for (rowIndex = 1; rowIndex <= rowsNumber; rowIndex++)
        {
            for (columnIndex = 1; columnIndex <= columnsNumber; columnIndex++)
            {
                localX = ((2 * columnIndex - (columnsNumber*1f + 1)) / (2f * columnsNumber));
                localZ = ((2 * rowIndex - (rowsNumber*1f + 1)) / (2f * rowsNumber));
                localY = 0.6f; //temporary

                //Debug.Log("X = " + localX + " Z = " + localZ + " (" + " j = " + rowIndex + " i = " + columnIndex + " c = " + columnsNumber + " r = " + rowsNumber + ")");
                point = Instantiate(emptyChild, newParent.transform) as GameObject;
                point.transform.localPosition = new Vector3(localX, localY, localZ);
                spawnPointsPositions[columnIndex - 1, rowIndex - 1] = new Vector3(localX, localY, localZ);
                //Debug.Log("Array Element" + "[" + (columnIndex - 1) + "," + (rowIndex - 1) + "]" + " is " + spawnPointsPositions[columnIndex - 1, rowIndex - 1]);
            }
        }
    }

    private void ExcludeFreePath()
    {
        playerPathPositions = new Vector3[rowsNumber];
        int playerPathIndex = Random.Range(0, columnsNumber);
        int previousPlayerPathIndex = -1;

        for (rowIndex = 1; rowIndex <= rowsNumber; rowIndex++)
        {

            if (previousPlayerPathIndex == playerPathIndex)
            {
                while(previousPlayerPathIndex == playerPathIndex)
                {
                    playerPathIndex = Random.Range(0, columnsNumber);
                }
            }
            playerPathPositions[rowIndex - 1] = spawnPointsPositions[playerPathIndex, rowIndex - 1];
            previousPlayerPathIndex = playerPathIndex;
            spawnPointsPositions[playerPathIndex, rowIndex - 1].z = -9999;
        }

    }

    private void PlaceObstacles()
    {
        for (rowIndex = 1; rowIndex <= rowsNumber; rowIndex++)
        {
            for (columnIndex = 1; columnIndex <= columnsNumber; columnIndex++)
            {
                if(spawnPointsPositions[columnIndex - 1, rowIndex - 1].z != -9999)
                {
                    Instantiate(smallCube, newParent.transform, false);
                    smallCube.transform.localPosition = spawnPointsPositions[columnIndex - 1, rowIndex - 1];

                }
            }
        }
    }

}
