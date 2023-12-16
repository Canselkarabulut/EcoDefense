using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance; // Singleton instance

    public List<GameObject> objectPrefabs; // Farklı tipte prefab'leri içeren liste
    public int poolSize = 10; // Her bir prefab için oluşturulacak obje sayısı

    private List<List<GameObject>> objectPool; // Ana object pool listesi

    void Awake()
    {
        // Singleton kontrolü
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InitializeObjectPool();
    }

    // Object pool'ü başlatan fonksiyon
    void InitializeObjectPool()
    {
        objectPool = new List<List<GameObject>>();

        foreach (GameObject prefab in objectPrefabs)
        {
            List<GameObject> prefabPool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                obj.SetActive(false);
                prefabPool.Add(obj);
            }

            objectPool.Add(prefabPool);
        }
    }

    // Objeyi havuzdan çeken fonksiyon
    public GameObject GetObjectFromPool(int prefabIndex)
    {
        // Belirtilen prefab'ın havuzundan etkin olmayan bir obje al
        foreach (GameObject obj in objectPool[prefabIndex])
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // Havuzda uygun obje yoksa yeni bir obje oluştur ve havuza ekle
        GameObject newObj = Instantiate(objectPrefabs[prefabIndex], Vector3.zero, Quaternion.identity);
        objectPool[prefabIndex].Add(newObj);

        newObj.SetActive(true);
        return newObj;
    }

    // Objeyi havuza geri bırakan fonksiyon
    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}