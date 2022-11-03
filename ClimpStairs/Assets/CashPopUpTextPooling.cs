using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashPopUpTextPooling : MonoSingleton<CashPopUpTextPooling>
{
    public GameObject prefab;
    public int startNum;
    public int allocateNum;
    public Stack<Stair> poolStack = new Stack<Stair>();
    public List<CashPopUpText> listPool = new List<CashPopUpText>();
    public int currentListIndex;

    private void OnEnable()
    {
        Allocate(startNum);
    }

    public CashPopUpText SpawnList()
    {
        currentListIndex = currentListIndex < startNum ? currentListIndex : 0;

        CashPopUpText cpt = listPool[currentListIndex];
        cpt.gameObject.SetActive(true);

        currentListIndex++;

        return cpt;
    }

    public CashPopUpText SpawnList(Vector3 position)
    {

        CashPopUpText cpt = SpawnList();
        cpt.transform.position = position;

        return cpt;
    }
    private void Allocate(int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject go = Instantiate(prefab);
            go.name = prefab.name;
            go.transform.parent = this.transform;
            var cpt = go.GetComponent<CashPopUpText>();
            listPool.Add(cpt);
            //stair.gameObject.SetActive(false);
        }
        Debug.Log("Created CPT Pool");
    }
}
