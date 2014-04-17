using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestration
{
    public class BlobFileresult
    {
        private DateTime m_lastModified;

        public DateTime LastModified
        {
            get { return m_lastModified; }
            set { m_lastModified = value; }
        }
        private DateTime m_created;

        public DateTime Created
        {
            get { return m_created; }
            set { m_created = value; }
        }

        private string m_owner;

        public string Owner
        {
            get { return m_owner; }
            set { m_owner = value; }
        }

        private string m_fileName;

        public string FileName
        {
            get { return m_fileName; }
            set { m_fileName = value; }
        }
        private Uri m_absoluteUri;

        public Uri AbsoluteUri
        {
            get { return m_absoluteUri; }
            set { m_absoluteUri = value; }
        }

        public BlobFileresult(string fileName, Uri absoluteUri,string owner,DateTime lastModified)
        {
            m_fileName = fileName;
            m_absoluteUri = absoluteUri;
            m_owner = owner;
            m_lastModified = lastModified;

        }

    }
}
