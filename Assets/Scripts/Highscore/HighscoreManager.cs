using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;
    private string keyToSave = "keyHighscore";
    [Header("References")]
    public TextMeshProUGUI uiTextHighscore;


    private void Awake()
    {
        Instance = this;
    }

    public void OnEnable()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        uiTextHighscore.text = PlayerPrefs.GetString(keyToSave, "Sem Highscore");
        Debug.Log(PlayerPrefs.GetString(keyToSave));
    }

    public void SavePlayerWin(Player p)
    {
        PlayerPrefs.SetString(keyToSave, p.playerName);
        UpdateText();
    }
}
