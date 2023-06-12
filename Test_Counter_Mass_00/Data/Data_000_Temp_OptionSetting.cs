/*
	Version : 0.0.0
*/
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

public class Data_000_Temp_OptionSettingRow : BaseTableRow , ICloneable
{
     //테이블의 첫번째 컬럼은 무조건 UniqueIndex 여야 한다.
     public int m_UniqueIndex;
     public float m_fMinLimt_Y;
     public float m_fMaxLimt_Y;
     public float m_fRotationSpeedX;
     public float m_fRotationSpeedY;
     public override void DoField(string line)
     {
         string[] lineArray = line.Split(',');
         int count = 0;
         //반드시 제일 첫번째
#if UNITY_EDITOR
          m_UniqueIndex = Convert.ToInt32(lineArray[count++]);
          m_fMinLimt_Y = Convert.ToSingle(lineArray[count++]);
          m_fMaxLimt_Y = Convert.ToSingle(lineArray[count++]);
          m_fRotationSpeedX = Convert.ToSingle(lineArray[count++]);
          m_fRotationSpeedY = Convert.ToSingle(lineArray[count++]);
#else // 예외 처리 추가
          int.TryParse(lineArray[count++], out m_UniqueIndex);
          float.TryParse(lineArray[count++], out m_fMinLimt_Y);
          float.TryParse(lineArray[count++], out m_fMaxLimt_Y);
          float.TryParse(lineArray[count++], out m_fRotationSpeedX);
          float.TryParse(lineArray[count++], out m_fRotationSpeedY);
#endif
     }
     public object Clone()
     {
           return this.MemberwiseClone();
     }
}
public class Data_000_Temp_OptionSettingList : BaseTableList
{
     public Dictionary<int,Data_000_Temp_OptionSettingRow> m_Data;
     public Data_000_Temp_OptionSettingList()
     {
         m_Data = new Dictionary<int,Data_000_Temp_OptionSettingRow>();
     }
     public override void SetRow(string line)
     {
         Data_000_Temp_OptionSettingRow row = new Data_000_Temp_OptionSettingRow();
         row.DoField(line);
         m_Data.Add(row.m_UniqueIndex,row);
     }
     public Data_000_Temp_OptionSettingRow GetRow(int index)
     {
         if(m_Data.ContainsKey(index))
         {
             return m_Data[index];
         }
         return null;
     }
     public Data_000_Temp_OptionSettingList CopyTable()
     {
         Data_000_Temp_OptionSettingList temp = new Data_000_Temp_OptionSettingList(); 
         foreach( KeyValuePair<int ,Data_000_Temp_OptionSettingRow> pair in m_Data)
         {
             Data_000_Temp_OptionSettingRow row = (Data_000_Temp_OptionSettingRow)pair.Value.Clone();
             temp.m_Data.Add(row.m_UniqueIndex,row);
         }
         return temp;
     }
}
