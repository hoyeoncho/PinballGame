using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CompressorController : MonoBehaviour
{
    public float restPower = 0f;
    public float maxPower = 100f;
    public float power = 0f;
    public Slider slider;
    List<Rigidbody> balls;
    public bool isReadyToShot = false;
    //Sound Effect
    public AudioClip sfxSound;


    void Start()
    {
        balls = new List<Rigidbody>();
        slider.minValue = restPower;
        slider.maxValue = maxPower;

        //FindObjectOfType<AudioSource>().clip = GameManager.Get.bgms[1];
        
        //GameManager.Get.PlayMusic(GetComponent<AudioSource>().clip, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReadyToShot)
        {
            slider.gameObject.SetActive(true);
        }
        else slider.gameObject.SetActive(false);

        if (balls.Count > 0)
        {
            isReadyToShot = true;
            if (Input.GetKey(KeyCode.Space))
            {
                if (power <= maxPower)
                {
                    power += 50f * Time.deltaTime;

                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                GameManager.Get.PlaySound(sfxSound,transform.position);
                foreach (var ball in balls)
                {
                    ball.AddForce((power*10) * Vector3.forward);
                }
            }
        }
        else
        {
            isReadyToShot = false;
            power = 0f;
        }
        slider.value = power;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            balls.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            balls.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = 0f;
        }
    }
}
