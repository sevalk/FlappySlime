using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class TopToStart : MonoBehaviour
{

    [SerializeField] GameObject player;
    
    private Touch theTouch;

    private void Awake()
    {
        player.SetActive(false);
    }
    
  
    void Update()
    {
        topToStart();
    }

    public void topToStart()
    {


        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            Destroy(this.gameObject);
            player.SetActive(true);
            //EventManager.TriggerPlayAds(AdsPlacementType.bannerPlacement);
            
        }
       
    }


}
