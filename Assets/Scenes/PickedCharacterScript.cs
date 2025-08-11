using UnityEngine;
using UnityEngine.UI;

public class PickedCharacterScript : MonoBehaviour
{
    public Button[] slotButtons; // ���� ���� ��ư��
    public Button[] portraitButtons; // ĳ���� �ʻ�ȭ ��ư��
    public Image[] characterImages; // ĳ���� �̹�����

    private Image[] slotCharacters = new Image[3]; // ���õ� ĳ����
    private int currentSlot = 0; // ���� ���� ����

    void Start()
    {
        // ��� ĳ���� �̹��� �����
        HideAll();

        // ���� ��ư Ŭ�� �̺�Ʈ
        for (int i = 0; i < slotButtons.Length; i++)
        {
            int index = i;
            slotButtons[i].onClick.AddListener(() => SwitchSlot(index));
        }

        // ĳ���� �ʻ�ȭ ��ư Ŭ�� �̺�Ʈ
        for (int i = 0; i < portraitButtons.Length; i++)
        {
            int index = i;
            portraitButtons[i].onClick.AddListener(() => SelectCharacter(characterImages[index]));
        }
    }

    // ���� ��ȯ
    void SwitchSlot(int slotIndex)
    {
        currentSlot = slotIndex;
        ShowSlotCharacter(slotIndex);
    }

    // ĳ���� ����
    void SelectCharacter(Image selected)
    {
        // �̹� �ٸ� ���Կ� ���õ� ĳ�������� Ȯ��
        for (int i = 0; i < slotCharacters.Length; i++)
        {
            if (slotCharacters[i] == selected && i != currentSlot)
                return; // �ٸ� ���Կ� �̹� ���õ� ĳ���͸� ���� �Ұ�
        }

        // ���� ���Կ� �̹� ���õ� ĳ���͸� �ٽ� ������ ���� ���
        if (slotCharacters[currentSlot] == selected)
        {
            slotCharacters[currentSlot] = null; // ���Կ��� ����
            selected.enabled = false;           // �̹��� �����
            return;
        }

        // ���� ���Կ� ĳ���� ����
        slotCharacters[currentSlot] = selected;

        // ĳ���� ǥ�� ������Ʈ
        ShowSlotCharacter(currentSlot);
    }

    // ���� ������ ĳ���͸� ǥ��
    void ShowSlotCharacter(int slotIndex)
    {
        HideAll();

        if (slotCharacters[slotIndex] != null)
            slotCharacters[slotIndex].enabled = true;
    }

    // ��� ĳ���� �̹��� �����
    void HideAll()
    {
        foreach (var img in characterImages)
        {
            img.enabled = false;
        }
    }
}
