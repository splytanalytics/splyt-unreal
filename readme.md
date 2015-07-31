# Splyt Unreal Engine 4 SDK
This is the Splyt Unreal Engine 4 software development kit. This SDK should provide everything needed to integrate your Unreal Engine project with Splyt Analytics. This SDK is in Unreal's plugin format for ease of installation.

This documentation does not explain how to use the Splyt Platform its self, but how to install and integrate this plugin. The plugin is built off of the core [Splyt C++ SDK](https://github.com/splytanalytics/splyt-cpp), so more in depth API information can be found there.

# Installation
How to install this plugin into your Unreal project.

### Getting the Plugin
In the base folder of your Unreal Project, create a folder named "Plugins". Using any Git program of your choice pull this repo into the Plugins folder and name the folder "SplytAnalytics". For UNIX based systems you can use a command like this:
```
git clone --recursive https://github.com/splytanalytics/splyt-unreal.git SplytAnalytics
```

### Enabling the Plugin
Once the plugin has been installed it must be enabled in the Unreal Editor. Start the Unreal Editor with your project, and in the top left select the windown dropdown. In this dropdown you will find the Plugins window. Select this and navagate the the Analytics section, once there you can check enable for the Splyt Analytics project.

### Building the Plugin
This plugin will need to be added as a public dependency module to your project and built. In your project you will have a C# file called "YourProjectName.Build.cs" located in your Source folder in the base of your project. In this file all of your project dependencies will be found here. We will need to add the dependency SplytAnalytics to the PublicDependencyModuleNames. An example for a project SplytTest is shown below.
```c#
using UnrealBuildTool;

public class SplytTest : ModuleRules
{
    public SplytTest(TargetInfo Target)
    {
        PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore", "SplytAnalytics" });
    }
}

```
Once that is done you must save this and restart the Unreal Editor. The editor will ask you to build the SplytAnalytics plugin upon starting, select yes and once the build is complete you will now be able to start using the plugin.

# Overview
How to use this plugin in your Unreal project.

### Includes
Only one include is required to use this plugin, and it is recommended to put the include in the precompiled header that is included in all project files.
```c++
#include "SplytAnalytics.h"
```
For example the project SplytTest, the precompiled header "SplytTest.h" is located in the "Source/SplytTest" folder and looks like this:
```c++
#ifndef __SPLYTTEST_H__
#define __SPLYTTEST_H__

#include "EngineMinimal.h"
#include "SplytAnalytics.h"

#endif

```

### Initialization
Initialization and usage of this plugin is slightly different from the C++ SDK core. To initialize we must access the SplytAnalytics module and call its Init function to declare the Splyt class used by the module.

**NOTE:** This plugin must be initialized before using any functions in the API.
```c++
//Initalize the plugin.
FSplytAnalytics::Get().Init("unreal-example-test", "testuser", "testdevice", "testcontext");
```
The intialization function requires at least these parameters in this order:
- std::string customer_id - Customer ID provided by Splyt.
- std::string user_id - Optional when providing device_id.
- std::string device_id - Optional when providing user_id.
- std::string context - Context of this API call.

The Init function(as well as all other API functions) will throw a splyt_exception when there is some sort of error with initialization. More information on this available in the [Errors and Exceptions section](https://github.com/splytanalytics/splyt-cpp#errors-and-exceptions) in the core C++ SDK.

### Usage
Once the plugin has been initalized we can now use the API functions provided by the core Splyt C++ SDK like so:
```c++
//Begin a transaction.
FSplytAnalytics::Get().splyt->transaction->Begin("game_start", "init", 3600, "GameStart");
```
More examples can be found in the [API Functions section](https://github.com/splytanalytics/splyt-cpp#api-functions) in the core C++ SDK.

### Responses
All API functions, with the exception of Init, return an instance of the SplytResponse class that contains content returned from the network call. The content is an instance of the Json::Value class from the [JsonCpp library](https://github.com/open-source-parsers/jsoncpp). Documentation for the use of this class can be found [here](https://github.com/open-source-parsers/jsoncpp/wiki).

Response Example:
```c++
//Initalize the plugin.
FSplytAnalytics::Get().Init("unreal-example-test", "testuser", "testdevice", "testcontext");

//Get all tuning values for a user.
splytapi::SplytResponse resp = FSplytAnalytics::Get().splyt->tuning->GetAllValues("testuser", splytapi::kEntityTypeUser);

//Get the response content.
Json::Value content = resp.GetContent();

//Get a value from the content as a string.
std::string testval = content["testval"].asString();

//Print the JSON content recieved from the server.
std::cout << "testval value: " + testval << std::endl;
```
Any errors that occur will throw a splyt_exception, this can be handled as shown below.


### Errors and Exceptions
All API functions throw a splyt_exception when an error has occurred, these exceptions contain a SplytResponse holding error information needed to understand the issue. An example for handling these exceptions is shown below.
```c++
//Initalize the plugin.
FSplytAnalytics::Get().Init("unreal-example-test", "testuser", "testdevice", "testcontext");

try {
    splytapi::SplytResponse resp = FSplytAnalytics::Get().splyt->tuning->GetAllValues("testuser", splytapi::kEntityTypeUser);

    //... Do something with the response here.
} catch (splytapi::splyt_exception e) {
    //Get the SplytResponse from the exception.
    splytapi::SplytResponse resp = e.GetResponse();

    //Get the error message from the SplytResponse.
    std::cout << "error: " + resp.GetErrorMessage() << std::endl;
}
```
You can also get the response from the server by using the GetContent() function in SplytResponse class, as shown in the [Responses section](#responses).

### Configuration
This plugin can be configured in the sameway that the core C++ SDK can as shown in the [Configuration section](https://github.com/splytanalytics/splyt-cpp#configuration).

# API Functions
All API functions, with the exception of Init, have the exact same usage as the core C++ SDK as shown in its [API Functions section](https://github.com/splytanalytics/splyt-cpp#api-functions).

**NOTE:** All API functions, with the exception of Init, return a SplytResponse. Information on how to handle this response is shown in the [Responses section](#responses).

**NOTE:** All API functions throw an splyt_exception when an error occurs. Information on how to handle this is shown in the [Errors and Exceptions section](#errors-and-exceptions).