using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostraUltimaPalavraOculta : MonoBehaviour
{
    // Assim que inicia a cena, ele pega o texto de um objeto de outra cena
    void Start()
    {
        //  Altera texto do componente no canvas associado a esse script para exibir
        // a palavra oculta descoberta.
        GetComponent<Text>().text = PlayerPrefs.GetString("ultimaPalavraOculta");
    }

}
