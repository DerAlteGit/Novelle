using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class FindIItems : MonoBehaviour
{
    
    [SerializeField]private Flowchart flowchart;
    [SerializeField] private string executableBlockName;
    public void FindItem(int index)
    {
        Debug.Log("Ok!");
        flowchart.SetIntegerVariable("IndexOfItem", index);
        flowchart.ExecuteBlock(executableBlockName);
    }
}
