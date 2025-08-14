using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickedCharacterScript : MonoBehaviour
{
    public Button[] slotButtons;             // 슬롯 선택 버튼들
    public Button[] portraitButtons;         // 캐릭터 초상화 버튼들
    public GameObject[] characterGroups;     // 캐릭터 UI 그룹들 (이미지 + 텍스트 등)

    private GameObject[] slotCharacters = new GameObject[3]; // 슬롯에 선택된 캐릭터 그룹
    private int currentSlot = 0;             // 현재 선택 중인 슬롯

    void Start()
    {
        HideAll(); // 모든 캐릭터 그룹 숨기기

        // 슬롯 버튼 클릭 이벤트 등록
        for (int i = 0; i < slotButtons.Length; i++)
        {
            int index = i;
            slotButtons[i].onClick.AddListener(() => SwitchSlot(index));
        }

        // 초상화 버튼 클릭 이벤트 등록
        for (int i = 0; i < portraitButtons.Length; i++)
        {
            int index = i;
            portraitButtons[i].onClick.AddListener(() => SelectCharacter(characterGroups[index]));
        }
    }

    // 슬롯 전환
    void SwitchSlot(int slotIndex)
    {
        currentSlot = slotIndex;
        ShowSlotCharacter(slotIndex);
    }

    // 캐릭터 선택
    void SelectCharacter(GameObject selectedGroup)
    {
        // 이미 다른 슬롯에 선택된 캐릭터인지 확인
        for (int i = 0; i < slotCharacters.Length; i++)
        {
            if (slotCharacters[i] == selectedGroup && i != currentSlot)
                return; // 다른 슬롯에 이미 선택된 캐릭터면 선택 불가
        }

        // 현재 슬롯에 이미 선택된 캐릭터를 다시 누르면 선택 취소
        if (slotCharacters[currentSlot] == selectedGroup)
        {
            slotCharacters[currentSlot] = null;
            selectedGroup.SetActive(false);
            return;
        }

        // 현재 슬롯에 캐릭터 저장
        slotCharacters[currentSlot] = selectedGroup;

        // 캐릭터 표시 업데이트
        ShowSlotCharacter(currentSlot);
    }

    // 현재 슬롯의 캐릭터만 표시
    void ShowSlotCharacter(int slotIndex)
    {
        HideAll();

        if (slotCharacters[slotIndex] != null)
            EnableGroup(slotCharacters[slotIndex]);
    }

    // 모든 캐릭터 그룹 숨기기
    void HideAll()
    {
        foreach (var group in characterGroups)
        {
            group.SetActive(false);
        }
    }

    // 그룹 오브젝트와 내부 UI 요소 활성화
    void EnableGroup(GameObject group)
    {
        group.SetActive(true);

        // 내부 이미지 켜기
        Image[] images = group.GetComponentsInChildren<Image>(true);
        foreach (var img in images)
        {
            img.enabled = true;
        }

        // 내부 TextMeshProUGUI 켜기
        TMP_Text[] tmps = group.GetComponentsInChildren<TMP_Text>(true);
        foreach (var tmp in tmps)
        {
            tmp.enabled = true;

            // 알파값이 0일 경우 대비
            Color c = tmp.color;
            c.a = 1f;
            tmp.color = c;
        }
    }
}
