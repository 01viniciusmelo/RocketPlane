using UnityEngine;
using System.Collections;

[System.Serializable]
public class DataSave{

	public static DataSave current;
	
	public int NumberOfLevels;

	public level[] levels;

	public void setCompleted(bool isCompleted, int index)
	{
		levels [index].completed = isCompleted;
	}
}

[System.Serializable]
public class level
{
	public bool completed;
}