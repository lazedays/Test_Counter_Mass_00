using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player00 : MonoBehaviour
{
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Set();
        SetTempTable();
    }

    // Update is called once per frame
    void Update()
    {
       
        InputControl();
        Mover();
        SyncParameters();

        UpdateFireDir();
        InputMouseFire();
    }
    

    private void Set()
    {

        SetPlayerCamera();
    }

    private void SetPlayerCamera()
    {
        //--카메라 프리펩 설정 후 생성
        //임시 카메라
        if(temp_ObjCamera != null)
        {
            temp_ObjCamera.GetComponent<Camera_FPS_00>().SetFollowPlayerTarget(this.gameObject);
        }

    }

    private void SetTempTable()
    {
        TableManager.Instance.TestLoadTable();
        Data_000_Temp_PlayerStatRow row = TableManager._DATA_000_TEMP_PLAYERSTAT.GetRow(1);
        if (row == null)
            Debug.Log("테이블 없음");
        fMaxSpeedMove = TableManager._DATA_000_TEMP_PLAYERSTAT.GetRow(1).m_fMoveSpeed;
        fMaxSpeedRun = TableManager._DATA_000_TEMP_PLAYERSTAT.GetRow(1).m_fMoveRun;

        Debug.Log(fMaxSpeedRun);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
