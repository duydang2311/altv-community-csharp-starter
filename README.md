# Starter project for alt:V C\#

The starter project provides a simple setup of [.NET generic host](https://learn.microsoft.com/en-us/dotnet/core/extensions/generic-host), [Marten](https://martendb.io/) database, a project structure inspired by [Vertical Slice Architecture](https://www.jimmybogard.com/vertical-slice-architecture/) and some simple code examples.

## Development

This project uses [just](https://github.com/casey/just) (a command runner) for running some frequently used commands. I created a [justfile](https://github.com/duydang2311/altv-community-csharp-starter/blob/main/justfile) with a set of default recipes.

*But you don't have to use it. Feel free to use your favourite way to run commands/scripts.*

### Download or update alt:V server files

Execute `update` recipe using just:

```bash
just update
```

### Build

Execute `build` recipe using just:

```bash
just build
```

### Publish

Execute `publish` recipe using just. At this step, all output files will be copied to resources folder as configured in `.csproj` files.

```bash
just publish
```

This recipe also receives rest parameters and pass it to `dotnet` command. If you wish to publish the project with Debug configuration, use this:

```bash
just publish -c Debug
```

### Run

Execute `run` recipe using just:

```bash
just run
```

### Notes

There is a default recipe if you don't specify any recipe for just which will execute both `publish` and `run` recipes. If you want to run the project after publishing, then just type this in the shell:

```bash
just
```
