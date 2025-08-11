using UnityEngine;
using UnityEngine.UI;

public class PickedCharacterScript : MonoBehaviour
{
    public Button[] slotButtons; // 슬롯 선택 버튼들
    public Button[] portraitButtons; // 캐릭터 초상화 버튼들
    public Image[] characterImages; // 캐릭터 이미지들

    private Image[] slotCharacters = new Image[3]; // 선택된 캐릭터
    private int currentSlot = 0; // 선택 중인 슬롯

    void Start()
    {
        // 모든 캐릭터 이미지 숨기기
        HideAll();

        // 슬롯 버튼 클릭 이벤트
        for (int i = 0; i < slotButtons.Length; i++)
        {
            int index = i;
            slotButtons[i].onClick.AddListener(() => SwitchSlot(index));
        }

        // 캐릭터 초상화 버튼 클릭 이벤트
        for (int i = 0; i < portraitButtons.Length; i++)
        {
            int index = i;
            portraitButtons[i].onClick.AddListener(() => SelectCharacter(characterImages[index]));
        }
    }

    // 슬롯 전환
    void SwitchSlot(int slotIndex)
    {
        currentSlot = slotIndex;
        ShowSlotCharacter(slotIndex);
    }

    // 캐릭터 선택
    void SelectCharacter(Image selected)
    {
        // 이미 다른 슬롯에 선택된 캐릭터인지 확인
        for (int i = 0; i < slotCharacters.Length; i++)
        {
            if (slotCharacters[i] == selected && i != currentSlot)
                return; // 다른 슬롯에 이미 선택된 캐릭터면 선택 불가
        }

        // 현재 슬롯에 이미 선택된 캐릭터를 다시 누르면 선택 취소
        if (slotCharacters[currentSlot] == selected)
        {
            slotCharacters[currentSlot] = null; // 슬롯에서 제거
            selected.enabled = false;           // 이미지 숨기기
            return;
        }

        // 현재 슬롯에 캐릭터 저장
        slotCharacters[currentSlot] = selected;

        // 캐릭터 표시 업데이트
        ShowSlotCharacter(currentSlot);
    }

    // 현재 슬롯의 캐릭터만 표시
    void ShowSlotCharacter(int slotIndex)
    {
        HideAll();

        if (slotCharacters[slotIndex] != null)
            slotCharacters[slotIndex].enabled = true;
    }

    // 모든 캐릭터 이미지 숨기기
    void HideAll()
    {
        foreach (var img in characterImages)
        {
            img.enabled = false;
        }
    }
}
