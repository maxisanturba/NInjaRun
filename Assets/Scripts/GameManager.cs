using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float generalVolume = 1;

    private void OnEnable()
    {
        ChangeVolume(generalVolume);
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ChangeVolume(float value)
    {
        foreach (AudioSource audioSource in GameObject.FindObjectsOfType<AudioSource>())
        {
            audioSource.volume = value;
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
