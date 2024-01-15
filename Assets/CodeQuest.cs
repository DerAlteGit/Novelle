using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Fungus;
using System.Threading.Tasks;

public class CodeQuest : MonoBehaviour
{
    [SerializeField]private int[] rightCode = new int[4] ;
    [SerializeField]private int[] enteredCode = new int[4] { -1, -1, -1, -1 };
    [SerializeField] private Image[] indicators = new Image[4];
    [SerializeField] private string blockName;
    [SerializeField] private Flowchart chart;
    [SerializeField] private AudioSource click;
    [SerializeField] private string helpBlockName;
    [SerializeField] private int helpTimer;
   
    private void Start()
    {
        foreach (var item in indicators)
        {
            item.color = new Color(0, 0, 0, 0);
        }
    }
    public void EnterNumber(int number)
    {
        click.Play();
        Debug.Log("Click");
        for (int i = 0; i < enteredCode.Length; i++)
        {
            if (enteredCode[i] == -1)
            {
                if (number == rightCode[i])
                {
                    enteredCode[i] = number;
                    indicators[i].color = new Color(0,1,0,0.7f);
                    if(i == enteredCode.Length - 1)
                    {
                        chart.ExecuteBlock(blockName);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    enteredCode = new int[4] { -1, -1, -1, -1 };
                    foreach (var item in indicators)
                    {
                        item.color = new Color(0, 0, 0, 0);
                    }
                }
                break;
            }
            
        }
    }
}
