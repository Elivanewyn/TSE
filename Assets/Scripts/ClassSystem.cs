using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass
{
    //basic info on each class
    protected string name_;
    protected int strength_;
    protected int defence_;
    protected int intelligence_;
    protected int stealth_;
    protected int dext_;

    //will need a class for Skills that will be used for following attributes. For now they will be represented as strings
    protected string[] basicSkills_;
    protected string[] skillTreeOne_;
    protected string skillTreeOneName_;

    protected string[] skillTreeTwo_;
    protected string skillTreeTwoName_;

    protected string[] skillTreeThree_;
    protected string skillTreeThreeName_;

    protected string[] skillTreeFour_;
    protected string skillTreeFourName_;

    //will need a class for Weapons, a child class for types of weapons (eg Sword) and child class for types of those weapons (eg Wooden Sword). Here represented as strings
    protected string weaponType_;


    public string name
    {
        get { return name_; }
        set { name_ = value; }
    }

    public int strength
    {
        get { return strength_; }
        set { strength_ = value; }
    }

    public int defence
    {
        get { return defence_; }
        set { defence_ = value; }
    }

    public int intelligence
    {
        get { return intelligence_; }
        set { intelligence_ = value; }
    }

    public int stealth
    {
        get { return stealth_; }
        set { stealth_ = value; }
    }

    public int dext
    {
        get { return dext_; }
        set { dext_ = value; }
    }


    public PlayerClass()
    {
        name_ = "default";
        strength_ = 0;
        defence_ = 0;
        intelligence_ = 0;
        stealth_ = 0;
        dext_ = 0;
    }
}


public class WizardClass : PlayerClass
{
    public WizardClass()
    {
        name_ = "Wizard";
        strength_ = 1;
        defence_ = 1;
        intelligence_ = 3;
        stealth_ = 2;
        dext_ = 1;
        SetSkills();
        weaponType_ = "Wand";
    }

    private void SetSkills()
    {
        basicSkills_[0] = "Fireball";
        basicSkills_[1] = "Lightning Strike";
        basicSkills_[2] = "Frost Wave";
        basicSkills_[3] = "Healing Chime";

        skillTreeOneName_ = "Fire";
        skillTreeOne_[0] = basicSkills_[0];
        skillTreeOne_[1] = "Fire Blast";
        skillTreeOne_[2] = "Flamethrower";
        skillTreeOne_[3] = "Flame Burst";
        skillTreeOne_[4] = "Flame Inferno";

        skillTreeTwoName_ = "Lightning";
        skillTreeTwo_[0] = basicSkills_[1];
        skillTreeTwo_[1] = "Lightning Bolt";
        skillTreeTwo_[2] = "Electric Cage";
        skillTreeTwo_[3] = "Plasma Charge";
        skillTreeTwo_[4] = "Lightning Pillar";

        skillTreeThreeName_ = "Ice";
        skillTreeThree_[0] = basicSkills_[2];
        skillTreeThree_[1] = "Ice Prison";
        skillTreeThree_[2] = "Freezing Breath";
        skillTreeThree_[3] = "Ice Crash";
        skillTreeThree_[4] = "Freezing Land";

        skillTreeFourName_ = "Utility";
        skillTreeFour_[0] = basicSkills_[3];
        skillTreeFour_[1] = "Speed Boost";
        skillTreeFour_[2] = "Evasion Amplification";
        skillTreeFour_[3] = "Defence Boost";
        skillTreeFour_[4] = "Health Renewal";
    }
}


public class KnightClass : PlayerClass
{
    public KnightClass()
    {
        name_ = "Knight";
        strength_ = 3;
        defence_ = 2;
        intelligence_ = 1;
        stealth_ = 1;
        dext_ = 1;
        SetSkills();
        weaponType_ = "Sword";
    }

