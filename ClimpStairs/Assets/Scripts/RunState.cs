using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunState : State
{
    public IdleState idleState;

    public float speed;
    [SerializeField] float posOffset;
    [SerializeField] float rotOffset;

    private Animator characterAnimator;

    [SerializeField]private List<Stair> moveStairs;
    [SerializeField]private List<CashPopUpText> cptList;

    private Transform character;
    private Transform _camera;
    [SerializeField] Transform disatancePanel;

    Vector3 newRot;
    Vector3 newPos;

    private void Awake()
    {
        _camera = Camera.main.transform;
        character = GameObject.FindObjectOfType<StateMachine>().transform;
        characterAnimator = character.GetComponent<Animator>();

        //canvas = GameObject.FindGameObjectWithTag("canvas").transform;
    }
    public override State RunCurrentState()
    {
        if (Input.GetMouseButton(0) && moveStairs.Count < 2 && cptList.Count < 2)
        {
            GetStairs();
            //GetStairs();
        }

        if (moveStairs.Count > 0)
        {
            MoveToNextStair();
        }
        else
        {
            return idleState;
        }

        return this;
    }

    void GetStairs()
    {
        for (int i = 0; i < 2; i++)
        {
            _camera.transform.position = new Vector3(0, newPos.y + 2.25f, -4);
            disatancePanel.position = newPos + new Vector3(0, 0.2f, 0);

            Stair s = StairPooling.Instance.SpawnList(newPos, newRot);
            CashPopUpText cpt = CashPopUpTextPooling.Instance.SpawnList();

            s.transform.localScale = new Vector3(1, 0, 1);

            cpt.GetComponent<RectTransform>().localScale = Vector3.one;
            cpt.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -350 + i * 50);

            moveStairs.Add(s);
            cptList.Add(cpt);

            newRot += new Vector3(0, rotOffset, 0);
            newPos += new Vector3(0, posOffset, 0);
        }
    }

    void MoveToNextStair()
    {
        characterAnimator.SetBool("Running", true);
        character.localPosition = Vector3.MoveTowards(character.localPosition,
            moveStairs[0].transform.GetChild(1).position + new Vector3(0, .03f, 0),
            speed / 5 * Time.deltaTime);
        character.eulerAngles = moveStairs[0].transform.eulerAngles;

        //CashPopUpText cpt = CashPopUpTextPooling.Instance.SpawnList();
        //cpt.GetComponent<RectTransform>().localScale = Vector3.one;
        //cpt.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -260);

        if (character.localPosition.y >= moveStairs[0].transform.GetChild(1).position.y + .0275f)
        {

            cptList.RemoveAt(0);
            moveStairs.RemoveAt(0);
            CharacterStats.Instance.Distance();
        }
    }
}
