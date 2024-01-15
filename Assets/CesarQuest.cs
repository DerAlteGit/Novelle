using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fungus;

public class CesarQuest : MonoBehaviour
{
    [SerializeField]private TMP_Text _text;
    [SerializeField] private string rightWord;
    [SerializeField] private string messageWord;
    [SerializeField] private Flowchart chart;
    [SerializeField] private string blockName;
    [SerializeField] private TMP_Text message;
    private void Start()
    {
        message.text = messageWord;
    }
    public void CheckAnswer()
    {
        Debug.Log(_text.text + " " + rightWord);
        if(_text.text.ToLower().Trim().CompareTo( rightWord.ToLower().Trim()) == 0)
        {
            Debug.Log("Ok!!");
            chart.ExecuteBlock(blockName);
            gameObject.SetActive(false);
        }
    }
    public void Skip()
    {
        chart.ExecuteBlock(blockName);
        gameObject.SetActive(false);
    }
}
