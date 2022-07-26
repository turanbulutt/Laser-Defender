using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider HealthSlider;
    [SerializeField] Health PlayerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;



    // Start is called before the first frame update
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        SetSlider();
    }

    private void SetSlider()
    {
        HealthSlider.maxValue = PlayerHealth.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        HealthSlider.value = PlayerHealth.GetHealth();
    }

    private void UpdateScore()
    {
        string newText=("Score: " + scoreKeeper.GetScore());
        scoreText.SetText(newText);
    }
}
