using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.ComponentModel;

class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 4 && args[3] == "run")
            {
                var crawler = new Crawler.CrawlerController(args[0], Int32.Parse(args[1]), args[2]);

            }else if (args.Length == 0)
            {
                Console.WriteLine("Version {0}", Assembly.GetEntryAssembly().GetName().Version.ToString());
                Console.Write("Enter the site to crawl>>");
                String path = Console.ReadLine();
                Console.Write("Enter the crawl level>>");
                String level = Console.ReadLine();
                Console.Write("Enter e-mail address to respond to>>");
                String email = Console.ReadLine();
                Console.WriteLine("Crawling, press \'c\' to cancel the crawl");

                Debug.Assert(!String.IsNullOrWhiteSpace(path));
                Debug.Assert(!String.IsNullOrWhiteSpace(level));

                string[] arguments = new string[3];

                arguments[0] = path;
                arguments[1] = level;
                arguments[2] = email;

                var worker = new Worker(arguments);
                do
                {
                    while(!Console.KeyAvailable && worker.getIsBusy())
                    {
                        Thread.Sleep(100);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.C && worker.getIsBusy());

                if(worker.getIsBusy())
                {
                    worker.cancelWork();
                }
            }else
            {
                Console.Out.WriteLine("Correct useage:\n\nInteractive:\n\tCrawler.exe\nAutomatic:\n\tCrawler.exe <url> <crawl level> <response email address>");
                Console.Read();
            }


        }
        
    }

public class Worker
{
    private BackgroundWorker worker;

    public Worker(string[] arguments)
    {
        this.worker = new BackgroundWorker();
        worker.WorkerSupportsCancellation = true;
        worker.WorkerReportsProgress = true;
        worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        worker.RunWorkerAsync(arguments);
    }

    public void cancelWork()
    {
        this.worker.CancelAsync();
        Console.WriteLine("Crawling Canceled. Press any key to continue...");
    }

    public bool getIsBusy()
    {
        return worker.IsBusy;
    }

    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        var arguments = (string[]) e.Argument;

        var crawler = new Crawler.CrawlerController(arguments[0], Int32.Parse(arguments[1]), arguments[2]);
    }

    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            Console.Write("Crawling Error: " + e.Error.Message);
            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }else
        {

            Console.WriteLine("Crawling Completed. Press any key to continue...");
            Console.Read();
        }
    }
}