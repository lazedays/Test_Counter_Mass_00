using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public partial class Player00 : MonoBehaviour
{
    //float h, v;

    private Vector3 vMoveDir = new Vector3(); //이동용
    private Vector3 vJumperDir = new Vector3(); //점프용...

    private bool isRunning = false;
    public bool IsRunning { get { return isRunning; } }

    private bool isSlideing = false;
    public bool IsSlideing { get { return isSlideing; } }

    private bool isDashTrigger = false;
    public bool IsDashTrigger { get { return isDashTrigger; } }

    private float fCurrentMoveSpeed;
    public float CurrentMoveSpeed { get { return fCurrentMoveSpeed; } }

    //
    private float fAccMoveSpeed = 20.0f;
    public float AccMoveSpeed { get { return fAccMoveSpeed; } set { fAccMoveSpeed = value; } }

    private float fMaxSpeedMove = 5;
    public float MaxSpeedMove { get { return fMaxSpeedMove; } set { fMaxSpeedMove = value; } }

    private float fMaxSpeedRun = 5;
    public float MaxSpeedRun { get { return fMaxSpeedRun; } set { fMaxSpeedRun = value; } }


    private void PlayerMoveAccCalc()
    {
        if (isSlideing == false)
        {
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                fCurrentMoveSpeed = 0.0f;
            }
            else
            {
                // 가속도
                fCurrentMoveSpeed += fAccMoveSpeed * Time.deltaTime;

                // 최대속도
                if (isRunning)
                {
                    if (fCurrentMoveSpeed >= fMaxSpeedRun)
                        fCurrentMoveSpeed = fMaxSpeedRun;
                }
                else
                {
                    if (fCurrentMoveSpeed >= fMaxSpeedMove)
                        fCurrentMoveSpeed = fMaxSpeedMove;
                }
            }
        }
        else
        {

        }

    }

    private void InputControl()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = !isRunning;
        }
    }

    private void Mover()
    {
        PlayerMoveAccCalc();

       float h = isSlideing == false ? Input.GetAxis(String_.Horizontal) : 0;
       float v = isSlideing == false ? Input.GetAxis(String_.Vertical) : 0;

        if (v <= 0.1f)
            isRunning = false;

        vMoveDir = isSlideing == false ? (this.transform.forward * v) + (this.transform.right * h) : this.transform.forward;
        //vMoveDir = (this.transform.forward * v) + (this.transform.right * h);

        if (isDashTrigger)
        {
            if (Mathf.Abs(h) <= 0.2f && Mathf.Abs(v) <= 0.2f)
                controller.Move(this.transform.forward * 50.0f * Time.deltaTime);
            else
                controller.Move(vMoveDir.normalized * 50.0f * Time.deltaTime);
        }
        else
            controller.Move((vMoveDir) * (fCurrentMoveSpeed * Time.deltaTime));

    }   

}
