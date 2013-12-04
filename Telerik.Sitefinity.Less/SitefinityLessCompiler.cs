using System;
using System.IO;
using Telerik.Less;
using Telerik.Sitefinity.Web;

namespace Telerik.Sitefinity.Less
{
	public class SitefinityLessCompiler : ILessCompiler
	{
		public SitefinityLessCompiler()
		{
			compiler = new LessCompiler();
		}

		public string Compile(Stream less)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public string CompileFile(string filePath)
		{
			return this.compiler.CompileFile(filePath);
		}

		private readonly LessCompiler compiler;
	}
}
