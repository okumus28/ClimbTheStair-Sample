using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashPopUpText : MonoBehaviour
{
    RectTransform rt;
    //Transform rt;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        if (rt.localScale.y > 0)
        {
            //transform.localScale = 
            rt.localScale = Vector3.MoveTowards(rt.localScale, Vector3.zero, 1f * Time.deltaTime);
            //rt.anchoredPosition = Vector3.MoveTowards(rt.anchoredPosition, new Vector3(0, -660, 0), 125 * Time.deltaTime);
        }
    }
}
