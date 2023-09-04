using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    AudioManager audioManager;
    public TextMeshProUGUI scoreText;
    public int score;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
      UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            audioManager.PlaySFX(audioManager.itemCollectedSFX);
            score += 2;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Hearth"))
        {
            audioManager.PlaySFX(audioManager.heartCollectedSFX);
            score += 5;
            Destroy(other.gameObject);
        }
    }


    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}