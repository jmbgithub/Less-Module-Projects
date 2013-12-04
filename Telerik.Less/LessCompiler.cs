using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Telerik.Windows.Zip;

namespace Telerik.Less
{
	/// <summary>
	/// Used to obtain the Css style rules from less files.
	/// </summary>
	public class LessCompiler
	{
		private const string DestFolder = "Less\\";

		// The name of the resource that should be used.
		private const string ResName = "Installation.zip";

		// The folder that should be created on the local file system.
		private const string ResFolder = "Installation";

		/// <summary>
		/// Extracts the resources while constructing the object.
		/// </summary>
		public LessCompiler()
		{
			string destPath = this.PrepareDestinationPath(LessCompiler.DestFolder);
			Stream stream = this.GetResourceStream(LessCompiler.ResName);
			this.ExtractResources(stream, destPath);
		}

		/// <summary>
		/// Compiles a LESS file to CSS.
		/// </summary>
		/// <param name="filePath">Path to the LESS file.</param>
		/// <returns>Compiled CSS.</returns>
		public string CompileFile(string filePath)
		{
			return this.ParseLess(this.PrepareDestinationPath(LessCompiler.DestFolder), filePath);
		}

		/// <summary>
		/// Checks whether the destination directory exists. If needed creates the directory.
		/// </summary>
		/// <param name="childDir">The name of the child directory that should be created.</param>
		/// <returns>Path to the newly created folder.</returns>
		private string PrepareDestinationPath(string childDir)
		{
			string tempPath = Path.GetTempPath();
			string destinationPath = Path.Combine(tempPath, childDir);

			if (!Directory.Exists(destinationPath))
			{
				Directory.CreateDirectory(destinationPath);
			}
			return destinationPath;
		}

		/// <summary>
		/// Opens the resources for reading.
		/// </summary>
		/// <param name="resourceName">The name of the resource.</param>
		/// <returns>Stream to the specified resource.</returns>
		private Stream GetResourceStream(string resourceName)
		{
			Assembly assembly = this.GetType().Assembly;
			string name = assembly.GetName().Name;
			return assembly.GetManifestResourceStream(name + "." + resourceName);
		}

		/// <summary>
		/// Extracts the resource to the specified folder of the local file system.
		/// </summary>
		/// <param name="zipStream">Stream to the resources.</param>
		/// <param name="destinationPath">Path where the resource should be extracted.</param>
		private void ExtractResources(Stream zipStream, string destinationPath)
		{
			using (ZipPackage zipPackage = ZipPackage.Open(zipStream))
			{
				// Entry could be file, folder or another archive
				foreach (ZipPackageEntry entry in zipPackage.ZipPackageEntries)
				{
					// Opens the compressed file for reading.
					using (Stream exportStream = entry.OpenInputStream())
					{
						string path = Path.Combine(destinationPath, (entry.FileNameInZip.TrimEnd('/').Replace('/', '\\')));
						// Needed in order for the File.Create method to succeed. If the file path 
						// contains directory that does not exist exception will be thrown.
						bool isDir = entry.Attributes.HasFlag(FileAttributes.Directory);

						if (isDir)
						{
							if (!Directory.Exists(path))
							{
								try
								{
									Directory.CreateDirectory(path);

								}
								catch (UnauthorizedAccessException)
								{
									throw new UnauthorizedAccessException("You do not have sufficient permissions to create directory!");
								}
								catch (PathTooLongException)
								{
									throw new PathTooLongException("The destination path is too long!");
								}
							}
						}
						else
						{
							if (!File.Exists(path))
							{
								try
								{
									using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
									{
										// Copy the uncompressed data to disk
										exportStream.CopyTo(fs);
										fs.Close();
									}
								}
								catch (UnauthorizedAccessException)
								{
									throw new UnauthorizedAccessException("You do not have sufficient permission to create files!");
								}
								catch (PathTooLongException)
								{
									throw new PathTooLongException("The destination path is too long!");
								}
							}
							else
							{
								using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
								{
									// Copy the uncompressed data to disk
									exportStream.CopyTo(fs);
									fs.Close();
								}
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Call the less.js compiler with node.js
		/// </summary>
		/// <param name="binPath">Path to node.exe</param>
		/// <param name="filePath">Path to the file that should be parsed.</param>
		/// <returns>Stream that holds the result of parsing.</returns>
		private string ParseLess(string binPath, string filePath)
		{
			Process process = new Process();

			process.StartInfo.WorkingDirectory = binPath;
			process.StartInfo.FileName = Path.Combine(binPath, LessCompiler.ResFolder, "node.exe");
			process.StartInfo.Arguments = Path.Combine(binPath + LessCompiler.ResFolder) + "\\bin\\lessc \"" + filePath + "\"";
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.UseShellExecute = false;
			process.Start();
			string result = string.Empty;
			try
			{
				result = process.StandardOutput.ReadToEnd();
			}
			catch (OutOfMemoryException)
			{
				throw new OutOfMemoryException("There was not enough memory to perform the reading!");
			}

			process.WaitForExit();

			return result;
		}
	}
}