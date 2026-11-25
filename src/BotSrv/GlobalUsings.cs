// 重构时 BotSrv 原有的以下 using 被一并移除，但代码仍引用其中类型，通过全局 using 重新导入。
global using SystemModule.SocketComponents.AsyncSocketClient;
global using SystemModule.SocketComponents.Event;
global using OpenMir2.Hosts;
