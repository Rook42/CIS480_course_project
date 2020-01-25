using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown difficultyDropdown;
    public int difficulty;


    public void Awake()
    {
        difficultyDropdown = GameObject.Find("Difficulty").GetComponent<TMPro.TMP_Dropdown>();
    }

    public void NextLevel()
    {
        //Saves difficulty and moves to the next level (level 1)
        SetDifficulty();
        PlayerPrefs.SetInt("difficulty", difficulty);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SetDifficulty()
    {
        //change difficulty according to slider
        difficulty = difficultyDropdown.value;
    }
}
