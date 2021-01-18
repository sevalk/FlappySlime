using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Player : MonoBehaviour
{

    [SerializeField] float mainThrust = 100f;
    [Range(0, 5)] public float speed;

    [SerializeField] AudioClip death_audio;
    
    [SerializeField] Text highScore;
    [SerializeField] Text score;
    [SerializeField] int point;
    [SerializeField] public int highPoint;
    [SerializeField] int pointForPerObs = 30;

    private Touch theTouch;


    Rigidbody rigidBody;

    [SerializeField] GameObject restart;
    [SerializeField] GameObject player;
    
    
    
  
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        GetComponent<SaveLoad>().Load();
        highScore.text = highPoint.ToString();
    }

    void Update()
    {

        var X = new Vector3(0, 0, speed);
        transform.position = transform.position + X;
        RespondToThrustInput();
       
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "obstacle")
        {
            AudioSource.PlayClipAtPoint(death_audio, Camera.main.transform.position);
            
            StartCoroutine(sceneLoader());
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacleMid")
        {
            Destroy(other.gameObject,2f);
            speed += 0.005f;

             point += pointForPerObs;
             pointForPerObs += 16;
             score.text = point.ToString();


            if(highPoint < point)
            {
                highPoint = point;
                highScore.text = highPoint.ToString();
            }

            
            GetComponent<SaveLoad>().Save();


        }
    }

    public IEnumerator sceneLoader()
    {
        Advertisement.Banner.Hide(true);
        yield return new WaitForSeconds(1f);
        EventManager.TriggerPlayAds(AdsPlacementType.intersitialAds);
        SceneManager.LoadScene(0);
        

    }

   
   

    private void RespondToThrustInput()
    {

        if(Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            ApplyThrust();


        }


    }

    private void ApplyThrust()
    {
        rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

    }

}
