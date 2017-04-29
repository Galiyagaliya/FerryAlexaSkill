using System;
using System.Collections.Generic;
using NLog;
using Ferry.Domain;
using Ferry.Model;
using NUnit.Framework;

namespace FerryTests
{
    [TestFixture]
    public class WsdotServiceTests
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void GetTerminalBasicsByIdTest()
        {
            var fs = new FerryService();
            try
            {
                var terminalTask = fs.GetAsync<TerminalBasics>("7");
                terminalTask.Wait();
                var terminal = terminalTask.Result;


                Assert.NotNull(terminal);
                Assert.AreEqual("7", terminal.TerminalId);
                Assert.AreEqual("4", terminal.RegionId);
                Assert.AreEqual("Seattle", terminal.TerminalName);
            }
            catch (Exception e)
            {
                Logger.Debug(e);
            }

        }
    }


}