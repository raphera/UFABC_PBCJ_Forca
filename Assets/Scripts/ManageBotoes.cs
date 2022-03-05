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
        // Reinicia o score do jogador para caso queira começar um novo jogo.
        PlayerPrefs.SetInt("score", 0);

    }

    /// <summary>
    /// Carrega a cena de acordo com o botão pressionado.
    /// </summary>
    public void GoSceneByButtonPressed()
    {
        // Obtem o nome do botão pressinado verificando os eventos do sistema.
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

    /// <summary>
    /// Carrega a cena do jogo.
    /// </summary>
    public void ChangeLab1()
    {
        SceneManager.LoadScene("Lab1");
    }

    /// <summary>
    /// Carrega a cena de créditos
    /// </summary>
    public void ChangeLab1_Creditos()
    {
        SceneManager.LoadScene("Lab1_Creditos");
    }
}


