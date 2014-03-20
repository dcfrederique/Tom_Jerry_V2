using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class DrawLines : MonoBehaviour
{
		LineRenderer lineRender;
		int numberOfPoints = 0;
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
				} else {
						numberOfPoints = 0;
						lineRender.SetVertexCount (0);
				}
	
		}
}