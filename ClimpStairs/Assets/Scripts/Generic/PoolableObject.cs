using Generic;
using UnityEngine;

public abstract class PoolableObject<T> : MonoBehaviour where T : MonoBehaviour
{
    public T poolCreator;
    private void Awake()
    {
        poolCreator = FindObjectOfType<T>();
    }

    public void Destroy(float time = 0)
    {
        Invoke(nameof(Disable), time);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        //var a = GetComponent<ObjectPooling<T>>().prefab.get
        //poolCreator.GetComponent<ObjectPooling<T>>().Recycle();
    }
}
