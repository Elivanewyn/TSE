using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill
{
    protected string name_;
    protected bool isActive_;

    public string name
    {
        get { return name_; }
        set { name_ = value; }
    }

    public bool isActive
    {
        get { return isActive_; }
        set { isActive_ = value; }
    }

    public Skill(string skillName)
    {
        name_ = skillName;
        isActive_ = false;
    }

    public void Use()                       //may want to make this more efficient by splitting if statements by class and skill tree
    {
        if (name_ == "Fireball")
        {
            //shoot fireball
        }
        else if (name_ == "Fire Blast")
        {
            //shoot fireblast
        }
        //etc
    }
}

public class WeaponType
{
    protected string type_;

    public string type
    {
        get { return type_; }
        set { type_ = value; }
    }

    public WeaponType(string type)
    {
        type_ = type;
    }
    public WeaponType() { }
}

public class Wand : WeaponType
{
    private string name_;
    protected int damage_;

    public string name
    {
        get { return name_; }
        set { name_ = value; }
    }
    public int damage
    {
        get { return damage_; }
        set { damage_ = value; }
    }

    public Wand(string name)
    {
        type_ = "Wand";
        name_ = name;
        //damage_ = ?
    }
}

public class Sword : WeaponType
{
    private string name_;
    protected int damage_;

    public string name
    {
        get { return name_; }
        set { name_ = value; }
    }
    public int damage
    {
        get { return damage_; }
        set { damage_ = value; }
    }

    public Sword()
    {
        type_ = "Sword";
        name_ = name;
        //damage_ = ?
    }
}

public class Knife : WeaponType
{
    private string name_;
    protected int damage_;

    public string name
    {
        get { return name_; }
        set { name_ = value; }
    }
    public int damage
    {
        get { return damage_; }
        set { damage_ = value; }
    }

    public Knife(string name)
    {
        type_ = "Knife";
        name_ = name;
        //damage_ = ?
    }
}

public class TwoHanded : WeaponType
{
    private string name_;
    protected int damage_;

    public string name
    {
        get { return name_; }
        set { name_ = value; }
    }
    public int damage
    {
        get { return damage_; }
        set { damage_ = value; }
    }

    public TwoHanded(string name)
    {
        type_ = "TwoHanded";
        name_ = name;
        //damage_ = ?
    }
}

public class KnuckleDuster : WeaponType
{
    private string name_;
    protected int damage_;

    public string name
    {
        get { return name_; }
        set { name_ = value; }
    }
    public int damage
    {
        get { return damage_; }
        set { damage_ = value; }
    }

    public KnuckleDuster(string name)
    {
        type_ = "KnuckleDuster";
        name_ = name;
        //damage_ = ?
    }
}

public class BowMount : WeaponType
{
    private string name_;
    protected int damage_;

    public string name
    {
        get { return name_; }
        set { name_ = value; }
    }
    public int damage
    {
        get { return damage_; }
        set { damage_ = value; }
    }

    public BowMount(string name)
    {
        type_ = "BowMount";
        name_ = name;
        //damage_ = ?
    }
}



public class PlayerClass
{
    //basic info on each class
    protected string name_;
    protected int strength_;
    protected int defence_;
    protected int intelligence_;
    protected int stealth_;
    protected int dext_;

    protected Skill[] basicSkills_;
    protected Skill[] skillTreeOne_;
    protected string skillTreeOneName_;

    protected Skill[] skillTreeTwo_;
    protected string skillTreeTwoName_;

    protected Skill[] skillTreeThree_;
    protected string skillTreeThreeName_;

    protected Skill[] skillTreeFour_;
    protected string skillTreeFourName_;

