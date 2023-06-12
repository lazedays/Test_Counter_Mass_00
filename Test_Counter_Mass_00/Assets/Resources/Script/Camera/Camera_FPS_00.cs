using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Camera_FPS_00 : MonoBehaviour
{
    [SerializeField]
    private Camera fpsCamera;
    public Camera FpsCamera { get { return fpsCamera; }  set { fpsCamera = value; } }

    [SerializeField]
    private Transform tsmTempMuzzle;
    public Transform TsmTempMuzzle { get { return tsmTempMuzzle; } }

    [SerializeField]
    private GameObject followPlayer;
    public GameObject FollowPlayer { get { return followPlayer; } set { followPlayer = value; } }

    [SerializeField]
    private Transform tsmFollowPlayer;
    public Transform TsmFollowPlayer { get { return tsmFollowPlayer; } set { tsmFollowPlayer = value; } }

    //플레이어
    private Player00 _player;
    private bool isReadyPlayerFollow = false;

    //회전속도
    private float fRotationSpeedX = 200.0f;
    private float fRotationSpeedY = 200.0f;

    //카메라 초기 위치
    private float fPosX = 0.0f;
    private float fPosY = 0.0f;
    private float fPosY_fire = 0.0f;

    //회전 y제한 (외부)
    private float fMinLimt_Y = -60.0f;
    private float fMaxLimt_Y = 85.0f;

    //반동 변수----- (외부)
    private float fCurFireRecoil_Y = 0;
    private float fAddFireRecoil_Y = 5.0f;

    private float fCurFireRecoil_X = 0;     //X축 미구현
    private float fAddFireRecoil_X = 5.0f;
    //private float fMaxRecoil_Y = 10.0f;
    //private float fLastPos_Y = 0.0f;

    private bool isRecoil_y = false; //카메라 반동 여부


    private void OnDisable()
    {
        StopAllCoroutines();

        fCurFireRecoil_Y = 0.0f;
        fCurFireRecoil_X = 0.0f;

        isRecoil_y = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetCamere();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (Cursor.lockState == CursorLockMode.Locked) { Cursor.lockState = CursorLockMode.None; }
            else if (Cursor.lockState != CursorLockMode.Locked) { Cursor.lockState = CursorLockMode.Locked; }
        }

        //if (Input.GetMouseButton(0)) //꾹
        //{
        //}
        //if(Input.GetMouseButtonDown(0)) //단발
        //{
        //    PlayCameraRecoil();
        //}
        //if(Input.GetMouseButtonUp(0))
        //{

        //}

        //Debug.Log(fCurRecoil_Y);
    }

    private void LateUpdate()
    {
        UpdateCamera();
    }

    //카메라 생성
    public void SetCamere()
    {
        if(fpsCamera == null)
        {
            this.gameObject.AddComponent<Camera>();
        }

        Vector3 vAngle = this.transform.eulerAngles;
        fPosX = vAngle.y;
        fPosY = vAngle.x;
    }
    public void SetFollowPlayerTarget(GameObject player)
    {
        followPlayer = player;

        if (followPlayer != null && followPlayer.GetComponent<Transform>() != null)
        {
            tsmFollowPlayer = followPlayer.GetComponent<Transform>();

            if (followPlayer.GetComponent<Player00>() != null)
                _player = followPlayer.GetComponent<Player00>();
            else
                Debug.Log("Player.cs Is Null");

            isReadyPlayerFollow = true;
        }
        
    }

    private void UpdateCamera()
    {
        if (!isReadyPlayerFollow)
            return;

        if(followPlayer != null && tsmFollowPlayer != null) 
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                fPosX += Input.GetAxis(String_.Mouse_X) * fRotationSpeedX * Time.deltaTime;
                fPosY -= (Input.GetAxis(String_.Mouse_Y)) * fRotationSpeedY * Time.deltaTime;
                fPosY_fire -= (Input.GetAxis(String_.Mouse_Y)) * fRotationSpeedY * Time.deltaTime;
            }

            fPosY = ClampAngle(fPosY, fMinLimt_Y, fMaxLimt_Y);
            float temp_y = fPosY - fCurFireRecoil_Y;
            temp_y = ClampAngle(temp_y, fMinLimt_Y, fMaxLimt_Y);

            if(isRecoil_y == false)
            {
                fPosY = temp_y;
                fCurFireRecoil_Y = 0.0f;
            }

            Quaternion _Rotation = Quaternion.Euler(temp_y, fPosX, 0);
            this.transform.rotation = _Rotation;

            float fAddPos_y = 1.25f;
            if (_player.IsSlideing)
                fAddPos_y = 0.25f;

            Vector3 vCamerPos = new Vector3();
            vCamerPos.x = tsmFollowPlayer.position.x;
            vCamerPos.y = tsmFollowPlayer.position.y + fAddPos_y;
            vCamerPos.z = tsmFollowPlayer.position.z;

            this.transform.position = vCamerPos;
            tsmFollowPlayer.forward = new Vector3(this.transform.forward.x, 0.0f, this.transform.forward.z); //플레이어 방향

        }
        else
        {

        }


    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }


    public void PlayCameraRecoil(float addfireRacoil_x, float addfireRacoil_Y) //반동 실행
    {
        isRecoil_y = true;
        fCurFireRecoil_Y += addfireRacoil_Y;
        //fCurFireRecoil_X += addfireRacoil_x;
        StartCoroutine(CoRecoil_Y());
        StartCoroutine(CoRecoilReset());
    }

    public IEnumerator CoRecoil_Y()
    {
        //fCurRecoil_Y = fMaxRecoil_Y;

        //if(fCurRecoil_Y > 0.0f)
        //{
        //    fCurRecoil_Y -= Time.deltaTime;
        //    yield return null;
        //}

        while (fCurFireRecoil_Y > 0.0f && isRecoil_y)
        {
            fCurFireRecoil_Y -= Time.deltaTime;
            yield return null;
        }

        if(fCurFireRecoil_Y <= 0.0f)
        {
            yield break;
        }

        //yield return null;
    }

    public IEnumerator CoRecoilReset() //일정시간 지나면 반동헤제
    {
        yield return SavedYieldTimes.WaitForSecondsRealtime(0.5f);
        //fCurRecoil_Y = 0.0f;
        isRecoil_y = false;
    }
}
