using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ManageBotoes : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("score", 0);
        
    }

    public void GoSceneByButtonPressed()
    {
        string btnClicked = EventSystem.current.currentSelectedGameObject.name;

        if (btnClicked.Equals("BtnIniciar")) // Cria um delay por conta do som do botao
        {
            Invoke("ChangeLab1", 0.2f);
        }
        else if (btnClicked.Equals("BtnSair"))
        {
            Invoke("ChangeLab1_Creditos", 0.2f);
        }
    }


    public void ChangeLab1()
    {
        SceneManager.LoadScene("Lab1");
    }

    public void ChangeLab1_Creditos()
    {
        SceneManager.LoadScene("Lab1_Creditos");
    }
}