    protected WeaponType weaponType_;


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
        weaponType_ = new WeaponType("default");
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
        weaponType_ = new WeaponType("Wand");
    }

    private void SetSkills()
    {
        basicSkills_[0] = new Skill("Fireball");
        basicSkills_[1] = new Skill("Lightning Strike");
        basicSkills_[2] = new Skill("Frost Wave");
        basicSkills_[3] = new Skill("Healing Chime");
        foreach (Skill i in basicSkills_)
        {
            i.isActive = true;
        }

        skillTreeOneName_ = "Fire";
        skillTreeOne_[0] = basicSkills_[0];
        skillTreeOne_[1] = new Skill("Fire Blast");
        skillTreeOne_[2] = new Skill("Flamethrower");
        skillTreeOne_[3] = new Skill("Flame Burst");
        skillTreeOne_[4] = new Skill("Flame Inferno");

        skillTreeTwoName_ = "Lightning";
        skillTreeTwo_[0] = basicSkills_[1];
        skillTreeTwo_[1] = new Skill("Lightning Bolt");
        skillTreeTwo_[2] = new Skill("Electric Cage");
        skillTreeTwo_[3] = new Skill("Plasma Charge");
        skillTreeTwo_[4] = new Skill("Lightning Pillar");

        skillTreeThreeName_ = "Ice";
        skillTreeThree_[0] = basicSkills_[2];
        skillTreeThree_[1] = new Skill("Ice Prison");
        skillTreeThree_[2] = new Skill("Freezing Breath");
        skillTreeThree_[3] = new Skill("Ice Crash");
        skillTreeThree_[4] = new Skill("Freezing Land");

        skillTreeFourName_ = "Utility";
        skillTreeFour_[0] = basicSkills_[3];
        skillTreeFour_[1] = new Skill("Speed Boost");
        skillTreeFour_[2] = new Skill("Evasion Amplification");
        skillTreeFour_[3] = new Skill("Defence Boost");
        skillTreeFour_[4] = new Skill("Health Renewal");
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
        weaponType_ = new WeaponType("Sword");
    }

    private void SetSkills()
    {
        basicSkills_[0] = new Skill("Large Swing");
        basicSkills_[1] = new Skill("Block");
        basicSkills_[2] = new Skill("Roll");
        basicSkills_[3] = new Skill("Sprint");

        foreach(Skill i in basicSkills_)
        {
            i.isActive = true;
        }

        skillTreeOneName_ = "Offensive";
        skillTreeOne_[0] = basicSkills_[0];
        skillTreeOne_[1] = new Skill("Lunge");
        skillTreeOne_[2] = new Skill("Dual Slice");
        skillTreeOne_[3] = new Skill("Flame Sword");
        skillTreeOne_[4] = new Skill("");

        skillTreeTwoName_ = "Defensive";
        skillTreeTwo_[0] = basicSkills_[1];
        skillTreeTwo_[1] = new Skill("Parry");
        skillTreeTwo_[2] = new Skill("Warrior's Spirit");
        skillTreeTwo_[3] = new Skill("");
        skillTreeTwo_[4] = new Skill("");

        skillTreeThreeName_ = "Evasion";
        skillTreeThree_[0] = basicSkills_[2];
        skillTreeThree_[1] = new Skill("Lion's Roar");
        skillTreeThree_[2] = new Skill("");
        skillTreeThree_[3] = new Skill("");
        skillTreeThree_[4] = new Skill("");

        skillTreeFourName_ = "Movement";
        skillTreeFour_[0] = basicSkills_[3];
        skillTreeFour_[1] = new Skill("Dash");
        skillTreeFour_[2] = new Skill("");
        skillTreeFour_[3] = new Skill("");
        skillTreeFour_[4] = new Skill("");
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
        weaponType_ = new WeaponType("Knife");
    }

    private void SetSkills()
    {
        basicSkills_[0] = new Skill("Throwing Knife");
        basicSkills_[1] = new Skill("Smoke Bomb");
        basicSkills_[2] = new Skill("Slash");
        basicSkills_[3] = new Skill("Counter");
        foreach (Skill i in basicSkills_)
        {
            i.isActive = true;
        }

        skillTreeOneName_ = "Offensive";
        skillTreeOne_[0] = basicSkills_[0];
        skillTreeOne_[1] = new Skill("Poison Dart");
        skillTreeOne_[2] = new Skill("");
        skillTreeOne_[3] = new Skill("");
        skillTreeOne_[4] = new Skill("Assassinate");

        skillTreeTwoName_ = "Stealth";
        skillTreeTwo_[0] = basicSkills_[1];
        skillTreeTwo_[1] = new Skill("Invisibility");
        skillTreeTwo_[2] = new Skill("");
        skillTreeTwo_[3] = new Skill("");
        skillTreeTwo_[4] = new Skill("");

        skillTreeThreeName_ = "Potions";
        skillTreeThree_[0] = basicSkills_[2];
        skillTreeThree_[1] = new Skill("Weakness");
        skillTreeThree_[2] = new Skill("Poison");
        skillTreeThree_[3] = new Skill("");
        skillTreeThree_[4] = new Skill("");

        skillTreeFourName_ = "Magic";
        skillTreeFour_[0] = basicSkills_[3];
        skillTreeFour_[1] = new Skill("");
        skillTreeFour_[2] = new Skill("");
        skillTreeFour_[3] = new Skill("");
        skillTreeFour_[4] = new Skill("");
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
        weaponType_ = new WeaponType("Two-Handed");
    }

    private void SetSkills()
    {
        basicSkills_[0] = new Skill("Heavy Swing");
        basicSkills_[1] = new Skill("Shield Wall");
        basicSkills_[2] = new Skill("Charge");
        basicSkills_[3] = new Skill("Weapon Swing");
        foreach (Skill i in basicSkills_)
        {
            i.isActive = true;
        }

        skillTreeOneName_ = "Offensive";
        skillTreeOne_[0] = basicSkills_[0];
        skillTreeOne_[1] = new Skill("Shield Bash");
        skillTreeOne_[2] = new Skill("");
        skillTreeOne_[3] = new Skill("");
        skillTreeOne_[4] = new Skill("");

        skillTreeTwoName_ = "Defensive";
        skillTreeTwo_[0] = basicSkills_[1];
        skillTreeTwo_[1] = new Skill("Block");
        skillTreeTwo_[2] = new Skill("");
        skillTreeTwo_[3] = new Skill("");
        skillTreeTwo_[4] = new Skill("");

        skillTreeThreeName_ = "Aggro";
        skillTreeThree_[0] = basicSkills_[2];
        skillTreeThree_[1] = new Skill("");
        skillTreeThree_[2] = new Skill("");
        skillTreeThree_[3] = new Skill("");
        skillTreeThree_[4] = new Skill("");

        skillTreeFourName_ = "";
        skillTreeFour_[0] = basicSkills_[3];
        skillTreeFour_[1] = new Skill("");
        skillTreeFour_[2] = new Skill("");
        skillTreeFour_[3] = new Skill("");
        skillTreeFour_[4] = new Skill("");
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
        weaponType_ = new WeaponType("Knuckle-Duster");
    }

    private void SetSkills()
    {
        basicSkills_[0] = new Skill("Uppercut");
        basicSkills_[1] = new Skill("Kick");
        basicSkills_[2] = new Skill("Slide");
        basicSkills_[3] = new Skill("Block");
        foreach (Skill i in basicSkills_)
        {
            i.isActive = true;
        }

        skillTreeOneName_ = "";
        skillTreeOne_[0] = basicSkills_[0];
        skillTreeOne_[1] = new Skill("");
        skillTreeOne_[2] = new Skill("");
        skillTreeOne_[3] = new Skill("");
        skillTreeOne_[4] = new Skill("");

        skillTreeTwoName_ = "";
        skillTreeTwo_[0] = basicSkills_[1];
        skillTreeTwo_[1] = new Skill("");
        skillTreeTwo_[2] = new Skill("");
        skillTreeTwo_[3] = new Skill("");
        skillTreeTwo_[4] = new Skill("");

        skillTreeThreeName_ = "";
        skillTreeThree_[0] = basicSkills_[2];
        skillTreeThree_[1] = new Skill("");
        skillTreeThree_[2] = new Skill("");
        skillTreeThree_[3] = new Skill("");
        skillTreeThree_[4] = new Skill("");

        skillTreeFourName_ = "";
        skillTreeFour_[0] = basicSkills_[3];
        skillTreeFour_[1] = new Skill("");
        skillTreeFour_[2] = new Skill("");
        skillTreeFour_[3] = new Skill("");
        skillTreeFour_[4] = new Skill("");
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
        weaponType_ = new WeaponType("BowMount");
    }

    private void SetSkills()
    {
        basicSkills_[0] = new Skill("Arrow Flurry");
        basicSkills_[1] = new Skill("Saddle Up");
        basicSkills_[2] = new Skill("Hood");
        basicSkills_[3] = new Skill("Fire Arrow");
        foreach (Skill i in basicSkills_)
        {
            i.isActive = true;
        }

        skillTreeOneName_ = "";
        skillTreeOne_[0] = basicSkills_[0];
        skillTreeOne_[1] = new Skill("");
        skillTreeOne_[2] = new Skill("");
        skillTreeOne_[3] = new Skill("");
        skillTreeOne_[4] = new Skill("");

        skillTreeTwoName_ = "Mount";
        skillTreeTwo_[0] = basicSkills_[1];
        skillTreeTwo_[1] = new Skill("");
        skillTreeTwo_[2] = new Skill("");
        skillTreeTwo_[3] = new Skill("");
        skillTreeTwo_[4] = new Skill("");

        skillTreeThreeName_ = "";
        skillTreeThree_[0] = basicSkills_[2];
        skillTreeThree_[1] = new Skill("");
        skillTreeThree_[2] = new Skill("");
        skillTreeThree_[3] = new Skill("");
        skillTreeThree_[4] = new Skill("");

        skillTreeFourName_ = "";
        skillTreeFour_[0] = basicSkills_[3];
        skillTreeFour_[1] = new Skill("");
        skillTreeFour_[2] = new Skill("");
        skillTreeFour_[3] = new Skill("");
        skillTreeFour_[4] = new Skill("");
    }
}