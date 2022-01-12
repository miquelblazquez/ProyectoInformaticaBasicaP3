using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
  public void Menu(string Lv1)
    {
        print("Menu" + Lv1);
        SceneManager.LoadScene(Lv1);
    }
}
