using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPool : MonoBehaviour
{
    public static WolfPool instanceSingleton;

    private List<GameObject> pooledBears = new List<GameObject>();

    private int amountOfWolves = 4;

    [SerializeField]
    private GameObject bearPrefab;

    public static Vector3 defaultLoc;

    private void Awake()
    {
        if (instanceSingleton == null)
        {
            instanceSingleton = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountOfWolves; i++)
        {
            GameObject bear = Instantiate(bearPrefab);
            bear.SetActive(true);
            pooledBears.Add(bear);
            defaultLoc = bear.transform.localPosition;
        }
    }

    public GameObject getPooledBear()
    {
        for (int i = 0; i < pooledBears.Count; i++)
        {
            if (!pooledBears[i].activeInHierarchy)
            {
                return pooledBears[i];
            }
        }
        return null;
    }
}
