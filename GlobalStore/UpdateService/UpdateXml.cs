using System;

using System.Net;
using System.Xml;

namespace GlobalStore.UpdateService
{
    internal class UpdateXml
    {
        private Version version;
        private Uri uri;
        private string fileName;
        private string md5;
        private string description;
        private string launchArgs;

        internal Version Version
        {
            get { return this.version; }
        }
        internal Uri Uri
        {
            get { return this.uri; }
        }
        internal string FileName
        {
            get { return this.fileName; }
        }
        internal string MD5
        {
            get { return this.md5; }
        }
        internal string Description
        {

            get { return this.description; }
        }
        internal string LaunchArgs
        {
            get { return this.launchArgs; }
        }

        internal UpdateXml(Version version, Uri uri, string fileName, string md5, string description, string launchArgs)
        {
            this.version = version;
            this.md5 = md5;
            this.description = description;
            this.uri = uri;
            this.launchArgs = launchArgs;
            this.fileName = fileName;
        }
        internal bool IsNewerThan(Version version)
        {
            return this.version > version;
        }
        internal static bool ExistsOnServer(Uri location)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location.AbsoluteUri);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                resp.Close();
                return resp.StatusCode == HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }
        internal static UpdateXml Parse(Uri location, string appID)
        {
            Version version = null;
            string url = "", fileName = "", md5 = "", description = "",
                launchArgs = "";
            try {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(location.AbsoluteUri);
                XmlNode xmlNode = xmlDocument.DocumentElement.SelectSingleNode("//update[@appID='"+ appID + "']");
                if (xmlNode == null)
                {
                    return null;
                }
                version = Version.Parse(xmlNode["version"].InnerText);
                url = xmlNode["url"].InnerText;
                fileName = xmlNode["fileName"].InnerText;
                md5 = xmlNode["md5"].InnerText;
                description = xmlNode["description"].InnerText;
                launchArgs = xmlNode["launchArgs"].InnerText;
                return new UpdateXml(version, new Uri(url), fileName, md5, description, launchArgs);
            }
            catch
            {
                return null;
            }

        }
    }
}
