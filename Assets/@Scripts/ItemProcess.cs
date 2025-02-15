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
        // 코인 생성 개수 랜덤 지정
        int rnd = Random.Range(0, 4);
        for (int i = 0; i < CoinList.Count; i++)
        {
            if (rnd <= 0)
                break;
            // 코인 오브젝트풀에 비활성화 상태의 코인이 있으면
            if (!CoinList[i].activeSelf)
            {
                // 활성화해서 스폰시키고 생성 개수 감소
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
