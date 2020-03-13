using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetArchColor : MonoBehaviour
{
    Renderer rend;

    private void OnEnable()
    {
            rend = GetComponent<Renderer>();
            rend.material = GetComponent<AdditionalData>().materialToApply;
    }
}
