using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageBotoes : MonoBehaviour
{
    public string nomeDaCena;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("score", 0);
    }
    // Chama o ChangeScene pra conseguir ter um delay  com o som do botao
    public void ChangeS()
    {
        Invoke("ChangeScene", 0.2f);
    }
    // Troca basica de cena podendo ser usada em outros botoes com outras cenas
    public void ChangeScene()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}
