using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    public Text timerText;
    public Text timeIsOut;
    public GameObject player;
    public AudioSource intro;
    public AudioSource end;

    int _currentScore;

    void Start()
    {
        StartCoroutine(reloadTimer(0));
        StartCoroutine(EndTimer(0));
        intro.Play();
        
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitLevel();
        }
    }

    public void IncreaseScore(int scoreIncrease)
    {
        _currentScore += scoreIncrease;
        _currentScoreTextView.text = "Score: " + _currentScore.ToString();
    }

   

    public void ExitLevel()
    {
        SceneManager.LoadScene("MainMenu");
        //Cursor.visible = true;
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (_currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New high score: " + _currentScore);
            
        }
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

  

    IEnumerator reloadTimer(float reloadTimeInSeconds)
    {
        float counter = -30;

        while (counter < reloadTimeInSeconds)
        {
            counter += Time.deltaTime;
            timerText.text = counter.ToString();
            yield return null;
        }

        if (counter >= 0)
        {
            end.Play();
            counter = 0;
            timerText.text = counter.ToString();
            timeIsOut.transform.localScale = new Vector3(1, 1, 1);
            
            //Transport();
            Debug.Log("time ran out");
        }
    }

    IEnumerator EndTimer(float EndTimerInSeconds)
    {
        float counterdos = -35;

        while (counterdos < EndTimerInSeconds)
        {
            counterdos += Time.deltaTime;
            yield return null;
        }

        if (counterdos >= 0)
        {
            ExitLevel();
        }
    }
}
