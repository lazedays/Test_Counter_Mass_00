/*
	Version : 0.0.0
*/
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

public class Data_000_Temp_Item_WeaponRow : BaseTableRow , ICloneable
{
     //테이블의 첫번째 컬럼은 무조건 UniqueIndex 여야 한다.
     public int m_UniqueIndex;
     public string m_Name;
     public int m_Shoot_Type;
     public float m_Reload_Time;
     public int m_Bullet_Type;
     public int m_Type;
     public float m_Fire_Rate;
     public float m_Spread;
     public float m_Dmg;
     public float m_FireRecoil_Camera_X;
     public float m_FireRecoil_Camera_Y;
     public override void DoField(string line)
     {
         string[] lineArray = line.Split(',');
         int count = 0;
         //반드시 제일 첫번째
#if UNITY_EDITOR
          m_UniqueIndex = Convert.ToInt32(lineArray[count++]);
          m_Name = lineArray[count++];
          m_Shoot_Type = Convert.ToInt32(lineArray[count++]);
          m_Reload_Time = Convert.ToSingle(lineArray[count++]);
          m_Bullet_Type = Convert.ToInt32(lineArray[count++]);
          m_Type = Convert.ToInt32(lineArray[count++]);
          m_Fire_Rate = Convert.ToSingle(lineArray[count++]);
          m_Spread = Convert.ToSingle(lineArray[count++]);
          m_Dmg = Convert.ToSingle(lineArray[count++]);
          m_FireRecoil_Camera_X = Convert.ToSingle(lineArray[count++]);
          m_FireRecoil_Camera_Y = Convert.ToSingle(lineArray[count++]);
#else // 예외 처리 추가
          int.TryParse(lineArray[count++], out m_UniqueIndex);
          m_Name = lineArray[count++];
          int.TryParse(lineArray[count++], out m_Shoot_Type);
          float.TryParse(lineArray[count++], out m_Reload_Time);
          int.TryParse(lineArray[count++], out m_Bullet_Type);
          int.TryParse(lineArray[count++], out m_Type);
          float.TryParse(lineArray[count++], out m_Fire_Rate);
          float.TryParse(lineArray[count++], out m_Spread);
          float.TryParse(lineArray[count++], out m_Dmg);
          float.TryParse(lineArray[count++], out m_FireRecoil_Camera_X);
          float.TryParse(lineArray[count++], out m_FireRecoil_Camera_Y);
#endif
     }
     public object Clone()
     {
           return this.MemberwiseClone();
     }
}
public class Data_000_Temp_Item_WeaponList : BaseTableList
{
     public Dictionary<int,Data_000_Temp_Item_WeaponRow> m_Data;
     public Data_000_Temp_Item_WeaponList()
     {
         m_Data = new Dictionary<int,Data_000_Temp_Item_WeaponRow>();
     }
     public override void SetRow(string line)
     {
         Data_000_Temp_Item_WeaponRow row = new Data_000_Temp_Item_WeaponRow();
         row.DoField(line);
         m_Data.Add(row.m_UniqueIndex,row);
     }
     public Data_000_Temp_Item_WeaponRow GetRow(int index)
     {
         if(m_Data.ContainsKey(index))
         {
             return m_Data[index];
         }
         return null;
     }
     public Data_000_Temp_Item_WeaponList CopyTable()
     {
         Data_000_Temp_Item_WeaponList temp = new Data_000_Temp_Item_WeaponList(); 
         foreach( KeyValuePair<int ,Data_000_Temp_Item_WeaponRow> pair in m_Data)
         {
             Data_000_Temp_Item_WeaponRow row = (Data_000_Temp_Item_WeaponRow)pair.Value.Clone();
             temp.m_Data.Add(row.m_UniqueIndex,row);
         }
         return temp;
     }
}
