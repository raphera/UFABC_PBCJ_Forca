using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundControl : MonoBehaviour
{
    
    void Start()
    {
        GameObject GameSound = GameObject.Find("MenuSound"); // Procura o gameobject com o som de ambiente
        AudioSource source = GameSound.GetComponent<AudioSource>(); // Pega o arquivo de som do gameobject


        if(SceneManager.GetActiveScene().name == "Lab1_start") // Verifica qual a cena e decide oque fazer ( pause/play/stop )
        {
            source.Play();
        }
        else {
            if(SceneManager.GetActiveScene().name == "Lab1")
        {
            source.UnPause();
        }
        else{
            if(SceneManager.GetActiveScene().name == "Lab1_salvo")
        {
            source.Pause();
        }
        else{
            if(SceneManager.GetActiveScene().name == "Lab1_forca")
        {
            source.Pause();
        }

        }

        }
        }
    }

}
