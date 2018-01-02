using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Linq;
 
public class CameraSnapshot : MonoBehaviour
{
	public Camera renderCamera;

	public string snapshotKey = "s";
	
	void LateUpdate()
	{
	
		if (Input.GetKeyDown(snapshotKey))
		{
			StartCoroutine(SaveCameraView());
		}
	
	}
	
	public IEnumerator SaveCameraView()
    {
        RenderTexture renderTexture = new RenderTexture(renderCamera.pixelWidth, renderCamera.pixelHeight, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
        using (new PropertyRestorer<Camera>(renderCamera, c => c.targetTexture))
        using (new Disabler(renderCamera.gameObject.GetChildren().ToArray()))
        {
            yield return new WaitForEndOfFrame();

            renderCamera.targetTexture = renderTexture;

            RenderTexture rendText = RenderTexture.active;
            RenderTexture.active = renderCamera.targetTexture;

            renderCamera.Render();

            Texture2D cameraImage = new Texture2D(renderCamera.targetTexture.width, renderCamera.targetTexture.height, TextureFormat.ARGB32, false);
            cameraImage.ReadPixels(new Rect(0, 0, renderCamera.targetTexture.width, renderCamera.targetTexture.height), 0, 0);
            cameraImage.Apply();
            RenderTexture.active = rendText;

            var path = GetSnapshotPath();
            Debug.Log("Screenshot saved to: " + path);

            File.WriteAllBytes(path, cameraImage.EncodeToPNG());
        }
    }

    private string GetSnapshotPath()
    {
        var snapshotPath = String.Empty;
        var snapshotNumber = 0;
        do
        {
            snapshotNumber++;
            snapshotPath = Path.Combine(
				Application.persistentDataPath, 
				"shot" + snapshotNumber.ToString("D4") + ".png");

        } while (File.Exists(snapshotPath));
        return snapshotPath;
    }
}
