using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player00 : MonoBehaviour
{
    //반동관련....
    private bool isFireingRecoil = false;
    public bool IsFireingRecoil { get { return isFireingRecoil; } set { isFireingRecoil = value; } }

}
