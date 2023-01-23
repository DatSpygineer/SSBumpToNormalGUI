using SSBumpToNormal;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Source: https://github.com/rob5300/ssbumpToNormal-Win

[Serializable]
public struct VTFInfo {
	public Version Version;
	public bool Compressed, HasAlpha;
}

public class SSBumpConverter {
	private static float OO_SQRT_3 = 0.57735025882720947f;
	static Vector3[] bumpBasisTranspose = new Vector3[]{
		new Vector3( 0.81649661064147949f, -0.40824833512306213f, -0.40824833512306213f ),
		new Vector3(  0.0f, 0.70710676908493042f, -0.7071068286895752f ),
		new Vector3(  OO_SQRT_3, OO_SQRT_3, OO_SQRT_3 )
	};
	public static void ConvertToNormal(string inputPath, string outputPath, TextureFormat format, VTFInfo? vtfinfo = null) {
		// Convert vtf to png
		if (Path.GetExtension(inputPath).ToLower() == ".vtf") {
			var tempBasePath = Path.Combine(AppContext.BaseDirectory, "temp_in");
			if (!Directory.Exists(tempBasePath)) {
				Directory.CreateDirectory(tempBasePath);
			}

			var tempPath = Path.Combine(tempBasePath, Path.GetFileNameWithoutExtension(inputPath) + ".png");

			// Run vtf command line
			using var process = new Process();
			process.StartInfo = new ProcessStartInfo(
				Path.GetFullPath("VTFCmd.exe"),
				$"-file \"{inputPath}\" " +
				$"-output \"{tempBasePath}\" " +
				$"-exportformat png"
			) {
				RedirectStandardOutput = true,
			};
			process.Start();
			process.WaitForExit();
			var log = process.StandardOutput.ReadToEnd();
			if (log.Contains("0/1 files completed", StringComparison.OrdinalIgnoreCase)) {
				throw new Exception($"Error while converting vtf to png!\n\nOutput log:\n{log}");
			}
#if DEBUG
			// Log stdout in debug mode
			MessageBox.Show(log);
#endif
			inputPath = tempPath;
		}
		
		var image = new Bitmap(inputPath);
		var convertedImage = new Bitmap(image.Width, image.Height);
		for (int x = 0; x < image.Width; x++) {
			for (int y = 0; y < image.Height; y++) {
				var pixel = image.GetPixel(x, y);
				var readVector = new Vector3(pixel.R / 255f, pixel.G / 255f, pixel.B / 255f);
				var newColor = Color.FromArgb(
					ConvertVector(ref readVector, 0),
					ConvertVector(ref readVector, 1),
					ConvertVector(ref readVector, 2)
				);
				convertedImage.SetPixel(x, y, newColor);
			}
		}
		image.Dispose();

		outputPath = outputPath.Replace("-ssbump", "-normal").Replace("_ssbump", "_normal");

		if (format == TextureFormat.VTF) {
			if (!Directory.Exists(Path.Combine(AppContext.BaseDirectory, "temp"))) {
				Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, "temp"));
			}

			var tempPath = Path.Combine(
				AppContext.BaseDirectory,
				"temp",
				Path.GetFileNameWithoutExtension(outputPath) + ".png"
			);

			convertedImage.Save(tempPath, ImageFormat.Png);

			// Assing default config if it's null
			vtfinfo ??= new VTFInfo {
				Version = new Version(7, 4),
				Compressed = false,
				HasAlpha = false,
			};

			// Image format string
			var formatStr = vtfinfo.Value.Compressed ?
				(vtfinfo.Value.HasAlpha ? "DXT5" : "DXT1") :
				(vtfinfo.Value.HasAlpha ? "RGBA8888" : "RGB888");

			// Check if VTFCmd exists
			if (!File.Exists(Path.GetFullPath("VTFCmd.exe"))) {
				throw new Exception($"File \"{Path.GetFullPath("VTFCmd.exe")}\" is missing!");
			}

			// Run vtf command line
			using var process = new Process();
			process.StartInfo = new ProcessStartInfo(
				Path.GetFullPath("VTFCmd.exe"),
				$"-file \"{tempPath}\" " +
				$"-output \"{Path.GetFullPath(Path.GetDirectoryName(outputPath)!)}\" " +
				$"-format {formatStr} " +
				$"-flag NORMAL " +
				$"-version {vtfinfo.Value.Version}"
			) {
				RedirectStandardOutput = true,
				RedirectStandardError = true,
			};
			process.Start();
			process.WaitForExit();
			var log = process.StandardOutput.ReadToEnd();
			if (log.Contains("0/1 files completed", StringComparison.OrdinalIgnoreCase)) {
				throw new Exception($"Error while converting to vtf!\n\nOutput log:\n{log}");
			}
#if DEBUG
			// Log stdout in debug mode
			MessageBox.Show(log);
#endif
		} else {
			// Correct output extension
			var ext = format switch {
				TextureFormat.PNG => ".png",
				TextureFormat.BMP => ".bmp",
				TextureFormat.JPG => ".jpg",
				TextureFormat.TIFF => ".tiff",
				TextureFormat.GIF => ".gif",
				_ => throw new FormatException($"Unsupported texture format: {format}"),
			};

			var fixedPath = Path.GetExtension(outputPath) != ext ? 
				Path.Combine(
					Path.GetDirectoryName(outputPath)!, 
					Path.GetFileNameWithoutExtension(outputPath)
				) + ext : outputPath;

			convertedImage.Save(Path.GetFullPath(fixedPath), format switch {
				TextureFormat.PNG => ImageFormat.Png,
				TextureFormat.BMP => ImageFormat.Bmp,
				TextureFormat.JPG => ImageFormat.Jpeg,
				TextureFormat.TIFF => ImageFormat.Tiff,
				TextureFormat.GIF => ImageFormat.Gif,
				_ => throw new FormatException($"Unsupported texture format: {format}"),
			});
		}

		MessageBox.Show("Done!", "Conversion finished!");
	}

	private static int ConvertVector(ref Vector3 vecIn, int index) {
		float newColor = Vector3.Dot(vecIn, bumpBasisTranspose[index]) * 0.5f + 0.5f;
		return (int)Math.Floor(Math.Clamp(newColor, 0f, 1f) * 255f);
	}
}