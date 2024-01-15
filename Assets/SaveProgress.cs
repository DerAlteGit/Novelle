using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    private string blockName;
    //private int comandIndex;
    [SerializeField] private Flowchart chart;
    public void Save()
    {
        
        blockName = chart.GetExecutingBlocks().Count > 0 ? chart.GetExecutingBlocks()[0].BlockName : null;
       // comandIndex = chart.GetExecutingBlocks().Count > 0 ? chart.GetExecutingBlocks()[0].ActiveCommand.CommandIndex : 0;
        PlayerPrefs.SetString("BlockName", blockName);
        //PlayerPrefs.SetInt("ComandIndex", comandIndex);
    }
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        Load();
    }
    private void Update()
    {
        Save();
    }
    public void Load()
    {
        blockName = PlayerPrefs.GetString("BlockName");
        if(blockName == null || blockName == "")
        {
            Reset();
            Load();
        }
        //comandIndex = PlayerPrefs.GetInt("ComandIndex");
        chart.ExecuteBlock(blockName);
        chart.SetStringVariable("Name", PlayerPrefs.GetString("Name"));
        //chart.GetExecutingBlocks()[0].CommandList[comandIndex].Execute();
    }
    public void Reset()
    {
        PlayerPrefs.SetString("BlockName", "New Block26");
        PlayerPrefs.SetString("Name", null);
        
    }
}
