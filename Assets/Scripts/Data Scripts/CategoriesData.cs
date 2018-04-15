using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CategoriesData {

	public string categoryName;
	public LevelData[] levelsData;

	public LevelData getCurrentLevelsData(int b) {
		return levelsData[b];
	}
	
}