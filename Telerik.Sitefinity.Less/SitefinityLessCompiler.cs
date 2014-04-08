using System;
using System.IO;
using Telerik.Less;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web;

namespace Telerik.Sitefinity.Less
{
	public class SitefinityLessCompiler : ILessCompiler
	{
		public SitefinityLessCompiler()
		{
			compiler = new LessCompiler();
		}        
       
        public string Compile(Stream less, LessCompilerSettings settings)
        {
			throw new NotImplementedException();
		}

		/// <inheritdoc />
        public string CompileFile(string filePath, LessCompilerSettings settings)
		{
            if (settings != null)
            {
                return this.compiler.CompileFile(filePath, settings.Minify);
            }
			return this.compiler.CompileFile(filePath, this.ShouldMinify);
		}

        public bool ShouldMinify
        {
            get
            {
                LessConfig configSection = Config.Get<LessConfig>();
                return configSection.MinifyCSS;                
            }
        }

		private readonly LessCompiler compiler;
	}
}
