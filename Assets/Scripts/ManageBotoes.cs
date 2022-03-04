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

        if (btnClicked.Equals("BtnIniciar"))
        {
            SceneManager.LoadScene("Lab1");
        }
        else if (btnClicked.Equals("BtnSair"))
        {
            SceneManager.LoadScene("Lab1_Creditos");
        }
    }

}
