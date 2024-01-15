using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragText : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private Transform parent;
    [SerializeField]private GameObject empty;
    [SerializeField] private TextQuest questLogic;
    private int previousIndex;

    public void OnBeginDrag(PointerEventData eventData)
    {
        previousIndex = transform.GetSiblingIndex();
        parent = transform.parent;
        transform.parent = transform.parent.parent;
        empty.transform.parent = parent;
        empty.transform.SetSiblingIndex(previousIndex);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach(RaycastResult result in results)
        {
            if(result.gameObject.GetComponent<TMP_Text>() != null)
            {
                
                TMP_Text foundedText = result.gameObject.GetComponent<TMP_Text>();
                if(foundedText == GetComponent<TMP_Text>())
                {
                    continue;
                }
                if (foundedText.transform.parent == parent)
                {
                    empty.transform.parent = parent.transform.parent;
                    transform.parent = parent;
                    transform.SetSiblingIndex(foundedText.transform.GetSiblingIndex());
                    foundedText.transform.SetSiblingIndex(previousIndex);
                    StartCoroutine( questLogic.CheckWord());
                    return;
                }
                
            }
        }
        empty.transform.parent = parent.transform.parent;
        transform.parent = parent;
        transform.SetSiblingIndex(previousIndex);

    }

 
}
