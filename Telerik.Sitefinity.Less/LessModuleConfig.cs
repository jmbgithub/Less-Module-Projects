using System;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;

namespace Telerik.Sitefinity.Less
{
    /// <summary>
    /// Sitefinity configuration section.
    /// </summary>
    /// <remarks>
    /// If this is a Sitefinity module's configuration,
    /// you need to add this to the module's Initialize method:
    /// App.WorkWith()
    ///     .Module(ModuleName)
    ///     .Initialize()
    ///         .Configuration<LessConfig>();
    /// 
    /// You also need to add this to the module:
    /// protected override ConfigSection GetModuleConfig()
    /// {
    ///     return Config.Get<LessConfig>();
    /// }
    /// </remarks>
    /// <see cref="http://www.sitefinity.com/documentation/documentationarticles/developers-guide/deep-dive/configuration/creating-configuration-classes"/>
    [ObjectInfo(Title = "LessModule Configuration", Description = "Configuration file for Sitefinity Less Module.")]
    public class LessConfig : ConfigSection
    {
        [ObjectInfo(Title = "Minify CSS", Description = "Minify the generated CSS file.")]
        [ConfigurationProperty("MinifyCSS", DefaultValue = false)]
        public bool MinifyCSS
        {
            get
            {
                return (bool)this["MinifyCSS"];
            }
            set
            {
                this["MinifyCSS"] = value;
            }
        }
    }
}