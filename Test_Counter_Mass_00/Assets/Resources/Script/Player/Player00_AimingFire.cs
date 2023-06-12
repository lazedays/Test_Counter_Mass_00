using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player00 : MonoBehaviour
{
    //반동관련....
    private bool isFireingRecoil = false;
    public bool IsFireingRecoil { get { return isFireingRecoil; } set { isFireingRecoil = value; } }

    private float fCurDelay = 0.0f;
    private Ray rayCenterAim;
    private Vector2 vScreenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

    //테이블 이전 임시
    private float temp_fireRate = 0.4f;
    private float temp_damage = 1.0f;
    private float temp_spread = 0.2f;
    private float temp_recoil_X = 0.0f;
    private float temp_recoil_Y = 3.0f;
    private float temp_bulletSpeed = 10.0f;
    private float temp_range = 50.0f;

    private float temp_aimForntDir = 200.0f;

    private void OnDisable()
    {
        StopAllCoroutines();
        fCurDelay = 0.0f;
    }


    private void InputMouseFire()
    {
        if (Input.GetMouseButton(0))
        {
            if(fCurDelay <= 0)
            {
                //재장전 자동 만들기
                //fCurDelay = temp_fireRate;
                Fire();
            }
        }
    }

    private void Fire()
    {
        fCurDelay = temp_fireRate;
        StartCoroutine(CoResetFireRate());
        //발사 방향.... (화면 중앙과 총구).
        vScreenCenter.x = Screen.width / 2;
        vScreenCenter.y = Screen.height / 2;
       
        if (camera_fps != null)
        {
            rayCenterAim = camera_fps.FpsCamera.ScreenPointToRay(vScreenCenter);
            Debug.DrawRay(camera_fps.TsmTempMuzzle.position, rayCenterAim.direction, Color.red);
            Vector3 fireDir = (rayCenterAim.direction * 100) - camera_fps.TsmTempMuzzle.position;

            Bullet00 bullet = ObjectPoolManager.Instance.PullBulletObj(camera_fps.TsmTempMuzzle.position, Quaternion.LookRotation(camera_fps.TsmTempMuzzle.forward));
            bullet.SetAndFire(Enums_.Bullet_Owner.OWNER_PLAYER, fireDir, camera_fps.TsmTempMuzzle.position, temp_spread, temp_range, temp_damage);
        }
        else
        {
            Debug.Log("조준에 필요한 카메라 없음");
        }

        //카메라 반동 별도 
        if (camera_fps != null)
            camera_fps.PlayCameraRecoil(temp_recoil_X, temp_recoil_Y);
        
    }

    
    private IEnumerator CoResetFireRate()
    {
        while (fCurDelay > 0.0f)
        {
            fCurDelay -= Time.deltaTime;
            yield return null;
        }

        if (fCurDelay <= 0.0f)
        {
            yield break;
        }

    }
}
