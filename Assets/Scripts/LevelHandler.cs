using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public GameObject gameoverScreen, winScreen, controlsScreen;

    public List<GameObject> backgrounds;



    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Start")
        {
            gameoverScreen.SetActive(false);
            winScreen.SetActive(false);
        }
        else
        {
            AudioManager.instance.Play("Bg");
            controlsScreen.SetActive(false);
        }
    }

    private void Update()
    {
        
    }

    public void StartLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void ShowControls()
    {
        controlsScreen.SetActive(true);
    }

    public void BackButton()
    {
        controlsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
