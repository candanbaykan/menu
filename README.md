# Menu

Menu is a console-based tool for displaying and executing customizable menus defined in YAML files. It allows users to define commands and environment variables in a structured format and execute them interactively.

## Requirements

- .NET 9.0 SDK

## Building the Project

To build the project, run the following command in the project root directory. Once completed, it will print the directory of the compiled executable.

```sh
dotnet publish
```

## Installation

1. Rename the executable to your preference. (My preferences are `menu.exe` on Windows and `menu` on Linux so it is referred that way on the next steps.)
2. Place the `menu` executable in a directory which is included in your operating system's `PATH` environment variable.
3. Restart your terminal to apply the changes.
4. Verify the installation by running the following command:

```sh
menu --help
```
