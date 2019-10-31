using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject parentOfParent;
    public GameObject effect;
    public Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider otheer)
    {
        if(otheer.gameObject.tag == "Player")
        {
            parentOfParent = transform.parent.gameObject;

            effect = ObjectPooler.SharedInstance.GetPooledObject("ObstacleEffect");
            //Debug.Log(effect);
            effect.transform.SetParent(parentOfParent.transform);
            effect.transform.localPosition = transform.localPosition;
            effect.transform.localScale = new Vector3(1,1,1);
            effect.SetActive(true);
            //Debug.Log("effect = true");

            rend.enabled = false;
            parentOfParent = null;
        }
    }

}