    private void SetSkills()
    {
        basicSkills_[0] = "Large Swing";
        basicSkills_[1] = "Block";
        basicSkills_[2] = "Roll";
        basicSkills_[3] = "Sprint";

        skillTreeOneName_ = "Offensive";
        skillTreeOne_[0] = basicSkills_[0];
        skillTreeOne_[1] = "Lunge";
        skillTreeOne_[2] = "Dual Slice";
        skillTreeOne_[3] = "Flame Sword";
        skillTreeOne_[4] = "";

        skillTreeTwoName_ = "Defensive";
        skillTreeTwo_[0] = basicSkills_[1];
        skillTreeTwo_[1] = "Parry";
        skillTreeTwo_[2] = "Warrior's Spirit";
        skillTreeTwo_[3] = "";
        skillTreeTwo_[4] = "";

        skillTreeThreeName_ = "Evasion";
        skillTreeThree_[0] = basicSkills_[2];
        skillTreeThree_[1] = "Lion's Roar";
        skillTreeThree_[2] = "";
        skillTreeThree_[3] = "";
        skillTreeThree_[4] = "";

        skillTreeFourName_ = "Movement";
        skillTreeFour_[0] = basicSkills_[3];
        skillTreeFour_[1] = "Dash";
        skillTreeFour_[2] = "";
        skillTreeFour_[3] = "";
        skillTreeFour_[4] = "";
    }
}


public class AssassinClass : PlayerClass
{
    public AssassinClass()
    {
        name_ = "Assassin";
        strength_ = 1;
        defence_ = 1;
        intelligence_ = 2;
        stealth_ = 3;
        dext_ = 2;
        SetSkills();
        weaponType_ = "Knife";
    }

    private void SetSkills()
    {
        basicSkills_[0] = "Throwing Knife";
        basicSkills_[1] = "Smoke Bomb";
        basicSkills_[2] = "Slash";
        basicSkills_[3] = "Counter";

        skillTreeOneName_ = "Offensive";
        skillTreeOne_[0] = basicSkills_[0];
        skillTreeOne_[1] = "Poison Dart";
        skillTreeOne_[2] = "";
        skillTreeOne_[3] = "";
        skillTreeOne_[4] = "Assassinate";

        skillTreeTwoName_ = "Stealth";
        skillTreeTwo_[0] = basicSkills_[1];
        skillTreeTwo_[1] = "Invisibility";
        skillTreeTwo_[2] = "";
        skillTreeTwo_[3] = "";
        skillTreeTwo_[4] = "";

        skillTreeThreeName_ = "Potions";
        skillTreeThree_[0] = basicSkills_[2];
        skillTreeThree_[1] = "Weakness";
        skillTreeThree_[2] = "Poison";
        skillTreeThree_[3] = "";
        skillTreeThree_[4] = "";

        skillTreeFourName_ = "Magic";
        skillTreeFour_[0] = basicSkills_[3];
        skillTreeFour_[1] = "";
        skillTreeFour_[2] = "";
        skillTreeFour_[3] = "";
        skillTreeFour_[4] = "";
    }
}


public class TankClass : PlayerClass
{
    public TankClass()
    {
        name_ = "Tank";
        strength_ = 2;
        defence_ = 3;
        intelligence_ = 1;
        stealth_ = 1;
        dext_ = 1;
        SetSkills();
        weaponType_ = "Two-Handed";
    }

