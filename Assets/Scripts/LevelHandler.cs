using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public GameObject gameoverScreen, winScreen;



    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Start")
        {
            gameoverScreen.SetActive(false);
            winScreen.SetActive(false);
        }
        else
            AudioManager.instance.Play("Bg");
    }

    private void Update()
    {
        
    }

    public void StartLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
