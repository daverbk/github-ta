using NLog;
using NLog.Config;
using NLog.Targets;
using Xunit.Abstractions;

namespace Domain.Configuration;

public static class LoggerForXunitSetUp
{
    private const string XunitTargetName = "Xunit";
    private const string XunitNamePattern = "*";

    public static void SetUp(ITestOutputHelper testOutputHelper)
    {
        var target = new MethodCallTarget(XunitTargetName, (logEventInfo, _) => testOutputHelper.WriteLine(logEventInfo.FormattedMessage));
        var config = new LoggingConfiguration();
        
        config.LoggingRules.Add(new LoggingRule(XunitNamePattern, LogLevel.Info, target));
        
        LogManager.Configuration = config;
    }
}
