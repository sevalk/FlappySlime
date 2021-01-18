using UnityEngine;
using UnityEngine.Advertisements;



public class RewardAdController : MonoBehaviour, IUnityAdsListener
{
   
    void IUnityAdsListener.OnUnityAdsDidError(string message)
    {

    }

    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                //Dont give reward
                break;
            case ShowResult.Skipped:
                //Dont Give reward
                break;
            case ShowResult.Finished:
                Debug.Log("REWARD TO PLAYER MONEY TO ME");
                break;
        }
    }

    void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
    {

    }

    void IUnityAdsListener.OnUnityAdsReady(string placementId)
    {

    }
    public void OnDisable()
    {
        Advertisement.RemoveListener(this);
    }
}