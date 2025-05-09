using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInputText : MonoBehaviour
{
    public InputField mainInputField;
    public void Submit_Name()
    {
        Debug.Log("Submit_named");
        GameObject.FindGameObjectWithTag("Score").GetComponent<BestScoreText>().Save_Name(mainInputField.text);


    }
    
}
