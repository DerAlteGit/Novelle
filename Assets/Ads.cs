using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;


public class Ads : MonoBehaviour
{
    [SerializeField] private int _delay;
    [SerializeField] private GameObject _banner;
    [DllImport("__Internal")]
    public static extern void ShowAd();
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(AdForTime());
        ShowAd();
    }

    
    public IEnumerator AdForTime()
    {
        while (true)
        {
            Debug.Log("Ad");
           yield return new WaitForSeconds(_delay);
            _banner.SetActive(true);
            StartCoroutine( _banner.GetComponent<PrepareAds>().Activate());
            //_banner.SetActive(false);
        }
    }
}
