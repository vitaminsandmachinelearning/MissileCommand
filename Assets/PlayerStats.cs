using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI text;
    public int citiesLeft = 6;

    public void AddScore(int points)
    {
        score += points;
        text.text = score.ToString();
    }

    public void DestroyedCity()
    {
        citiesLeft--;
        if (citiesLeft <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
