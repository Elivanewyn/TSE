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

    public Sprite rollPortrait;
    public Sprite lionsPortrait;
    public Sprite btPortrait;

    public Sprite sprintPortrait;
    public Sprite springbootsPortrait;



    public GameObject throwingknife;
    public Sprite throwingknifePortrait;
    public GameObject poisondart;
    public Sprite poisondartPortrait;
    public Sprite sidePortrait;
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
    public Sprite walljumpPortrait;
    public Sprite triplePortrait;
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
    public Sprite flamechargePortrait;
    public Sprite mountsproPortrait;

    public Sprite hoodPortrait;
    public Sprite swiftPortrait;
    public Sprite soulPortrait;

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


    public static WizardClass wizard = new WizardClass();
    public static KnightClass knight = new KnightClass();
    public static AssassinClass assassin = new AssassinClass();
    public static RangerClass ranger = new RangerClass();


    void Awake()
    {
        wizard.portrait = wizardPortrait;
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
        wizard.skillTreeOne[2] = new Skill("Flamethrower", flamethrower, 0f, 0.1f, "Wizard", flamethrowerPortrait, "Shoots continuous fire ahead, small range");
        wizard.skillTreeOne[3] = new Skill("Flame Burst", flameburst, 0.4f, 4.5f, "Wizard", flameburstPortrait, "Shoot a large fireball ahead of you");
        wizard.skillTreeOne[4] = new Skill("Flame Inferno", flameinferno, 3.5f, 8f, "Wizard", flameinfernoPortrait, "Creates a tornado of fire, which moves forwards until it makes contact with a wall, will damage any enemies who makes contact with the tornado");

        wizard.skillTreeTwo[0] = wizard.basicSkills[1];
        wizard.skillTreeTwo[1] = new Skill("Lightning Bolt", lightningbolt, 1.5f, 3f, "Wizard", lightningboltPortrait, "Shoot a medium sized lightning bolt in a spot ahead of you");
        wizard.skillTreeTwo[2] = new Skill("Electric Cage", electriccage, 9f, 10f, "Wizard", electriccagePortrait, "Traps target in a cage, which paralyses target for a period of time");
        wizard.skillTreeTwo[3] = new Skill("Plasma Charge", plasmacharge, 5f, 8f, "Wizard", plasmachargePortrait, "Shoots a large sized lightning bolt in a spot ahead of you");
        wizard.skillTreeTwo[4] = new Skill("Lightning Pillar", lightningpillar, 18f, 14f, "Wizard", lightningpillarPortrait, "Sets up a pillar, which will attacks the enemy who is closest");

        wizard.skillTreeThree[0] = wizard.basicSkills[2];
        wizard.skillTreeThree[1] = new Skill("Ice Prison", iceprison, 12f, 10f, "Wizard", iceprisonPortrait, "Traps enemies in a cage, which will prevent movement and increases the damage taken for a period of time");
        wizard.skillTreeThree[2] = new Skill("Freezing Breath", freezingbreath, 0f, 0.1f, "Wizard", freezingbreathPortrait, "Attacks forwards, damaging enemies in range and decreases enemies speed");
        wizard.skillTreeThree[3] = new Skill("Ice Crash", icecrash, 0.5f, 5.5f, "Wizard", icecrashPortrait, "Shoot an icicle in front of you");
        wizard.skillTreeThree[4] = new Skill("Freezing Land", freezingland, 10f, 10f, "Wizard", freezinglandPortrait, "Attacks forwards, damaging enemies in range, higher damage and range than 'Freezing Breath'");

        wizard.skillTreeFour[0] = wizard.basicSkills[3];
        wizard.skillTreeFour[1] = new Skill("Speed Boost", 13f, 8.5f, "Wizard", speedboostPortrait, "Speeds you up for a short period of time");
        wizard.skillTreeFour[2] = new Skill("Evasion Amplification", 35f, 9f, "Wizard", evasionPortrait, "Have a chance to evade attacks for a medium amount of time");
        wizard.skillTreeFour[3] = new Skill("Defence Boost", 13f, 9f, "Wizard", defenceboostPortrait, "Increase your defence for a short period of time");
        wizard.skillTreeFour[4] = new Skill("Health Renewal", 15f, 16f, "Wizard", healthrenewalPortrait, "Recover a medium amount of health");



        knight.portrait = knightPortrait;
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
        knight.skillTreeTwo[3] = new Skill("");
        knight.skillTreeTwo[4] = new Skill("");

        knight.skillTreeThree[0] = knight.basicSkills[2];
        knight.skillTreeThree[1] = new Skill("Lion's Roar", 20f, 8f, "Knight", lionsPortrait, "Have a reasonable chance to evade attack for a short amount of time");
        knight.skillTreeThree[2] = new Skill("Blessed Touch", 10f, 10f, "Knight", btPortrait, "Restore a small amount of health over time");
        knight.skillTreeThree[3] = new Skill("");
        knight.skillTreeThree[4] = new Skill("");

        knight.skillTreeFour[0] = knight.basicSkills[3];
        knight.skillTreeFour[1] = new Skill("Spring Boots", 20f, 8f, "Knight", springbootsPortrait, "Increase your jump height for a period of time");
        knight.skillTreeFour[2] = new Skill("");
        knight.skillTreeFour[3] = new Skill("");
        knight.skillTreeFour[4] = new Skill("");



        assassin.portrait = assassinPortrait;
        assassin.basicSkills[0] = new Skill("Throwing Knife", throwingknife, 0.3f, 0.5f, "Assassin", throwingknifePortrait, "Throw knives in a given direction");
        assassin.basicSkills[1] = new Skill("Smoke Bomb", smokebomb, 8f, 3f, "Assassin", smokebombPortrait, "Blind enemies in an area");
        assassin.basicSkills[2] = new Skill("Slash");
        assassin.basicSkills[3] = new Skill("Counter");
        foreach (Skill i in assassin.basicSkills)
        {
            i.isActive = true;
        }

        assassin.skillTreeOne[0] = assassin.basicSkills[0];
        assassin.skillTreeOne[1] = new Skill("Poison Dart", poisondart, 4f, 2.5f, "Assassin", poisondartPortrait, "Fire a dart which inflicts the target with poison, which inflicts damage over time, but will leave the target at 1 hp");
        assassin.skillTreeOne[2] = new Skill("Slide");
        assassin.skillTreeOne[3] = new Skill("Taunt");
        assassin.skillTreeOne[4] = new Skill("Assassinate");

        assassin.skillTreeTwo[0] = assassin.basicSkills[1];
        assassin.skillTreeTwo[1] = new Skill("Invisibility", 20f, 9.5f, "Assassin", invisPortrait, "Go invisible for a period of time. Enemies won't attack, but neither can you");
        assassin.skillTreeTwo[2] = new Skill("Critical Strike");
        assassin.skillTreeTwo[3] = new Skill("Shadow Sneak");
        assassin.skillTreeTwo[4] = new Skill("Super Stealth");

        assassin.skillTreeThree[0] = assassin.basicSkills[2];
        assassin.skillTreeThree[1] = new Skill("Weakness", weakness, 10f, 7f, "Assassin", weaknessPortrait, "Throw a potion of weakness at the enemy, which increases the damage the enemy will recieve");
        assassin.skillTreeThree[2] = new Skill("Poison", poison, 10f, 6.5f, "Assassin", poisonPortrait, "Throws a potion of poison at the enemy, which will inflict damage over time, but will leave the target at 1 hp");
        assassin.skillTreeThree[3] = new Skill("Slowness", slowness, 10f, 7.5f, "Assassin", slownessPortrait, "Throw a potion of slowness at the enemy, slowing them down");
        assassin.skillTreeThree[4] = new Skill("Paralysis", paralysis, 15f, 10f, "Assassin", paralysisPortrait, "Throw a potion of paralysis at the enemy, paralyzing them for a short time");

        assassin.skillTreeFour[0] = assassin.basicSkills[3];
        assassin.skillTreeFour[1] = new Skill("Double Jump", 2f, 8f, "Assassin", doublePortrait, "Gain the ability to double jump when activated");
        assassin.skillTreeFour[2] = new Skill("Wall Jump", 2f, 8f, "Assassin", walljumpPortrait, "Gain the ability to wall jump when activated");
        assassin.skillTreeFour[3] = new Skill("Triple Jump", 2f, 10f, "Assassin", triplePortrait, "Gain the ability to triple jump when activated");
        assassin.skillTreeFour[4] = new Skill("Shadow Clone");



        ranger.portrait = knightPortrait;
        ranger.basicSkills[0] = new Skill("Arrow Flurry", arrowflurry, 2.5f, 5f, "Ranger", arrowflurryPortrait, "Shoot three arrows in the direction you're facing");
        ranger.basicSkills[1] = new Skill("Saddle Up", 2f, 8f, "Ranger", saddleupPortrait, "Mount your horse to move faster");
        ranger.basicSkills[2] = new Skill("Hood", 2f, 8f, "Ranger", hoodPortrait, "Increase your stealth, decrease your defence");
        ranger.basicSkills[3] = new Skill("Fire Arrow", firearrow, 3f, 3f, "Ranger", firearrowPortrait, "Shoot a fire arrow in the direction you're facing");
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
        ranger.skillTreeTwo[2] = new Skill("");
        ranger.skillTreeTwo[3] = new Skill("Flame Charge", 8f, 6f, "Ranger", flamechargePortrait, "Make your horse charge forward a longer distance, becoming invincible while doing so");
        ranger.skillTreeTwo[4] = new Skill("Mount's Protection", 20f, 10f, "Ranger", mountsproPortrait, "For a period of time your mount will protect you from any damage");

        ranger.skillTreeThree[0] = ranger.basicSkills[2];
        ranger.skillTreeThree[1] = new Skill("Swift Bird", 20f, 7f, "Ranger", swiftPortrait, "Increase your movement speed for a short time");
        ranger.skillTreeThree[2] = new Skill("Ranger's Soul", 15f, 7.5f, "Ranger", soulPortrait, "Projectile speed increased by 50% for a small period of time");
        ranger.skillTreeThree[3] = new Skill("");
        ranger.skillTreeThree[4] = new Skill("");

        ranger.skillTreeFour[0] = ranger.basicSkills[3];
        ranger.skillTreeFour[1] = new Skill("Ice Arrow", icearrow, 3f, 3.5f, "Ranger", icearrowPortrait, "Shoot an ice arrow in the direction you're facing");
        ranger.skillTreeFour[2] = new Skill("Thunder Arrow", thunderarrow, 4f, 5f, "Ranger", thunderarrowPortrait, "Shoot a thunder arrow in the direction you're facing");
        ranger.skillTreeFour[3] = new Skill("Shadow Arrow", shadowarrow, 3f, 6f, "Ranger", shadowarrowPortrait, "Shoot a shadow arrow in the direction you're facing");
        ranger.skillTreeFour[4] = new Skill("Light Arrow", lightarrow, 20f, 15f, "Ranger", lightarrowPortrait, "Shoot a light arrow in the direction you're facing. Kills most enemies instantly");
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
                    PlayerCombat player = playerObject.GetComponent<PlayerCombat>();
                    player.StartCoroutine(player.WizardFlamethrower());
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


                if (name_ == "Frost Wave")
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

                        if (enemy.tag == "skeletonfs")
                        {
                            enemy.GetComponent<SkeletonFS>().TakeDamage(200);
                        }
                        if (enemy.tag == "skeletonmage")
                        {
                            //enemy.GetComponent<SkeletonMage>().TakeDamge(300);
                        }
                        if (enemy.tag == "skeletontank")
                        {
                            //enemy.GetComponent<SkeletonTank>().TakeDamage(300);
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
                    if (direction == Vector2.left)
                    {
                        off = new Vector2(0, -1.3f);
                    }
                    GameObject Spark = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);

                    attack projectile = Spark.GetComponent<attack>();
                    projectile.damage = 1;
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
            }

            else if (skillClass_ == "Assassin")
            {
                if (name_ == "Throwing Knife")
                {
                    GameObject ThrowingKnife = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = ThrowingKnife.GetComponent<attack>();
                    projectile.damage = 0.5f;
                    projectile.life = 1f;
                    projectile.speed = 1000;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Poison Dart")
                {
                    GameObject PDart = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = PDart.GetComponent<attack>();
                    projectile.damage = 0f;
                    projectile.life = 1f;
                    projectile.speed = 1500;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Slide")
                {
                    //will wait until level is populated
                }
                else if (name_ == "Taunt")
                {
                    //will wait until level is populated
                }
                else if (name_ == "Assassinate")
                {
                    //will wait until level is populated
                }



                if (name_ == "Smoke Bomb")
                {
                    if ((direction == Vector2.up) || (direction == Vector2.down)) { direction = Vector2.right; }

                    Vector2 off = new Vector2(8, 2.5f);
                    if (direction == Vector2.left)
                    {
                        off = new Vector2(-8, 2.5f);
                    }

                    GameObject SmokeBomb = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
                    attack bomb = SmokeBomb.GetComponent<attack>();
                    bomb.damage = 0;
                    bomb.life = 6.0f;
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
                    //will change damage when enemy/player interactions been done
                    return;
                }
                else if (name_ == "Shadow Sneak")
                {
                    //will wait until level is populated
                }
                else if (name_ == "Super Stealth")
                {
                    //will wait for stealth stat to be done
                }
                


                if (name_ == "Slash")
                {
                    //will wait until populated
                }
                else if (name_ == "Weakness")
                {
                    GameObject WPotion = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = WPotion.GetComponent<attack>();
                    projectile.damage = 0f;
                    projectile.life = 1000f;
                    projectile.speed = 1200;
                    projectile.Throw(direction);
                    return;
                }
                else if (name_ == "Poison")
                {
                    GameObject PPotion = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = PPotion.GetComponent<attack>();
                    projectile.damage = 0f;
                    projectile.life = 1000f;
                    projectile.speed = 1200;
                    projectile.Throw(direction);
                    return;
                }
                else if (name_ == "Slowness")
                {
                    GameObject SPotion = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = SPotion.GetComponent<attack>();
                    projectile.damage = 0f;
                    projectile.life = 1000f;
                    projectile.speed = 500;
                    projectile.Throw(direction);
                    return;
                }
                else if (name_ == "Paralysis")
                {
                    GameObject PLPotion = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = PLPotion.GetComponent<attack>();
                    projectile.damage = 0f;
                    projectile.life = 1000f;
                    projectile.speed = 600;
                    projectile.Throw(direction);
                    return;
                }


                if (name_ == "Counter")
                {
                    //will wait until populated
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
                else if (name_ == "Wall Jump")
                {
                    PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
                    if(player.checkGroundRadius == 0.5f)
                    {
                        player.checkGroundRadius = 1;           //activate wall jump skill
                    }
                    else { player.checkGroundRadius = 0.5f; }   //deactivate wall jump skill
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
                    //will wait for the level to be populated
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
                    GameObject Spear = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = Spear.GetComponent<attack>();
                    projectile.damage = 3f;
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
                    GameObject Bouncy = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = Bouncy.GetComponent<attack>();
                    projectile.damage = 3f;
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
                        //increase stealth
                    }
                    else
                    {
                        player.defence = 0.3f;
                        //decrease stealth back
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


                if(name_ == "Fire Arrow")
                {
                    GameObject FArrow = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = FArrow.GetComponent<attack>();
                    projectile.damage = 0.5f;
                    projectile.life = 2f;
                    projectile.speed = 850;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Ice Arrow")
                {
                    GameObject IArrow = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = IArrow.GetComponent<attack>();
                    projectile.damage = 0.5f;
                    projectile.life = 2f;
                    projectile.speed = 850;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Thunder Arrow")
                {
                    GameObject TArrow = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = TArrow.GetComponent<attack>();
                    projectile.damage = 0.5f;
                    projectile.life = 5f;
                    projectile.speed = 850;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Shadow Arrow")
                {
                    GameObject SArrow = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = SArrow.GetComponent<attack>();
                    projectile.damage = 0.5f;
                    projectile.life = 5f;
                    projectile.speed = 850;
                    projectile.Launch(direction);
                    return;
                }
                else if (name_ == "Light Arrow")
                {
                    GameObject LArrow = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);

                    attack projectile = LArrow.GetComponent<attack>();
                    projectile.damage = 10f;
                    projectile.life = 3f;
                    projectile.speed = 850;
                    projectile.Launch(direction);
                    return;
                }
            }
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

        protected WeaponType weaponType_;
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
            weaponType_ = new WeaponType("default");
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
            defence_ = 0.2f;
            intelligence_ = 1;
            stealth_ = 1;
            dext_ = 1;
            SetSkills();
            weaponType_ = new WeaponType("Sword");
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
            weaponType_ = new WeaponType("Knife");
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
            weaponType_ = new WeaponType("BowMount");
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