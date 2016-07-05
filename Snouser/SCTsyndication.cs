using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace Snouser
{
    class SCTsyndication
    {
        private string SyndicationURL = "http://syndication.aws.cti/artifactory/maven-repo/au/gov/ncts/ncts-syndication/develop-SNAPSHOT/ncts-syndication-develop-SNAPSHOT.xml";
        //string releaseType = "SCT_RF2_DELTA";
        //private string codeSystemURIv = currentVersion;
        //string codeSystemURI = codeSystemURIv.Substring(0, codeSystemURIv.Length - 17);        

        public bool IsUpToDate(string currentVersion)
        {
            bool status = true;

            XmlReader xmlrdr = XmlReader.Create(SyndicationURL);
            Atom10FeedFormatter atmrdr = new Atom10FeedFormatter();
            atmrdr.ReadFrom(xmlrdr);

            //get all the RF2 deltas in the feed
            foreach (SyndicationItem item in atmrdr.Feed.Items.Where(e => e.Categories.First().Name == "SCT_RF2_DELTA"))
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

        public string FetchDeltaURL(string currentVersion)
        {
            XmlReader xmlrdr = XmlReader.Create(SyndicationURL);
            Atom10FeedFormatter atmrdr = new Atom10FeedFormatter();
            atmrdr.ReadFrom(xmlrdr);
            string updateLink = null;

            //get all the RF2 deltas in the feed
            foreach (SyndicationItem item in atmrdr.Feed.Items.Where(e => e.Categories.First().Name == "SCT_RF2_DELTA"))
            {
                //filter to just the delta with relevant base version
                var baseVersion = item.ElementExtensions.Where(e => e.OuterName == "sctBaseVersion").First().GetObject<XmlElement>();
                if (baseVersion.InnerText == currentVersion)
                {
                    var link = item.Links.FirstOrDefault();
                    updateLink = link.Uri.ToString();
                }
            }
            return updateLink;
        }

        public string FetchDeltaVersion(string currentVersion)
        {
            XmlReader xmlrdr = XmlReader.Create(SyndicationURL);
            Atom10FeedFormatter atmrdr = new Atom10FeedFormatter();
            atmrdr.ReadFrom(xmlrdr);
            string updateVersion = null;

            //get all the RF2 deltas in the feed
            foreach (SyndicationItem item in atmrdr.Feed.Items.Where(e => e.Categories.First().Name == "SCT_RF2_DELTA"))
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

    }
}
