using UnityEngine;

public class Effect : MonoBehaviour
{
    // * Animation Event
    // - 참조 0이면 뭔가 안쓰는거 같아보일 수 있으므로 주석 써주기
    void EffectEndEvent()
    {
        Destroy(gameObject);
    }
}
