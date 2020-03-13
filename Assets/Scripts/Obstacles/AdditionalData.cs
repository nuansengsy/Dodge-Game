using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalData : MonoBehaviour
{
    public string objectType;

    public bool isStationary;
    public bool isMovable;
    public bool movesHorizontal;
    public bool movesVertical;

    public Vector3 allocatedPosition;
    public Vector3 endPosition;

    public Material materialToApply;

}
