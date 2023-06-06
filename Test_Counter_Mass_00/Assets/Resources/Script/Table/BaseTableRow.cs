using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTableRow
{

    public abstract void DoField(string line);
}

public abstract class BaseTableList
{
    public abstract void SetRow(string line);
}
