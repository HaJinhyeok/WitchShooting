using UnityEngine;

public class Effect : MonoBehaviour
{
    // * Animation Event
    // - ���� 0�̸� ���� �Ⱦ��°� ���ƺ��� �� �����Ƿ� �ּ� ���ֱ�
    void EffectEndEvent()
    {
        Destroy(gameObject);
    }
}
