/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System;
using System.Reflection;

namespace JavaDocToMarkdownConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length < 2)
            {
                Console.WriteLine(string.Join(' ', args));
                Usage();
                return;
            }

            Console.WriteLine(string.Format("Converting '{0}' to '{1}'...", args[0], args[1]));

            //new DocConverter().ConvertDoc(@"F:\Projects\_Test\lucene-solr-4.8.0\lucene\demo\src\java\overview.html", @"F:\Projects\lucenenet\");
            new DocConverter().Convert(args[0], args[1]);

            Console.WriteLine("Conversion complete!");

#if DEBUG
            Console.ReadKey();
#endif
        }

        private static void Usage()
        {
            var versionString = Assembly.GetEntryAssembly()
                                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                .InformationalVersion
                                .ToString();

            Console.WriteLine($"javadoc2markdown v{versionString}");
            Console.WriteLine("-------------");
            Console.WriteLine("Usage: dotnet javadoc2markdown <LUCENE DIRECTORY> <LUCENENET DIRECTORY>");
            Console.WriteLine();
            Console.WriteLine(" Arguments:");
            Console.WriteLine(@"   LUCENE DIRECTORY: The root directory of the lucene project to convert (excluding SOLR). Example: F:\lucene-solr-4.8.0\lucene\");
            Console.WriteLine(@"   LUCENENET DIRECTORY: The root directory of Lucene.NET. Example: F:\Projects\lucenenet\");
        }
    }
}
