using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangueScene : MonoBehaviour
{
    public void Changue(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    public void QuitAplicattion()
    {
        Application.Quit();
    }
}
