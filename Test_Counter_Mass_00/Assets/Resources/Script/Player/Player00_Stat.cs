using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player00 : MonoBehaviour
{
    public class PlayerStat_Table
    {
        public float hp;
        public float damage;
        public float moveSpeed;
        public float moveSpeedRuning;
        public float slideSpeed;
        public float jumpForce;

        //public int roundMagMax;
        //public float fireRate;
        //public float bulletSpeed;
        //public float bulletRange;

        public float fireRecoil_Camera_Y;
        public float fireRecoil_Camera_X;
    }
    public class PlayerStat_Total
    {

    }

    private PlayerStat_Table playerStatTable = new PlayerStat_Table();
    public PlayerStat_Table PlayerStatTable { get { return playerStatTable; } }

    private PlayerStat_Total playerStatTotal = new PlayerStat_Total();
    public PlayerStat_Total PlayerStatTotal { get { return playerStatTotal; } }

    public void SetPlayerStat_Table()
    {

    }

}
