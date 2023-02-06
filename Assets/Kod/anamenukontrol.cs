using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class anamenukontrol : MonoBehaviour
{
    GameObject leveller;
    public GameObject ses_acik, ses_kapali;
    AudioSource ses_kontroll;
    public AudioClip buttonV;
    void Start()
    {
        leveller = GameObject.Find("leveller");

        leveller.SetActive(false);
        ses_kontroll = GetComponent<AudioSource>();
        ses_kontroll.mute = true;

        for(int i=0; i < PlayerPrefs.GetInt("kacincilevel"); i++)
        {
            leveller.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {
            ses_acik.SetActive(true);
            ses_kapali.SetActive(false);
            ses_kontroll.mute = false;
        }
        else if (PlayerPrefs.GetInt("sesDurum") == 0)
        {
            ses_acik.SetActive(false);
            ses_kapali.SetActive(true);
            ses_kontroll.mute = true;
        }
    }

    public void butonSec(int gelenbuton)
    {
        if (gelenbuton == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(buttonV, 1f);
            leveller.SetActive(true);
        }
        else if (gelenbuton == 2)
        {
            GetComponent<AudioSource>().PlayOneShot(buttonV, 1f);
            Application.Quit();
        }
    }

    public void ses_durum(string durum)
    {
        if (durum == "acik")
        {
            ses_acik.SetActive(false);
            ses_kapali.SetActive(true);
            PlayerPrefs.SetInt("sesDurum", 0);
        }
        else if (durum == "kapali")
        {
            ses_acik.SetActive(true);
            ses_kapali.SetActive(false);
            PlayerPrefs.SetInt("sesDurum", 1);
        }
    }
    public void levellerbuton(int gelenlevel)
    {
        GetComponent<AudioSource>().PlayOneShot(buttonV, 1f);
        SceneManager.LoadScene(gelenlevel);
    }
}
