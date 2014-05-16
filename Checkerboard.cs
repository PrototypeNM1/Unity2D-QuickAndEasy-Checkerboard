using UnityEngine;
using System.Collections;

public class Checkerboard : MonoBehaviour {
	[SerializeField]float scaleWorld = 0.25f;
	// Use this for initialization
	void Start () {
		// Size the background to the main camera
		Vector3 bottomLeft = new Vector3 (0.0f, 0.0f, 10.0f);
		bottomLeft = Camera.main.ViewportToWorldPoint (bottomLeft);
		Vector3 topRight = new Vector3 (1.0f, 1.0f, 10.0f);
		topRight = Camera.main.ViewportToWorldPoint (topRight);

		Vector3 Scale = new Vector3 (topRight.x - bottomLeft.x , topRight.y - bottomLeft.y, 1.0f);
		transform.localScale = Scale;
		renderer.material.mainTexture.wrapMode = TextureWrapMode.Repeat;
		renderer.material.SetTextureScale("_MainTex", Scale*scaleWorld);
	}
	
	// Update is called once per frame
	void Update () {
		// Update the UV coordinates to move the checker
		renderer.material.SetTextureOffset("_MainTex", transform.position*scaleWorld);
	}
}
