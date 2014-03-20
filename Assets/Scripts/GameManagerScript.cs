using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour
{
		public List<GameObject> ShapesList;
		public List<GameObject> ShapesAnswersList;
		private List<string> AnswerList;
		private int score;
		public int amountOfLevels = 3;
		private int levelNumber = 1;
		float time = 1.5f;
		List<GameObject> TempList;
		GameObject game;
		void Start ()
		{
				game = GameObject.Find ("game");
				CreateGame ();
		}

		void Update ()
		{
				score = PlayerPrefs.GetInt ("correctScore");
				if (score == 3) {
						time -= Time.deltaTime;
						if (time < 0) {
								if (levelNumber == amountOfLevels) {
										Application.LoadLevel (0);

								} else {
										levelNumber++;
										var children = new List<GameObject> ();
										foreach (Transform child in game.transform)
												children.Add (child.gameObject);
										children.ForEach (child => Destroy (child));
										CreateGame ();
										time = 1.5f;

								}
						}
				}
		}
		void CreateGame ()
		{
				AnswerList = new List<string> ();
				TempList = new List<GameObject> ();
				ShapesList.Shuffle ();
				for (int i =0; i<3; i++) {
						GameObject g = Instantiate (ShapesList [i], new Vector3 (8, 3 - (i * 4), -5), Quaternion.identity) as GameObject;
						g.transform.parent = game.transform;
						string prefabName = ShapesList [i].name + "Answer";
						AnswerList.Add (prefabName);
			
				}
				AnswerList.Shuffle ();
				for (int i =0; i<ShapesAnswersList.Count; i++) {
						for (int j =0; j<AnswerList.Count; j++) {
								if (ShapesAnswersList [i].name.Equals (AnswerList [j])) {
										TempList.Add (ShapesAnswersList [i]);
								}
						}
				}
				for (int i =0; i<TempList.Count; i++) {
						GameObject h = Instantiate (TempList [i], new Vector3 (-5, 3 - (i * 4), -4.9f), Quaternion.identity) as GameObject;
						h.transform.parent = game.transform;
				}
		}
}
