using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class MapQuest : MonoBehaviour
{
    [SerializeField]private bool[] points = new bool[4] { false, false,false,false };
    [SerializeField] private string blockName;
    [SerializeField] private Flowchart chart;
    [SerializeField] private List<Animator> lines;
    public void ClickArea(int index)
    {
        points[index] = true;
        foreach (var item in points)
        {
            if (!item)
            {
                return;
            }
        }
        StartCoroutine(ActiveLines());
    }
    public IEnumerator ActiveLines()
    {
        foreach (var item in lines)
        {
            item.SetTrigger("Fade1");
        }
        yield return new WaitForSeconds(2);
        chart.ExecuteBlock(blockName);
        gameObject.GetComponent<MapQuest>().enabled = false;
    }
}
