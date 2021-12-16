using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void MoveOut(GameObject openingMenu)
    {
        openingMenu.GetComponent<Animator>().SetBool("ShowMenu", false);
    }

    public void MoveIn(GameObject closingMenu)
    {
        closingMenu.GetComponent<Animator>().SetBool("ShowMenu", true);
    }

    public void Play(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
