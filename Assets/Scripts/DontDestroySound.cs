using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySound : MonoBehaviour
{

    public GameObject GameSound;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(GameSound);
    }
}
