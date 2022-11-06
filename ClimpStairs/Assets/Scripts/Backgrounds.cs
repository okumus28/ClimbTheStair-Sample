using System.Collections.Generic;
using UnityEngine;

public class Backgrounds : MonoBehaviour
{
    public List<Transform> backgrounds;
    
    void Start()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            backgrounds.Add(transform.GetChild(i));
        }
    }


    public void BGUpdate(float distance)
    {
        if (distance >= backgrounds[1].position.y)
        {
            Transform t = backgrounds[0];
            backgrounds.RemoveAt(0);
            t.transform.position += new Vector3(0,10.6f,0);
            backgrounds.Add(t);
        }
    }

    void OnEnable()
    {
        CharacterStats.PositionY += BGUpdate;
    }
    void OnDisable()
    {
        CharacterStats.PositionY -= BGUpdate;

    }
}
