using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;

    private List<GameObject> _pooledObjects = new List<GameObject>();
    [SerializeField] private int _poolCount = 5;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _parent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < _poolCount; i++)
        {
            GameObject obj = Instantiate(_prefab, _parent);
            _prefab.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        return null;
    }

    // DEBUG to refresh the pool if all objects are not available.
    public void ReturnAllObjects()
    {
        for(int i = 0; i < _pooledObjects.Count; i++)
        {
            if (_pooledObjects[i].activeInHierarchy)
            {
                _pooledObjects[i].SetActive(false);
            }
        }
    }
}
