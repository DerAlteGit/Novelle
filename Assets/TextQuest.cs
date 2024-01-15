using TMPro;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using System.Collections;

public class TextQuest : MonoBehaviour
{
    [SerializeField]private string rightWord;
    [SerializeField] private List<int> replaceCharByIndex;
    [SerializeField] private Transform textParent;
    [SerializeField]private TMP_Text textPrefab;
    [SerializeField] private string BlockName;
    [SerializeField] private Flowchart chart;
    private List<TMP_Text> texts = new List<TMP_Text>();
    private void Awake()
    {
        
        for (int i = 0; i < rightWord.Length; i++)
        {
            TMP_Text obj = Instantiate(textPrefab, textParent);
            obj.text = rightWord[i].ToString();
            texts.Add(obj);
        }
        for (int i = 0; i < replaceCharByIndex.Count; i++)
        {
            string container = texts[i].text;
            texts[i].text = texts[replaceCharByIndex[i]].text;
            texts[replaceCharByIndex[i]].text = container;
        }
    }
    public IEnumerator CheckWord()
    {
        
        string word = string.Empty;
        texts = new List<TMP_Text>();
        for(int i = 0; i < textParent.childCount; i++)
        {
            texts.Add(transform.GetChild(i).GetComponent<TMP_Text>());
        }
        foreach (TMP_Text text in texts)
        {
            word += text.text;
        }
        Debug.Log("¬веденное слово - " + word + " а правильное - " + rightWord);
        if (rightWord == word)
        {
            yield return new WaitForSeconds(1.2f);
            chart.ExecuteBlock(BlockName);
            gameObject.SetActive(false);
        }

    }

}
