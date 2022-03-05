using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int numTentativas;          // Armazena as tentativas válidas da rodada
    private int maxNumTentativas;       // Número máximo de tentativaspara Forca ou Salvação
    int score = 0;

    public GameObject letra;            // prefab da letra no Game
    public GameObject centro;           // objeto de texto que indica o centro da tela

    private string palavraOculta = "";  //palavra oculta a ser descoberta
    private string[] palavrasOcultas = new string[] { "carro", "elefante", "futebol" }; // array de palavras ocultas

    char[] letrasOcultas;               // letras da palavra oculta
    bool[] letrasDescobertas;           // indicador de quais letras foram descobertas

    // Start is called before the first frame update
    void Start()
    {
        centro = GameObject.Find("centroDaTela");

        InitGame();
        InitLetras();

        numTentativas = 0;
        maxNumTentativas = 10;

        UpdateNumTentativas();
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTeclado();
    }

    /// <summary>
    /// Inicializa todos os objetos necessários para a gestão da palavra oculta.
    /// </summary>
    void InitLetras()
    {
        int numLetas = palavraOculta.Length;
        for (int i = 0; i < numLetas; i++)
        {
            Vector3 novaPosicao = new Vector3((float)(centro.transform.position.x + ((i - (numLetas - 1) / 2.0f) * 80)), centro.transform.position.y, centro.transform.position.z);
            GameObject l = (GameObject)Instantiate(letra, novaPosicao, Quaternion.identity);
            l.name = "letra" + (i + 1); // nomeia na hierarquia a GameObject com letra-(iésima + 1), i = 1..numLetras
            l.transform.SetParent(GameObject.Find("Canvas").transform); // posiciona-se como filho do GameObject Canvas
            l.GetComponent<Text>().font = (Font)Resources.Load("Fonts/PWChalk");
        }
    }

    /// <summary>
    /// Contém o conjunto de métodos necessários para inicializar o jogo.
    /// </summary>
    void InitGame()
    {
        //palavraOculta = "Elefante";                             // definição da palavra a ser descoberta (usado no Lab1 - parte A)

        //palavraOculta = palavrasOcultas[Random.Range(0, palavrasOcultas.Length)];

        palavraOculta = PegaUmaPalavraDoArquivo();

        palavraOculta = palavraOculta.ToUpper();                // transforma-se a palavra em maiúscula
        letrasOcultas = new char[palavraOculta.Length];         // instanciamos o array char letras da palavra
        letrasDescobertas = new bool[palavraOculta.Length];     // instanciamos um array de bool do indicador de letras certas
        letrasOcultas = palavraOculta.ToCharArray();            // copia-se a palavra no array de letras
    }

    /// <summary>
    ///     Método responsável por checar teclas pressionadas, verifica se é uma letra (a, b,..., z)
    /// e se a letra está contida na palavra escolhida para o jogo atual. Cotabiliza score, tentativas
    /// e realiza flag das letras encontradas na palavra para exibição futura na tela.
    /// </summary>
    void CheckTeclado() // Verifica se foi digitado alguma letra
    {
        if (Input.anyKeyDown)
        {
            char letraTeclada = Input.inputString.ToCharArray()[0];
            int letraTecladaComoInt = System.Convert.ToInt32(letraTeclada);

            if (letraTecladaComoInt >= 97 && letraTecladaComoInt <= 122)
            {
                numTentativas++;
                UpdateNumTentativas();

                if (numTentativas > maxNumTentativas)
                {
                    SceneManager.LoadScene("Lab1_forca");
                }

                for (int i = 0; i < palavraOculta.Length; i++)
                {
                    if (!letrasDescobertas[i])
                    {
                        letraTeclada = System.Char.ToUpper(letraTeclada);
                        if (letrasOcultas[i] == letraTeclada)
                        {
                            letrasDescobertas[i] = true;
                            GameObject.Find("letra" + (i + 1)).GetComponent<Text>().text = letraTeclada.ToString();

                            score = PlayerPrefs.GetInt("score");
                            score++;
                            PlayerPrefs.SetInt("score", score);
                            UpdateScore();
                            VerificaSePalavraDescoberta();
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Atualiza o valor do número de tentativas na tela principal de acordo com valor da variável da classe, alterando o texto do componente 'numTentativas'
    /// no canvas da cena atual.
    /// </summary>
    void UpdateNumTentativas()
    {
        GameObject.Find("numTentativas").GetComponent<Text>().text = "Tentativas: " + numTentativas + " | " + maxNumTentativas;
    }

    /// <summary>
    /// Atualiza o valor do número de score na tela principal de acordo com valor da variável da classe, alterando o texto do componente 'scoreUI'
    /// no canvas da cena atual.
    /// </summary>
    void UpdateScore() // Faz update do score
    {
        GameObject.Find("scoreUI").GetComponent<Text>().text = "Score: " + score;
    }

    /// <summary>
    /// Verifica se todas as letras da palavra foram descobertas para que a cena de vitória seja carregada.
    /// </summary>
    void VerificaSePalavraDescoberta()  // Verifica se a palavra foi descoberta
    {
        bool condicao = true;
        for (int i = 0; i < palavraOculta.Length; i++)
        {
            condicao = condicao && letrasDescobertas[i];
        }
        if (condicao)
        {
            PlayerPrefs.SetString("ultimaPalavraOculta", palavraOculta);
            SceneManager.LoadScene("Lab1_salvo");
        }
    }

    /// <summary>
    /// Método resposnsável por pegar uma única palavra de um arquivo de texto
    /// na pasta de Assets chamado "palavras". O arquivo contem um sequência de
    /// palavras separadas por um espaço (' ').
    /// </summary>
    /// <returns>
    /// Um objeto do tipo 'string' que é a palavra selecionada no arquivo.
    /// </returns>
    string PegaUmaPalavraDoArquivo()
    {
        TextAsset t1 = (TextAsset)Resources.Load("palavras", typeof(TextAsset));
        string s = t1.text;
        string[] palavras = s.Split(' ');
        int palavraAleatoria = Random.Range(0, palavras.Length);
        return palavras[palavraAleatoria];
    }
}
