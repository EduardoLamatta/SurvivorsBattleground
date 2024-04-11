using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtons : MonoBehaviour
{
    [SerializeField] private GameObject interfaceHTP;
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
        AudioGameManager.Instance.SoundSelect();
    }
    public void ExitGame()
    {
        Application.Quit();
        AudioGameManager.Instance.SoundSelect();
    }

    public void HowToPlay()
    {
        interfaceHTP.SetActive(true);
        AudioGameManager.Instance.SoundSelect();
    }
    public void ExitHowToPlay()
    {
        interfaceHTP.SetActive(false);
        AudioGameManager.Instance.SoundSelect();
    }

    public void Store()
    {
        SceneManager.LoadScene(1);
        AudioGameManager.Instance.SoundSelect();
    }


}
