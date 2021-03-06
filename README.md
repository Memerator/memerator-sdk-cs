# memerator-sdk-cs

An implementation of the Memerator API in C#.

## Getting Started

To install and use the SDK, follow the steps below.

### Prerequisites

Memerator for C# depends on .NET Core version 2.1 or above, and requires NuGet package Newtonsoft.Json 12.0.3 or later.

### Installing

As of now, you can download the .dll from the Actions tab.

1) Go to [here](https://github.com/Memerator/memerator-sdk-cs/actions?query=branch%3Amaster+is%3Acompleted+event%3Apush)
2) Click the latest (highest) workflow
3) Click `Memerator.API.dll` to download the only artifact.

### Usage

Here is some sample code.

To get an API Key, go to the [API Authentication page](https://memerator.me/api/auth)

```c#
using System;
using Memerator.API;
using Memerator.API.Objects;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate MemeratorAPI
            MemeratorAPI api = new MemeratorAPI("[your api key]");
            // Get meme "aaaaaaa"
            Meme meme = api.GetMeme("aaaaaaa");
            // Return caption
            Console.WriteLine("Caption for meme aaaaaaa: " + meme.Caption());

            // To access the API directly
            JObject data = JObject.Parse(API.get("some/route"));
            Console.WriteLine("Check out: " + data["response"].Value<string>());
        
            // Change Key
            api.SetToken("MyNewToken");
        }
    }
}
```

## Built With

* .NET Core 2.1 - The framework used
* [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) - Handling JSON

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/Memerator/memerator-sdk-cs/tags).

## Authors

* **[Chew](https://github.com/Chew)** - *Initial work*

See also the list of [contributors](https://github.com/Memerator/memerator-sdk-cs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
