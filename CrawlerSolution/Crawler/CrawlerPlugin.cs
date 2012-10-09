using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler
{
    public abstract class CrawlerPlugin : IReport
    {
        protected IDatabaseAccessor db;
        protected Website website;
        protected int crawlID;
        protected Log log;

        /* Class methods */
        public CrawlerPlugin(Website website, IDatabaseAccessor db, int crawlID, Log l)
        {
            this.db = db;
            this.website = website;
            this.crawlID = crawlID;
            this.log = l;
        }

        protected void addToDatabase(List<String> results)
        {
            db.AddVulnerabilities(this.crawlID, results);
        }

        /* Abstract methods
         * TODO:  Add MustOverride*/
        public abstract List<String> analyzeSite();

        public void PrintReport()
        {
            System.Console.Out.WriteLine("CrawlerPlugin Report:");
            System.Console.Out.WriteLine("  db present? = " + (db != null ? "True" : "False"));
            System.Console.Out.WriteLine("  website present? = " + (website != null ? "True" : "False"));
            System.Console.Out.WriteLine("  Crawl ID = " + this.crawlID.ToString());
            System.Console.Out.WriteLine("  log present? = " + (log != null ? "True" : "False"));
        }
    }
}
