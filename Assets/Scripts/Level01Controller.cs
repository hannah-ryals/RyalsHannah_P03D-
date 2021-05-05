using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] 
    public GameObject player;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitLevel();
        }
    }



    public void ExitLevel()
    {
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
}
