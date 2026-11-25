// 重构删除 OpenMir2.SocketComponents 源码树时，MakePlayer 原有的以下 using 被一并移除，
// 类型现已恢复到 OpenMir2（原始位置），通过全局 using 重新导入。
global using SystemModule.SocketComponents.AsyncSocketClient;
global using SystemModule.SocketComponents.Event;
