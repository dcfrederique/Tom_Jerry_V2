using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DotConnectionScript : MonoBehaviour
{
		private Vector3 startPos;
		private int dotNr = 1;
		private int amountMistakes;
		private int amountOfDots;
		private int dotsTaken = 0;
		DrawLines7ShapesGame drawScript;
		void Start ()
		{
				startPos = transform.position;
				amountOfDots = GameObject.Find ("game").transform.childCount - 1;
				drawScript = GameObject.Find ("tk2dCamera").GetComponent<DrawLines7ShapesGame> ();
		}	
		void OnTriggerExit (Collider collisionInfo)
		{			
				int otherDotNr = int.Parse (collisionInfo.gameObject.name);
				if (dotNr + 1 == otherDotNr) {
						Destroy (collisionInfo.gameObject);
						dotNr++;
						dotsTaken++;
						if (dotsTaken == amountOfDots) {
								Destroy (gameObject);
								drawScript.NextGame ();
						}
				} else {
						drawScript.Reset ();
						amountMistakes++;
						if (amountMistakes == 2) {
								drawScript.CompleteGame ();
								Destroy (gameObject);
								drawScript.NextGame ();
						}
				}
		}
		void OnMouseUp ()
		{
				transform.position = startPos;
		}

}