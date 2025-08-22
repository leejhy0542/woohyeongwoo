using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class CharacterSkillPicker : MonoBehaviour
{
    [Header("UI Elements")]
    public Button[] slotButtons;
    public Button[] portraitButtons;
    public GameObject[] characterGroups;
    public GameObject[] skillGroups;

    private GameObject[] slotCharacters = new GameObject[3];
    private GameObject[] slotSkills = new GameObject[3];
    private List<Button>[] slotSkillButtons = new List<Button>[3];

    private int currentSlot = 0;
    private Color selectedColor = Color.yellow;
    private Color defaultColor = Color.white;

    void Start()
    {
        HideAll();

        for (int i = 0; i < 3; i++)
            slotSkillButtons[i] = new List<Button>();

        for (int i = 0; i < slotButtons.Length; i++)
        {
            int index = i;
            slotButtons[i].onClick.AddListener(() => SwitchSlot(index));
        }

        for (int i = 0; i < portraitButtons.Length; i++)
        {
            int index = i;
            portraitButtons[i].onClick.AddListener(() => SelectCharacter(index));
        }

        for (int i = 0; i < skillGroups.Length; i++)
        {
            int characterIndex = i;
            Button[] skillButtons = skillGroups[i].GetComponentsInChildren<Button>(true);

            foreach (var btn in skillButtons)
            {
                btn.onClick.AddListener(() => SelectSkill(characterIndex, btn));
            }
        }
    }

    void SwitchSlot(int slotIndex)
    {
        currentSlot = slotIndex;
        ShowSlotCharacter(slotIndex);
    }

    void SelectCharacter(int characterIndex)
    {
        GameObject selectedGroup = characterGroups[characterIndex];

        // 이미 다른 슬롯에서 선택된 캐릭터인지 확인
        for (int i = 0; i < slotCharacters.Length; i++)
        {
            if (i != currentSlot && slotCharacters[i] == selectedGroup)
            {
                Debug.Log("이 캐릭터는 이미 다른 슬롯에서 선택되었습니다.");
                return;
            }
        }

        // 선택 취소
        if (slotCharacters[currentSlot] == selectedGroup)
        {
            slotCharacters[currentSlot] = null;
            slotSkills[currentSlot] = null;
            slotSkillButtons[currentSlot].Clear();
            selectedGroup.SetActive(false);
            HideSkillGroup(characterIndex);
            return;
        }

        // 캐릭터 선택
        slotCharacters[currentSlot] = selectedGroup;
        slotSkills[currentSlot] = skillGroups[characterIndex];
        slotSkillButtons[currentSlot].Clear();

        ShowSlotCharacter(currentSlot);
        EnableGroup(skillGroups[characterIndex]);
    }

    void SelectSkill(int characterIndex, Button clickedButton)
    {
        if (slotCharacters[currentSlot] != characterGroups[characterIndex])
            return;

        List<Button> selectedButtons = slotSkillButtons[currentSlot];

        if (selectedButtons.Contains(clickedButton))
        {
            SetButtonBorder(clickedButton, defaultColor);
            selectedButtons.Remove(clickedButton);
            return;
        }

        if (selectedButtons.Count >= 2)
        {
            Debug.Log("최대 2개의 스킬만 선택할 수 있습니다.");
            return;
        }

        selectedButtons.Add(clickedButton);
        SetButtonBorder(clickedButton, selectedColor);
    }

    void ShowSlotCharacter(int slotIndex)
    {
        HideAll();

        GameObject characterGroup = slotCharacters[slotIndex];
        GameObject skillGroup = slotSkills[slotIndex];
        List<Button> skillButtons = slotSkillButtons[slotIndex];

        if (characterGroup != null)
            EnableGroup(characterGroup);

        if (skillGroup != null)
            EnableGroup(skillGroup);

        foreach (var btn in skillButtons)
            SetButtonBorder(btn, selectedColor);
    }

    void HideAll()
    {
        foreach (var group in characterGroups)
        {
            group.SetActive(false);
            DisableTexts(group);
        }

        foreach (var skill in skillGroups)
        {
            skill.SetActive(false);
            DisableTexts(skill);

            Button[] buttons = skill.GetComponentsInChildren<Button>(true);
            foreach (var btn in buttons)
                SetButtonBorder(btn, defaultColor);
        }
    }

    void EnableGroup(GameObject group)
    {
        group.SetActive(true);

        Image[] images = group.GetComponentsInChildren<Image>(true);
        foreach (var img in images)
            img.enabled = true;

        TMP_Text[] tmps = group.GetComponentsInChildren<TMP_Text>(true);
        foreach (var tmp in tmps)
        {
            tmp.enabled = true;
            Color c = tmp.color;
            c.a = 1f;
            tmp.color = c;
        }
    }

    void DisableTexts(GameObject group)
    {
        TMP_Text[] tmps = group.GetComponentsInChildren<TMP_Text>(true);
        foreach (var tmp in tmps)
            tmp.enabled = false;
    }

    void HideSkillGroup(int characterIndex)
    {
        if (characterIndex >= 0 && characterIndex < skillGroups.Length)
        {
            GameObject skillGroup = skillGroups[characterIndex];
            skillGroup.SetActive(false);
            DisableTexts(skillGroup);
        }
    }

    void SetButtonBorder(Button btn, Color borderColor)
    {
        Image img = btn.GetComponent<Image>();
        if (img != null)
            img.color = borderColor;
    }
}
