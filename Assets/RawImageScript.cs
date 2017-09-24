using SkiaSharp;
using UnityEngine;
using UnityEngine.UI;

public class RawImageScript : MonoBehaviour
{
	void Start()
	{
		var texture = SharedDrawing.CreateXamagonTexture();

		var rawImage = gameObject.GetComponent<RawImage>();
		rawImage.texture = texture;
	}

	void Update()
	{
	}
}
