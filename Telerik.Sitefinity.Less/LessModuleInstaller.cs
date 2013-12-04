using System.Linq;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web;

namespace Telerik.Sitefinity.Less
{
	/// <summary>
	/// Module installer class
	/// </summary>
	/// <remarks>
	/// This installer is registered in the /Properties/AssemblyInfo.cs file
	/// The purpose of it is to register the module in Sitefinity automatically.
	/// The User will have to enable the module from Administration -> Modules & Services
	/// </remarks>
	/// <see cref="http://www.sitefinity.com/blogs/peter-marinovs-blog/2013/03/20/creating-self-installing-widgets-and-modules-in-sitefinity"/>
	public static class LessModuleInstaller
	{
		#region Public methods
		/// <summary>
		/// Called before the application start.
		/// </summary>
		public static void PreApplicationStart()
		{
			Bootstrapper.Initialized += LessModuleInstaller.OnBootstrapperInitialized;
		}
		#endregion

		#region Private methods
		/// <summary>
		/// Called when the Bootstrapper is initialized.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="Telerik.Sitefinity.Data.ExecutedEventArgs" /> instance containing the event data.</param>
		private static void OnBootstrapperInitialized(object sender, ExecutedEventArgs e)
		{
			if (e.CommandName == "RegisterRoutes")
			{
				// We have to register the module at a very early stage when sitefinity is initializing
				LessModuleInstaller.RegisterModule();
			}
		}

		/// <summary>
		/// Registers the Module module.
		/// </summary>
		private static void RegisterModule()
		{
			var configManager = ConfigManager.GetManager();
			var modulesConfig = configManager.GetSection<SystemConfig>().ApplicationModules;
			if (!modulesConfig.Elements.Any(el => el.GetKey().Equals(LessModule.ModuleName)))
			{
				modulesConfig.Add(LessModule.ModuleName, new AppModuleSettings(modulesConfig)
				{
					Name = LessModule.ModuleName,
					Title = LessModule.ModuleTitle,
					Description = LessModule.ModuleDescription,
					Type = typeof(LessModule).AssemblyQualifiedName,
					// Change to StartupType.OnApplicationStart if you wish to have the module automatically installed.
					StartupType = StartupType.Disabled
				});

				configManager.SaveSection(modulesConfig.Section);

				// Uncomment if you change the StartupType to OnApplicationStart
				//SystemManager.RestartApplication(false);
			}
		}
		#endregion
	}
}
