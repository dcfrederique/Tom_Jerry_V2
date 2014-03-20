using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Gesture : MonoBehaviour
{
		static GameObject gestureDrawing;
		public List<GameObject> prefabsList;
		ArrayList pointArr;
		static int mouseDown;
		private GameObject correctGesture;
		public Sprite[] sprites;
		string[] names ;
		private int amountOfCorrectAnswers = 0;
		private int answersNeeded = 0;
		float time = 1.5f;
		private int amount = 0;

		// runs when game starts - main function
		void Start ()
		{
				new GestureTemplates ();
				pointArr = new ArrayList ();
				gestureDrawing = GameObject.Find ("gesture");
				names = new string[sprites.Length];
				for (int i=0; i< names.Length; i++) {
						names [i] = sprites [i].name;
				}	
				answersNeeded = GameObject.Find ("Figure").transform.childCount;
		}
	
		IEnumerator worldToScreenCoordinates ()
		{
				// fix world coordinate to the viewport coordinate
				Vector3 screenSpace = Camera.main.WorldToScreenPoint (gestureDrawing.transform.position);
    	
				while (Input.GetMouseButton(1)) {
						Vector3 curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
						Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace); 
						gestureDrawing.transform.position = curPosition;
						yield return 0;
				}
		}

		void Update ()
		{
				if (amountOfCorrectAnswers == answersNeeded) {
						time -= Time.deltaTime;
						if (time < 0) {
								if (++amount == 3) {
										Application.LoadLevel (0);										
								} else {
										Destroy (GameObject.Find ("Figure"));
										prefabsList.RemoveAt (0);
										GameObject g = Instantiate (prefabsList [0]) as GameObject;
										g.name = "Figure";
										amountOfCorrectAnswers = 0;
										time = 1.5f;
								}
						}
				}
				if (Input.GetMouseButtonDown (0)) {
						mouseDown = 1;
				}
    	
				if (mouseDown == 1) {
						Vector2 p = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
						pointArr.Add (p);
						StartCoroutine (worldToScreenCoordinates ());
				}


				if (Input.GetMouseButtonUp (0)) {					
						mouseDown = 0;
						// start recognizing! 
						string gestureName = GestureRecognizer.startRecognizer (pointArr);
						pointArr.Clear ();		
						try {
								correctGesture = GameObject.Find (gestureName);
								if (correctGesture.GetComponent<SpriteRenderer> ().sprite != sprites [Array.IndexOf (names, gestureName + "Filled")]) {
										correctGesture.GetComponent<SpriteRenderer> ().sprite = sprites [Array.IndexOf (names, gestureName + "Filled")];
										amountOfCorrectAnswers++;
								} 
						} catch (NullReferenceException) {
						}
    		
				}
    	
		} 
	
}
