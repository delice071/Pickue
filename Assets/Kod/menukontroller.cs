using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menukontroller : MonoBehaviour
{

    

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject levelcomplatemenu;
    public AudioSource Damn;
    public AudioClip buttonV;

    // Update is called once per frame
    void start()
    {

        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        levelcomplatemenu.SetActive(false);
    }
    


    public void buttonlar(int gelenbuton)
    {
        if(gelenbuton == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(buttonV, 1f);
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if(gelenbuton == 2)
        {
            GetComponent<AudioSource>().PlayOneShot(buttonV, 1f);
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        if(gelenbuton == 3)
        {
            GetComponent<AudioSource>().PlayOneShot(buttonV, 1f);
            optionsMenu.SetActive(true);
            pauseMenu.SetActive(false);
        }
        if(gelenbuton == 4)
        {
            GetComponent<AudioSource>().PlayOneShot(buttonV, 1f);
            SceneManager.LoadScene(0);
        }
        if(gelenbuton == 5)
        {
            GetComponent<AudioSource>().PlayOneShot(buttonV, 1f);
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void SetQuality(int qual)
    {
        QualitySettings.SetQualityLevel(qual);
    }
    public void SetFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
    public void SetMusic(bool isMusic)
    {
        Damn.mute = !isMusic;
    }

    public void levelcompletecontrol(int lvlcomp)
    {
        if(lvlcomp == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(buttonV, 1f);
            SceneManager.LoadScene(0);
        }
        if(lvlcomp == 2)
        {
            GetComponent<AudioSource>().PlayOneShot(buttonV, 1f);
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        if(lvlcomp == 3)
        {
            GetComponent<AudioSource>().PlayOneShot(buttonV, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    } 
    public void deadcontrol(int dead)
    {
        if(dead == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(buttonV, 1f);
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        if(dead == 2)
        {
            GetComponent<AudioSource>().PlayOneShot(buttonV, 1f);
            SceneManager.LoadScene(0);
        }
    }
}
