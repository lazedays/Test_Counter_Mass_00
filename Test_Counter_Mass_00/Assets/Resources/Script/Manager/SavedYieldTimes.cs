using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ڷ�ƾ Yieldinstruction�� ���� �����ϴ� ��� �̸� ������ ���� ���
/// </summary>
public static class SavedYieldTimes
{
    private static Dictionary<float, WaitForSecondsRealtime> savedWaitForSecondsRealtime = new Dictionary<float, WaitForSecondsRealtime>();
    private static Dictionary<float, WaitForSeconds> savedWaitForSeconds = new Dictionary<float, WaitForSeconds>();

    public static WaitForSecondsRealtime WaitForSecondsRealtime_ = new WaitForSecondsRealtime(0.02f);
    public static WaitForEndOfFrame WaitForEndOfFrame_ = new WaitForEndOfFrame();
    public static WaitForFixedUpdate WaitForFixedUpdate_ = new WaitForFixedUpdate();

    public static WaitForSecondsRealtime WaitForSecondsRealtime(float second)
    {
        if (savedWaitForSecondsRealtime.ContainsKey(second))
            return savedWaitForSecondsRealtime[second];

        WaitForSecondsRealtime newWaitForSecondsRealtime = new WaitForSecondsRealtime(second);
        savedWaitForSecondsRealtime.Add(second, newWaitForSecondsRealtime);
        return newWaitForSecondsRealtime;
    }

    public static WaitForSeconds WaitForSeconds(float second)
    {
        if(savedWaitForSeconds.ContainsKey(second))
            return savedWaitForSeconds[second];

        WaitForSeconds newWaitForSeconds = new WaitForSeconds(second);
        savedWaitForSeconds.Add(second, newWaitForSeconds);
        return newWaitForSeconds;
    }

}
