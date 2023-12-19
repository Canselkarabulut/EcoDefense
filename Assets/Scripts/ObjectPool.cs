using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance; 
    public List<GameObject> objectPrefabs; 
    public int poolSize = 10; 
    private List<List<GameObject>> objectPool; 
    public Transform parentSpawnObject;
    void Awake()
    {
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
    void InitializeObjectPool()
    {
        if (objectPrefabs == null)
        {
            return;
        }
        objectPool = new List<List<GameObject>>();
        
        foreach (GameObject prefab in objectPrefabs)
        {
            if (prefab == null)
            {
                continue;
            }
            List<GameObject> prefabPool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                obj.transform.SetParent(parentSpawnObject);
                obj.SetActive(false);
                prefabPool.Add(obj);
            }
            objectPool.Add(prefabPool);
        }
    }
    public GameObject GetObjectFromPool(int prefabIndex)
    {
        foreach (GameObject obj in objectPool[prefabIndex])
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        GameObject newObj = Instantiate(objectPrefabs[prefabIndex], Vector3.zero, Quaternion.identity);
        objectPool[prefabIndex].Add(newObj);
        newObj.SetActive(true);
        return newObj;
    }
    public void ReturnObjectToPool(GameObject obj)
    {
        obj.transform.SetParent(parentSpawnObject);
        obj.SetActive(false);
        obj.transform.position = Vector3.zero;  // Reset position
        obj.transform.rotation = Quaternion.identity;  // Reset rotation
    }
}