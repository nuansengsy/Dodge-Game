using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public int chanceToSpawn;
    public bool shouldExpand;
}

/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////
public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<ObjectPoolItem> itemsToPool; //List with types of obstacles;
    public List<GameObject> pooledObjects;

    public int obstacleDensity;
    public Renderer rend;

    void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();

        foreach(ObjectPoolItem item in itemsToPool) //Fills diferrent lists with corresponding types of obstacles
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = Instantiate(item.objectToPool) as GameObject;
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

        itemsToPool.Sort((x, y) => x.chanceToSpawn.CompareTo(y.chanceToSpawn));

    }

    public GameObject ChooseRandomObstacle()
    {
        float random = Random.Range(1, 100);
        float minValue = 0f;
        float maxValue = 0f;
        string choosenObstacleType = null;

        random = Random.Range(1, 100);

        if (random < obstacleDensity)
        {
            random = Random.Range(1, 100);
            for (int i = 0; i < itemsToPool.Count; i++)
            {
                maxValue = minValue + itemsToPool[i].chanceToSpawn;
                if(random >= minValue & random < maxValue)
                {
                    choosenObstacleType = itemsToPool[i].objectToPool.GetComponent<AdditionalData>().objectType;
                }

                minValue += itemsToPool[i].chanceToSpawn;
            }
        }

        else
        {
            choosenObstacleType = null; 
        }

        return GetPooledObject(choosenObstacleType);

    }

    public GameObject GetPooledObject(string choosenObstacleType)
    {

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].GetComponent<AdditionalData>().objectType == choosenObstacleType && !pooledObjects[i].activeInHierarchy)
            {
                
                if(pooledObjects[i].GetComponent<Renderer>() != null)
                {
                    rend = pooledObjects[i].GetComponent<Renderer>();
                    rend.enabled = true;
                }
                return pooledObjects[i];
                
            }
            
        }

        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.GetComponent<AdditionalData>().objectType == choosenObstacleType)
            {

                if (item.shouldExpand)
                {
                    GameObject obj = Instantiate(item.objectToPool) as GameObject;
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }



}   
