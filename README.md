# MilkyOS

MilkyOS is a x86 operating system based on Cosmos.

## To Compile

1. Install following:

   - [Visual Studio 2019](https://visualstudio.com)
   - [Cosmos UserKit](https://github.com/CosmosOS/Cosmos/releases/)
   - Make sure you place [XSharp nuget packages](https://github.com/orgs/CosmosOS/packages?repo_name=XSharp) in the right directory, which you can find out after installed two above, and check it in VS2019 -> Options -> Search for `nuget` -> Package Source -> `Cosmos Local Package Feed`.
   - VMWare Player

2. Open `MilkyOS.sln` and right-click on MilkyOS.Core__Asm -> Build.
   > You may find error on bilding first time, don't worry, try again, and it will fix it.

3. Hit `F5` to start debugging.

## Roadmap

- [x] System Call Mechanism
- [ ] More System API
- [ ] Basic Commands
- [ ] Process/Thread Scheduling
- [ ] Executable file
- [ ] Header Files for `gcc`
- [ ] (Maybe) Networking
- [ ] (Maybe) GUI Support
- [ ] (Maybe) User Management
