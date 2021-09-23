using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonX : MonoBehaviour
{
    [SerializeField] private int difficulty = 1;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name);

        GameManagerX gameManagerX = GameObject.FindObjectOfType<GameManagerX>();
        gameManagerX?.StartGame(difficulty);
    }
}
