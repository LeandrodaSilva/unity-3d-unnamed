using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlacarScript : MonoBehaviour
{
    Text placar;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        placar = GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        placar.text = "Pontos: " + score;
    }
}
