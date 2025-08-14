using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickedCharacterScript : MonoBehaviour
{
    public Button[] slotButtons;             // ���� ���� ��ư��
    public Button[] portraitButtons;         // ĳ���� �ʻ�ȭ ��ư��
    public GameObject[] characterGroups;     // ĳ���� UI �׷�� (�̹��� + �ؽ�Ʈ ��)

    private GameObject[] slotCharacters = new GameObject[3]; // ���Կ� ���õ� ĳ���� �׷�
    private int currentSlot = 0;             // ���� ���� ���� ����

    void Start()
    {
        HideAll(); // ��� ĳ���� �׷� �����

        // ���� ��ư Ŭ�� �̺�Ʈ ���
        for (int i = 0; i < slotButtons.Length; i++)
        {
            int index = i;
            slotButtons[i].onClick.AddListener(() => SwitchSlot(index));
        }

        // �ʻ�ȭ ��ư Ŭ�� �̺�Ʈ ���
        for (int i = 0; i < portraitButtons.Length; i++)
        {
            int index = i;
            portraitButtons[i].onClick.AddListener(() => SelectCharacter(characterGroups[index]));
        }
    }

    // ���� ��ȯ
    void SwitchSlot(int slotIndex)
    {
        currentSlot = slotIndex;
        ShowSlotCharacter(slotIndex);
    }

    // ĳ���� ����
    void SelectCharacter(GameObject selectedGroup)
    {
        // �̹� �ٸ� ���Կ� ���õ� ĳ�������� Ȯ��
        for (int i = 0; i < slotCharacters.Length; i++)
        {
            if (slotCharacters[i] == selectedGroup && i != currentSlot)
                return; // �ٸ� ���Կ� �̹� ���õ� ĳ���͸� ���� �Ұ�
        }

        // ���� ���Կ� �̹� ���õ� ĳ���͸� �ٽ� ������ ���� ���
        if (slotCharacters[currentSlot] == selectedGroup)
        {
            slotCharacters[currentSlot] = null;
            selectedGroup.SetActive(false);
            return;
        }

        // ���� ���Կ� ĳ���� ����
        slotCharacters[currentSlot] = selectedGroup;

        // ĳ���� ǥ�� ������Ʈ
        ShowSlotCharacter(currentSlot);
    }

    // ���� ������ ĳ���͸� ǥ��
    void ShowSlotCharacter(int slotIndex)
    {
        HideAll();

        if (slotCharacters[slotIndex] != null)
            EnableGroup(slotCharacters[slotIndex]);
    }

    // ��� ĳ���� �׷� �����
    void HideAll()
    {
        foreach (var group in characterGroups)
        {
            group.SetActive(false);
        }
    }

    // �׷� ������Ʈ�� ���� UI ��� Ȱ��ȭ
    void EnableGroup(GameObject group)
    {
        group.SetActive(true);

        // ���� �̹��� �ѱ�
        Image[] images = group.GetComponentsInChildren<Image>(true);
        foreach (var img in images)
        {
            img.enabled = true;
        }

        // ���� TextMeshProUGUI �ѱ�
        TMP_Text[] tmps = group.GetComponentsInChildren<TMP_Text>(true);
        foreach (var tmp in tmps)
        {
            tmp.enabled = true;

            // ���İ��� 0�� ��� ���
            Color c = tmp.color;
            c.a = 1f;
            tmp.color = c;
        }
    }
}
