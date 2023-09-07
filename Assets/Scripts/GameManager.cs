using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playAgainButton;
    public GameObject nextLevelButton;
    public GameObject gameCompletedMenu;
    PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.isLive == false)
        {
            StartCoroutine(GameOverMenu());
        }

        if(playerControllerScript.completedLevel == true)
        {
            StartCoroutine(NextLevelButton());
        }

        if (playerControllerScript.completedLevel == true && SceneManager.GetActiveScene().buildIndex == 2 )
        {
            StartCoroutine(GameCompletedMenu());
        }
    }

    public IEnumerator GameOverMenu()
    {
        yield return new WaitForSeconds(2.5f);
        playAgainButton.SetActive(true);
    }

    public IEnumerator NextLevelButton()
    {
        yield return new WaitForSeconds(6f);
        nextLevelButton.SetActive(true);
    }

    public IEnumerator GameCompletedMenu()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(3);

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RePlay()
    {
        SceneManager.LoadScene(1);
    }


    public void PlayNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
