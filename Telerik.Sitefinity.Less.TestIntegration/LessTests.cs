using System;
using System.Linq;
using MbUnit.Framework;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Services;

namespace Telerik.Sitefinity.Less.TestIntegration
{
	[TestFixture]
	[Author("Andrey Simeonov")]
	[Description("Integration tests for LESS parser module.")]
	class LessTests
	{
		[Test]
		[Description("Tests whether the module is registered successfully.")]
		public void IsModuleRegistered()
		{
			try
			{
				Config.UpdateSection<SystemConfig>(p =>
				{
					var settings = new AppModuleSettings(p.ApplicationModules)
					{
						Name = LessModule.ModuleName,
						Title = "Less Module",
						Description = "Less module",
						Type = "",
						StartupType = StartupType.OnApplicationStart
					};
					if (!p.ApplicationModules.ContainsKey(LessModule.ModuleName))
					{
						p.ApplicationModules.Add(settings);
						SystemManager.RestartApplication(true);
					}
				});
				Assert.IsTrue(SystemManager.ApplicationModules.ContainsKey(LessModule.ModuleName));
				UninstallModule();
				Assert.IsFalse(SystemManager.ApplicationModules.ContainsKey(LessModule.ModuleName));
			}
			finally
			{
				UninstallModule();
			}
		}

		private void UninstallModule()
		{
			Config.UpdateSection<SystemConfig>(
				p =>
				{
					if (p.ApplicationModules.ContainsKey(LessModule.ModuleName))
					{
						p.ApplicationModules.Remove(LessModule.ModuleName);
						SystemManager.RestartApplication(true);
					}
				});
		}
	}
}
