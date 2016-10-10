using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Net;
using System;
using System.IO;

namespace Snouser
{
    //enum RF2format { SCT_RF2_FULL, SCT_RF2_SNAPSHOT, SCT_RF2_DELTA };   
    struct RF2format
    {
        public const string Full = "SCT_RF2_FULL";
        public const string Snapshot = "SCT_RF2_SNAPSHOT";
        public const string Delta = "SCT_RF2_DELTA";
    }

    class SCTsyndication
    {
        private string SyndicationURL = "https://api.healthterminologies.gov.au/syndication/v1/syndication.xml";
        //string releaseType = "SCT_RF2_DELTA";
        //private string codeSystemURIv = currentVersion;
        //string codeSystemURI = codeSystemURIv.Substring(0, codeSystemURIv.Length - 17);        
        
        public bool IsUpToDate(string currentVersion)
        {
            bool status = true;

            //specify security protocol, else gets nowhere.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            XmlReader xmlrdr = XmlReader.Create(SyndicationURL);
            Atom10FeedFormatter atmrdr = new Atom10FeedFormatter();
            atmrdr.ReadFrom(xmlrdr);

            //get all the RF2 deltas in the feed
            foreach (SyndicationItem item in atmrdr.Feed.Items.Where(e => e.Categories.First().Name == RF2format.Delta))
            {
                //filter to just the delta with relevant base version
                var baseVersion = item.ElementExtensions.Where(e => e.OuterName == "sctBaseVersion").First().GetObject<XmlElement>();
                if (baseVersion.InnerText == currentVersion)
                {
                    var link = item.Links.FirstOrDefault();
                    status = false;
                }
            }
            return status;
        }

        public Uri FetchDeltaURL(string currentVersion)
        {
            XmlReader xmlrdr = XmlReader.Create(SyndicationURL);
            Atom10FeedFormatter atmrdr = new Atom10FeedFormatter();
            atmrdr.ReadFrom(xmlrdr);
            string updateLink = null;

            //get all the RF2 deltas in the feed
            foreach (SyndicationItem item in atmrdr.Feed.Items.Where(e => e.Categories.First().Name == RF2format.Delta))
            {
                //filter to just the delta with relevant base version
                var baseVersion = item.ElementExtensions.Where(e => e.OuterName == "sctBaseVersion").First().GetObject<XmlElement>();
                if (baseVersion.InnerText == currentVersion)
                {
                    var link = item.Links.FirstOrDefault();
                    updateLink = link.Uri.ToString();
                }
            }

            Uri updateUri = new Uri(updateLink);

            return updateUri;
        }

        public string FetchDeltaVersion(string currentVersion)
        {
            XmlReader xmlrdr = XmlReader.Create(SyndicationURL);
            Atom10FeedFormatter atmrdr = new Atom10FeedFormatter();
            atmrdr.ReadFrom(xmlrdr);
            string updateVersion = null;

            //get all the RF2 deltas in the feed
            foreach (SyndicationItem item in atmrdr.Feed.Items.Where(e => e.Categories.First().Name == RF2format.Delta))
            {
                //filter to just the delta with relevant base version
                var baseVersion = item.ElementExtensions.Where(e => e.OuterName == "sctBaseVersion").First().GetObject<XmlElement>();
                if (baseVersion.InnerText == currentVersion)
                {
                    var newDeltaVersion = item.ElementExtensions.Where(e => e.OuterName == "contentItemVersion").First().GetObject<XmlElement>();
                    updateVersion = newDeltaVersion.InnerText;
                }
            }
            return updateVersion;
        }

        public string DownloadFile(Uri patchUrl)
        {
            string patchDirectory = Directory.GetCurrentDirectory() + @"\Updates\";

            if (!Directory.Exists(patchDirectory))
            {
                Directory.CreateDirectory(patchDirectory);
            }

            string filename = System.IO.Path.GetFileName(patchUrl.LocalPath);
            string patchLocation = string.Concat(patchDirectory, filename);
            
            using (var client = new WebClient())
            {
                string id = globalArguments.client_id;
                string secret = globalArguments.client_secret;

                NCTS.NCTSAuthentication authenticator = new NCTS.NCTSAuthentication(id, secret);
                client.Headers.Add("Authorization", authenticator.FetchTokenValue());               

                client.DownloadFile(patchUrl, patchLocation);
            }

            return patchLocation;
        }
    }
}
