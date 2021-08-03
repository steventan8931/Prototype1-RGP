using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{
    public GameObject Basiclayer;
    public GameObject Tutoriallayer;
    public void startgame()
    {
        SceneManager.LoadScene(1);
    }

    public void openTutorial()
    {
        
        Basiclayer.SetActive(false);
        Tutoriallayer.SetActive(true);

    }

    public void closeTutorial()
    {
        Tutoriallayer.SetActive(false);
        Basiclayer.SetActive(true);

    }

}
