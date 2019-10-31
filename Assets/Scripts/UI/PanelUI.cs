using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUI : MonoBehaviour
{
    Animator animator;
    public bool isShown;
    public void Start()
    {
        animator = GetComponent<Animator>();
        isShown = false;
    }

    public void Update()
    {

        if (PlayerHealth.lifesCount == 0)
        {
            if (!isShown)
            {
                Debug.Log("LifesCount = " + PlayerHealth.lifesCount);
                ShowPanel();
                //Time.timeScale = 0;
            }
            else
            {
                //HidePanel();
            }
            
        }
    }

    public void ShowPanel()
    {     
        if(animator != null)
            {
                animator.SetTrigger("ShowPanel");
                //Debug.Log(isShown);
            }

            isShown = true;
            //Debug.Log(isShown);
    }

    public void HidePanel()
    {
        if (animator != null)
        {
            animator.SetTrigger("HidePanel");
        }

        isShown = false;
        //Debug.Log(isShown);
    }
}
