using SkiaSharp;
using UnityEngine;

public class SharedDrawing
{
	public static Texture2D CreateXamagonTexture()
	{
		// create a SkiaSharp bitmap
		var info = new SKImageInfo(200, 200);
		var bmp = new SKBitmap(info);

		DrawXamagon(bmp);

		// convert the SkiaSharp color type to a Unity color type
		TextureFormat format;
		if (info.ColorType == SKColorType.Bgra8888)
			format = TextureFormat.BGRA32;
		else
			format = TextureFormat.RGBA32;

		// create a Unity texture
		var texture = new Texture2D(info.Width, info.Height, format, false);
		texture.LoadRawTextureData(bmp.GetPixels(), info.BytesSize);
		texture.Apply();

		return texture;
	}

	public static void DrawXamagon(SKBitmap bitmap)
	{
		var canvas = new SKCanvas(bitmap);

		// flip the texture due to coordinate differences
		canvas.Scale(1, -1, 0, bitmap.Height / 2f);

		// white background
		canvas.Clear(SKColors.White);

		// blue
		var bluePaint = new SKPaint
		{
			StrokeCap = SKStrokeCap.Round,
			StrokeJoin = SKStrokeJoin.Round,
			StrokeWidth = 30,
			Color = (SKColor)0xff3498db,
			Style = SKPaintStyle.StrokeAndFill,
			IsAntialias = true
		};
		// xamagon path
		var xamagon = new SKPath();
		xamagon.MoveTo(40, 80);
		xamagon.LineTo(70, 25);
		xamagon.LineTo(135, 25);
		xamagon.LineTo(166, 80);
		xamagon.LineTo(135, 135);
		xamagon.LineTo(70, 135);
		xamagon.Close();
		// draw blue xamagon
		canvas.DrawPath(xamagon, bluePaint);

		// white
		var whitePaint = new SKPaint
		{
			StrokeCap = SKStrokeCap.Round,
			StrokeJoin = SKStrokeJoin.Round,
			StrokeWidth = 15,
			Color = SKColors.White,
			Style = SKPaintStyle.Stroke,
			IsAntialias = true
		};
		// the X path
		var x = new SKPath();
		x.MoveTo(80, 110);
		x.LineTo(95, 80);
		x.LineTo(80, 50);
		x.MoveTo(125, 110);
		x.LineTo(110, 80);
		x.LineTo(125, 50);
		// draw white X
		canvas.DrawPath(x, whitePaint);

		// green
		var greenPaint = new SKPaint
		{
			Typeface = SKTypeface.FromFamilyName(null, SKTypefaceStyle.Bold),
			TextAlign = SKTextAlign.Center,
			TextSize = 30,
			Color = (SKColor)0xff77d065,
			Style = SKPaintStyle.Fill,
			IsAntialias = true
		};
		// draw green text
		canvas.DrawText("SkiaSharp", 100, 180, greenPaint);

		// push to the pixel buffer
		canvas.Flush();
	}
}
