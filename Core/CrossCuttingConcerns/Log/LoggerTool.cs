using Castle.Components.DictionaryAdapter.Xml;
using Castle.DynamicProxy;
using Core.Utilities.Results;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logger
{
    public class LoggerTool
    {
        public static void DebugLoggerService(IInvocation invocation)
        {
            string connnectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LogCourseDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            string tableName = "Logs";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("C:\\Users\\ITopya\\Desktop\\Tobeto\\UdemyProject\\Core\\CrossCuttingConcerns\\Log\\log.txt")
                .WriteTo.MSSqlServer(connnectionstring, tableName)
            .CreateLogger();

            IResult result = invocation.ReturnValue as IResult;

            try
            {
                Log.Debug("->Operation : " + invocation.Method.Name +
                    " ->Type of: " + invocation.Arguments[0] +
                    " ->Details: " + result.LogMessage
                    );
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

    }
}