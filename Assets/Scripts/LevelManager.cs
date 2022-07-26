using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame()
    {
        if(scoreKeeper!=null)
            scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void LoadEndGame()
    {
        StartCoroutine(WaitAndLoad("End", 2));
    }

    public IEnumerator WaitAndLoad(string sceneName,float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(sceneName);
    }
}
