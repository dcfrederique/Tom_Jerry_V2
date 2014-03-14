using UnityEngine;
using System.Collections;
using Vectrosity;
using System;

public class GestureRecognizingScript : MonoBehaviour
{
		public Material lineMaterial;
		int maxPoints = 1000;
		public int lineWidth = 1;
		int minPixelMove = 5;
		private Vector2[] linePoints;
		private VectorLine line;
		private int lineIndex = 0;
		private Vector2 previousPosition;
		private int sqrMinPixelMove;
		private bool canDraw = false;
		private GameObject correctGesture;
		public Sprite[] sprites;
		string[] names ;
		void Start ()
		{
				names = new string[sprites.Length];
				for (int i=0; i< names.Length; i++) {
						names [i] = sprites [i].name;
				}			
				linePoints = new Vector2[maxPoints];
				line = new VectorLine ("DrawnLine", linePoints, lineMaterial, lineWidth, LineType.Continuous, Joins.Weld);
				sqrMinPixelMove = minPixelMove * minPixelMove;
		}
		void OnCustomGesture (PointCloudGesture gesture)
		{
				string gestureName = gesture.RecognizedTemplate.name;
				if (gesture.MatchScore > 0.35f) {
						correctGesture = GameObject.Find (gestureName);
						correctGesture.GetComponent<SpriteRenderer> ().sprite = sprites [Array.IndexOf (names, gestureName + "Filled")];
						line.ZeroPoints ();
						line.minDrawIndex = 0;
						line.Draw ();
						Vector2 mousePos = Input.mousePosition;
						previousPosition = linePoints [0] = mousePos;
						lineIndex = 0;
						canDraw = true;
				}
		}
		void Update ()
		{
				Vector2 mousePos = Input.mousePosition;
				if (Input.GetMouseButtonDown (0)) {
						line.ZeroPoints ();
						line.minDrawIndex = 0;
						line.Draw ();
						previousPosition = linePoints [0] = mousePos;
						lineIndex = 0;
						canDraw = true;
			
				} else if (Input.GetMouseButton (0) && (mousePos - previousPosition).sqrMagnitude > sqrMinPixelMove && canDraw) {
						previousPosition = linePoints [++lineIndex] = mousePos;
						line.minDrawIndex = lineIndex - 1;
						line.maxDrawIndex = lineIndex;
						if (lineIndex >= maxPoints - 1)
								canDraw = false;
						line.Draw ();

				}
		}
}