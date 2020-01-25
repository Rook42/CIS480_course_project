using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour

{
    public int position;
    public void Start()
    {
        position = (System.Convert.ToInt32(gameObject.transform.parent.Find("posText").GetComponent<TMPro.TextMeshProUGUI>().text)-1);
    }

    public void Update()
    {
        GetScore();
    }
    public void GetScore()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = (PlayerPrefs.GetInt(position.ToString())).ToString();
    }
}
