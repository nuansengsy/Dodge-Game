using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    public GameObject parentObject;
    private GameObject parentOfParent;
    private GameObject effect;
    public string effectName;
    private Renderer rend;
    private Collider coll;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        coll = GetComponent<Collider>();
        
    }
    private void OnTriggerEnter(Collider otheer)
    {
        if(otheer.gameObject.tag == "Player")
        {
            parentOfParent = transform.parent.gameObject;

            if(tag == "ObstacleObject")
            {
                effectName = "ObstacleHit";
                effect = ObjectPooler.SharedInstance.GetPooledObject(effectName);
                effect.GetComponent<ParticleSystemRenderer>().material = parentObject.GetComponent<AdditionalData>().materialToApply;
            }

            if (tag == "TargetObject")
            {

                effectName = "ParticlesExplosion";
                effect = ObjectPooler.SharedInstance.GetPooledObject(effectName);
                effect.GetComponent<ParticleSystemRenderer>().material = parentObject.GetComponent<AdditionalData>().materialToApply;
            }

            
            effect.transform.SetParent(parentOfParent.transform);
            effect.transform.localPosition = transform.localPosition;
            effect.transform.localScale = new Vector3(1,1,1);
            
            effect.SetActive(true);

            rend.enabled = false;
            coll.enabled = false;
            parentOfParent = null;
        }
    }

}
