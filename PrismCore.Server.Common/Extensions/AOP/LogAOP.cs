using Castle.DynamicProxy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrismCore.Server.Common.Extensions.AOP
{
    public class LogAOP : IInterceptor
    {
        //支持单个写线程和多个读线程的锁
        private static readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();

        private static readonly string FileName = "AOPInterceptor-" + DateTime.Now.ToString("yyyyMMddHH") + ".log";
        public void Intercept(IInvocation invocation)
        {
            string UserName = "";
            //记录被拦截方法信息的日志信息
            var dataIntercept = "" +
                $"【当前操作用户】：{ UserName} \r\n" +
                $"【当前执行方法】：{ invocation.Method.Name} \r\n" +
                $"【携带的参数有】： {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())} \r\n";

            try
            {
                //在被拦截的方法执行完毕后 继续执行当前方法，注意是被拦截的是异步的
                invocation.Proceed();

                var type = invocation.Method.ReturnType;
                var resultProperty = type.GetProperty("Result");
                //dataIntercept += ($"【执行完成结果】：{JsonConvert.SerializeObject(resultProperty.GetValue(invocation.ReturnValue))}");
                dataIntercept += $"【执行完成】：{invocation.ReturnValue}";
                Parallel.For(0, 1, e =>
                {
                    WriteLog(new[] { dataIntercept });
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void WriteLog(string[] parameters, bool isHeader = true)
        {
            try
            {
                //进入写模式
                Lock.EnterWriteLock();

                //获取或创建文件夹
                var path = Path.Combine(Directory.GetCurrentDirectory(), "AOPLog");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //获取log文件路径
                var logFilePath = Path.Combine(path, FileName);

                //转换及拼接字符
                var logContent = string.Join("\r\n", parameters);
                if (isHeader)
                {
                    logContent = "---------------------------------------\r\n"
                                 + DateTime.Now + "\r\n" + logContent + "\r\n";
                }

                //写入文件
                File.AppendAllText(logFilePath, logContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                //退出写入模式，释放资源占用
                Lock.ExitWriteLock();
            }
        }
    }
}
