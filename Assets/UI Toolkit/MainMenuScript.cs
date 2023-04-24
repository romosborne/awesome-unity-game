using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
  public void OnEnable()
  {
    var root = GetComponent<UIDocument>().rootVisualElement;

    var mainMenu = root.Q("MainMenu");
    var settingsMenu = root.Q("SettingsMenu");

    // Main menu setup
    var startButton = mainMenu.Q<Button>("StartButton");
    var optionsButton = mainMenu.Q<Button>("OptionsButton");
    var quitButton = mainMenu.Q<Button>("QuitButton");

    startButton.Focus();

    startButton.clicked += () => SceneManager.LoadScene("Level1");
    optionsButton.clicked += () =>
    {
      Display(mainMenu, false);
      Display(settingsMenu, true);
    };
    quitButton.clicked += () => Application.Quit();

    // Settings menu
    var backButton = settingsMenu.Q<Button>("BackButton");

    backButton.clicked += () =>
    {
      Display(settingsMenu, false);
      Display(mainMenu, true);
    };
  }

  private void Display(VisualElement e, bool display)
  {
    e.style.display = display ? DisplayStyle.Flex : DisplayStyle.None;
  }
}
