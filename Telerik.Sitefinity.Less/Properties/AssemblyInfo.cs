using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using Telerik.Sitefinity.Less;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Telerik.Sitefinity.Less")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Telerik")]
[assembly: AssemblyProduct("Telerik Sitefinity CMS")]
[assembly: AssemblyCopyright("Copyright © Telerik 2013")]
[assembly: AssemblyTrademark("Sitefinity")]
[assembly: AssemblyCulture("")]

// Registers ModuleInstaller.PreApplicationStart() to be executed prior to the application start
[assembly: PreApplicationStartMethod(typeof(LessModuleInstaller), "PreApplicationStart")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("5692e865-28fc-4804-9c50-746524d80896")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("6.2.4910.0")]
[assembly: AssemblyVersion("6.2.4910.0")]
[assembly: AssemblyFileVersion("6.2.4910.0")]

[assembly: WebResource("Telerik.Sitefinity.Less.Module.Web.Resources.CustomStylesKendoUIView.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("Telerik.Sitefinity.Less.Module.Web.Resources.paging.png", "image/gif")]
