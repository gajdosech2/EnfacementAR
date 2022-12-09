using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIBlackOut : MonoBehaviour
{
    public GameObject blackOutSquare;
    public TextMeshProUGUI EmbodimentPercentage;   
    public GameObject BackToStart; 

    // Start is called before the first frame update
    void Start()
    {  
        StartCoroutine(FadeBlackOutSquare());
        BackToStart.SetActive(false);                   
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StopAllCoroutines();

            EmbodimentPercentage.text = "Tvár, ktorú ste považovali za svoju je \n: " + 100 * blackOutSquare.GetComponent<Image>().color.a + "% vaša biologická tvár \n a " + 100 * (1 - blackOutSquare.GetComponent<Image>().color.a) + "% avatar";
            Destroy(EmbodimentPercentage, 5f);
            
            BackToStart.SetActive(true);
        }        
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, float fadeSpeed = 0.1f )
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        yield return new WaitForSeconds(5f);

        if (fadeToBlack)
        {
            while (blackOutSquare.GetComponent<Image>().color.a < 1)
            {               
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;         
            }           
        }       
    }
}
