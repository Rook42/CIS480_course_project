using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameInput : MonoBehaviour
{
    private string playerName;
    private int score;
    void Awake()
    {
        score = PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckName()
    {
    }
}
