using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MainMenu
{
    new void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
