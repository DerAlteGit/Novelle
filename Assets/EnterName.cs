using Fungus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnterName : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Flowchart chart;
    [SerializeField]private Character character;
    [SerializeField] private string nextBlockName;
    
    public void Save()
    {
        foreach (var variable in chart.Variables)
        {
            if (variable.Key == "Name")
            {
                Debug.Log("Founded");
                variable.Apply(SetOperator.Assign, text.text);
                character.NameText = text.text;
                PlayerPrefs.SetString("Name", text.text);
                //character.SetSayDialog.SetCharacterName(text.text, Color.white);
                chart.ExecuteBlock(nextBlockName);
                gameObject.SetActive(false);
            }
        }
    }
}
