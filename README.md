LESS Support
============

General Information
-------------------

The solution contains projects for compilation of LESS syntax to CSS styles.

- `Telerik.Less` - contains the compiler that takes the LESS input and returns the CSS output.
- `Telerik.Less.Test` - contains unit tests for the compiler.
- `Telerik.Sitefinity.Less` - contains the Sitefinity module that adds the compiler functionality to Telerik Sitefinity product.
- `Telerik.Sitefinity.Less.TestIntegration` - contains the integration tests for Sitefinity product.

Requirements
------------

- `Telerik.Sitefinity` assembly, version 6.1 or higher
- `Telerik.Sitefinity.Model` assembly, version 6.1 or higher
- `Telerik.Sitefinty.Utility` assembly, version 6.1 or higher
- `Telerik.OpenAccess assembly`, version 2013.2.807 or higher
- `Telerik.Windows.Zip assembly`, version 2013.1.415 or higher
- Approximately 10 MB of disk space.
- The account that will use the module (the application pool identity if the application is hosted in IIS) should have write permissions to the Temp folder (`C:\Windows\Temp or C:\Users\user\AppData\Local\Temp`).

Features
--------

This module handles requests to files with extension `*.less` that are stored in the following locations:

- `Sitefinity_application\App_Themes\ThemeName\`
- `Sitefinity_application\App_Data\Sitefinity\WebsiteTemplates\`

Installation
------------

There are several ways you can use this module in Sitefinity.

Since the module depends on the Sitefiinty assembly you should add a reference to Sitefinity assembly (from the bin folder of your Sitefinity project).

The build order is as follows:

- Build the Sitefinity assembly.
- Build the Telerik.Less assembly.
- Build Telerik.Sitefinity.Less assembly.
- Copy the Telerik.Sitefinity.Less assembly to the bin folder of the Sitefinity application.
- Copy the Telerik.Less assembly to the bin folder of the Sitefinity application.

After you build the Telerik.Less and Telerik.Sitefinity.Less modules you should copy their assemblies from each modules's Debug folder and transfer the assemblies to the bin folder of your SitefinityWebApp project. Build SitefinityWebApp.

With the current implementation the Less module is self-registered. Once you copy the assembly to the bin folder of the application on the next load the module would be automatically registered. 

This behavior could be changed if you remove the `PreApplicationStartMethodAttribute` from the `AssemblyInfo.cs` file of the `Telerik.Sitefinity.Less` project and add the call to the `RegisterModule` method in the `Initialize` method of the `LessModule.cs` file.

What you need to do next is go to `Administration -> Modules and services` and activate the Less module.

Another approach is to create new solution that holds the Sitefinity project, `Telerik.Less` and `Telerik.Sitefinity.Less` projects. Then you could configure the output folder of `Telerik.Less` and `Telerik.Sitefinity.Less` projects to be the Sitefinity application's bin folder. Thus when you build the solution the module will be copied automatically and you would need to only refresh the page.

Troubleshooting
---------------

- Please note that in order for the module to work correctly you need to copy not only the module assembly (`Telerik.Sitefinity.Less.dll`) but the compiler assembly (`Telerik.Less.dll`) as well to the bin folder of the application.
- Make sure that the `Telerik.Windows.Zip` assembly is presented and it is the same version across all projects.
- On shared hosting there might be some problems with the permissions required to run the compiler process.
