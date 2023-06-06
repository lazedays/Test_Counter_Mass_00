using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player00 : MonoBehaviour
{
    [Space(20), SerializeField]
    private Animator animatorUpperBody;

    private readonly int hashToMoveSpeed = Animator.StringToHash("fMoveSpeed");
    private readonly int hashToisSlideing = Animator.StringToHash("isSlideing");
    private readonly int hashToReloadTrigger = Animator.StringToHash("reloadTrigger");
    private readonly int hashToWeaponDrawTrigger = Animator.StringToHash("weaponDrawTrigger");

    private void SyncParameters()
    {
        if(animatorUpperBody != null)
        {
            animatorUpperBody.SetFloat(hashToMoveSpeed, fCurrentMoveSpeed);
            animatorUpperBody.SetBool(hashToisSlideing, isSlideing);
            //
        }
    }

}
