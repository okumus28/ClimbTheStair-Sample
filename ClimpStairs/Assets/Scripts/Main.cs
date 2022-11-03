using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic;

public class Main : MonoBehaviour
{
    public Animator characterAnimator;
    public GameObject character;
    Transform camera;

    [SerializeField] float posOffset;
    [SerializeField] float rotOffset;

    public List<Stair> moveStairs;
    int i = 0;

    public float speed;

    public bool climbing;

    Vector3 newRot;
    Vector3 newPos;

    Stair currentStair;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0) && moveStairs.Count < 2)
        //{
        //    //characterAnimator.SetBool("Running",true);
        //    GetStairs();
        //    GetStairs();
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    moveStairs.RemoveAt(0);
        //}

        //if (moveStairs.Count > 0)
        //{
        //    characterAnimator.SetBool("Running", true);
        //    character.transform.position = Vector3.MoveTowards(character.transform.position, moveStairs[0].transform.GetChild(1).position + new Vector3(0, .03f, 0), speed);
        //    character.transform.eulerAngles = moveStairs[0].transform.eulerAngles;
        //    if (character.transform.position.y >= moveStairs[0].transform.GetChild(1).position.y + .025f)
        //    {
        //        moveStairs.RemoveAt(0);
        //    }
        //}
        //else
        //{
        //    characterAnimator.SetBool("Running", false);
        //}
    }

    void GetStairs()
    {
        camera.transform.position = new Vector3(0,newPos.y + 2.75f , -4);

        Stair s = StairPooling.Instance.SpawnList(newPos , newRot);

        moveStairs.Add(s);

        currentStair = s;
        
        newRot += new Vector3(0,rotOffset,0);
        newPos += new Vector3(0,posOffset,0);
    }
}
