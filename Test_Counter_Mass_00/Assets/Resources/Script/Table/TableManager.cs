using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    static public string ResourceseDataPath = "Resources/Data/";
    static public string DataPath = "Data/";
    static public string Media_Ext = ".txt";

    private static TableManager instance = null;

    public static TableManager Instance
    {
        get
        {
            //if (instance == null)
            //{
            //    instance = FindObjectOfType(typeof(TableManager)) as TableManager;
            //}
            if (instance == null)
            {
                GameObject obj = new GameObject(typeof(TableManager).ToString());
                instance = obj.AddComponent(typeof(TableManager)) as TableManager;
            }

            return instance;
        }
    }

    private Data_000_Temp_PlayerStatList m_Data_000_Temp_PlayerStat;
    public static Data_000_Temp_PlayerStatList _DATA_000_TEMP_PLAYERSTAT { get { return instance.m_Data_000_Temp_PlayerStat; } }


    private void Awake() //테이블 생성
    {
        //CreateTable<Data_000_Temp_PlayerStatList>(out m_Data_000_Temp_PlayerStat);
    }

    public void CreateTable<T>(out T table) where T : new()
    {
        table = new T();
        //LoadTable(typeof(T).FullName.Replace("List", ""), (table as BaseTableList));
        LoadTable(DataPath + typeof(T).FullName.Replace("List", ""), (table as BaseTableList));
        //LoadTable(ResourceseDataPath + typeof(T).FullName.Replace("List", ""), (table as BaseTableList));
    }
    public static void LoadTable(string filename, BaseTableList tableList)
    {
        List<string> textArray = new List<string>();

        //
        if (!File.Exists(filename + Media_Ext)) return;

        //TextAsset textAsset = (TextAsset)Resources.Load(filename, typeof(TextAsset));
        //if (null == textAsset) return;
        //using (StringReader sr = new StringReader(textAsset.text))
        //{
        //    while (sr.Peek() >= 0)
        //        textArray.Add(sr.ReadLine());
        //}

        using (StreamReader sr = new StreamReader(filename + Media_Ext))
        {
            while (sr.Peek() >= 0)
                textArray.Add(sr.ReadLine());
        }

        //추후 ㅇ에셋 번들 혹은 기타 로드 방식 사용시
        //----------------------


        for (int i = 1; i < textArray.Count; i++)
        {
            if (textArray[i].Length > 0)
            {
                if (textArray[i].Contains("\r"))
                {
                    string[] strSplit = textArray[i].Split('\r');
                    tableList.SetRow(strSplit[0].Replace("\\n", "\n"));
                }
                else
                    tableList.SetRow(textArray[i].Replace("\\n", "\n"));
            }
        }
    }

    public void LoadTableFromText(string text, BaseTableList tableList)
    {
        List<string> textArray = new List<string>();
        using (StringReader sr = new StringReader(text))
        {
            while (sr.Peek() >= 0)
                textArray.Add(sr.ReadLine());
        }
        for (int i = 1; i < textArray.Count; i++)
        {
            if (textArray[i].Length > 0)
            {
                if (textArray[i].Contains("\r"))
                {
                    string[] strSplit = textArray[i].Split('\r');
                    tableList.SetRow(strSplit[0].Replace("\\n", "\n"));
                }
                else
                    tableList.SetRow(textArray[i].Replace("\\n", "\n"));
            }
        }
    }

    public void TestLoadTable()
    {
        CreateTable<Data_000_Temp_PlayerStatList>(out m_Data_000_Temp_PlayerStat);
    }

}
