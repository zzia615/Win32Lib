using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

/// <summary>
/// 日志
/// </summary>
public class LogManager
{
    int DebugMode = 0;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="DebugMode">1调试 其他非调试</param>
    public LogManager(int DebugMode)
    {
        this.DebugMode = DebugMode;
    }
    /// <summary>
    /// 普通日志
    /// </summary>
    /// <param name="content">内容</param>
    public void Info(string content)
    {
        Logger.Info(content);
    }
    /// <summary>
    /// 错误日志
    /// </summary>
    /// <param name="content">内容</param>
    public void Error(string content)
    {
        Logger.Error(content);
    }
    /// <summary>
    /// 错误日志
    /// </summary>
    /// <param name="ex">内容</param>
    public void Error(Exception ex)
    {
        Logger.Error(ex.ToString());
    }
    /// <summary>
    /// 警告日志
    /// </summary>
    /// <param name="content">内容</param>
    public void Warn(string content)
    {
        Logger.Warn(content);
    }

}


/// <summary>
/// 日志对象
/// </summary>
public sealed class Logger
{
    static string LogName = "JCYY_WEB";
    public static void SetLogName(string logName)
    {
        LogName = logName;
    }
    /// <summary>
    /// 普通日志
    /// </summary>
    /// <param name="data"></param>
    public static void Info(string data)
    {
        Log(LoggerType.INFO, data);
    }
    /// <summary>
    /// 错误日志
    /// </summary>
    /// <param name="data"></param>
    public static void Error(string data)
    {
        Log(LoggerType.ERROR, data);
    }
    /// <summary>
    /// 警告日志
    /// </summary>
    /// <param name="data"></param>
    public static void Warn(string data)
    {
        Log(LoggerType.WARN, data);
    }
    //static ReaderWriterLockSlim writeLock = new ReaderWriterLockSlim();
    static void Log(LoggerType type, string data)
    {
        try
        {
            //writeLock.EnterWriteLock();
            string path = "${AppPath}\\logs";
            //如果配置了AppPath,则默认在程序根目录创建log文件夹
            if (path.Contains("${AppPath}"))
                path = path.Replace("${AppPath}", AppDomain.CurrentDomain.BaseDirectory);
            path = "d:\\hislog";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string logFile = Path.Combine(path, $"{LogName}{DateTime.Now.ToString("yyyyMMdd")}.log");
            if (!File.Exists(logFile))
            {
                File.Create(logFile).Close();
            }
            string msg = $"【{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}】:{type} ";
            File.AppendAllText(logFile, msg, Encoding.UTF8);
            File.AppendAllText(logFile, $"{data}\r\n", Encoding.UTF8);
        }
        catch
        {

        }
        finally
        {
            //writeLock.ExitWriteLock();
        }
    }
}


public enum LoggerType
{
    INFO, ERROR, WARN
}
