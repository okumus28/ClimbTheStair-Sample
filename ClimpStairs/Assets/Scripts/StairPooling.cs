using System.Collections.Generic;
using UnityEngine;

public class StairPooling : MonoSingleton<StairPooling>
{
    public GameObject prefab;
    public int startNum;
    public List<Stair> listPool = new List<Stair>();
    public int currentListIndex;

    private void OnEnable()
    {
        Allocate(startNum);
    }

    public Stair SpawnList()
    {
        currentListIndex = currentListIndex < startNum ? currentListIndex : 0;

        Stair stair = listPool[currentListIndex];
        stair.gameObject.SetActive(true);

        currentListIndex++;

        return stair;
    }

    public Stair SpawnList(Vector3 position, Vector3 eulerAngles)
    {
        Stair stair = SpawnList();
        stair.gameObject.SetActive(true);
        stair.transform.position = position;
        stair.transform.eulerAngles = eulerAngles;

        return stair;
    }
    private void Allocate(int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject go = Instantiate(prefab);
            go.name = prefab.name;
            go.transform.parent = this.transform;
            var stair = go.GetComponent<Stair>();
            listPool.Add(stair);
            stair.gameObject.SetActive(false);
        }
        Debug.Log("Created Stair Pool");
    }
}