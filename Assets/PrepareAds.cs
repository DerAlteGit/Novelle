
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class PrepareAds : MonoBehaviour
{
    [SerializeField] private int timerSeconds;
    private int currentTimeInSeconds;
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private Fungus.DialogInput input;
    public IEnumerator Activate()
    {
        input = FindObjectOfType<Fungus.DialogInput>();
        if(input != null)input.enabled = false;
        currentTimeInSeconds = 0;
        _timer.text = timerSeconds.ToString();
        while(currentTimeInSeconds < timerSeconds)
        {
            yield return new WaitForSeconds(1);
            currentTimeInSeconds++;
            _timer.text = (timerSeconds - currentTimeInSeconds).ToString();
        }

        if (input != null) input.enabled = true;
        gameObject.SetActive(false);
    }
}
