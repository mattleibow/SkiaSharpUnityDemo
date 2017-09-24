using UnityEngine;

public class CubeScript : MonoBehaviour
{
	void Start()
	{
		var texture = SharedDrawing.CreateXamagonTexture();

		var material = gameObject.GetComponent<MeshRenderer>().material;
		material.mainTexture = texture;
	}

	void Update()
	{
		// we want to spin the cube
		transform.Rotate(new Vector3(0, Time.deltaTime * 100, 0));
	}
}
