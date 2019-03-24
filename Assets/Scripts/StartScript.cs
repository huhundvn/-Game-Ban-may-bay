using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public void loadGame()
    {
        Application.LoadLevel("Play");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
