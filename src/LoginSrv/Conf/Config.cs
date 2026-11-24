namespace LoginSrv.Conf
{
    public class Config
    {
        /// <summary>
        /// 是否显示调试日志
        /// </summary>
        public bool ShowDebug;
        /// <summary>
        /// 日志等级
        /// </summary>
        public int ShowLogLevel;
        public string sDBServer;
        public int nDBSPort;
        public string sFeeServer;
        public int nFeePort;
        public string sLogServer;
        public int nLogPort;
        public string sGateAddr;
        public int nGatePort;
        public string sServerAddr;
        public int nServerPort;
        public string sMonAddr;
        public int nMonPort;
        public string sGateIPaddr;
        /// <summary>
        /// 测试
        /// </summary>
        public bool TestServer;
        /// <summary>
        /// 是否允许创建账号
        /// </summary>
        public bool EnableMakingID;
        public bool DynamicIPMode;
        public IList<string> ServerNameList;
        public int RouteCount;
        public GateRoute[] GateRoute;
        public string ConnctionString;

        public Config()
        {
            sDBServer = "127.0.0.1";
            nDBSPort = 16300;
            sFeeServer = "127.0.0.1";
            nFeePort = 16301;
            sLogServer = "127.0.0.1";
            nLogPort = 16301;
                // 默认改为本地地址，避免在运行时对 '*' 调用 IPAddress.Parse 抛出异常
                // 如果需要监听所有地址，可在运行目录的 logsrv.conf 中将 GateAddr 设置为 0.0.0.0
                sGateAddr = "127.0.0.1";
            nGatePort = 5500;
            // 使用本地回环地址作为默认，避免对 '*' 调用 IPAddress.Parse 时抛出异常
            // 可在运行目录的 logsrv.conf 中设置为 0.0.0.0 来监听所有地址
            sServerAddr = "127.0.0.1";
            nServerPort = 5600;
            // 监控地址也默认改为本地回环地址
            sMonAddr = "127.0.0.1";
            nMonPort = 3000;
            TestServer = true;
            EnableMakingID = true;
            DynamicIPMode = false;
            GateRoute = new GateRoute[60];
            ConnctionString = "server=127.0.0.1;uid=root;pwd=123456;database=mir2_account;";
            ShowDebug = false;
            ShowLogLevel = 1;
        }
    }
}

