using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

public class ScriptCombiner
{
	[MenuItem("Tools/Combine All Scripts", false, 200)]
	public static void CombineScripts()
	{
		var projectPath = Application.dataPath;
		var scriptsFolder = Path.Combine(projectPath, "Scripts");

		if (!Directory.Exists(scriptsFolder))
		{
			Debug.LogError("Scripts folder not found!");
			return;
		}

		var outputPath = EditorUtility.SaveFilePanel(
			"Save Combined Scripts",
			projectPath,
			"Scripts.txt",
			"txt");

		if (string.IsNullOrEmpty(outputPath)) // User cancelled the save dialog
			return;

		var sb = new StringBuilder();
		var scriptFiles = Directory.GetFiles(scriptsFolder, "*.cs", SearchOption.AllDirectories);

		foreach (var file in scriptFiles)
		{
			var fileName = Path.GetFileName(file);
			sb.AppendLine($"// FILE: {fileName}");
			sb.AppendLine("```csharp");
			sb.AppendLine(File.ReadAllText(file));
			sb.AppendLine("```");
			sb.AppendLine();
		}

		File.WriteAllText(outputPath, sb.ToString());
		Debug.Log($"Combined scripts saved to: {outputPath}");
	}
}
