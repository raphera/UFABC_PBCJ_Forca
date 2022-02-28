using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject letra;            // prefab da letra no Game
    public GameObject centro;           // objeto de texto que indica o centro da tela

    private string palavraOculta = "";  //palavra oculta a ser descoberta
    private string[] palavrasOcultas = new string[] { "carro", "elefante", "futebol" }; // array de palavras ocultas

    private int tamanhoPalavraOculta;   // tamanho da palavra
    char[] letrasOcultas;               // letras da palavra oculta
    bool[] letrasDescobertas;           // indicador de quais letras foram descobertas

    // Start is called before the first frame update
    void Start()
    {
        centro = GameObject.Find("centroDaTela");
        InitGame();
        InitLetras();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTeclado();
    }

    void InitLetras()
    {
        int numLetas = palavraOculta.Length;
        for (int i = 0; i < numLetas; i++)
        {
            Vector3 novaPosicao = new Vector3(centro.transform.position.x + ((i-numLetas/2.0f)* 80), centro.transform.position.y, centro.transform.position.z);
            GameObject l = (GameObject)Instantiate(letra, novaPosicao, Quaternion.identity);
            l.name = "letra" + (i + 1); // nomeia na hierarquia a GameObject com letra-(iésima + 1), i = 1..numLetras
            l.transform.SetParent(GameObject.Find("Canvas").transform); // posiciona-se como filho do GameObject Canvas
        }
    }

    void InitGame()
    {
        //palavraOculta = "Elefante";                             // definição da palavra a ser descoberta (usado no Lab1 - parte A)

        palavraOculta = palavrasOcultas[Random.Range(0, palavrasOcultas.Length)];
        tamanhoPalavraOculta = palavraOculta.Length;            // determina-se o número de letras da palavra
        palavraOculta = palavraOculta.ToUpper();                // transforma-se a palavra em maiúscula
        letrasOcultas = new char[palavraOculta.Length];         // instanciamos o array char letras da palavra
        letrasDescobertas = new bool[palavraOculta.Length];     // instanciamos um array de bool do indicador de letras certas
        letrasOcultas = palavraOculta.ToCharArray();            // copia-se a palavra no array de letras
    }

    void CheckTeclado()
    {
        if (Input.anyKeyDown)
        {
            char letraTeclada = Input.inputString.ToCharArray()[0];
            int letraTecladaComoInt = System.Convert.ToInt32(letraTeclada);

            if(letraTecladaComoInt >= 97 && letraTecladaComoInt <= 122)
            {
                for (int i = 0; i < tamanhoPalavraOculta; i++)
                {
                    if(!letrasDescobertas[i])
                    {
                        letraTeclada = System.Char.ToUpper(letraTeclada);
                        if(letrasOcultas[i] == letraTeclada)
                        {
                            letrasDescobertas[i] = true;
                            GameObject.Find("letra" + (i + 1)).GetComponent<Text>().text = letraTeclada.ToString();
                        }
                    }
                }
            }
        }
    }
}
