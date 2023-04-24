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

    var startButton = root.Q<Button>("StartButton");
    var optionsButton = root.Q<Button>("OptionsButton");
    var quitButton = root.Q<Button>("QuitButton");

    startButton.clicked += () => SceneManager.LoadScene("Level1");
    optionsButton.clicked += () => Debug.Log("There aren't any options");
    quitButton.clicked += () => Application.Quit();
  }
}
