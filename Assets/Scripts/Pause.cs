using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{
    public Toggle music, sfx, control;

    public Slider Music, SFX;

    



    // Start is called before the first frame update
    void Start()
    {
        
        if (!PlayerPrefs.HasKey("musicVol"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("musicVol", 1); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("SFXVol"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("SFXVol", 1); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("musicMute"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("musicMute", 1); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("SFXMute"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("SFXMute", 1); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("controller"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetInt("controller", 1); // If it’s not, then save one
        }

    }

    // Update is called once per frame
    void Update()
    {
       
        if (!control.isOn)
        {
            PlayerPrefs.SetInt("controller", 0);
        }
        else
        {
            PlayerPrefs.SetInt("controller", 1);
        }

        PlayerPrefs.SetFloat("musicVol", Music.value);

        PlayerPrefs.SetFloat("SFXVol", SFX.value);


        if (!music.isOn)
        {
            PlayerPrefs.SetFloat("musicMute", 0);
        }
        else
        {
            PlayerPrefs.SetFloat("musicMute", 1);
        }

        if (!sfx.isOn)
        {
            PlayerPrefs.SetFloat("SFXMute", 0);
        }
        else
        {
            PlayerPrefs.SetFloat("SFXMute", 1);
        }




    }
   

}

