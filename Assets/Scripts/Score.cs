using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    string updatedText;
    GameController gameController;
    void Start()
    {
        gameController = GameController.FindObjectOfType<GameController>();
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + gameController.score;
    }
}
