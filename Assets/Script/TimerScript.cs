using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{  
    public Image Timer;
    public float maxTime = 150f;
    public float timeLeft;
    public GameObject InstructionsSelfRecognition;

    // Start is called before the first frame update
    void Start()
    {
        InstructionsSelfRecognition.SetActive(false);
        Timer = GetComponent<Image> ();
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            Timer.fillAmount = timeLeft / maxTime;
        } else
        {
            InstructionsSelfRecognition.SetActive (true);
            Destroy(InstructionsSelfRecognition, 10f);
            Destroy(Timer, 5f);
            Time.timeScale = 0;
            SceneManager.LoadScene("Untitled", LoadSceneMode.Single);
        }        
    }
   
}