    private void SetSkills()
    {
        basicSkills_[0] = "Heavy Swing";
        basicSkills_[1] = "Shield Wall";
        basicSkills_[2] = "Charge";
        basicSkills_[3] = "Weapon Swing";

        skillTreeOneName_ = "Offensive";
        skillTreeOne_[0] = basicSkills_[0];
        skillTreeOne_[1] = "Shield Bash";
        skillTreeOne_[2] = "";
        skillTreeOne_[3] = "";
        skillTreeOne_[4] = "";

        skillTreeTwoName_ = "Defensive";
        skillTreeTwo_[0] = basicSkills_[1];
        skillTreeTwo_[1] = "Block";
        skillTreeTwo_[2] = "";
        skillTreeTwo_[3] = "";
        skillTreeTwo_[4] = "";

        skillTreeThreeName_ = "Aggro";
        skillTreeThree_[0] = basicSkills_[2];
        skillTreeThree_[1] = "";
        skillTreeThree_[2] = "";
        skillTreeThree_[3] = "";
        skillTreeThree_[4] = "";

        skillTreeFourName_ = "";
        skillTreeFour_[0] = basicSkills_[3];
        skillTreeFour_[1] = "";
        skillTreeFour_[2] = "";
        skillTreeFour_[3] = "";
        skillTreeFour_[4] = "";
    }
}

public class BrawlerClass : PlayerClass
{
    public BrawlerClass()
    {
        name_ = "Brawler";
        strength_ = 1;
        defence_ = 2;
        intelligence_ = 1;
        stealth_ = 2;
        dext_ = 3;
        SetSkills();
        weaponType_ = "Knuckle-Duster";
    }

    private void SetSkills()
    {
        basicSkills_[0] = "Uppercut";
        basicSkills_[1] = "Kick";
        basicSkills_[2] = "Slide";
        basicSkills_[3] = "Block";

        skillTreeOneName_ = "";
        skillTreeOne_[0] = basicSkills_[0];
        skillTreeOne_[1] = "";
        skillTreeOne_[2] = "";
        skillTreeOne_[3] = "";
        skillTreeOne_[4] = "";

        skillTreeTwoName_ = "";
        skillTreeTwo_[0] = basicSkills_[1];
        skillTreeTwo_[1] = "";
        skillTreeTwo_[2] = "";
        skillTreeTwo_[3] = "";
        skillTreeTwo_[4] = "";

        skillTreeThreeName_ = "";
        skillTreeThree_[0] = basicSkills_[2];
        skillTreeThree_[1] = "";
        skillTreeThree_[2] = "";
        skillTreeThree_[3] = "";
        skillTreeThree_[4] = "";

        skillTreeFourName_ = "";
        skillTreeFour_[0] = basicSkills_[3];
        skillTreeFour_[1] = "";
        skillTreeFour_[2] = "";
        skillTreeFour_[3] = "";
        skillTreeFour_[4] = "";
    }
}

public class RangerClass : PlayerClass
{
    public RangerClass()
    {
        name_ = "Ranger";
        strength_ = 2;
        defence_ = 1;
        intelligence_ = 1;
        stealth_ = 3;
        dext_ = 2;
        SetSkills();
        weaponType_ = "Bow/Mount";
    }

    private void SetSkills()
    {
        basicSkills_[0] = "Arrow Flurry";
        basicSkills_[1] = "Saddle Up";
        basicSkills_[2] = "Hood";
        basicSkills_[3] = "Fire Arrow";

        skillTreeOneName_ = "";
        skillTreeOne_[0] = basicSkills_[0];
        skillTreeOne_[1] = "";
        skillTreeOne_[2] = "";
        skillTreeOne_[3] = "";
        skillTreeOne_[4] = "";

        skillTreeTwoName_ = "Mount";
        skillTreeTwo_[0] = basicSkills_[1];
        skillTreeTwo_[1] = "";
        skillTreeTwo_[2] = "";
        skillTreeTwo_[3] = "";
        skillTreeTwo_[4] = "";

        skillTreeThreeName_ = "";
        skillTreeThree_[0] = basicSkills_[2];
        skillTreeThree_[1] = "";
        skillTreeThree_[2] = "";
        skillTreeThree_[3] = "";
        skillTreeThree_[4] = "";

        skillTreeFourName_ = "";
        skillTreeFour_[0] = basicSkills_[3];
        skillTreeFour_[1] = "";
        skillTreeFour_[2] = "";
        skillTreeFour_[3] = "";
        skillTreeFour_[4] = "";
    }
}


