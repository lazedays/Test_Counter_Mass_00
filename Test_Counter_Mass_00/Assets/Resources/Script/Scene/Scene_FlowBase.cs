using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_FlowBase : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabMapMovePoint;

    [SerializeField]
    protected List<Transform> listMoveMapPoint;

    [SerializeField]
    protected List<MapMovePoint> listMovePoint_Move;
    [SerializeField]
    protected List<MapMovePoint> listMovePoint_Arrive;

    [SerializeField]
    protected Player00 player;
    public Player00 Player { get { return player;  } set { player = value; } }

    private float fCurDelay = 0.0f;



    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void MovePlayerByPositionIndex(int positionIndex)
    {
        if(player != null  && listMovePoint_Arrive != null && listMovePoint_Arrive.Count > positionIndex)
        {
            player.gameObject.transform.position = listMovePoint_Arrive[positionIndex].transform.position;
            return;
        }
    }
}
