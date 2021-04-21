﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassSystem : MonoBehaviour
{
    public GameObject fireball;
    public GameObject fireblast;
    public GameObject flamethrower;
    public GameObject flameburst;
    public GameObject flameinferno;

    public GameObject lightningstrike;
    public GameObject lightningbolt;
    public GameObject electriccage;
    public GameObject plasmacharge;
    public GameObject lightningpillar;

    public GameObject frostwave;
    public GameObject iceprison;
    public GameObject freezingbreath;
    public GameObject icecrash;
    public GameObject freezingland;

    public static WizardClass wizard = new WizardClass();

    void Start()
    {
        wizard.basicSkills[0] = new Skill("Fireball", fireball);
        wizard.basicSkills[1] = new Skill("Lightning Strike", lightningstrike);
        wizard.basicSkills[2] = new Skill("Frost Wave", frostwave);
        wizard.basicSkills[3] = new Skill("Healing Chime");
        foreach (Skill i in wizard.basicSkills)
        {
            i.isActive = true;
        }

        wizard.skillTreeOne[0] = wizard.basicSkills[0];
        wizard.skillTreeOne[1] = new Skill("Fire Blast", fireblast);
        wizard.skillTreeOne[2] = new Skill("Flamethrower", flamethrower);
        wizard.skillTreeOne[3] = new Skill("Flame Burst", flameburst);
        wizard.skillTreeOne[4] = new Skill("Flame Inferno", flameinferno);

        wizard.skillTreeTwo[0] = wizard.basicSkills[1];
        wizard.skillTreeTwo[1] = new Skill("Lightning Bolt", lightningbolt);
        wizard.skillTreeTwo[2] = new Skill("Electric Cage", electriccage);
        wizard.skillTreeTwo[3] = new Skill("Plasma Charge", plasmacharge);
        wizard.skillTreeTwo[4] = new Skill("Lightning Pillar", lightningpillar);

        wizard.skillTreeThree[0] = wizard.basicSkills[2];
        wizard.skillTreeThree[1] = new Skill("Ice Prison", iceprison);
        wizard.skillTreeThree[2] = new Skill("Freezing Breath", freezingbreath);
        wizard.skillTreeThree[3] = new Skill("Ice Crash", icecrash);
        wizard.skillTreeThree[4] = new Skill("Freezing Land", freezingland);

        wizard.skillTreeFour[0] = wizard.basicSkills[3];
        wizard.skillTreeFour[1] = new Skill("Speed Boost");
        wizard.skillTreeFour[2] = new Skill("Evasion Amplification");
        wizard.skillTreeFour[3] = new Skill("Defence Boost");
        wizard.skillTreeFour[4] = new Skill("Health Renewal");
    }



    public class Skill
    {
        private string name_;
        private int skillSlot_;   //0 the skill is unequipped, 1 is in slot 1, 2is in slot 2.
        private bool isActive_;   //is the skill unlocked.

        public GameObject prefab;

        public string name
        {
            get { return name_; }
            set { name_ = value; }
        }

        public int skillSlot
        {
            get { return skillSlot_; }
            set { skillSlot_ = value; }
        }

        public bool isActive
        {
            get { return isActive_; }
            set { isActive_ = value; }
        }


        public Skill(string skillName)
        {
            name_ = skillName;
            skillSlot_ = 0;
            isActive_ = false;
        }
        //constructor for skills without an object needed (eg. healing chime)

        public Skill(string skillName, GameObject skillPrefab)
        {
            name_ = skillName;
            skillSlot_ = 0;
            isActive_ = false;
            prefab = skillPrefab;
        }

        public void Use(Rigidbody2D rb2D, Vector2 direction, GameObject playerObject)           //may want to make this more efficient by splitting if statements by class and skill tree
        {
            if (name_ == "Fireball")
            {
                GameObject Fireball = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                attack projectile = Fireball.GetComponent<attack>();
                projectile.damage = 1;
                projectile.life = 0.5f;
                projectile.speed = 800;
                projectile.Launch(direction);
                return;
            }
            else if (name_ == "Fire Blast")
            {
                GameObject Fireblast = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                attack projectile = Fireblast.GetComponent<attack>();
                projectile.damage = 2;
                projectile.life = 3.0f;
                projectile.speed = 650;
                projectile.Launch(direction);
                return;
            }
            else if (name_ == "Flamethrower")
            {
                //will wait for level to be populated to test easier
                return;
            }
            else if (name_ == "Flame Burst")
            {
                GameObject Flameburst = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                attack projectile = Flameburst.GetComponent<attack>();
                projectile.damage = 3;
                projectile.life = 6.0f;
                projectile.speed = 500;
                projectile.Launch(direction);
                return;
            }
            else if (name_ == "Flame Inferno")
            {
                GameObject FireTornado = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                attack projectile = FireTornado.GetComponent<attack>();
                projectile.damage = 4;
                projectile.life = 1000f;
                projectile.speed = 750;
                projectile.hitsEnemies = false;
                projectile.Launch(direction);
                return;
            }


            if (name_ == "Lightning Strike")
            {
                Vector2 off = new Vector2(5, -0.3f);
                if (direction == Vector2.left)
                {
                    off = new Vector2(-5, -0.3f);
                }

                GameObject LightningStrike = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                attack strike = LightningStrike.GetComponent<attack>();
                strike.damage = 2;
                strike.life = 0.5f;
                return;
            }
            else if (name_ == "Lightning Bolt")
            {
                Vector2 off = new Vector2(5, 1f);
                if (direction == Vector2.left)
                {
                    off = new Vector2(-5, 1f);
                }

                GameObject LightningBolt = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                attack strike = LightningBolt.GetComponent<attack>();
                strike.damage = 3;
                strike.life = 0.5f;
                return;
            }
            else if (name_ == "Electric Cage")
            {
                //will wait for level to be populated
                return;
            }
            else if (name_ == "Plasma Charge")
            {
                Vector2 off = new Vector2(5, 2.7f);
                if (direction == Vector2.left)
                {
                    off = new Vector2(-5, 2.7f);
                }

                GameObject PlasmaCharge = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                attack strike = PlasmaCharge.GetComponent<attack>();
                strike.damage = 3;
                strike.life = 0.8f;
                return;
            }
            else if (name_ == "Lightning Pillar")
            {
                Vector2 off = new Vector2(5, 0.2f);
                if (direction == Vector2.left)
                {
                    off = new Vector2(-5, 0.2f);
                }

                GameObject LightningPillar = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                attack strike = LightningPillar.GetComponent<attack>();
                strike.damage = 0.1f;
                strike.life = 150f;
                strike.hitsEnemies = false;
                return;
            }


            if(name_ == "Frost Wave")
            {
                if ((direction == Vector2.up) || (direction == Vector2.down)) { direction = Vector2.right; }

                Vector2 off = new Vector2(8, -1.3f);
                if (direction == Vector2.left)
                {
                    off = new Vector2(-8, -1.3f);
                }

                GameObject FrostWave = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                attack fwave = FrostWave.GetComponent<attack>();
                fwave.damage = 1;
                fwave.life = 6.0f;
                return;
            }
            else if (name_ == "Ice Prison")
            {
                //will wait for level to be populated
                return;
            }
            else if (name_ == "Freezing Breath")
            {
                //will wait for level to be populated
                return;
            }
            else if (name_ == "Ice Crash")
            {
                if ((direction == Vector2.up) || (direction == Vector2.down)) { direction = Vector2.right; }



                GameObject IceCrash = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);
                attack fwave = IceCrash.GetComponent<attack>();
                fwave.damage = 3.5f;
                fwave.life = 5.0f;
                fwave.speed = 1000f;
                fwave.Launch(direction);
                return;
            }
            else if (name_ == "Freezing Land")
            {
                //will wait for level to be populated
                return;
            }


            if (name_ == "Healing Chime")
            {
                PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                player.ChangeHealth(1);
                return;
            }
            else if (name_ == "Speed Boost")
            {
                SpeedBoost(playerObject);       //may not work
                return;
            }
            else if (name_ == "Evasion Amplification")
            {
                EvasionAmplification(playerObject); //also may not work
                return;
            }
            else if (name_ == "Defence Boost")
            {
                DefenceBoost(playerObject);         //and this
                return;
            }
            else if (name_ == "Health Renewal")
            {
                PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                player.ChangeHealth(3);
            }
        }

        IEnumerator SpeedBoost(GameObject playerObject)
        {
            PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
            player.speed += 3;
            yield return new WaitForSeconds(5);
            player.speed -= 3;
        }

        IEnumerable EvasionAmplification(GameObject playerObject)
        {
            PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
            player.evadeChance += 10;
            yield return new WaitForSeconds(15);
            player.evadeChance -= 10;
        }

        IEnumerable DefenceBoost(GameObject playerObject)
        {
            PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
            player.defence += 0.1f;
            yield return new WaitForSeconds(15);
            player.defence -= 0.1f;
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

        protected Skill[] basicSkills_ = new Skill[4];

        protected Skill[] skillTreeOne_ = new Skill[5];
        protected string skillTreeOneName_;

        protected Skill[] skillTreeTwo_ = new Skill[5];
        protected string skillTreeTwoName_;

        protected Skill[] skillTreeThree_ = new Skill[5];
        protected string skillTreeThreeName_;

        protected Skill[] skillTreeFour_ = new Skill[5];
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

        public Skill[] basicSkills
        {
            get { return basicSkills_; }
            set { basicSkills_ = value; }
        }

        public Skill[] skillTreeOne
        {
            get { return skillTreeOne_; }
            set { skillTreeOne_ = value; }
        }

        public Skill[] skillTreeTwo
        {
            get { return skillTreeTwo_; }
            set { skillTreeTwo_ = value; }
        }

        public Skill[] skillTreeThree
        {
            get { return skillTreeThree_; }
            set { skillTreeThree_ = value; }
        }
        public Skill[] skillTreeFour
        {
            get { return skillTreeFour_; }
            set { skillTreeFour_ = value; }
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
            skillTreeOneName_ = "Fire";
            skillTreeTwoName_ = "Lightning";
            skillTreeThreeName_ = "Ice";
            skillTreeFourName_ = "Utility";
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

            foreach (Skill i in basicSkills_)
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
}