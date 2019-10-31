using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateHandler : MonoBehaviour
{
    delegate void MultiDelegate();
    MultiDelegate myMultiDelegate;
    void Start()
    {
        myMultiDelegate += ShowText;
        myMultiDelegate += ShowAnotherText;

        myMultiDelegate();
    }

    void ShowText()
    {
        //Debug.Log("First Method");
    }

    void ShowAnotherText()
    {
        //Debug.Log("Second Method");
    }

}