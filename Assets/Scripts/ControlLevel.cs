using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlLevel : MonoBehaviour
{
   public void Lv1()
    {
        SceneManager.LoadScene("Lv1");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
