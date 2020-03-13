using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ColorsSet
{
    public Material playerColor;
    public Material targetObjectColor;
    //public Material ArchColor;
    public Material obstacleFirstColor;
    public Material obstacleSecondColor;
}
public class ColorManager : MonoBehaviour
{
    public static ColorManager SharedInstance;
    public List<ColorsSet> SetsOfColorsList;
    public GameObject player;
    private Renderer playerRend;
    private int currentColorsSetIndex;
    private int nextColorSetIndex;


    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        playerRend = player.GetComponent<Renderer>();
        currentColorsSetIndex = Random.Range(0, SetsOfColorsList.Count);

        playerRend.material = SetsOfColorsList[currentColorsSetIndex].playerColor;
    }

    public void ApplyNewColorSet()
    {
        playerRend.material = SetsOfColorsList[nextColorSetIndex].playerColor;
        
    }
    


    public void ChooseObjectsColors(GameObject go)
    {
        if(go != null)
        {
            
                if (go.tag == "TargetObject")
                {

                go.GetComponent<AdditionalData>().materialToApply = SetsOfColorsList[currentColorsSetIndex].targetObjectColor;
                }

                if (go.tag == "ObstacleObject")
                {
                    if (Random.Range(0, 2) > 0)
                    {

                    go.GetComponent<AdditionalData>().materialToApply = SetsOfColorsList[currentColorsSetIndex].obstacleFirstColor;
                    }
                    else
                    {

                    go.GetComponent<AdditionalData>().materialToApply = SetsOfColorsList[currentColorsSetIndex].obstacleSecondColor;
                    }
                }

                if (go.tag == "ColorChanger")
                {

                    nextColorSetIndex = RandomIntExcept(0, SetsOfColorsList.Count, currentColorsSetIndex);
                    //Debug.Log("current index = " + currentColorsSetIndex + " " + SetsOfColorsList[currentColorsSetIndex].playerColor 
                    //+ " next index = " + nextColorSetIndex + " " + SetsOfColorsList[nextColorSetIndex].playerColor);
                    go.GetComponent<AdditionalData>().materialToApply = SetsOfColorsList[nextColorSetIndex].playerColor;
                    currentColorsSetIndex = nextColorSetIndex;
            }

        }

    }



    private int RandomIntExcept(int min, int max, int except)
    {
        int result = Random.Range(min, max);

        if (result == except)
        {
            if (except == max - 1 || except == min)
            {
                if (except == max - 1)
                {
                    result = max - Random.Range(1, max);
                }

                if (except == min)
                {
                    result = min + Random.Range(1, max);
                }
            }
            else
            {
                result += 1;
            }
        }

        return result;
    }

}
