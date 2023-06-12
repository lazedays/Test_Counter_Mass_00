using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Bullet00 : MonoBehaviour
{
    [SerializeField]
    private Enums_.Bullet_Owner eBulletOwner;

    [SerializeField]
    private Rigidbody _rigidbody;

    private Vector3 vDir = new Vector3();
    private Vector3 vStartPos = new Vector3();

    private float fSpeed;
    private float fRange;
    private float fDamage;

    private Action actPlayerHitUiDisplay;

    public void PoolInit(Vector3 pos, Quaternion quat)
    {
        this.transform.position = pos;
        this.transform.rotation = quat;
    }
    public void SetAndFire(Enums_.Bullet_Owner owner, Vector3 forwordDir, Vector3 startPos, float speed, float range, float damege, Action actPlayerHitDisplay = null)
    {
        eBulletOwner = owner;
        vDir = forwordDir;
        fSpeed = speed;
        fRange = range;
        fDamage = damege;
        this.actPlayerHitUiDisplay = actPlayerHitDisplay;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        BulletMove_Rig();
    }

    private void LateUpdate()
    {
            
    }

    private void BulletMove_Rig()
    {
        this.transform.position += vDir * fSpeed * Time.fixedDeltaTime;
    }
}
