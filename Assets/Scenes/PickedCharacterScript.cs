using UnityEngine;
using UnityEngine.UI;

public class PickedCharacterScript : MonoBehaviour
{
    public Button portrait_1;
    public Image PickedDarknight;

    void Start()
    {
        // PickedDarknight �̹��� �����
        PickedDarknight.enabled = false;

        // ��ư Ŭ�� �̺�Ʈ ����
        portrait_1.onClick.AddListener(ToggleDarknight);
    }

    void ToggleDarknight()
    {
        // ���� ���¸� �ݴ�� �ٲٱ�
        bool isVisible = PickedDarknight.enabled;
        PickedDarknight.enabled = !isVisible;
    }
}
