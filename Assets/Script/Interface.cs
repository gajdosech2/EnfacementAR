using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interface : MonoBehaviour
{
    public Image Timer;
    public float maxTime = 150f;
    float timeLeft;
    public GameObject InstructionsSelfRecognition;
    public GameObject blackOutSquare;
    public TextMeshProUGUI EmbodimentPercentage;

    void Awake()
    {
        GameObject.Find("blackOutSquare");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeBlackOutSquare());
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
            Time.timeScale = 0;            
        }          

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StopAllCoroutines();

            EmbodimentPercentage.text = "Biological Enfacement: " + 100 * blackOutSquare.GetComponent<Image>().color.a + "% \nAvatar Enfacemenet: " + 100 * (1 - blackOutSquare.GetComponent<Image>().color.a) + "%";
            Destroy(EmbodimentPercentage, 5f);
        }
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, float fadeSpeed = 0.01f)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        yield return new WaitForSeconds (maxTime);

        if (fadeToBlack)
        {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackOutSquare.GetComponent<Image>().color = objectColor;
            yield return null;           
        }       
    }
}
