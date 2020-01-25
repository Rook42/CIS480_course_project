using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscores : MonoBehaviour
{
    public int score;
    public List<GameObject> entries;
    public SortedDictionary<int, string> scores = new SortedDictionary<int, string>{
        { 320,"UMR" },
        { 301,"RMS" },
        { 240,"RCC" },
        { 250,"DJT" },
        { 300,"ESR" },
        { 290,"SLL" },
        { 280,"CAT" },
        { 260,"DOG" },
        { 230,"GOD" },
        { 210,"K&R" },
    }; //Key is recorded highscore, value is name of player
    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetInt("0", 320);
        PlayerPrefs.SetString("320", "UMR");
        PlayerPrefs.SetInt("1", 301);
        PlayerPrefs.SetString("301", "RMS");
        PlayerPrefs.SetInt("2", 240);
        PlayerPrefs.SetString("240", "RCC");
        PlayerPrefs.SetInt("3", 250);
        PlayerPrefs.SetString("250", "DJT");
        PlayerPrefs.SetInt("4", 300);
        PlayerPrefs.SetString("300", "ESR");
        PlayerPrefs.SetInt("5", 290);
        PlayerPrefs.SetString("290", "SLL");
        PlayerPrefs.SetInt("6", 280);
        PlayerPrefs.SetString("280", "CAT");
        PlayerPrefs.SetInt("7", 260);
        PlayerPrefs.SetString("260", "DOG");
        PlayerPrefs.SetInt("8", 230);
        PlayerPrefs.SetString("230", "GOD");
        PlayerPrefs.SetInt("9", 210);
        PlayerPrefs.SetString("210", "K&R");
        score = PlayerPrefs.GetInt("score");
        for (int i = 0; i < 10; i++)
        {
            int thisScore = PlayerPrefs.GetInt(i.ToString(), 10); //get the top scores from PlayerPrefs, saved in strings numbered 0-9
            string thisName = PlayerPrefs.GetString(thisScore.ToString(), "RCC");
            while (scores.ContainsKey(thisScore)) //just to make sure the dictionary won't have any duplicates, even when first ran
            {
                thisScore--;
            }            
            if (thisScore == PlayerPrefs.GetInt("score"))
            {
                score--; // no two scores may be exactly alike.
            }

            scores.Add(thisScore, thisName); 
        }
    }
    public void CheckPlayer(string playerName)
    {
        int playerScore = score;
        scores.Add(playerScore, playerName); // add player to scores
        int i = scores.Count;
        foreach ( KeyValuePair<int, string> score in scores) //have to do this backwards since it's sorted ascending
            {        
            if (i <= 10) //grab only the last 10 entries
            { 

                PlayerPrefs.SetInt(i.ToString(), score.Key); // set the new top score for that position
                PlayerPrefs.SetString(score.Key.ToString(), score.Value); // set the new name for that position
            }
            i--;
        }
        PlayerPrefs.Save();
    }

}
