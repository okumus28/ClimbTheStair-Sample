using UnityEngine;

public class CashPopUpText : MonoBehaviour
{
    RectTransform rt;
    public Transform target;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }
    void Update()
    {
        if (rt.localScale.y > 0)
        {
            rt.localScale = Vector3.MoveTowards(rt.localScale, Vector3.zero, 1.5f * Time.deltaTime);
        }

        if (target != null)
        {
            rt.position = Camera.main.WorldToScreenPoint(target.position);
        }
    }
}
