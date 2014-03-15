using UnityEngine;
using System.Collections;

public class BtnShapesEventHandlerScript : MonoBehaviour
{

		tk2dUIItem uiItem;
		public int nextSceneNumber;
		// Adding events 
		void OnEnable ()
		{
				uiItem = GetComponent<tk2dUIItem> ();
				uiItem.OnDown += ButtonDown;
				uiItem.OnClickUIItem += Clicked;
		}
		//ButtonDown ...
		void ButtonDown ()
		{
				//Debug.Log ("Button Down");
		}
		//Loading specific scen
		void Clicked (tk2dUIItem clickedUIItem)
		{
				Application.LoadLevel (nextSceneNumber);
		}
	
		//Remove events from event handler
		void OnDisable ()
		{
				uiItem.OnDown -= ButtonDown;
				uiItem.OnClickUIItem -= Clicked;
		}
	
}
