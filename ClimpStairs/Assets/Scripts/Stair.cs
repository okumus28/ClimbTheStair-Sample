using UnityEngine;

public class Stair : MonoBehaviour
{
    private void Update()
    {
        SpawningAnim();
    }

    void SpawningAnim()
    {
        if (transform.localScale != Vector3.one)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, .15f);
        }
    }
}
