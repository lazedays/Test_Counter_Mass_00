/*
	Version : 0.0.0
*/
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

public class Data_000_Temp_1st_CameraStatRow : BaseTableRow , ICloneable
{
     //테이블의 첫번째 컬럼은 무조건 UniqueIndex 여야 한다.
     public int m_UniqueIndex;
     public float m_MinLimt_Y;
     public float m_MaxLimt_Y;
     public float m_RotationSpeedX;
     public float m_RotationSpeedY;
     public override void DoField(string line)
     {
         string[] lineArray = line.Split(',');
         int count = 0;
         //반드시 제일 첫번째
#if UNITY_EDITOR
          m_UniqueIndex = Convert.ToInt32(lineArray[count++]);
          m_MinLimt_Y = Convert.ToSingle(lineArray[count++]);
          m_MaxLimt_Y = Convert.ToSingle(lineArray[count++]);
          m_RotationSpeedX = Convert.ToSingle(lineArray[count++]);
          m_RotationSpeedY = Convert.ToSingle(lineArray[count++]);
#else // 예외 처리 추가
          int.TryParse(lineArray[count++], out m_UniqueIndex);
          float.TryParse(lineArray[count++], out m_MinLimt_Y);
          float.TryParse(lineArray[count++], out m_MaxLimt_Y);
          float.TryParse(lineArray[count++], out m_RotationSpeedX);
          float.TryParse(lineArray[count++], out m_RotationSpeedY);
#endif
     }
     public object Clone()
     {
           return this.MemberwiseClone();
     }
}
public class Data_000_Temp_1st_CameraStatList : BaseTableList
{
     public Dictionary<int,Data_000_Temp_1st_CameraStatRow> m_Data;
     public Data_000_Temp_1st_CameraStatList()
     {
         m_Data = new Dictionary<int,Data_000_Temp_1st_CameraStatRow>();
     }
     public override void SetRow(string line)
     {
         Data_000_Temp_1st_CameraStatRow row = new Data_000_Temp_1st_CameraStatRow();
         row.DoField(line);
         m_Data.Add(row.m_UniqueIndex,row);
     }
     public Data_000_Temp_1st_CameraStatRow GetRow(int index)
     {
         if(m_Data.ContainsKey(index))
         {
             return m_Data[index];
         }
         return null;
     }
     public Data_000_Temp_1st_CameraStatList CopyTable()
     {
         Data_000_Temp_1st_CameraStatList temp = new Data_000_Temp_1st_CameraStatList(); 
         foreach( KeyValuePair<int ,Data_000_Temp_1st_CameraStatRow> pair in m_Data)
         {
             Data_000_Temp_1st_CameraStatRow row = (Data_000_Temp_1st_CameraStatRow)pair.Value.Clone();
             temp.m_Data.Add(row.m_UniqueIndex,row);
         }
         return temp;
     }
}
