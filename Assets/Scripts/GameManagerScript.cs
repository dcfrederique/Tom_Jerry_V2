using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour
{

		public List<GameObject> ShapesList;
		private List<string> AnswerList;
		private int score;
		public int amountOfLevels = 3;
		private int levelNumber = 1;
		float time = 1.5f;
		void Start ()
		{
				AnswerList = new List<string> ();
				ShapesList.Shuffle ();
				for (int i =0; i<3; i++) {
						Instantiate (ShapesList [i], new Vector3 (8, 3 - (i * 4), -5), Quaternion.identity);
						string prefabName = ShapesList [i].name + "Answer";
						AnswerList.Add (prefabName);
						
				}
				AnswerList.Shuffle ();
				for (int i =0; i<AnswerList.Count; i++) {
						Instantiate (Resources.LoadAssetAtPath ("Assets/Prefabs/" + AnswerList [i] + ".prefab", typeof(GameObject)),
			             new Vector3 (-5, 3 - (i * 4), -4.9f), Quaternion.identity);
				}
				levelNumber = PlayerPrefs.GetInt ("levelNumber");
				if (levelNumber == amountOfLevels) {
						PlayerPrefs.SetInt ("levelNumber", 1);
				}
		}

		void Update ()
		{

				score = PlayerPrefs.GetInt ("correctScore");
				if (score == 3) {
						time -= Time.deltaTime;
						if (time < 0) {
								if (levelNumber == amountOfLevels) {
										PlayerPrefs.SetInt ("levelNumber", 1);
										Application.LoadLevel (1);

								} else {
										levelNumber++;
										PlayerPrefs.SetInt ("levelNumber", levelNumber);
										Application.LoadLevel (0);
								}
						}
				}
		}
}
