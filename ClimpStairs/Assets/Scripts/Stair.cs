using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    private void Update()
    {
        if (transform.localScale != Vector3.one)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, .15f);
        }
    }
}
