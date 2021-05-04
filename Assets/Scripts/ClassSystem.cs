using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassSystem : MonoBehaviour
{
    public Sprite wizardPortrait;
    public Sprite knightPortrait;
    public Sprite assassinPortrait;

    public Animator knightAnimator;


    public GameObject fireball;
    public Sprite fireballPortrait;
    public GameObject fireblast;
    public Sprite fireblastPortrait;
    public GameObject flamethrower;
    public Sprite flamethrowerPortrait;
    public GameObject flameburst;
    public Sprite flameburstPortrait;
    public GameObject flameinferno;
    public Sprite flameinfernoPortrait;

    public GameObject lightningstrike;
    public Sprite lightningstrikePortrait;
    public GameObject lightningbolt;
    public Sprite lightningboltPortrait;
    public GameObject electriccage;
    public Sprite electriccagePortrait;
    public GameObject plasmacharge;
    public Sprite plasmachargePortrait;
    public GameObject lightningpillar;
    public Sprite lightningpillarPortrait;

    public GameObject frostwave;
    public Sprite frostwavePortrait;
    public GameObject iceprison;
    public Sprite iceprisonPortrait;
    public GameObject freezingbreath;
    public Sprite freezingbreathPortrait;
    public GameObject icecrash;
    public Sprite icecrashPortrait;
    public GameObject freezingland;
    public Sprite freezinglandPortrait;

    public Sprite healingchimePortrait;
    public Sprite speedboostPortrait;
    public Sprite evasionPortrait;
    public Sprite defenceboostPortrait;
    public Sprite healthrenewalPortrait;



    public Sprite largeswingPortrait;
    public Sprite lungePortrait;
    public Sprite tripleswipePortrait;
    public Sprite dualslicePortrait;
    public GameObject frictionspark;
    public Sprite frictionPortrait;

    public Sprite blockPortrait;
    public Sprite parryPortrait;
    public Sprite wsPortrait;
    public Sprite mpPortrait;
    public Sprite ksPortrait;

    public Sprite rollPortrait;
    public Sprite lionsPortrait;
    public Sprite btPortrait;
    public Sprite maPortrait;
    public Sprite adrenlinePortrait;

    public Sprite sprintPortrait;
    public Sprite springbootsPortrait;
    public Sprite featherbootsPortrait;
    public Sprite lightspringPortrait;
    public Sprite lightfeatherPortrait;



    public GameObject throwingknife;
    public Sprite throwingknifePortrait;
    public GameObject poisondart;
    public Sprite poisondartPortrait;
    public Sprite slidePortrait;
    public Sprite tauntPortrait;
    public Sprite assassinatePortrait;

    public GameObject smokebomb;
    public Sprite smokebombPortrait;
    public Sprite invisPortrait;
    public Sprite criticalPortrait;
    public Sprite shadowPortrait;
    public Sprite superstealthPortrait;

    public Sprite slashPortrait;
    public GameObject weakness;
    public Sprite weaknessPortrait;
    public GameObject poison;
    public Sprite poisonPortrait;
    public GameObject slowness;
    public Sprite slownessPortrait;
    public GameObject paralysis;
    public Sprite paralysisPortrait;

    public Sprite counterSprite;
    public Sprite doublePortrait;
    public Sprite overhealthPortrait;
    public Sprite triplePortrait;
    public GameObject shadowclone;
    public Sprite shadowclonePortrait;



    public GameObject arrowflurry;
    public Sprite arrowflurryPortrait;
    public GameObject spear;
    public Sprite spearPortrait;
    public Sprite spearflurryPortrait;
    public GameObject bouncyarrow;
    public Sprite bouncyarrowPortrait;
    public GameObject heavansflurry;
    public Sprite heavansSprite;

    public Sprite saddleupPortrait;
    public Sprite chargePortrait;
    public Sprite horseshoesPortrait;
    public Sprite flamechargePortrait;
    public Sprite mountsproPortrait;

    public Sprite hoodPortrait;
    public Sprite swiftPortrait;
    public Sprite soulPortrait;
    public Sprite sharpenedPortrait;
    public Sprite herbalPortrait;

    public GameObject firearrow;
    public Sprite firearrowPortrait;
    public GameObject icearrow;
    public Sprite icearrowPortrait;
    public GameObject thunderarrow;
    public Sprite thunderarrowPortrait;
    public GameObject shadowarrow;
    public Sprite shadowarrowPortrait;
    public GameObject lightarrow;
    public Sprite lightarrowPortrait;

    public Sprite oakwandPortrait;
    public Sprite bronzewandPortrait;
    public Sprite goldwandPortrait;
    public Sprite dragonbonewandPortrait;

    public Sprite woodenswordPortrait;
    public Sprite ironswordPortrait;
    public Sprite steelswordPortrait;
    public Sprite obsidianswordPortrait;

    public Sprite knifePortrait;
    public Sprite sharpenedknifePortrait;
    public Sprite daggerPortrait;
    public Sprite sharpeneddaggerPortrait;

    public Sprite bowPortrait;
    public Sprite lightbowPortrait;
    public Sprite darkbowPortrait;
    public Sprite horsearmourPortrait;


    public static WizardClass wizard = new WizardClass();
    public static KnightClass knight = new KnightClass();
    public static AssassinClass assassin = new AssassinClass();
    public static RangerClass ranger = new RangerClass();


    void Awake()
    {
        wizard.portrait = wizardPortrait;
        wizard.weapons[0] = new Weapon("Oak Wand", oakwandPortrait);
        wizard.weapons[1] = new Weapon("Bronze Wand", bronzewandPortrait);
        wizard.weapons[2] = new Weapon("Gold Wand", goldwandPortrait);
        wizard.weapons[3] = new Weapon("Dragonbone Wand", dragonbonewandPortrait);
        wizard.weapons[0].isBought = true;

        wizard.basicSkills[0] = new Skill("Fireball", fireball, 0.5f, 0.5f, "Wizard", fireballPortrait, "Shoots a small fireball ahead of you");
        wizard.basicSkills[1] = new Skill("Lightning Strike", lightningstrike, 1.3f, 1f, "Wizard", lightningstrikePortrait, "Shoot a small lightning bolt in a spot ahead of you");
        wizard.basicSkills[2] = new Skill("Frost Wave", frostwave, 5f, 5f, "Wizard", frostwavePortrait, "Decreases enemies speed, and increases the damage taken for a period of time in a small area");
        wizard.basicSkills[3] = new Skill("Healing Chime", 8f, 9f, "Wizard", healingchimePortrait, "Recover a small amount of health");
        foreach (Skill i in wizard.basicSkills)
        {
            i.isActive = true;
        }

        wizard.skillTreeOne[0] = wizard.basicSkills[0];
        wizard.skillTreeOne[1] = new Skill("Fire Blast", fireblast, 0.2f, 1.5f, "Wizard", fireblastPortrait, "Shoot a medium sized fireball ahead of you");
        wizard.skillTreeOne[2] = new Skill("Flamethrower", 2f, 2f, "Wizard", flamethrowerPortrait, "Shoots continuous fire ahead, small range");
        wizard.skillTreeOne[3] = new Skill("Flame Burst", flameburst, 0.4f, 4.5f, "Wizard", flameburstPortrait, "Shoot a large fireball ahead of you");
        wizard.skillTreeOne[4] = new Skill("Flame Inferno", flameinferno, 3.5f, 8f, "Wizard", flameinfernoPortrait, "Creates a tornado of fire, which moves forwards until it makes contact with a wall, will damage any enemies who makes contact with the tornado");

        wizard.skillTreeTwo[0] = wizard.basicSkills[1];
        wizard.skillTreeTwo[1] = new Skill("Lightning Bolt", lightningbolt, 1.5f, 3f, "Wizard", lightningboltPortrait, "Shoot a medium sized lightning bolt in a spot ahead of you");
        wizard.skillTreeTwo[2] = new Skill("Electric Cage", electriccage, 9f, 10f, "Wizard", electriccagePortrait, "Traps target in a cage, which paralyses target for a period of time");
        wizard.skillTreeTwo[3] = new Skill("Plasma Charge", plasmacharge, 5f, 8f, "Wizard", plasmachargePortrait, "Shoots a large sized lightning bolt in a spot ahead of you");
        wizard.skillTreeTwo[4] = new Skill("Lightning Pillar", lightningpillar, 18f, 14f, "Wizard", lightningpillarPortrait, "Sets up a pillar, which will attacks the enemy who is closest");

        wizard.skillTreeThree[0] = wizard.basicSkills[2];
        wizard.skillTreeThree[1] = new Skill("Ice Prison", iceprison, 12f, 10f, "Wizard", iceprisonPortrait, "Decrease enemies speed, and increase the damage taken for a longer period of time");
        wizard.skillTreeThree[2] = new Skill("Freezing Breath", 2f, 4f, "Wizard", freezingbreathPortrait, "Attacks forwards, damaging enemies in range and decreases enemies speed");
        wizard.skillTreeThree[3] = new Skill("Ice Crash", icecrash, 0.5f, 5.5f, "Wizard", icecrashPortrait, "Shoot an icicle in front of you");
        wizard.skillTreeThree[4] = new Skill("Freezing Land", 5f, 7f, "Wizard", freezinglandPortrait, "Attacks forwards, damaging enemies in range, higher damage and range than 'Freezing Breath'");

        wizard.skillTreeFour[0] = wizard.basicSkills[3];
        wizard.skillTreeFour[1] = new Skill("Speed Boost", 13f, 8.5f, "Wizard", speedboostPortrait, "Speeds you up for a short period of time");
        wizard.skillTreeFour[2] = new Skill("Evasion Amplification", 35f, 9f, "Wizard", evasionPortrait, "Have a chance to evade attacks for a medium amount of time");
        wizard.skillTreeFour[3] = new Skill("Defence Boost", 13f, 9f, "Wizard", defenceboostPortrait, "Increase your defence for a short period of time");
        wizard.skillTreeFour[4] = new Skill("Health Renewal", 15f, 16f, "Wizard", healthrenewalPortrait, "Recover a medium amount of health");



        knight.portrait = knightPortrait;
        knight.weapons[0] = new Weapon("Wooden Sword", woodenswordPortrait);
        knight.weapons[1] = new Weapon("Iron Sword", ironswordPortrait);
        knight.weapons[2] = new Weapon("Steel Sword", steelswordPortrait);
        knight.weapons[3] = new Weapon("Obsidian Sword", obsidianswordPortrait);
        knight.weapons[0].isBought = true;

        knight.basicSkills[0] = new Skill("Large Swing", 3f, 5f, "Knight", largeswingPortrait, "Swing your sword ahead, dealing large damage");
        knight.basicSkills[1] = new Skill("Block", 2.5f, 1f, "Knight", blockPortrait, "Block oncoming attacks for the next second");
        knight.basicSkills[2] = new Skill("Roll", 1.5f, 2f, "Knight", rollPortrait, "Roll left or right");
        knight.basicSkills[3] = new Skill("Sprint", 15f, 3f, "Knight", sprintPortrait, "Increase your speed for a period of time");

        foreach (Skill i in knight.basicSkills)
        {
            i.isActive = true;
        }

        knight.skillTreeOne[0] = knight.basicSkills[0];
        knight.skillTreeOne[1] = new Skill("Lunge", 3f, 2.5f, "Knight", lungePortrait, "Move forward rapidly using your sword");
        knight.skillTreeOne[2] = new Skill("Triple Swipe", 0.25f, 1f, "Knight", tripleswipePortrait, "Small attack that deals more damage when used in quick succession (three times)");
        knight.skillTreeOne[3] = new Skill("Dual Slice", 5f, 5f, "Knight", dualslicePortrait, "Jump forward and attack twice in quick succession");
        knight.skillTreeOne[4] = new Skill("Friction Spark", frictionspark, 2f, 7f, "Knight", frictionPortrait, "Send a high damage spark hurling in front of you");

        knight.skillTreeTwo[0] = knight.basicSkills[1];
        knight.skillTreeTwo[1] = new Skill("Parry", 6f, 5f, "Knight", parryPortrait, "Block and counters any incoming attacks for a second");
        knight.skillTreeTwo[2] = new Skill("Warrior's Spirit", 18f, 8.5f, "Knight", wsPortrait, "Raise your defence for a short period of time");
        knight.skillTreeTwo[3] = new Skill("Mother's Prayer", 20f, 1f, "Knight", mpPortrait, "Regain mana at the cost of remaining still");
        knight.skillTreeTwo[4] = new Skill("Knight's Spirit", 28f, 10f, "Knight", ksPortrait, "Raise your defence for a longer period of time");

        knight.skillTreeThree[0] = knight.basicSkills[2];
        knight.skillTreeThree[1] = new Skill("Lion's Roar", 20f, 8f, "Knight", lionsPortrait, "Have a reasonable chance to evade attack for a short amount of time");
        knight.skillTreeThree[2] = new Skill("Blessed Touch", 10f, 10f, "Knight", btPortrait, "Restore a small amount of health over time");
        knight.skillTreeThree[3] = new Skill("Magic Armour", 12f, 8f, "Knight", maPortrait, "Have a high chance to evade attacks at the cost of speed, for a short amount of time");
        knight.skillTreeThree[4] = new Skill("Adrenaline Rush", 20f, 10f, "Knight", adrenlinePortrait, "Have a high chance of evading attacks for a short amount of time");

        knight.skillTreeFour[0] = knight.basicSkills[3];
        knight.skillTreeFour[1] = new Skill("Spring Boots", 20f, 8f, "Knight", springbootsPortrait, "Increase your jump height for a period of time");
        knight.skillTreeFour[2] = new Skill("Feather Boots", 20f, 8.5f, "Knight", featherbootsPortrait, "Makes your jumps floatier");
        knight.skillTreeFour[3] = new Skill("Light Spring Boots", 20f, 10f, "Knight", lightspringPortrait, "Increase your speed and jump height for a short time");
        knight.skillTreeFour[4] = new Skill("Light Feather Boots", 20f, 10.5f, "Knight", lightfeatherPortrait, "Increase your speed and make your jumps floatier for a short time");



        assassin.portrait = assassinPortrait;
        assassin.weapons[0] = new Weapon("Knife", knifePortrait);
        assassin.weapons[1] = new Weapon("Sharpened Knife", sharpenedknifePortrait);
        assassin.weapons[2] = new Weapon("Dagger", daggerPortrait);
        assassin.weapons[3] = new Weapon("Sharpened Dagger", sharpeneddaggerPortrait);
        assassin.weapons[0].isBought = true;

        assassin.basicSkills[0] = new Skill("Throwing Knife", throwingknife, 0.3f, 0.5f, "Assassin", throwingknifePortrait, "Throw knives in a given direction");
        assassin.basicSkills[1] = new Skill("Smoke Bomb", smokebomb, 6f, 3f, "Assassin", smokebombPortrait, "Blind enemies in an area");
        assassin.basicSkills[2] = new Skill("Slash", 6f, 8f, "Assassin", slashPortrait, "Launch forward, doing damage to enemies in front of you");
        assassin.basicSkills[3] = new Skill("Counter", 10f, 8f, "Assassin", counterSprite, "Have a high chance of dodging attacks, briefly. Hit enemies in-front of you after");
        foreach (Skill i in assassin.basicSkills)
        {
            i.isActive = true;
        }

        assassin.skillTreeOne[0] = assassin.basicSkills[0];
        assassin.skillTreeOne[1] = new Skill("Poison Dart", poisondart, 4f, 2.5f, "Assassin", poisondartPortrait, "Fire a dart which inflicts the target with poison, which inflicts damage over time, but will leave the target at 1 hp");
        assassin.skillTreeOne[2] = new Skill("Slide", 3f, 4f, "Assassin", slidePortrait, "Slide along the floor, dodging any attacks");
        assassin.skillTreeOne[3] = new Skill("Taunt", 4f, 3f, "Assassin", tauntPortrait, "Taunt enemies from afar");
        assassin.skillTreeOne[4] = new Skill("Assassinate", 15f, 15f, "Assassin", assassinatePortrait, "When in the air, damage enemies below you to do massive damage");

        assassin.skillTreeTwo[0] = assassin.basicSkills[1];
        assassin.skillTreeTwo[1] = new Skill("Invisibility", 20f, 9.5f, "Assassin", invisPortrait, "Go invisible for a period of time. Enemies won't attack, but neither can you");
        assassin.skillTreeTwo[2] = new Skill("Critical Strike", 22f, 10f, "Assassin",criticalPortrait, "Invisibility but when you attack, your next attack will do double damage and will take you out of invisibility");
        assassin.skillTreeTwo[3] = new Skill("Shadow Sneak", 5f, 8.5f, "Assassin", shadowPortrait, "Teleport in a given direction");
        assassin.skillTreeTwo[4] = new Skill("Super Stealth", 15f, 14f, "Assassin", superstealthPortrait, "Increase your stealth further, making it so enemies don't see you for a limited time");

        assassin.skillTreeThree[0] = assassin.basicSkills[2];
        assassin.skillTreeThree[1] = new Skill("Weakness", weakness, 10f, 7f, "Assassin", weaknessPortrait, "Throw a potion of weakness at the enemy, which increases the damage the enemy will recieve");
        assassin.skillTreeThree[2] = new Skill("Poison", poison, 10f, 6.5f, "Assassin", poisonPortrait, "Throws a potion of poison at the enemy, which will inflict damage over time, but will leave the target at 1 hp");
        assassin.skillTreeThree[3] = new Skill("Slowness", slowness, 10f, 7.5f, "Assassin", slownessPortrait, "Throw a potion of slowness at the enemy, slowing them down");
        assassin.skillTreeThree[4] = new Skill("Paralysis", paralysis, 15f, 10f, "Assassin", paralysisPortrait, "Throw a potion of paralysis at the enemy, paralyzing them for a short time");

        assassin.skillTreeFour[0] = assassin.basicSkills[3];
        assassin.skillTreeFour[1] = new Skill("Double Jump", 2f, 8f, "Assassin", doublePortrait, "Gain the ability to double jump when activated");
        assassin.skillTreeFour[2] = new Skill("Over-Health", 25f, 10f, "Assassin", overhealthPortrait, "Increase your strength for a period of time");
        assassin.skillTreeFour[3] = new Skill("Triple Jump", 2f, 10f, "Assassin", triplePortrait, "Gain the ability to triple jump when activated");
        assassin.skillTreeFour[4] = new Skill("Shadow Clone", shadowclone, 20f, 15f, "Assassin", shadowclonePortrait, "Clone a skeleton foot-soilder to fight for you");



        ranger.portrait = knightPortrait;
        ranger.weapons[0] = new Weapon("Bow", bowPortrait);
        ranger.weapons[1] = new Weapon("Light Bow", lightbowPortrait);
        ranger.weapons[2] = new Weapon("Dark Bow", darkbowPortrait);
        ranger.weapons[3] = new Weapon("Horse Armour", horsearmourPortrait);
        ranger.weapons[0].isBought = true;

        ranger.basicSkills[0] = new Skill("Arrow Flurry", arrowflurry, 2.5f, 5f, "Ranger", arrowflurryPortrait, "Shoot three arrows in the direction you're facing");
        ranger.basicSkills[1] = new Skill("Saddle Up", 2f, 8f, "Ranger", saddleupPortrait, "Mount your horse to move faster");
        ranger.basicSkills[2] = new Skill("Hood", 2f, 8f, "Ranger", hoodPortrait, "Increase your stealth, decrease your defence");
        ranger.basicSkills[3] = new Skill("Fire Arrow", firearrow, 5.5f, 3f, "Ranger", firearrowPortrait, "Shoot a high damage arrow in the direction you're facing");
        foreach (Skill i in ranger.basicSkills)
        {
            i.isActive = true;
        }

        ranger.skillTreeOne[0] = ranger.basicSkills[0];
        ranger.skillTreeOne[1] = new Skill("Spear", spear, 1.5f, 5f, "Ranger", spearPortrait, "Shoot a spear in the direction you're facing");
        ranger.skillTreeOne[2] = new Skill("Spear Flurry", spear, 2.5f, 8f, "Ranger", spearflurryPortrait, "Shoot three spears in the direction you're facing");
        ranger.skillTreeOne[3] = new Skill("Bouncy Arrow", bouncyarrow, 1.5f, 4f, "Ranger", bouncyarrowPortrait, "Shoots arrow which bounces off 2 walls before breaking");
        ranger.skillTreeOne[4] = new Skill("Heavan's Flurry", heavansflurry, 4f, 5f, "Ranger", heavansSprite, "Rains down arrows from above for period of time");

        ranger.skillTreeTwo[0] = ranger.basicSkills[1];
        ranger.skillTreeTwo[1] = new Skill("Charge", 4f, 3f, "Ranger", chargePortrait, "Make your horse charge a short distance");
        ranger.skillTreeTwo[2] = new Skill("Horse Shoes", 2f, 8.5f, "Ranger", horseshoesPortrait, "Give your horse new shoes to go faster");
        ranger.skillTreeTwo[3] = new Skill("Flame Charge", 8f, 6f, "Ranger", flamechargePortrait, "Make your horse charge forward a longer distance, becoming invincible while doing so");
        ranger.skillTreeTwo[4] = new Skill("Mount's Protection", 20f, 10f, "Ranger", mountsproPortrait, "For a period of time your mount will protect you from any damage");

        ranger.skillTreeThree[0] = ranger.basicSkills[2];
        ranger.skillTreeThree[1] = new Skill("Swift Bird", 20f, 7f, "Ranger", swiftPortrait, "Increase your movement speed for a short time");
        ranger.skillTreeThree[2] = new Skill("Ranger's Soul", 15f, 7.5f, "Ranger", soulPortrait, "Projectile speed increased by 50% for a small period of time");
        ranger.skillTreeThree[3] = new Skill("Sharpened Blade", 15f, 8f, "Ranger", sharpenedPortrait, "Increase the amount of damage you do for a period of time");
        ranger.skillTreeThree[4] = new Skill("Herbal Remedy", 20f, 5f, "Ranger", herbalPortrait, "Gain back health over time until you're at max health");

        ranger.skillTreeFour[0] = ranger.basicSkills[3];
        ranger.skillTreeFour[1] = new Skill("Ice Arrow", icearrow, 5f, 3.5f, "Ranger", icearrowPortrait, "Shoot an ice arrow in the direction you're facing, damaging and freezing enemies");
        ranger.skillTreeFour[2] = new Skill("Thunder Arrow", thunderarrow, 5f, 5f, "Ranger", thunderarrowPortrait, "Shoot a high damage, fast moving arrow in the direction you're facing");
        ranger.skillTreeFour[3] = new Skill("Shadow Arrow", shadowarrow, 3f, 6f, "Ranger", shadowarrowPortrait, "Shoot a low damage arrow in the direction you're facing and another high damage arrow behing you");
        ranger.skillTreeFour[4] = new Skill("Light Arrow", lightarrow, 20f, 15f, "Ranger", lightarrowPortrait, "Shoot a slow, short range arrow in the direction you're facing. Kills most enemies instantly");
    }



    public class Skill
    {
        private string name_;
        private string description_;
        private int skillSlot_;   //0 the skill is unequipped, 1 is in slot 1, 2is in slot 2.
        private bool isActive_;   //is the skill unlocked.
        private float cooldown_;
        private float cost_;
        private string skillClass_;

        public GameObject prefab;
        private Sprite portrait_;

        public string name
        {
            get { return name_; }
            set { name_ = value; }
        }


        public string description
        {
            get { return description_; }
            set { description_ = value; }
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

        public float cooldown
        {
            get { return cooldown_; }
            set { cooldown_ = value; }
        }

        public float cost
        {
            get { return cost_; }
            set { cost_ = value; }
        }

        public string skillClass
        {
            get { return skillClass_; }
            set { skillClass_ = value; }
        }

        public Sprite portrait
        {
            get { return portrait_; }
            set { portrait_ = value; }
        }



        public Skill(string skillName)
        {
            name_ = skillName;
            skillSlot_ = 0;
            isActive_ = false;
        }
        //constructor for skills without an object needed (eg. healing chime). delete soon


        public Skill(string skillName, float skillCooldown, float skillCost, string aClass, Sprite skillPortrait, string skillDescription)
        {
            name_ = skillName;
            skillSlot_ = 0;
            isActive_ = false;
            cooldown_ = skillCooldown;
            cost_ = skillCost;
            skillClass_ = aClass;
            portrait_ = skillPortrait;
            description_ = skillDescription;
        }
        //constructor for skills without an object needed (eg. healing chime)

        public Skill(string skillName, GameObject skillPrefab, float skillCooldown, float skillCost, string aClass, Sprite skillPortrait, string skillDescription)
        {
            name_ = skillName;
            skillSlot_ = 0;
            isActive_ = false;
            prefab = skillPrefab;
            cooldown_ = skillCooldown;
            cost_ = skillCost;
            skillClass_ = aClass;
            portrait_ = skillPortrait;
            description_ = skillDescription;
        }


        public void Use(Rigidbody2D rb2D, Vector2 direction, GameObject playerObject)           //may want to make this more efficient by splitting if statements by class and skill tree
        {
            if (skillClass_ == "Wizard")
            {
                if (name_ == "Fireball")
                {
                    GameObject Fireball = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = Fireball.GetComponent<attack>();
                    projectile.damage = 20;
                    projectile.life = 0.5f;
                    projectile.speed = 800;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Fire Blast")
                {
                    GameObject Fireblast = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = Fireblast.GetComponent<attack>();
                    projectile.damage = 30;
                    projectile.life = 3.0f;
                    projectile.speed = 650;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Flamethrower")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.WizardFlamethrower());
                    return;
                }
                else if (name_ == "Flame Burst")
                {
                    GameObject Flameburst = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = Flameburst.GetComponent<attack>();
                    projectile.damage = 50;
                    projectile.life = 6.0f;
                    projectile.speed = 500;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Flame Inferno")
                {
                    Vector2 off = new Vector2(5, 1.8f);
                    if (direction == Vector2.left)
                    {
                        off = new Vector2(-5, 1.8f);
                    }

                    GameObject FireTornado = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);

                    attack projectile = FireTornado.GetComponent<attack>();
                    projectile.damage = 100;
                    projectile.life = 1000f;
                    projectile.speed = 750;
                    projectile.hitsEnemies = false;
                    projectile.Launch(direction);
                    return;
                }


                if (name_ == "Lightning Strike")
                {
                    Vector2 off = new Vector2(5, 0.3f);
                    if (direction == Vector2.left)
                    {
                        off = new Vector2(-5, 0.3f);
                    }

                    GameObject LightningStrike = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                    attack strike = LightningStrike.GetComponent<attack>();
                    strike.damage = 50;
                    strike.life = 0.5f;
                    return;
                }
                else if (name_ == "Lightning Bolt")
                {
                    Vector2 off = new Vector2(5, 1.9f);
                    if (direction == Vector2.left)
                    {
                        off = new Vector2(-5, 1.9f);
                    }

                    GameObject LightningBolt = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                    attack strike = LightningBolt.GetComponent<attack>();
                    strike.damage = 65;
                    strike.life = 0.5f;
                    return;
                }
                else if (name_ == "Electric Cage")
                {
                    if ((direction == Vector2.up) || (direction == Vector2.down)) { direction = Vector2.right; }

                    Vector2 off = new Vector2(8, -0.2f);
                    if (direction == Vector2.left)
                    {
                        off = new Vector2(-8, -0.2f);
                    }

                    GameObject Cage = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                    attack ecage = Cage.GetComponent<attack>();
                    ecage.damage = 0;
                    ecage.life = 6.0f;
                    ecage.hitsEnemies = false;
                    ecage.isStun = true;
                    ecage.stunTime = 3.2f;
                    return;
                }
                else if (name_ == "Plasma Charge")
                {
                    Vector2 off = new Vector2(5, 3.3f);
                    if (direction == Vector2.left)
                    {
                        off = new Vector2(-5, 3.3f);
                    }

                    GameObject PlasmaCharge = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                    attack strike = PlasmaCharge.GetComponent<attack>();
                    strike.damage = 85;
                    strike.life = 0.8f;
                    return;
                }
                else if (name_ == "Lightning Pillar")
                {
                    Vector2 off = new Vector2(5, 1.7f);
                    if (direction == Vector2.left)
                    {
                        off = new Vector2(-5, 1.7f);
                    }

                    GameObject LightningPillar = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                    attack strike = LightningPillar.GetComponent<attack>();
                    strike.damage = 46f;
                    strike.life = 150f;
                    strike.isPillar = true;
                    strike.hitsEnemies = false;
                    return;
                }


                if (name_ == "Frost Wave")
                {
                    if ((direction == Vector2.up) || (direction == Vector2.down)) { direction = Vector2.right; }

                    Vector2 off = new Vector2(8, -0.2f);
                    if (direction == Vector2.left)
                    {
                        off = new Vector2(-8, -0.2f);
                    }

                    GameObject Wave = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                    attack fwave = Wave.GetComponent<attack>();
                    fwave.damage = 0;
                    fwave.life = 5.0f;
                    fwave.hitsEnemies = false;
                    fwave.isFreeze = true;
                    fwave.freezeTime = 2.5f;
                    fwave.freezeWeakness = 1.2f;
                    return;
                }
                else if (name_ == "Ice Prison")
                {
                    if ((direction == Vector2.up) || (direction == Vector2.down)) { direction = Vector2.right; }

                    Vector2 off = new Vector2(8, 0.4f);
                    if (direction == Vector2.left)
                    {
                        off = new Vector2(-8, 0.4f);
                    }

                    GameObject Prison = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                    attack iprison = Prison.GetComponent<attack>();
                    iprison.damage = 0;
                    iprison.life = 6.0f;
                    iprison.hitsEnemies = false;
                    iprison.isFreeze = true;
                    iprison.freezeTime = 5f;
                    iprison.freezeWeakness = 1.5f;
                    return;
                }
                else if (name_ == "Freezing Breath")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.WizardFreezingBreath());
                    return;
                }
                else if (name_ == "Ice Crash")
                {
                    if ((direction == Vector2.up) || (direction == Vector2.down)) { direction = Vector2.right; }



                    GameObject IceCrash = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);
                    attack fwave = IceCrash.GetComponent<attack>();
                    fwave.damage = 70f;
                    fwave.life = 5.0f;
                    fwave.speed = 1000f;
                    fwave.Launch(direction);
                    return;
                }
                else if (name_ == "Freezing Land")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.WizardFreezingLand());
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
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.WizardSpeedBoost());
                    return;
                }
                else if (name_ == "Evasion Amplification")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.WizardEvasionAmplification());
                    return;
                }
                else if (name_ == "Defence Boost")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.WizardDefenceBoost());
                    return;
                }
                else if (name_ == "Health Renewal")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.ChangeHealth(3);
                    return;
                }
            }

            else if (skillClass_ == "Knight")
            {

                if(name_ == "Large Swing")
                {
                    playerObject.GetComponent<ClassSystem>().knightAnimator.SetTrigger("Skill4");
                    PlayerCombat pc = playerObject.GetComponent<PlayerCombat>();
                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(pc.currentMelee.position, pc.meleeRange + 1.5f, pc.enemyLayer);
                    foreach (Collider2D enemy in hitEnemies)
                    {
                        if (!enemy.isTrigger)
                        {
                            if (enemy.tag == "skeletonfs")
                            {
                                enemy.GetComponent<SkeletonFS>().TakeDamage(150);
                            }
                            if (enemy.tag == "skeletonmage")
                            {
                                enemy.GetComponent<SkeletonMage>().TakeDamage(150);
                            }
                            if (enemy.tag == "skeletontank")
                            {
                                enemy.GetComponent<SkeletonTank>().TakeDamage(150);
                            }
                        }
                    }
                    return;
                }
                else if (name_ == "Lunge")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightLunge());
                    return;
                }
                else if (name_ == "Triple Swipe")
                {
                    playerObject.GetComponent<PlayerCombat>().KnightTripleSwipe();
                    return;
                }
                else if (name_ == "Dual Slice")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightDualSlice());
                    return;
                }
                else if (name_ == "Friction Spark")
                {
                    playerObject.GetComponent<ClassSystem>().knightAnimator.SetTrigger("Attack" + 3);
                    Vector2 off = new Vector2(0, -1.3f);
                    float rotation = 0;
                    if (direction == Vector2.left)
                    {
                        off = new Vector2(0, -1.3f);
                        rotation = 180;
                    }
                    GameObject Spark = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));

                    attack projectile = Spark.GetComponent<attack>();
                    projectile.damage = 100;
                    projectile.life = 3f;
                    projectile.speed = 600;
                    projectile.Launch(direction);
                    return;
                }



                if (name_ == "Block")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.KnightBlock());
                    return;
                }
                else if (name_ == "Parry")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.KnightParry());
                    return;
                }
                else if (name_ == "Warrior's Spirit")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightWarriorsSpirit());
                    return;
                }
                else if (name_ == "Mother's Prayer")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightMothersPrayer());
                    return;
                }
                else if (name_ == "Knight's Spirit")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightKnightsSpirit());
                    return;
                }



                if (name_ == "Roll")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightRoll());
                    return;
                }
                else if (name_ == "Lion's Roar")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightLionsRoar());
                    return;
                }
                else if (name_ == "Blessed Touch")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightBlessedTouch());
                    return;
                }
                else if (name_ == "Magic Armour")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightMagicArmour());
                    return;
                }
                else if (name_ == "Adrenline Rush")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightAdrenlineRush());
                    return;
                }


                if (name_ == "Sprint")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightSprint());
                    return;
                }
                else if(name_ == "Spring Boots")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightSpringBoots());
                    return;
                }
                else if(name_ == "Feather Boots")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightFeatherBoots());
                    return;
                }
                else if (name_ == "Light Spring Boots")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightLightSpringBoots());
                    return;
                }
                else if (name_ == "Light Feather Boots")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.KnightLightFeatherBoots());
                    return;
                }
            }

            else if (skillClass_ == "Assassin")
            {
                if (name_ == "Throwing Knife")
                {
                    playerObject.GetComponent<Animator>().SetTrigger("Throw");
                    float rotation = 0;
                    if(direction == Vector2.left) { rotation = 180; }
                    if(direction == Vector2.up) { rotation = 90; }
                    if(direction == Vector2.down) { rotation = 270;}

                    GameObject ThrowingKnife = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));

                    attack projectile = ThrowingKnife.GetComponent<attack>();
                    projectile.damage = 8f;
                    projectile.life = 1f;
                    projectile.speed = 1000;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Poison Dart")
                {
                    playerObject.GetComponent<Animator>().SetTrigger("Throw");
                    float rotation = 0;
                    if (direction == Vector2.left) { rotation = 180; }
                    if (direction == Vector2.up) { rotation = 90; }
                    if (direction == Vector2.down) { rotation = 270; }
                    GameObject PDart = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));

                    attack projectile = PDart.GetComponent<attack>();
                    projectile.damage = 0f;
                    projectile.life = 1f;
                    projectile.speed = 1500;
                    projectile.isPoison = true;
                    projectile.poisonTime = 5;
                    projectile.poisonDPS = 35;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Slide")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.AssassinSlide());
                    return;
                }
                else if (name_ == "Taunt")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.AssassinTaunt());
                    return;
                }
                else if (name_ == "Assassinate")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.AssassinAssassinate());
                    return;
                }



                if (name_ == "Smoke Bomb")
                {
                    playerObject.GetComponent<Animator>().SetTrigger("Throw");
                    if ((direction == Vector2.up) || (direction == Vector2.down)) { direction = Vector2.right; }

                    Vector2 off = new Vector2(8, 2.5f);
                    if (direction == Vector2.left)
                    {
                        off = new Vector2(-8, 2.5f);
                    }

                    GameObject Bomb = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                    attack sbomb = Bomb.GetComponent<attack>();
                    sbomb.damage = 0;
                    sbomb.life = 4.0f;
                    sbomb.hitsEnemies = false;
                    sbomb.isBlind = true;
                    sbomb.blindTime = 3.5f;
                    return;
                }
                else if (name_ == "Invisibility")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.AssassinInvis());
                    return;
                }
                else if (name_ == "Critical Strike")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.AssassinCriticalStrike());
                    return;
                }
                else if (name_ == "Shadow Sneak")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.AssassinShadowSneak());
                    return;
                }
                else if (name_ == "Super Stealth")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.AssassinSuperStealth());
                    return;
                }
                


                if (name_ == "Slash")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.AssassinSlash());
                    return;
                }
                else if (name_ == "Weakness")
                {
                    playerObject.GetComponent<Animator>().SetTrigger("Throw");
                    GameObject WPotion = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = WPotion.GetComponent<attack>();
                    projectile.damage = 0f;
                    projectile.life = 1000f;
                    projectile.speed = 1200;
                    projectile.isWeakness = true;
                    projectile.weaknessTime = 5f;
                    projectile.Throw(direction);
                    return;
                }
                else if (name_ == "Poison")
                {
                    playerObject.GetComponent<Animator>().SetTrigger("Throw");
                    GameObject PPotion = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = PPotion.GetComponent<attack>();
                    projectile.damage = 0f;
                    projectile.life = 1000f;
                    projectile.speed = 1200;
                    projectile.isPoison = true;
                    projectile.poisonTime = 8;
                    projectile.poisonDPS = 40;
                    projectile.Throw(direction);
                    return;
                }
                else if (name_ == "Slowness")
                {
                    playerObject.GetComponent<Animator>().SetTrigger("Throw");
                    GameObject SPotion = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = SPotion.GetComponent<attack>();
                    projectile.damage = 0f;
                    projectile.life = 1000f;
                    projectile.speed = 500;
                    projectile.isSlowness = true;
                    projectile.slownessTime = 8f;
                    projectile.slownessEffect = 0.5f;
                    projectile.Throw(direction);
                    return;
                }
                else if (name_ == "Paralysis")
                {
                    playerObject.GetComponent<Animator>().SetTrigger("Throw");
                    GameObject PLPotion = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = PLPotion.GetComponent<attack>();
                    projectile.damage = 0f;
                    projectile.life = 1000f;
                    projectile.speed = 600;
                    projectile.isSlowness = true;
                    projectile.slownessTime = 5f;
                    projectile.slownessEffect = 0f;
                    projectile.Throw(direction);
                    return;
                }


                if (name_ == "Counter")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.AssassinCounter());
                }
                else if (name_ == "Double Jump")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    if (player.maxJumps == 1)
                    {
                        player.maxJumps = 2;        //activate double jump skill
                    }
                    else { player.maxJumps = 1; }   //deactivate double jump skill
                    return;
                }
                else if (name_ == "Over-Health")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.AssassinOverHealth());
                    return;
                }
                else if (name_ == "Triple Jump")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    if (player.maxJumps <= 2)
                    {
                        player.maxJumps = 3;        //activate triple jump skill
                    }
                    else { player.maxJumps = 1; }   //deactivate triple jump skill
                    return;
                }
                else if (name_ == "Shadow Clone")
                {
                    playerObject.GetComponent<Animator>().SetTrigger("Throw");
                    if ((direction == Vector2.up) || (direction == Vector2.down)) { direction = Vector2.right; }

                    Vector2 off = new Vector2(5, 2.5f);
                    if (direction == Vector2.left)
                    {
                        off = new Vector2(-5, 2.5f);
                    }

                    GameObject Clone = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                    return;
                }

            }

            else if (skillClass_ == "Ranger")
            {
                if (name_ == "Arrow Flurry")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.RangerArrowFlurry(prefab));
                    return;
                }
                else if (name_ == "Spear")
                {
                    float rotation = 0;
                    if (direction == Vector2.left) { rotation = 180; }
                    if (direction == Vector2.up) { rotation = 90; }
                    if (direction == Vector2.down) { rotation = 270; }
                    GameObject Spear = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));

                    attack projectile = Spear.GetComponent<attack>();
                    projectile.damage = 20f;
                    projectile.life = 5;
                    projectile.speed = 1600;
                    projectile.Throw(direction);
                    return;
                }
                else if (name_ == "Spear Flurry")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.RangerSpearFlurry(prefab));
                    return;
                }
                else if (name_ == "Bouncy Arrow")
                {
                    float rotation = 0;
                    if (direction == Vector2.left) { rotation = 180; }
                    if (direction == Vector2.up) { rotation = 90; }
                    if (direction == Vector2.down) { rotation = 270; }
                    GameObject Bouncy = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));

                    attack projectile = Bouncy.GetComponent<attack>();
                    projectile.damage = 30f;
                    projectile.life = 1000;
                    projectile.speed = 1000;
                    projectile.isBouncy = 2;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Heavan's Flurry")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.RangerHeavansFlurry(prefab));
                    return;
                }


                if(name_ == "Saddle Up")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();

                    if (player.jumpForce == 10f)
                    {
                        player.speed += 5f;
                        player.jumpForce -= 2f;
                        player.fallMultiplier += 2f;
                        player.transform.localScale = new Vector3(12, 15, 1);
                        player.groundChecker.localPosition += new Vector3(0, -0.025f, 0);
                    }
                    else
                    {
                        player.speed -= 5f;
                        player.jumpForce += 2f;
                        player.fallMultiplier -= 2f;
                        player.transform.localScale = new Vector3(10, 10, 1);
                        player.groundChecker.localPosition += new Vector3(0, 0.025f, 0);
                    }
                    return;
                }
                else if (name_ == "Charge")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.RangerCharge());
                    return;
                }
                else if (name == "Horse Shoes")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();

                    if (player.jumpForce == 10f)
                    {
                        player.speed += 7f;
                        player.jumpForce -= 1.5f;
                        player.fallMultiplier += 1.5f;
                        player.transform.localScale = new Vector3(12, 15, 1);
                        player.groundChecker.localPosition += new Vector3(0, -0.025f, 0);
                    }
                    else
                    {
                        player.speed -= 7f;
                        player.jumpForce += 1.5f;
                        player.fallMultiplier -= 1.5f;
                        player.transform.localScale = new Vector3(10, 10, 1);
                        player.groundChecker.localPosition += new Vector3(0, 0.025f, 0);
                    }
                    return;
                }
                else if (name_ == "Flame Charge")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.RangerFlameCharge());
                    return;
                }
                else if (name_ == "Mount's Protection")
                {
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.RangerMountsProtection());
                    return;
                }


                if (name_ == "Hood")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();

                    if(player.defence == 0.3f)
                    {
                        player.defence = 0.1f;
                        SkeletonFS.sightRange = 3;
                        SkeletonMage.sightRange = 3;
                        SkeletonTank.sightRange = 3;
                    }
                    else
                    {
                        player.defence = 0.3f;
                        SkeletonFS.sightRange = 5;
                        SkeletonMage.sightRange = 5;
                        SkeletonTank.sightRange = 4;
                    }
                    return;
                }
                else if (name_ == "Swift Bird")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.RangerSwiftBird());
                    return;
                }
                else if (name_ == "Ranger's Soul")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.RangerRangersSoul());
                    return;
                }
                else if(name_ == "Sharpened Blade")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.RangerSharpenedBlade());
                    return;
                }
                else if (name_ == "Herbal Remedy")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    player.StartCoroutine(player.RangersHerbalRemedy());
                    return;
                }


                if(name_ == "Fire Arrow")
                {
                    float rotation = 0;
                    if (direction == Vector2.left) { rotation = 180; }
                    if (direction == Vector2.up) { rotation = 90; }
                    if (direction == Vector2.down) { rotation = 270; }
                    GameObject FArrow = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));

                    attack projectile = FArrow.GetComponent<attack>();
                    projectile.damage = 100f;
                    projectile.life = 2f;
                    projectile.speed = 850;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Ice Arrow")
                {
                    float rotation = 0;
                    if (direction == Vector2.left) { rotation = 180; }
                    if (direction == Vector2.up) { rotation = 90; }
                    if (direction == Vector2.down) { rotation = 270; }
                    GameObject IArrow = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));

                    attack projectile = IArrow.GetComponent<attack>();
                    projectile.damage = 50f;
                    projectile.life = 2f;
                    projectile.speed = 850;
                    projectile.isFreeze = true;
                    projectile.freezeTime = 5f;
                    projectile.freezeWeakness = 1.5f;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Thunder Arrow")
                {
                    float rotation = 0;
                    if (direction == Vector2.left) { rotation = 180; }
                    if (direction == Vector2.up) { rotation = 90; }
                    if (direction == Vector2.down) { rotation = 270; }
                    GameObject TArrow = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));

                    attack projectile = TArrow.GetComponent<attack>();
                    projectile.damage = 150;
                    projectile.life = 3f;
                    projectile.speed = 1300;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Shadow Arrow")
                {
                    float rotation = 0;
                    if (direction == Vector2.left) { rotation = 180; }
                    if (direction == Vector2.up) { rotation = 90; }
                    if (direction == Vector2.down) { rotation = 270; }
                    GameObject SArrow = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
                    GameObject SArrowClone = Instantiate(prefab, rb2D.position + -direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation +180f)));
                    attack projectile = SArrow.GetComponent<attack>();
                    attack projectile2 = SArrowClone.GetComponent<attack>();
                    projectile.damage = 50f;
                    projectile2.damage = 200f;
                    projectile.life = 5f;
                    projectile2.life = 5f;
                    projectile.speed = 850;
                    projectile2.speed = 850;
                    projectile.Launch(direction);
                    projectile2.Launch(-direction);
                    return;
                }
                else if (name_ == "Light Arrow")
                {
                    float rotation = 0;
                    if (direction == Vector2.left) { rotation = 180; }
                    if (direction == Vector2.up) { rotation = 90; }
                    if (direction == Vector2.down) { rotation = 270; }
                    GameObject LArrow = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));

                    attack projectile = LArrow.GetComponent<attack>();
                    projectile.damage = 1000f;
                    projectile.life = 1f;
                    projectile.speed = 400;
                    projectile.Launch(direction);
                    return;
                }
            }
        }
    }


    public class Weapon
    {
        protected bool isBought_;

        public Sprite portrait;

        private string name_;

        public string name
        {
            get { return name_; }
            set { name_ = value; }
        }

        public bool isBought
        {
            get { return isBought_; }
            set { isBought_ = value; }
        }

        public Weapon(string weaponName, Sprite weaponPortrait)
        {
            name_ = weaponName;
            portrait = weaponPortrait;
            isBought_ = false;
        }
    }




    public class PlayerClass
    {
        //basic info on each class
        protected string name_;
        protected int strength_;
        protected float defence_;
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

        protected Weapon[] weapons_ = new Weapon[4];
        protected Sprite portrait_;

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

        public float defence
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

        public Weapon[] weapons
        {
            get { return weapons_; }
            set { weapons_ = value; }
        }

        public Sprite portrait
        {
            get { return portrait_; }
            set { portrait_ = value; }
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
            defence_ = 0.1f;
            intelligence_ = 3;
            stealth_ = 2;
            dext_ = 1;
            SetSkills();
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
            defence_ = 0.2f;
            intelligence_ = 1;
            stealth_ = 1;
            dext_ = 1;
            SetSkills();
        }

        private void SetSkills()
        {
            skillTreeOneName_ = "Offensive";
            skillTreeTwoName_ = "Defensive";
            skillTreeThreeName_ = "Evasion";
            skillTreeFourName_ = "Movement";
        }
    }


    public class AssassinClass : PlayerClass
    {
        public AssassinClass()
        {
            name_ = "Assassin";
            strength_ = 1;
            defence_ = 0.1f;
            intelligence_ = 2;
            stealth_ = 3;
            dext_ = 3;
            SetSkills();
        }

        private void SetSkills()
        {
            skillTreeOneName_ = "Offensive";
            skillTreeTwoName_ = "Stealth";
            skillTreeThreeName_ = "Potions";
            skillTreeFourName_ = "Magic";
        }
    }


    public class RangerClass : PlayerClass
    {
        public RangerClass()
        {
            name_ = "Ranger";
            strength_ = 2;
            defence_ = 0.3f;
            intelligence_ = 1;
            stealth_ = 2;
            dext_ = 2;
            SetSkills();
        }

        private void SetSkills()
        {
           skillTreeOneName_ = "Ranged";
           skillTreeTwoName_ = "Mount";
           skillTreeThreeName_ = "Utility";
           skillTreeFourName_ = "Elemental";
        }
    }
}