using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMovePoint : MonoBehaviour
{
    [SerializeField]
    private Scene_FlowBase sceneFlow;
    public Scene_FlowBase SceneFlow { get { return sceneFlow; } set { sceneFlow = value; } }

    [SerializeField]
    private Enums_.Map_Move_Point eMoveStat;
    public Enums_.Map_Move_Point MoveStat { get { return eMoveStat; } set { eMoveStat = value; } }

    [SerializeField]
    private Transform tsm;
    public Transform Tsn { get { return tsm; } }

    [SerializeField]
    private int nSelfNum;
    public int SelfNum { get { return nSelfNum; } set { nSelfNum = value; } }

    [SerializeField]
    private int nTargetNum;
    public int TargetNum { get { return nTargetNum; } set { nTargetNum = value; } }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerMoveToMapPopint(int posIndex)
    {
        if(sceneFlow != null)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(String_.Player) && eMoveStat == Enums_.Map_Move_Point.POINT_NEXT_MOVE)
        {
            if (sceneFlow != null)
            {
                sceneFlow.MovePlayerByPositionIndex(nTargetNum);
                return;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(String_.Player) && eMoveStat == Enums_.Map_Move_Point.POINT_NEXT_MOVE)
        {
            if (sceneFlow != null)
            {
                sceneFlow.MovePlayerByPositionIndex(nTargetNum);
                return;
            }
        }
    }
}
