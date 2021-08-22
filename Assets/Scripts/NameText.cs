using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameText : MonoBehaviour
{
    public int score;
    public void Start()
    {
 
    }

    public void Update()
    {
        score = System.Convert.ToInt32(gameObject.transform.parent.Find("scoreText").GetComponent<TMPro.TextMeshProUGUI>().text); // get score from relevant sibling
        GetName();
    }
    public void GetName()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetString(score.ToString());
    }
}
