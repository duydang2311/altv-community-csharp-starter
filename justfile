set windows-shell := ["cmd", "/c"]

default *args:
    just publish {{args}}
    just run

build *args:
    just build-client {{args}}
    just build-server {{args}}

build-server *args:
    dotnet build ./src/Com.Server.AltV/Com.Server.AltV.csproj {{args}}

build-client *args:
    dotnet build ./src/Com.Client.AltV/Com.Client.AltV.csproj {{args}}

publish *args:
    just publish-client {{args}}
    just publish-server {{args}}

publish-server *args:
    dotnet publish ./src/Com.Server.AltV/Com.Server.AltV.csproj {{args}}

publish-client *args:
    dotnet publish ./src/Com.Client.AltV/Com.Client.AltV.csproj {{args}}

[windows]
run:
    altv-server.exe

[linux]
run:
    ./altv-server

[windows]
update: update-server update-modules update-data

[windows]
update-server:
    wget -N https://cdn.alt-mp.com/voice-server/release/x64_win32/altv-voice-server.exe https://cdn.alt-mp.com/coreclr-module/release/x64_win32/AltV.Net.Host.dll https://cdn.alt-mp.com/coreclr-module/release/x64_win32/AltV.Net.Host.runtimeconfig.json https://cdn.alt-mp.com/data/release/update.json https://cdn.alt-mp.com/server/release/x64_win32/altv-crash-handler.exe https://cdn.alt-mp.com/server/release/x64_win32/altv-server.exe

[windows]
update-modules:
    wget -P ./modules -N https://cdn.alt-mp.com/coreclr-module/release/x64_win32/modules/csharp-module.dll

[windows]
update-data:
    wget -P ./data -N https://cdn.alt-mp.com/data/release/data/vehmodels.bin https://cdn.alt-mp.com/data/release/data/vehmods.bin https://cdn.alt-mp.com/data/release/data/clothes.bin https://cdn.alt-mp.com/data/release/data/pedmodels.bin https://cdn.alt-mp.com/data/release/data/rpfdata.bin https://cdn.alt-mp.com/data/release/data/weaponmodels.bin


[linux]
update: update-server update-modules update-data

[linux]
update-server:
    wget -N https://cdn.alt-mp.com/voice-server/dev/x64_linux/altv-voice-server https://cdn.alt-mp.com/coreclr-module/dev/x64_linux/AltV.Net.Host.dll https://cdn.alt-mp.com/coreclr-module/dev/x64_linux/AltV.Net.Host.runtimeconfig.json https://cdn.alt-mp.com/data/dev/update.json https://cdn.alt-mp.com/server/dev/x64_linux/altv-crash-handler https://cdn.alt-mp.com/server/dev/x64_linux/altv-server

[linux]
update-modules:
    wget -P ./modules -N https://cdn.alt-mp.com/coreclr-module/dev/x64_linux/modules/libcsharp-module.so

[linux]
update-data:
    wget -P ./data -N https://cdn.alt-mp.com/data/dev/data/vehmodels.bin https://cdn.alt-mp.com/data/dev/data/vehmods.bin https://cdn.alt-mp.com/data/dev/data/clothes.bin https://cdn.alt-mp.com/data/dev/data/pedmodels.bin https://cdn.alt-mp.com/data/dev/data/rpfdata.bin https://cdn.alt-mp.com/data/dev/data/weaponmodels.bin
