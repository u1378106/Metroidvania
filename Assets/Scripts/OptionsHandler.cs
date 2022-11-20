using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject optionScreen;

    private bool isOptionsVisible;

    // Start is called before the first frame update
    void Start()
    {
        isOptionsVisible = false;
        optionScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isOptionsVisible)
        {
            optionScreen.SetActive(true);
            isOptionsVisible = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isOptionsVisible)
        {
            optionScreen.SetActive(false);
            isOptionsVisible = false;
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        optionScreen.SetActive(false);
        isOptionsVisible = false;
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);     
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
