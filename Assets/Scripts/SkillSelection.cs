using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelection : MonoBehaviour
{
    public GameObject errorBoard;
    public Text errorText;

    Transform parent;
    Transform sibling;
    Image skillFrame;
    public Text skillDescription;

    ClassSystem.PlayerClass currentClass = PlayerCombat.currentClass;

    public Image playerSelf;
    public Text classText;

    ClassSystem.Skill previousSkill;
    ClassSystem.Skill selectedSkill;
    Image selectedFrame;
    Image previousFrame1;
    Image previousFrame2;

    public Image skilloneone;
    public Image skillonetwo;
    public Image skillonethree;
    public Image skillonefour;
    public Image skillonefive;

    public Image skill1OneFrame;
    public Image skill1TwoFrame;
    public Image skill1ThreeFrame;
    public Image skill1FourFrame;
    public Image skill1FiveFrame;

    public Image skilltwoone;
    public Image skilltwotwo;
    public Image skilltwothree;
    public Image skilltwofour;
    public Image skilltwofive;

    public Image skill2OneFrame;
    public Image skill2TwoFrame;
    public Image skill2ThreeFrame;
    public Image skill2FourFrame;
    public Image skill2FiveFrame;

    public Image skillthreeone;
    public Image skillthreetwo;
    public Image skillthreethree;
    public Image skillthreefour;
    public Image skillthreefive;

    public Image skill3OneFrame;
    public Image skill3TwoFrame;
    public Image skill3ThreeFrame;
    public Image skill3FourFrame;
    public Image skill3FiveFrame;

    public Image skillfourone;
    public Image skillfourtwo;
    public Image skillfourthree;
    public Image skillfourfour;
    public Image skillfourfive;

    public Image skill4OneFrame;
    public Image skill4TwoFrame;
    public Image skill4ThreeFrame;
    public Image skill4FourFrame;
    public Image skill4FiveFrame;

    Color previousColor;


    // Start is called before the first frame update
    void Start()
    {
        skill1OneFrame.color = new Color(1, 0, 0, 1);
        skill2OneFrame.color = new Color(1, 0, 0, 1);
        previousFrame1 = GetFrame(ref skill1OneFrame);
        previousFrame2 = GetFrame(ref skill2OneFrame);

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
        if (Input.GetKeyDown(KeyCode.F))
        {
            errorText.text = "";
            errorBoard.SetActive(false);
        }

        //Debug.Log(currentClass.skillTreeOne[1].isActive);
        if (selectedSkill != null)
        {
            skillDescription.text = selectedSkill.name + ": " + selectedSkill.description + ".";
        }
    }


    public void BuySkill()
    {
        if (selectedSkill != null)
        {
            if (!selectedSkill.isActive)
            {
                if (previousSkill == null || previousSkill.isActive)
                {
                    if (GameManager.Instance.currentPoints >= 1)
                    {
                        selectedSkill.isActive = true;
                        GameManager.Instance.currentPoints--;
                        previousColor = new Color(1, 1, 0, 1);
                    }
                    else
                    {
                        if(!errorBoard.activeInHierarchy)
                        {
                            errorBoard.SetActive(true);
                        }
                        errorText.text = "You dont have enough Skill Points!\nGain Skill Points by getting 5EXP.";
                    }
                }
                else
                {
                    if (!errorBoard.activeInHierarchy)
                    {
                        errorBoard.SetActive(true);
                    }
                    errorText.text = "You must buy the previous skill to unlock this one.";
                }
            }
            else
            {
                if (!errorBoard.activeInHierarchy)
                {
                    errorBoard.SetActive(true);
                }
                errorText.text = "You have already bought this skill!";
            }
        }
        else { return; }
    }



    public void EquipSkill1()
    {
        if (selectedSkill != null)
        {
            if (selectedSkill.isActive)
            {
                PlayerCombat.equippedSkill1 = selectedSkill;
                previousFrame1.color = new Color(1, 1, 0, 1);
                previousColor = new Color(1, 0, 0, 1);
                previousFrame1 = GetFrame(ref selectedFrame);
            }
            else
            {
                if (!errorBoard.activeInHierarchy)
                {
                    errorBoard.SetActive(true);
                }
                errorText.text = "You have not bought this skill.";
            }
        }
        else { return; }
    }

    public void EquipSkill2()
    {
        if (selectedSkill != null)
        {
            if (selectedSkill.isActive)
            {
                PlayerCombat.equippedSkill2 = selectedSkill;
                previousFrame2.color = new Color(1, 1, 0, 1);
                previousColor = new Color(1, 0, 0, 1);
                previousFrame2 = GetFrame(ref selectedFrame);
            }
            else
            {
                if (!errorBoard.activeInHierarchy)
                {
                    errorBoard.SetActive(true);
                }
                errorText.text = "You have not bought this skill.";
            }
        }
        else { return; }
    }


    public ref ClassSystem.Skill GetSkill(ref ClassSystem.Skill skill)
    {
        return ref skill;
    }
    public ref Image GetFrame(ref Image frame)
    {
        return ref frame;
    }

    public void Select1One()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill1OneFrame.color;

        previousSkill = null;
        selectedSkill = GetSkill(ref currentClass.skillTreeOne[0]);
        selectedFrame = GetFrame(ref skill1OneFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select1Two()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill1TwoFrame.color;

        previousSkill = GetSkill(ref currentClass.skillTreeOne[0]);
        selectedSkill = GetSkill(ref currentClass.skillTreeOne[1]);
        selectedFrame = GetFrame(ref skill1TwoFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select1Three()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill1ThreeFrame.color;

        previousSkill = GetSkill(ref currentClass.skillTreeOne[1]);
        selectedSkill = currentClass.skillTreeOne[2];
        selectedFrame = GetFrame(ref skill1ThreeFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select1Four()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill1FourFrame.color;
        previousSkill = GetSkill(ref currentClass.skillTreeOne[2]);
        selectedSkill = currentClass.skillTreeOne[3];
        selectedFrame = GetFrame(ref skill1FourFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select1Five()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill1FiveFrame.color;
        previousSkill = GetSkill(ref currentClass.skillTreeOne[3]);
        selectedSkill = currentClass.skillTreeOne[4];
        selectedFrame = GetFrame(ref skill1FiveFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }

    public void Select2One()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill2OneFrame.color;
        previousSkill = null;
        selectedSkill = currentClass.skillTreeTwo[0];
        selectedFrame = GetFrame(ref skill2OneFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select2Two()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill2TwoFrame.color;
        previousSkill = GetSkill(ref currentClass.skillTreeTwo[0]);
        selectedSkill = currentClass.skillTreeTwo[1];
        selectedFrame = GetFrame(ref skill2TwoFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select2Three()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill2ThreeFrame.color;
        previousSkill = GetSkill(ref currentClass.skillTreeTwo[1]);
        selectedSkill = currentClass.skillTreeTwo[2];
        selectedFrame = GetFrame(ref skill2ThreeFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select2Four()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill2FourFrame.color;
        previousSkill = GetSkill(ref currentClass.skillTreeTwo[2]);
        selectedSkill = currentClass.skillTreeTwo[3];
        selectedFrame = GetFrame(ref skill2FourFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select2Five()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill2FiveFrame.color;
        previousSkill = GetSkill(ref currentClass.skillTreeTwo[3]);
        selectedSkill = currentClass.skillTreeTwo[4];
        selectedFrame = GetFrame(ref skill2FiveFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }

    public void Select3One()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill3OneFrame.color;
        previousSkill = null;
        selectedSkill = currentClass.skillTreeThree[0];
        selectedFrame = GetFrame(ref skill3OneFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select3Two()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill3TwoFrame.color;
        previousSkill = GetSkill(ref currentClass.skillTreeThree[0]);
        selectedSkill = currentClass.skillTreeThree[1];
        selectedFrame = GetFrame(ref skill3TwoFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select3Three()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill3ThreeFrame.color;
        previousSkill = GetSkill(ref currentClass.skillTreeThree[1]);
        selectedSkill = currentClass.skillTreeThree[2];
        selectedFrame = GetFrame(ref skill3ThreeFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select3Four()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill3FourFrame.color;
        previousSkill = GetSkill(ref currentClass.skillTreeThree[2]);
        selectedSkill = currentClass.skillTreeThree[3];
        selectedFrame = GetFrame(ref skill3FourFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select3Five()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill3FiveFrame.color;
        previousSkill = GetSkill(ref currentClass.skillTreeThree[3]);
        selectedSkill = currentClass.skillTreeThree[4];
        selectedFrame = GetFrame(ref skill3FiveFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }

    public void Select4One()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill4OneFrame.color;
        previousSkill = null;
        selectedSkill = currentClass.skillTreeFour[0];
        selectedFrame = GetFrame(ref skill4OneFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select4Two()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill4TwoFrame.color;
        previousSkill = GetSkill(ref currentClass.skillTreeFour[0]);
        selectedSkill = currentClass.skillTreeFour[1];
        selectedFrame = GetFrame(ref skill4TwoFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select4Three()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill4ThreeFrame.color;
        previousSkill = GetSkill(ref currentClass.skillTreeFour[1]);
        selectedSkill = currentClass.skillTreeFour[2];
        selectedFrame = GetFrame(ref skill4ThreeFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select4Four()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill4FourFrame.color;
        previousSkill = GetSkill(ref currentClass.skillTreeFour[2]);
        selectedSkill = currentClass.skillTreeFour[3];
        selectedFrame = GetFrame(ref skill4FourFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
    public void Select4Five()
    {
        if (selectedSkill != null)
        {
            selectedFrame.color = previousColor;
        }
        previousColor = skill4FiveFrame.color;
        previousSkill = GetSkill(ref currentClass.skillTreeFour[3]);
        selectedSkill = currentClass.skillTreeFour[4];
        selectedFrame = GetFrame(ref skill4FiveFrame);
        selectedFrame.color = new Color(0, 0, 1, 0);
    }
}
