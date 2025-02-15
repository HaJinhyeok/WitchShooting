using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class ItemProcess : MonoBehaviour
{
    public static UnityAction<Vector3> SpawnItemDel;
    public GameObject Coin;
    public GameObject Kit;
    public List<GameObject> CoinList;
    public List<GameObject> KitList;

    GameObject _itemPool;

    void Start()
    {
        _itemPool = new GameObject("ItemPool");
        SpawnItemDel = SpawnItem;
    }

    void SpawnItem(Vector3 spawnPos)
    {
        MakeCoin(spawnPos);
        MakeKit(spawnPos);
    }

    void MakeCoin(Vector3 spawnPos)
    {
        // ���� ���� ���� ���� ����
        int rnd = Random.Range(0, 4);
        for (int i = 0; i < CoinList.Count; i++)
        {
            if (rnd <= 0)
                break;
            // ���� ������ƮǮ�� ��Ȱ��ȭ ������ ������ ������
            if (!CoinList[i].activeSelf)
            {
                // Ȱ��ȭ�ؼ� ������Ű�� ���� ���� ����
                CoinList[i].SetActive(true);
                CoinList[i].transform.position = spawnPos;
                rnd--;
            }
        }
        for (int i = 0; i < rnd; i++)
        {
            GameObject coin = Instantiate(Coin, spawnPos, Quaternion.identity);
            coin.transform.parent = _itemPool.transform;
            CoinList.Add(coin);
        }
    }

    void MakeKit(Vector3 spawnPos)
    {
        int rnd = Random.Range(0, 2);
        if (rnd == 1)
        {
            for (int i = 0; i < KitList.Count; i++)
            {
                if (!KitList[i].activeSelf)
                {
                    KitList[i].SetActive(true);
                    KitList[i].transform.position = spawnPos;
                    return;
                }
            }
            GameObject healthKit = Instantiate(Kit, spawnPos, Quaternion.identity);
            healthKit.transform.parent = _itemPool.transform;
            KitList.Add(healthKit);
        }
        
    }
}
