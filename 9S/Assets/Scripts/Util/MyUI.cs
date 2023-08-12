using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyUI : MonoBehaviour
{
    public void DoExitGame() {
        Application.Quit();
    }

    public void GoToLVLsMenu()
    {
        SceneManager.LoadScene("LVLs");
    }
    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
    public void GoToLVL(int LVLNumber)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        
        
        string LVLName = "LVL " + LVLNumber;
        SceneManager.LoadScene(LVLName);
    }
}
