using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscores : MonoBehaviour
{
    public int score;
    public List<GameObject> entries;
    public SortedDictionary<int, string> scores = new SortedDictionary<int, string> { }; //Key is recorded highscore, value is name of player
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetInt("0", 0) == 0){
            LoadDefaultHighscores();
         }
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
            i--;
            if (i <= 10) //grab only the last 10 entries
            { 

                PlayerPrefs.SetInt(i.ToString(), score.Key); // set the new top score for that position
                PlayerPrefs.SetString(score.Key.ToString(), score.Value); // set the new name for that position
            }
        }
        PlayerPrefs.Save();
    }

    public void LoadDefaultHighscores()
    {
        PlayerPrefs.SetInt("0", 301);
        PlayerPrefs.SetString("301", "UMR");
        PlayerPrefs.SetInt("1", 299);
        PlayerPrefs.SetString("299", "RMS");
        PlayerPrefs.SetInt("2", 298);
        PlayerPrefs.SetString("298", "ESR");
        PlayerPrefs.SetInt("3", 297);
        PlayerPrefs.SetString("297", "K&R");
        PlayerPrefs.SetInt("4", 296);
        PlayerPrefs.SetString("296", "RCC");
        PlayerPrefs.SetInt("5", 295);
        PlayerPrefs.SetString("295", "SLL");
        PlayerPrefs.SetInt("6", 294);
        PlayerPrefs.SetString("294", "CAT");
        PlayerPrefs.SetInt("7", 293);
        PlayerPrefs.SetString("293", "DOG");
        PlayerPrefs.SetInt("8", 292);
        PlayerPrefs.SetString("292", "GOD");
        PlayerPrefs.SetInt("9", 291);
        PlayerPrefs.SetString("291", "MAN");
    }
}
