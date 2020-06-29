using UnityEngine;
using System.Collections;

public class explosions_script : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		GetComponent<AudioSource>().Play(); //Play Explosion Sound
        StartCoroutine(delete());
	}
    IEnumerator delete()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
