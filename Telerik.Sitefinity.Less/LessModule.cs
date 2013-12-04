using System;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web;

namespace Telerik.Sitefinity.Less
{
	/// <summary>
	/// Custom Sitefinity content module 
	/// </summary>
	public class LessModule : ModuleBase
	{
		#region Properties

		/// <inheritdoc />
		public override Guid LandingPageId
		{
			get { return Guid.Empty; }
		}

		/// <inheritdoc />
		public override Type[] Managers
		{
			get
			{
				return null;
			}
		}
		#endregion

		#region Module Initialization

		/// <inheritdoc />
		public override void Initialize(ModuleSettings settings)
		{
			base.Initialize(settings);
			ObjectFactory.Container.RegisterType<ILessCompiler, SitefinityLessCompiler>(new InjectionConstructor());
			App.WorkWith()
				.Module(settings.Name)
					.Initialize();
		}

		public override void Install(SiteInitializer initializer)
		{
		}

		public override void Upgrade(SiteInitializer initializer, Version upgradeFrom)
		{
		}

		protected override ConfigSection GetModuleConfig()
		{
			return null;
		}

		#endregion

		#region Private members & constants

		public const string ModuleName = "LessModule";
		internal const string ModuleTitle = "LessModule";
		internal const string ModuleDescription = "This a Sitefinity module that takes a \"less\" file and transforms it to \"Css\" file.";

		#endregion
	}
}