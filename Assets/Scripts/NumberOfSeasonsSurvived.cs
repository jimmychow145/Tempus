using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NumberOfSeasonsSurvived : MonoBehaviour
{
    public Text seasonText;
    public SeasonChangerScript seasonChangerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seasonText.text = "You have survived: " + seasonChangerScript.numberOfSeasonSurvived + " Season";
    }
}
