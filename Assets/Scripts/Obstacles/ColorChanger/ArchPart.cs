using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchPart : MonoBehaviour
{
    Renderer rend;
    public GameObject parentObject;

    private void Start()
    {

    }
    private void OnEnable()
    {
        rend = GetComponent<Renderer>();
        rend.material = parentObject.GetComponent<AdditionalData>().materialToApply;

    }
}
