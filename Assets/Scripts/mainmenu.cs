using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{
    public GameObject Basiclayer;
    public GameObject Tutoriallayer;
    public Animator transistion;
    public float transistionTime = 1f;
    //If you want to add a transistion animation to game scene, u need to make scene loader a sepereate prefab and drag it 
    //into the game scene.
    public void startgame()
    {
        transistion.SetTrigger("Start");
        print("trigger activated");   
        Invoke("loadscene", transistionTime);
    }
       
    public void quitgame()
    {
        
         Application.Quit();
        
    }
  

    public void loadscene()
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
