using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour
{

		public List<GameObject> ShapesList;
		private List<string> AnswerList;
		void Start ()
		{
				AnswerList = new List<string> ();
				ShapesList.Shuffle ();
				for (int i =0; i<2; i++) {
						Instantiate (ShapesList [i], new Vector3 (8, 3 - (i * 4), -5), Quaternion.identity);
						string prefabName = ShapesList [i].name + "Answer";
						AnswerList.Add (prefabName);
						
				}
				AnswerList.Shuffle ();
				for (int i =0; i<AnswerList.Count; i++) {
						Instantiate (Resources.LoadAssetAtPath ("Assets/Prefabs/" + AnswerList [i] + ".prefab", typeof(GameObject)), new Vector3 (-5, 3 - (i * 4), -4.9f), Quaternion.identity);
				}
		}

		void Update ()
		{
	
		}
}
