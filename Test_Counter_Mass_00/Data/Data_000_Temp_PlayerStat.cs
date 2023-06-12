/*
	Version : 0.0.0
*/
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

public class Data_000_Temp_PlayerStatRow : BaseTableRow , ICloneable
{
     //테이블의 첫번째 컬럼은 무조건 UniqueIndex 여야 한다.
     public int m_UniqueIndex;
     public float m_MoveSpeed;
     public float m_MoveSpeed_Run;
     public float m_MoveSpeed_Slide;
     public float m_JumpForce;
     public float m_AccMoveSpeed;
     public float m_AddFireRecoil_X;
     public float m_AddFireRecoil_Y;
     public float m_Hp;
     public override void DoField(string line)
     {
         string[] lineArray = line.Split(',');
         int count = 0;
         //반드시 제일 첫번째
#if UNITY_EDITOR
          m_UniqueIndex = Convert.ToInt32(lineArray[count++]);
          m_MoveSpeed = Convert.ToSingle(lineArray[count++]);
          m_MoveSpeed_Run = Convert.ToSingle(lineArray[count++]);
          m_MoveSpeed_Slide = Convert.ToSingle(lineArray[count++]);
          m_JumpForce = Convert.ToSingle(lineArray[count++]);
          m_AccMoveSpeed = Convert.ToSingle(lineArray[count++]);
          m_AddFireRecoil_X = Convert.ToSingle(lineArray[count++]);
          m_AddFireRecoil_Y = Convert.ToSingle(lineArray[count++]);
          m_Hp = Convert.ToSingle(lineArray[count++]);
#else // 예외 처리 추가
          int.TryParse(lineArray[count++], out m_UniqueIndex);
          float.TryParse(lineArray[count++], out m_MoveSpeed);
          float.TryParse(lineArray[count++], out m_MoveSpeed_Run);
          float.TryParse(lineArray[count++], out m_MoveSpeed_Slide);
          float.TryParse(lineArray[count++], out m_JumpForce);
          float.TryParse(lineArray[count++], out m_AccMoveSpeed);
          float.TryParse(lineArray[count++], out m_AddFireRecoil_X);
          float.TryParse(lineArray[count++], out m_AddFireRecoil_Y);
          float.TryParse(lineArray[count++], out m_Hp);
#endif
     }
     public object Clone()
     {
           return this.MemberwiseClone();
     }
}
public class Data_000_Temp_PlayerStatList : BaseTableList
{
     public Dictionary<int,Data_000_Temp_PlayerStatRow> m_Data;
     public Data_000_Temp_PlayerStatList()
     {
         m_Data = new Dictionary<int,Data_000_Temp_PlayerStatRow>();
     }
     public override void SetRow(string line)
     {
         Data_000_Temp_PlayerStatRow row = new Data_000_Temp_PlayerStatRow();
         row.DoField(line);
         m_Data.Add(row.m_UniqueIndex,row);
     }
     public Data_000_Temp_PlayerStatRow GetRow(int index)
     {
         if(m_Data.ContainsKey(index))
         {
             return m_Data[index];
         }
         return null;
     }
     public Data_000_Temp_PlayerStatList CopyTable()
     {
         Data_000_Temp_PlayerStatList temp = new Data_000_Temp_PlayerStatList(); 
         foreach( KeyValuePair<int ,Data_000_Temp_PlayerStatRow> pair in m_Data)
         {
             Data_000_Temp_PlayerStatRow row = (Data_000_Temp_PlayerStatRow)pair.Value.Clone();
             temp.m_Data.Add(row.m_UniqueIndex,row);
         }
         return temp;
     }
}
