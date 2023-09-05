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

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
