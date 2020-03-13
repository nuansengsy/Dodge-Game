using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public float rotationSpeed;
    public float z;
    public Vector3 correctedPosistion;

    private List<GameObject> childObjects;
    void Start()
    {

    }

    void FixedUpdate()
    {
        z += Time.deltaTime * rotationSpeed;
        if (z > 360.0f)
        {
            z = 0f;
        }
        transform.localRotation = Quaternion.Euler(0, 0, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }

    private void OnEnable()
    {

        if (GetComponent<AdditionalData>().allocatedPosition.z < 0)
        {
            correctedPosistion.z = (GetComponent<AdditionalData>().allocatedPosition.z * 48) - (1 - (transform.localScale.z / 2));

        }

        if (GetComponent<AdditionalData>().allocatedPosition.z == 0)
        {
            correctedPosistion.z = 0;

        }

        if (GetComponent<AdditionalData>().allocatedPosition.z > 0)
        {
            correctedPosistion.z = (GetComponent<AdditionalData>().allocatedPosition.z * 48) + (1 - (transform.localScale.z / 2));

        }
        correctedPosistion.x = 0f;
        correctedPosistion.y = 8f;
        transform.localPosition = correctedPosistion;


    }
}
