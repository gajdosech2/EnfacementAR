using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    // Update is called once per frame
    public void StartExperience()
    {
        SceneManager.LoadScene("ARface");           
    }
}
