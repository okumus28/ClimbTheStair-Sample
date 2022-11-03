using System.Collections.Generic;
using UnityEngine;

public class StairPooling : MonoSingleton<StairPooling>
{
    public GameObject prefab;
    public int startNum;
    public int allocateNum;
    public Stack<Stair> poolStack = new Stack<Stair>();
    public List<Stair> listPool = new List<Stair>();
    public int currentListIndex;

    private void OnEnable()
    {
        Allocate(startNum);
    }

    public Stair SpawnList()
    {
        //if (currentListIndex >= startNum) currentListIndex = 0;
        currentListIndex = currentListIndex < startNum ? currentListIndex : 0;

        Stair stair = listPool[currentListIndex];
        stair.gameObject.SetActive(true);

        currentListIndex++;

        return stair;
    }

    public Stair SpawnList(Vector3 position, Vector3 eulerAngles)
    {

        Stair stair = SpawnList();
        stair.transform.position = position;
        stair.transform.eulerAngles = eulerAngles;

        return stair;
    }

    public Stair Spawn()
    {
        if (poolStack.Count == 0)
        {
            Allocate(allocateNum);
        }
        Stair stair = poolStack.Pop();
        stair.gameObject.SetActive(true);
        return stair;
    }
    public Stair Spawn(Vector3 position)
    {
        Stair stair = Spawn();
        stair.transform.position = position;
        return stair;
    }
    public Stair Spawn(Vector3 position, Vector3 eulerAngles)
    {
        Stair stair = Spawn();
        stair.transform.position = position;
        stair.transform.eulerAngles = eulerAngles;
        return stair;
    }

    public void Recycle(Stair stair)
    {
        poolStack.Push(stair);
    }
    private void Allocate(int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject go = Instantiate(prefab);
            go.name = prefab.name;
            go.transform.parent = this.transform;
            var stair = go.GetComponent<Stair>();
            poolStack.Push(stair);
            listPool.Add(stair);
            //stair.gameObject.SetActive(false);
        }
        Debug.Log("Created Stair Pool");
    }
}