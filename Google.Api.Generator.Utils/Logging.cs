// Copyright 2024 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.IO;
using System.Text;
using static System.FormattableString;

namespace Google.Api.Generator.Utils;

public static class Logging
{
    private static ILogger s_logger = NullLogger.Instance;

    public static void ConfigureForFile(string file)
    {
        s_logger = file is null ? NullLogger.Instance : new FileLogger(file);
    }

    // Static methods to mirror extension methods on ILogger, so we should be able to replace calls to "Logging.LogError" etc
    // with find/replace easily.
    public static void LogTrace(string message, params object[] args) => s_logger.LogTrace(message, args);
    public static void LogDebug(string message, params object[] args) => s_logger.LogDebug(message, args);
    public static void LogInformation(string message, params object[] args) => s_logger.LogInformation(message, args);
    public static void LogError(string message, params object[] args) => s_logger.LogError(message, args);
    public static void LogError(Exception exception, string message, params object[] args) => s_logger.LogError(exception, message, args);
    public static void LogWarning(string message, params object[] args) => s_logger.LogWarning(message, args);
    public static void LogWarning(Exception exception, string message, params object[] args) => s_logger.LogWarning(exception, message, args);

    /// <summary>
    /// Initial really simple implementation of ILogger with no categories etc.
    /// </summary>
    private class FileLogger : ILogger
    {
        private readonly TextWriter _writer;

        public IDisposable BeginScope<TState>(TState state) where TState : notnull =>
            throw new NotImplementedException();

        public bool IsEnabled(LogLevel logLevel) => true;

        internal FileLogger(string file)
        {
            _writer = new StreamWriter(file, append: false, Encoding.UTF8, bufferSize: 0) { AutoFlush = true };
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message = formatter(state, exception);
            string line = Invariant($"{DateTime.UtcNow:yyyy-MM-dd'T'HH:mm:ss.fff} {logLevel} - {message}");
            _writer.WriteLine(line);
        }
    }
}
