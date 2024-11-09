using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] private string _iOsAdUnitId = "Interstitial_iOS";
    private string _adUnitId;

    private bool isAdLoaded = false;
    private int builtTowers = 0;

    public void OnUnityAdsAdLoaded(string placementId)
    {
        
    }
   
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
       
    }

    public void OnUnityAdsShowClick(string placementId)
    {
       

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {

    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        
    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }

    private void LoadAd()
    {
        Debug.Log("Advertisement has started loading...");
        Advertisement.LOad(_adUnitId, this);
    }
}
