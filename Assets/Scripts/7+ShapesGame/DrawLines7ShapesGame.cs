using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class DrawLines7ShapesGame : MonoBehaviour
{
	
		LineRenderer lineRender;
		int numberOfPoints = 0;
		public List<GameObject> prefabsList;
		float time = 1.5f;
		private int gamesPlayed = 0;
		public int gameAmount = 3;
		private bool renewGame = false;
		// Use this for initialization
		void Start ()
		{
				lineRender = GetComponent<LineRenderer> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetMouseButton (0)) {
						numberOfPoints++;
						lineRender.SetVertexCount (numberOfPoints);
						Vector3 mousePos = new Vector3 (0, 0, 0);
						mousePos = Input.mousePosition;
						mousePos.z = 1.0f;
						Vector3 worldPos = camera.ScreenToWorldPoint (mousePos);
						lineRender.SetPosition (numberOfPoints - 1, worldPos);
				}
				if (renewGame) {
						time -= Time.deltaTime;				
						if (time <= 0) {
								Destroy (GameObject.Find ("game"));
								lineRender.SetVertexCount (0);
								numberOfPoints = 0;
								prefabsList.RemoveAt (0);
								GameObject g = Instantiate (prefabsList [0]) as GameObject;
								g.name = "game";
								time = 1.5f;
								renewGame = false;
						}
				}
				
	
		}
		public  void CompleteGame ()
		{
				lineRender.SetVertexCount (0);
				numberOfPoints = 0;
				for (int i =1; i<=GameObject.Find("game").transform.childCount; i++) {
						numberOfPoints++;
						lineRender.SetVertexCount (numberOfPoints);
						Vector3 pos = GameObject.Find (i.ToString () + "dot").transform.position;
						lineRender.SetPosition (numberOfPoints - 1, pos);
				}
		}
		public void Reset ()
		{
				numberOfPoints = 0;
				lineRender.SetVertexCount (0);
				
		}
		public void NextGame ()
		{		
				gamesPlayed++;
				renewGame = gamesPlayed < 3;
				if (!renewGame) {
						Application.LoadLevel (0);
				}

				

				

		}
}