using System.Collections.Generic;
using UnityEngine;

public class CashPopUpTextPooling : MonoSingleton<CashPopUpTextPooling>
{
    public GameObject prefab;
    public int startNum;
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

    private void Allocate(int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject go = Instantiate(prefab);
            go.name = prefab.name;
            go.transform.SetParent(this.transform);
            var cpt = go.GetComponent<CashPopUpText>();
            listPool.Add(cpt);
            //go.gameObject.SetActive(false);
        }
        Debug.Log("Created CPT Pool");
    }
}
