using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    public GameObject player;
    public AudioSource intro;

    int _currentScore;

    void Start()
    {
        //intro.Play();

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitLevel();
        }
    }


    public void IncreaseScore()
    {
        _currentScore += 1;
        _currentScoreTextView.text = "Score: " + _currentScore.ToString();
    }



    public void ExitLevel()
    {
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
}
