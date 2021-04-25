using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassSelection : MonoBehaviour
{
    public GameObject playerPrefab;
    public void WizardSelect()
    {
        PlayerCombat.currentClass = ClassSystem.wizard;
        Debug.Log("Class: Wizard");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void KnightSelect()
    {
        PlayerCombat.currentClass = ClassSystem.knight;
        Debug.Log("Class: Knight");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AssassinSelect()
    {
        PlayerCombat.currentClass = ClassSystem.assassin;
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
        PlayerCombat.currentClass = ClassSystem.ranger;
        Debug.Log("Class: Ranger");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
