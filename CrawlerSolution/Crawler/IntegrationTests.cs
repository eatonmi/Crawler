﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Crawler
{
    [TestFixture]
    class IntegrationTests
    {
        [Test]
        public void TestDirectory()
        {
            string path = "www.google.com_" + DateTime.Now.ToString("hh-mm_MM-dd-yyyy");
            Website website = new Website("google.com",path);
            Bot bot = new Bot(website,null,null,null,null);
            bot.CrawlSite(0);
            Assert.IsTrue(Directory.Exists(path));
        }

        [Test]
        public void TestDownloadFile()
        {
            string path = "www.google.com_" + DateTime.Now.ToString("hh-mm_MM-dd-yyyy");
            Website website = new Website("google.com", path);
            Bot bot = new Bot(website, null, null, null, null);
            bot.CrawlSite(0);
            Assert.IsTrue(File.Exists(path+"/testfile.html"));//TODO: Change test file
        }

        [Test]
        public void Test404ReturnCode()
        {
            string path = "www.google.com_" + DateTime.Now.ToString("hh-mm_MM-dd-yyyy");
            Website website = new Website("google.com/doesnotexist.html", path);
            Bot bot = new Bot(website, null, null, null, null);
            CrawlResult cr = bot.CrawlSite(0);
            Assert.AreEqual(cr.ReturnCode,404);
            Assert.AreEqual("NotFound",cr.ReturnStatus);
        } 
        //        [Test]
        //        public void TestDirectory()
        //        {
        //            Bot mockBot = MockRepository.GenerateStub<Bot>("www.test.com", 0, null, null, null);
        //            using (mock.Record())
        //            {
        //                mockBot.C
        //                
        //            }
        //            Bot b = new Bot("www.test.com",0,null,null,null);
        //            b.CrawlSite();
        //            //Assert.IsTrue(Directory.Exists("www.test.com"));
        //            path = "www.test.com_" + DateTime.Now.ToString("hh-mm_MM-dd-yyyy");
        //            Assert.IsTrue(Directory.Exists(path));
        //        }
        //
        //        [Test]
        //        public void TestDownloadFile()
        //        {
        //            Bot b = new Bot("www.test.com", 0, null, null, null);
        //            b.CrawlSite();
        //            Assert.IsTrue(File.Exists(path+"/testfile.html"));
        //            
        //        }
        //        [Test]
        //        public void Test404ReturnCode()
        //        {
        //            Bot b = new Bot("www.google.com/doesntexist", 0, null, null, null);
        //            CrawlResult cr = b.CrawlSite();
        //            Assert.AreEqual(cr.ReturnCode,404);
        //            Assert.AreEqual("NotFound",cr.ReturnStatus);
        //        } 
        //
        //        [Test]
        //        public void Test200ReturnCode()
        //        {
        //            Bot b = new Bot("www.google.com", 0, null, null, null);
        //            CrawlResult cr = b.CrawlSite();
        //            Assert.AreEqual(cr.ReturnCode,200);
        //            Assert.AreEqual(cr.ReturnStatus,"OK");
        //        }

        //        [Test]
        //        public void TestChristmasHTML()
        //        {
        //            Bot b = new Bot("www.isitchristmasyet.com", 0, null, null, null);
        //            CrawlResult cr = b.CrawlSite();
        //            
        //       }
    }
}
