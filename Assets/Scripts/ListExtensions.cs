using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ListExtensions
{

		// Extension method to shuffle a list 
		public static void Shuffle<T> (this IList<T> list)
		{  
				int i = list.Count;  
				while (i > 1) {  
						i--;  
						int j = Random.Range (0, i + 1);  
						T value = list [j];  
						list [j] = list [i];  
						list [i] = value;  
				}  
		}
}
