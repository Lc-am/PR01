using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private CanvasGroup mainMenuCanvasGroup;
    [SerializeField] private CanvasGroup optionsMenuCanvasGroup;
    [SerializeField] private CanvasGroup levelSelectorCanvasGroup;  // CanvasGroup para el selector de niveles

    void OnEnable()
    {
        playButton.onClick.AddListener(OpenLevelSelector);
        optionsButton.onClick.AddListener(OpenOptionsMenu);
        exitButton.onClick.AddListener(ExitButtonClick);
    }

    void OnDisable()
    {
        playButton.onClick.RemoveListener(OpenLevelSelector);
        optionsButton.onClick.RemoveListener(OpenOptionsMenu);
        exitButton.onClick.RemoveListener(ExitButtonClick);
    }

    void OpenLevelSelector()
    {
        // Muestra el CanvasGroup del selector de niveles y oculta el menú principal
        ShowCanvasGroup(levelSelectorCanvasGroup, true);
        ShowCanvasGroup(mainMenuCanvasGroup, false);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void CloseSelectLevel()
    {
        // Muestra el menú principal y oculta el selector de niveles
        ShowCanvasGroup(mainMenuCanvasGroup, true);
        ShowCanvasGroup(levelSelectorCanvasGroup, false);
    }

    void ExitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    void OpenOptionsMenu()
    {
        ShowCanvasGroup(optionsMenuCanvasGroup, true);
        ShowCanvasGroup(mainMenuCanvasGroup, false);
    }

    public void CloseOptionsMenu()
    {
        ShowCanvasGroup(optionsMenuCanvasGroup, false);
        ShowCanvasGroup(mainMenuCanvasGroup, true);
    }

    void ShowCanvasGroup(CanvasGroup canvasGroup, bool show)
    {
        canvasGroup.alpha = show ? 1 : 0;
        canvasGroup.interactable = show;
        canvasGroup.blocksRaycasts = show;
    }
}
