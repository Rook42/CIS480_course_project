using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
            GameController.FindObjectOfType<GameController>().score--;
        }
        else if (transform.position.z < lowerBound)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
