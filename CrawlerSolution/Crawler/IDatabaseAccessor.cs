using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler
{
    public interface IDatabaseAccessor : IReport
    {
        void AddVulnerabilities(int crawlID, List<String> details);
        
        int newCrawl(string url, string email);

        int addWebsite(string url, string software, string language, string version);

        List<String> RetrieveVulnerabilities(string url);
    }
}
