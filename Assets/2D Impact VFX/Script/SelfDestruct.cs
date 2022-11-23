using UnityEngine;
using System.Collections;


namespace InguzPings
{


public class SelfDestruct : MonoBehaviour {
	public float selfdestruct_in = 3; // Setting this to 0 means no selfdestruct.

	void Start () {
		if ( selfdestruct_in != 0){ 
			Destroy (gameObject, selfdestruct_in);
		}
	}
}


}
