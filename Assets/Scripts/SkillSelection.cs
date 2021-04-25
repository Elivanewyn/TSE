using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelection : MonoBehaviour
{

    ClassSystem.PlayerClass currentClass = PlayerCombat.currentClass;

    public Image playerSelf;
    public Text classText;

    public Image skilloneone;
    public Image skillonetwo;
    public Image skillonethree;
    public Image skillonefour;
    public Image skillonefive;

    public Image skilltwoone;
    public Image skilltwotwo;
    public Image skilltwothree;
    public Image skilltwofour;
    public Image skilltwofive;

    public Image skillthreeone;
    public Image skillthreetwo;
    public Image skillthreethree;
    public Image skillthreefour;
    public Image skillthreefive;

    public Image skillfourone;
    public Image skillfourtwo;
    public Image skillfourthree;
    public Image skillfourfour;
    public Image skillfourfive;

    // Start is called before the first frame update
    void Start()
    {
        playerSelf.sprite = currentClass.portrait;
        classText.text = "Current Class: " + currentClass.name;

        skilloneone.sprite = currentClass.skillTreeOne[0].portrait;
        skillonetwo.sprite = currentClass.skillTreeOne[1].portrait;
        skillonethree.sprite = currentClass.skillTreeOne[2].portrait;
        skillonefour.sprite = currentClass.skillTreeOne[3].portrait;
        skillonefive.sprite = currentClass.skillTreeOne[4].portrait;

        skilltwoone.sprite = currentClass.skillTreeTwo[0].portrait;
        skilltwotwo.sprite = currentClass.skillTreeTwo[1].portrait;
        skilltwothree.sprite = currentClass.skillTreeTwo[2].portrait;
        skilltwofour.sprite = currentClass.skillTreeTwo[3].portrait;
        skilltwofive.sprite = currentClass.skillTreeTwo[4].portrait;

        skillthreeone.sprite = currentClass.skillTreeThree[0].portrait;
        skillthreetwo.sprite = currentClass.skillTreeThree[1].portrait;
        skillthreethree.sprite = currentClass.skillTreeThree[2].portrait;
        skillthreefour.sprite = currentClass.skillTreeThree[3].portrait;
        skillthreefive.sprite = currentClass.skillTreeThree[4].portrait;

        skillfourone.sprite = currentClass.skillTreeFour[0].portrait;
        skillfourtwo.sprite = currentClass.skillTreeFour[1].portrait;
        skillfourthree.sprite = currentClass.skillTreeFour[2].portrait;
        skillfourfour.sprite = currentClass.skillTreeFour[3].portrait;
        skillfourfive.sprite = currentClass.skillTreeFour[4].portrait;
    }

    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
