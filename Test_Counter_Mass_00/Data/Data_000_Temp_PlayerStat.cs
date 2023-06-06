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
     public float m_fMoveSpeed;
     public float m_fMoveRun;
     public float m_fAccMoveSpeed;
     public float m_fAddFireRecoil_X;
     public float m_fAddFireRecoil_Y;
     public override void DoField(string line)
     {
         string[] lineArray = line.Split(',');
         int count = 0;
         //반드시 제일 첫번째
#if UNITY_EDITOR
          m_UniqueIndex = Convert.ToInt32(lineArray[count++]);
          m_fMoveSpeed = Convert.ToSingle(lineArray[count++]);
          m_fMoveRun = Convert.ToSingle(lineArray[count++]);
          m_fAccMoveSpeed = Convert.ToSingle(lineArray[count++]);
          m_fAddFireRecoil_X = Convert.ToSingle(lineArray[count++]);
          m_fAddFireRecoil_Y = Convert.ToSingle(lineArray[count++]);
#else // 예외 처리 추가
          int.TryParse(lineArray[count++], out m_UniqueIndex);
          float.TryParse(lineArray[count++], out m_fMoveSpeed);
          float.TryParse(lineArray[count++], out m_fMoveRun);
          float.TryParse(lineArray[count++], out m_fAccMoveSpeed);
          float.TryParse(lineArray[count++], out m_fAddFireRecoil_X);
          float.TryParse(lineArray[count++], out m_fAddFireRecoil_Y);
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
