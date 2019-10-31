using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 cameraPos;
    public Vector3 offset;

    private void Update()
    {
        cameraPos.x = offset.x;
        cameraPos.y = offset.y;
        cameraPos.z = player.position.z + offset.z;
        transform.position = cameraPos;
    }
}
