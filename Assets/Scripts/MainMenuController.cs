using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip _startingSong;
    [SerializeField] Text _highScoreTextView;


    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();

        if (_startingSong != null)
        {
            AudioManager.Instance.PlaySong(_startingSong);
        }

    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        _highScoreTextView.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    /* public void HideMouse()
     {
         Cursor.visible = false;
     } */

    public void EndGame()
    {
        Application.Quit();
    }

}

