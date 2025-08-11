using UnityEngine;
using UnityEngine.UI;

public class PickedCharacterScript : MonoBehaviour
{
    public Button portrait_1;
    public Image PickedDarknight;

    void Start()
    {
        // PickedDarknight 이미지 숨기기
        PickedDarknight.enabled = false;

        // 버튼 클릭 이벤트 연결
        portrait_1.onClick.AddListener(ToggleDarknight);
    }

    void ToggleDarknight()
    {
        // 현재 상태를 반대로 바꾸기
        bool isVisible = PickedDarknight.enabled;
        PickedDarknight.enabled = !isVisible;
    }
}
