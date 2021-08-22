using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject SpawnManager;
    public int animals;
    public int level;
    public int difficulty = 1;
    public int score;
    public GameObject[] liveAnimals;
    // Start is called before the first frame update

    void Start()
    {
        difficulty = PlayerPrefs.GetInt("difficulty") + 1;
        level = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
        animals = level * difficulty * 5;
        SpawnManager = GameObject.Find("SpawnManager");
        score = PlayerPrefs.GetInt("score");
        Wait();
    }

    // Update is called once per frame
    void Update()
    {
        liveAnimals = GameObject.FindGameObjectsWithTag("Animals");
        if (animals == 0 && liveAnimals.Length == 0) //if there aren't any animals left to spawn and there aren't any alive, load the next scene.
        {
            PlayerPrefs.SetInt("score", score);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        GameObject.Find("Level Text").SetActive(false);
    }
}
