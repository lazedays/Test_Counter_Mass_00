using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player00 : MonoBehaviour
{
    [Space(20), SerializeField]
    private Animator animatorUpperBody;

    private readonly int hashToMoveSpeed = Animator.StringToHash(String_.fMoveSpeed);
    private readonly int hashToisSlideing = Animator.StringToHash(String_.isSlideing);
    private readonly int hashToReloadTrigger = Animator.StringToHash(String_.reloadTrigger);
    private readonly int hashToWeaponDrawTrigger = Animator.StringToHash(String_.weaponDrawTrigger);

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
