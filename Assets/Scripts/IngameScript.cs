using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

public class IngameScript : MonoBehaviour
{
    struct PlayerCharacter
    {
        public int characterId;
        public char type;
        public int hp;
        public int skill1;
        public int skill2;
    }

    struct EnemyCharacter
    {
        public int characterId;
        public char type;
        public int hp;
        public int skill;
    }

    void StageInfo(int stageNum)
    {
        Dictionary<string, List<string>> stageData = new Dictionary<string, List<string>>()
        {
            { "1", new List<string> { "FireDog", "FireDog", "FireDog", "FireDog", "FireDog", "FireDog", "FireDog" } },
            { "2", new List<string> { "Detail1", "Detail2" } },
            { "3", new List<string> { "Detail1", "Detail2" } },
            { "4", new List<string> { "Detail1", "Detail2" } },
            { "5", new List<string> { "Detail1", "Detail2" } },
            { "6", new List<string> { "Detail1", "Detail2" } },
            { "7", new List<string> { "Detail1", "Detail2" } },
            { "8", new List<string> { "Detail1", "Detail2" } }

        };

    }

    void UseSkill(int skill1, int skill2)
    {

    }

    void ChangeCharacter(int currentcharacterId, int leftcharacterId, int rightcharacterId)
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button useSkillButton;
    public Button changeCharacterButton;
    public Button character1Button;
    public Button character2Button;
    public Button character3Button;
    public Button skill1Button;
    public Button skill2Button;
    public Button useItemButton;
    public Button item1Button;
    public Button item2Button;
    public Button item3Button;
    public Button item4Button;
    public Button attackButton;
    public Canvas skillUi;

    public Button testbtn;
    void Start()
    {
        PlayerCharacter player1 = new PlayerCharacter();
        PlayerCharacter player2 = new PlayerCharacter();
        PlayerCharacter player3 = new PlayerCharacter();
        EnemyCharacter enemy1 = new EnemyCharacter();
        EnemyCharacter enemy2 = new EnemyCharacter();
        EnemyCharacter enemy3 = new EnemyCharacter();
        EnemyCharacter enemy4 = new EnemyCharacter();
        EnemyCharacter enemy5 = new EnemyCharacter();
        EnemyCharacter enemy6 = new EnemyCharacter();
        EnemyCharacter enemy7 = new EnemyCharacter();

        attackButton = GameObject.Find("AttackBtn").GetComponent<Button>();
        useSkillButton = GameObject.Find("SkillBtn").GetComponent<Button>();
        // skill1Button = GameObject.Find("Skill1Btn").GetComponent<Button>();
        // skill2Button = GameObject.Find("Skill2Btn").GetComponent<Button>();
        // changeCharacterButton = GameObject.Find("RotationBtn").GetComponent<Button>();
        // character1Button = GameObject.Find("Character1").GetComponent<Button>();
        // character2Button = GameObject.Find("Character2").GetComponent<Button>();
        // character3Button = GameObject.Find("Character3").GetComponent<Button>();
        // useItemButton = GameObject.Find("ItemBtn").GetComponent<Button>();
        // item1Button = GameObject.Find("Item1").GetComponent<Button>();
        // item2Button = GameObject.Find("Item2").GetComponent<Button>();
        // item3Button = GameObject.Find("Item3").GetComponent<Button>();
        // item4Button = GameObject.Find("Item4").GetComponent<Button>();
        skillUi = GameObject.Find("SkillUI").GetComponent<Canvas>();

        testbtn = GameObject.Find("Button").GetComponent<Button>();
        testbtn.onClick.AddListener(EnableSkillUI);
        skillUi.enabled = false;
        int selectedStage = 1;
        StageInfo(selectedStage);

        useSkillButton.onClick.AddListener(EnableSkillUI);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // void PlayerCharacterData(int characterId, int hp, int skill1, int skill2)
    // {

    // }

    void EnableSkillUI()
    {
        skillUi.enabled = true;
    }
}
