using System.Collections;
using System.IO;
using System.Runtime;

namespace Aceade.Util.NullHunter
{
	/// <summary>
	/// Utility class for input/output.
	/// </summary>
	public static class InputOutput 
	{
		
		public static void WriteToFile(string text, string filename)
		{
			using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
	        {
	            writer.Write(text);
	        }
		}
		
	}

}
