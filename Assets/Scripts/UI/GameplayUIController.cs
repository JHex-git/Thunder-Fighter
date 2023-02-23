using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    [Header("-------- PlayerInput --------")]
    [SerializeField] PlayerInput playerInput;

    [Header("-------- Canvas --------")]
    [SerializeField] Canvas hUDCanvas;
    [SerializeField] Canvas menusCanvas;

    [Header("-------- Player Input --------")]
    [SerializeField] Button resumeButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button mainMenuButton;
    private void OnEnable()
    {
        playerInput.onPause += Pause;
        playerInput.onUnpause += Unpause;
        resumeButton.onClick.AddListener(OnResumeButtonClick);
        optionsButton.onClick.AddListener(OnOptionsButtonClick);
        mainMenuButton.onClick.AddListener(OnMainMenuClick);
    }

    private void OnDisable()
    {
        playerInput.onPause -= Pause;
        playerInput.onUnpause -= Unpause;
        resumeButton.onClick.RemoveAllListeners();
        optionsButton.onClick.RemoveAllListeners();
        mainMenuButton.onClick.RemoveAllListeners();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        hUDCanvas.enabled = false;
        menusCanvas.enabled = true;
        playerInput.EnablePauseMenuInput();
        playerInput.SwitchToDynamicUpdateMode();
    }

    public void Unpause()
    {
        OnResumeButtonClick();
    }

    public void OnResumeButtonClick()
    {
        Time.timeScale = 1f;
        hUDCanvas.enabled = true;
        menusCanvas.enabled = false;
        playerInput.EnableGameplayInput();
        playerInput.SwitchToFixedUpdateMode();
    }

    public void OnOptionsButtonClick()
    {
        // TODO
    }

    void OnMainMenuClick()
    {
        menusCanvas.enabled = false;
        SceneLoader.Instance.LoadMainMenuScene();
    }
}
