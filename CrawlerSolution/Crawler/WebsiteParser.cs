using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;

namespace Crawler
{
    //This class parses all of the files found and logs all of them
    class WebsiteParser : CrawlerPlugin
    {
        private FileSystemInteractor fsInteractor;

        public WebsiteParser(Website website, IDatabaseAccessor db, int crawlID, Log l, FileSystemInteractor fs)
            : base(website, db, crawlID, l)
        {
            fsInteractor = fs;
        }

       public override List<String> analyzeSite()
       {
           int count = 0;
            log.writeInfo("Beginning website directory parsing");
            log.writeDebug("Beginning to list files");

           var file = new StreamWriter(fsInteractor.BasePath() + @"\\log_filegraph.txt");
           Debug.Assert(file != null);
            file.WriteLine(fsInteractor.MakeFilesystemGraph());
           file.Close();

            log.writeDebug("DONE");
            log.writeDebug("Done finding files");
            return new List<String>();
        }
    }
}
