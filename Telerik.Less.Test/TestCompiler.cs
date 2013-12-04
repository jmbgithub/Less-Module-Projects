using System;
using MbUnit.Framework;

namespace Telerik.Less.UnitTests
{
	[TestFixture]
	public class TestCompiler
	{
		[Test]
		public void TestCssOutPut()
		{
			string lessFile = Environment.CurrentDirectory + @"\test.less";
			string output = @"body {
  background-color: Green;
}
";

			LessCompiler compiler = null;
			try
			{
				compiler = new LessCompiler();
			}
			catch (Exception)
			{
				Assert.Fail("Compiler was not created successfully!");
			}

			string css = string.Empty;
			if (compiler != null)
			{
				css = compiler.CompileFile(lessFile);
			}

			Assert.AreEqual(output, css);
		}
	}
}
