[Running application](http://104.236.48.115:1400/ "WeeklyDev-Frontend")

#WeeklyDev.io .NET Core Front End

##Quick Start - Installation & Dev Environment Setup

###Linux Setup
*Only been tested with Ubuntu 14.04 & Ubuntu 16.04 (requires 64 bit)*

1. `git clone https://github.com/wakawaka54/weeklydev-frontend.git` Clone or Fork GitHub repository into your local machine 
2. Follow the .NET Core setup located [here](https://www.microsoft.com/net/core#ubuntu "dotnet setup")
3. `cd weeklydev-frontend` Move into the project subdirectory
4. `dotnet restore` Restore packages (similar to npm install)
5. `dotnet run` Runs the dotnet core application
6. Defaults to `localhost:1400`

####Development Environment Setup

####Linux
1. Download [Visual Studio Code](https://code.visualstudio.com/ "Visual Studio Code")
2. Install C# extension and anything else you may find interesting!
3. Line by Line debugging is supported on Visual Studio Code
(note: I have not been able to get Razor intellisense to work on Visual Studio Code)

####Windows (preferred)
1. Download [Visual Studio Community](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx "Visual Studio Community")
2. Download [.Net Core for Windows](https://www.microsoft.com/net/core#windows "dotnet setup") - if you experience any issues with this, let me know. There are some known bugs with the installer.
3. Open `.sln` file and it should open up the project. You will have full intellisense for Razor and C#.

##Project Documentation

Extension .Net Core Documentation can be found [here](https://docs.asp.net/en/latest/ "dotnet docs")

###Configuration

Configuration for this project is done in following files **`project.json`**, **`appsettings.json`**, **`.\Properties\launchSettings.json`**, **`Startup.cs`**, **`Program.cs`**, `web.config`.

####`project.json`
* `"dependencies"` are all the 'packages' that are required by the dotnet application

####`appsettings.json`
* `"ConnectionStrings"` are connection strings to dbs, I believe this is currently unsed.
* `"Logging""` works with ILogger and tells what level alerts do you want to see in the console
* `"server.urls"` default launch url for the application
* `"apiAddress"` web address of WeeklyDev.io backend

####`.\Properties\launchSettings.json`
* I don't think this is used

####`Startup.cs`
* Startup(...) - Configuration is built here, add any new configuration files here.
* ConfigureServices(...) - Some services need to be pre-configured which is what happens here. *Dependency Injection* mapping happens here.
* Configure(...) - WeeklyDevApiAuthentication is setup here and JsonConvert default settings are assigned here. Routes are assigned here.

####`Program.cs`
* Main(...) - starting point of the application, creates and configures Server and adds `Startup.cs` file along with retreives config files.

###Project Folder Structure
* `.vscode` -> ignore
* `**Controllers**` - The C of MVC
* `Properties` some configuration
* `**Services**` definitions for all the services that are injected through DI to the controller. This is the implementation of how data gets to the Controllers.
* `**Views**` - the V of MVC, these contain the *HTML* mark up for all pages and use a templating engine called *Razor*
* `bin` -> ignore
* `obj` -> ignore
* `wwwroot` -> all static files are kept here (imgs, css, js)

###Basic Technologies
*Bootstrap* layout

*Razor* templating engine

*AspNetCore* Class libraries for server side implementation

**Default .Net Core Readme Material Below**
## How to

*   [Add a Controller and View](https://go.microsoft.com/fwlink/?LinkID=398600)
*   [Add an appsetting in config and access it in app.](https://go.microsoft.com/fwlink/?LinkID=699562)
*   [Manage User Secrets using Secret Manager.](https://go.microsoft.com/fwlink/?LinkId=699315)
*   [Use logging to log a message.](https://go.microsoft.com/fwlink/?LinkId=699316)
*   [Add client packages using Bower.](https://go.microsoft.com/fwlink/?LinkId=699318)
*   [Target development, staging or production environment.](https://go.microsoft.com/fwlink/?LinkId=699319)

## Overview

*   [Conceptual overview of what is ASP.NET Core](https://go.microsoft.com/fwlink/?LinkId=518008)
*   [Fundamentals of ASP.NET Core such as Startup and middleware.](https://go.microsoft.com/fwlink/?LinkId=699320)
*   [Working with Data](https://go.microsoft.com/fwlink/?LinkId=398602)
*   [Security](https://go.microsoft.com/fwlink/?LinkId=398603)
*   [Client side development](https://go.microsoft.com/fwlink/?LinkID=699321)
*   [Develop on different platforms](https://go.microsoft.com/fwlink/?LinkID=699322)
*   [Read more on the documentation site](https://go.microsoft.com/fwlink/?LinkID=699323)

## Run & Deploy

*   [Run your app](https://go.microsoft.com/fwlink/?LinkID=517851)
