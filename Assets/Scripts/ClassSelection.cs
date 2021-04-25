using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassSelection : MonoBehaviour
{
    public void WizardSelect()
    {
        //Code to set class to wizard.
        Debug.Log("Class: Wizard");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void KnightSelect()
    {
        //Code to set class to knight.
        Debug.Log("Class: Knight");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AssassinSelect()
    {
        //Code to set class to assassin.
        Debug.Log("Class: Assassin");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void TankSelect()
    {
        //Code to set class to tank.
        Debug.Log("Class: Tank");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrawlerSelect()
    {
        //Code to set class to brawler.
        Debug.Log("Class: Brawler");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RangerSelect()
    {
        //Code to set class to ranger.
        Debug.Log("Class: Ranger");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
