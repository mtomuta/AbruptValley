using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PlayerController player;

    void Update()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        player.GetComponent<LvlExperience>().ResetAttributePoints();
        player.GetComponent<LvlExperience>().ResetXpAndLevel();
        PopUpIntroductionToValley.PopUpEnabled = 1;
        PopUpIntroductionToValley.PopUpTextEnabled = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
