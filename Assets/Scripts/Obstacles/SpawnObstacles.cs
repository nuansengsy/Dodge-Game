using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnPointInfo
{
    public int pointIndex;
    public Vector3 pointPosition;
    public bool isReserved = false;
    public bool isOccupied = false;
    public bool isPlayerPath = false;


}
public class SpawnObstacles : MonoBehaviour
{
    [Header("GameObgects")]
    public GameObject emptyChild;
    public Transform parentPath;

    [Header("Rows & Columns")]
    public int rowsNumber;
    public int columnsNumber;

    [Header("Positioning")]
    public Vector3[] allSpawnPositions;

    [Header("Percentage of Target Objects")]
    public float targetObjectsRate;

    SpawnPointInfo[] allSpawnPoints = new SpawnPointInfo[9]; //rowsNumber * columnsNumber
    List<SpawnPointInfo> freeSpawnPoints = new List<SpawnPointInfo>();

    void Start()
    {
        GetSpawnPositions();
        ExcludeFreePath();
        PlaceObjects();
    }

    public void GetSpawnPositions()
    {
        
        float localX, localY, localZ;
        int columnIndex, rowIndex; // i j

        for (rowIndex = 0; rowIndex < rowsNumber; rowIndex++)
        {
            for (columnIndex = 0; columnIndex < columnsNumber; columnIndex++)
            {
                localX = ((2 * columnIndex - columnsNumber * 1f + 1) / (2f * columnsNumber));
                localZ = ((2 * rowIndex - rowsNumber * 1f + 1) / (2f * rowsNumber));
                localY = 0.6f; 
                allSpawnPoints[rowIndex * columnsNumber + columnIndex] = new SpawnPointInfo();
                allSpawnPoints[rowIndex * columnsNumber + columnIndex].pointIndex = rowIndex * columnsNumber + columnIndex;
                allSpawnPoints[rowIndex * columnsNumber + columnIndex].pointPosition = new Vector3(localX, localY, localZ);

            }
        }
    }

    public void ExcludeFreePath()
    {
        int newExclusionIndex;
        int previousExclusionIndex = -999;
        int minIndex = 0;
        int maxIndex = columnsNumber;

        for (int i = 0; i < rowsNumber; i++)
        {
            newExclusionIndex = Random.Range(minIndex, maxIndex);

            if (newExclusionIndex == previousExclusionIndex + columnsNumber)
            {
                while(newExclusionIndex == previousExclusionIndex + columnsNumber)
                {
                    newExclusionIndex = Random.Range(minIndex, maxIndex);
                }
            }

            allSpawnPoints[newExclusionIndex].isPlayerPath = true;
            allSpawnPoints[newExclusionIndex].isReserved = true;
            freeSpawnPoints.Remove(allSpawnPoints[newExclusionIndex]);

            minIndex += columnsNumber;
            maxIndex += columnsNumber;
            previousExclusionIndex = newExclusionIndex;

        }

    }

    public void PlaceObjects()
    {
        GameObject objectToSpawn = null;
        int minPointIndex = 0, maxPointIndex = 0, randomPointIndex = 0;

        for (int i = 0; i < allSpawnPoints.Length; i++)
        {
            if (!allSpawnPoints[i].isReserved)
            {
                ///
                objectToSpawn = ObjectPooler.SharedInstance.ChooseRandomObjectType();
                if(objectToSpawn != null)
                {
                    ResetObjectRole(objectToSpawn);
                    ColorManager.SharedInstance.ChooseObjectsColors(objectToSpawn);
                }
                ///

                if (objectToSpawn != null && objectToSpawn.GetComponent<AdditionalData>().isMovable && objectToSpawn.GetComponent<AdditionalData>().movesHorizontal)
                {
                    allSpawnPoints[i].isReserved = true;
                    allSpawnPoints[i].isOccupied = true;
                    minPointIndex = (int)Mathf.Floor(i / columnsNumber) * columnsNumber;

                    if (minPointIndex != (columnsNumber * (rowsNumber - 1))) // check if it is not last row
                    {
                        maxPointIndex = minPointIndex + columnsNumber * 2;
                    }
                    else
                    {
                        maxPointIndex = minPointIndex + columnsNumber;
                    }

                    foreach (SpawnPointInfo point in allSpawnPoints)
                    {
                        if (point.pointIndex >= minPointIndex && point.pointIndex < maxPointIndex && !point.isReserved)
                        {
                            freeSpawnPoints.Add(point);
                        }
                    }

                    if (freeSpawnPoints.Count != 0)
                    {
                        randomPointIndex = Random.Range(0, freeSpawnPoints.Count);
                        allSpawnPoints[freeSpawnPoints[randomPointIndex].pointIndex].isReserved = true;
                        //picking final destination
                        objectToSpawn.GetComponent<AdditionalData>().endPosition = freeSpawnPoints[randomPointIndex].pointPosition; 
                        freeSpawnPoints.Clear();
                    }
                    else
                    {
                        allSpawnPoints[i].isReserved = false;
                        allSpawnPoints[i].isOccupied = false;
                        objectToSpawn = null;
                    }

                }
                ///
                if (objectToSpawn != null)
                {
                    objectToSpawn.GetComponent<AdditionalData>().allocatedPosition = allSpawnPoints[i].pointPosition;

                    allSpawnPoints[i].isReserved = true;
                    allSpawnPoints[i].isOccupied = true;
                    objectToSpawn.transform.SetParent(parentPath);
                    objectToSpawn.transform.localPosition = allSpawnPoints[i].pointPosition;
                    objectToSpawn.SetActive(true);

                }

            }

        }

    }

    public void ResetObjectRole(GameObject go)
    {
        if(go != null)
        {
            if(go.tag != "ColorChanger" && go.tag != "Heart")
            {
                if (targetObjectsRate >= Random.Range(1f, 100f))
                {
                    go.tag = "TargetObject";
                }
                else
                {
                    go.tag = "ObstacleObject";
                }
            }
            
        }
    }


}
