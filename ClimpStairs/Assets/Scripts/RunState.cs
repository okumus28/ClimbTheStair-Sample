using System;
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

    [SerializeField]private List<Stair> moveStairs;
    [SerializeField]private List<CashPopUpText> cptList;

    private Animator characterAnimator;
    private Transform character;
    private Transform _camera;
    [SerializeField] Transform distancePanel;

    Vector3 newRot;
    Vector3 newPos;

    private void Awake()
    {
        _camera = Camera.main.transform;
        character = GameObject.FindObjectOfType<StateMachine>().transform;
        characterAnimator = character.GetComponent<Animator>();
    }
    public override State RunCurrentState()
    {
        if (!UIController.Instance.canRun)
        {
            return idleState;
        }

        if (Input.GetMouseButton(0) && moveStairs.Count < 2 && cptList.Count < 2)
        {
            GetStairs();
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
        _camera.transform.position = new Vector3(0, newPos.y + 2.25f, -4);
        distancePanel.position = newPos + new Vector3(0, 0.2f, 0);

        SpawnCashText(SpawnStair());

        newRot += new Vector3(0, rotOffset, 0);
        newPos += new Vector3(0, posOffset, 0);
    }

    IEnumerator CPTDelay(CashPopUpText cpt)
    {
        yield return new WaitForSeconds(0.1f);
        CharacterStats.Instance.Cash += (int)CharacterStats.Instance.Income;
        cpt.GetComponent<RectTransform>().localScale = Vector3.one;
    }

    Stair SpawnStair()
    {
        Stair s = StairPooling.Instance.SpawnList(newPos, newRot);
        s.transform.localScale = new Vector3(1, 0.1f, 0.1f);
        moveStairs.Add(s);

        return s;
    }

    void SpawnCashText(Stair s)
    {
        CashPopUpText cpt = CashPopUpTextPooling.Instance.SpawnList();
        cpt.target = s.transform;
        float incomeCash = CharacterStats.Instance.Income;
        cpt.GetComponent<TextMeshProUGUI>().text = "$" + incomeCash.ToString();
        CharacterStats.Instance.Cash += incomeCash;
        StartCoroutine(CPTDelay(cpt));
        cptList.Add(cpt);
    }

    void MoveToNextStair()
    {
        speed = CharacterStats.Instance.Speed;
        characterAnimator.SetFloat("RunAmimSpeed" , speed /2);
        characterAnimator.SetBool("Running", true);

        character.localPosition = Vector3.MoveTowards(character.localPosition,
            moveStairs[0].transform.GetChild(1).position + new Vector3(0, .03f, 0),
            speed / 5 * Time.deltaTime);
        character.eulerAngles = moveStairs[0].transform.eulerAngles;

        if (character.localPosition.y >= moveStairs[0].transform.GetChild(1).position.y + .0275f)
        {
            cptList.RemoveAt(0);
            moveStairs.RemoveAt(0);

            CharacterStats.Instance.ClimbCountUpdate();
            CharacterStats.Instance.Distance();
        }
    }
}
