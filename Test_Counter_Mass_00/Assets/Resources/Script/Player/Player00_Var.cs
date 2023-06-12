using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player00 : MonoBehaviour
{
    [Space(20), SerializeField]
    private GameObject temp_ObjCamera;

    //------------------Prefab------------------
    [Space(20), SerializeField]
    private GameObject prefab_Camera;
    [SerializeField]
    private Camera_FPS_00 camera_fps;

    //------------------Control------------------
    [Space(20), SerializeField]
    private Transform tsm;

    [SerializeField]
    private CharacterController controller;
    public CharacterController Controller { get { return controller; } }

    [SerializeField]
    private Transform playerHitPosition;
    public Transform PlayerHitPosition { get { return playerHitPosition; } }

    [SerializeField]
    private Rigidbody rigbody;  //---มกวม---




    //------------------AimingFire------------------


}
