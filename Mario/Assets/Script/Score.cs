using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scorea = 0;
    Text scor;
    // Start is called before the first frame update
    void Start()
    {
        scor = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        scor.text = "Score: " + scorea;
    }
}
