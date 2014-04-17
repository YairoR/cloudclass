using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestration
{

    

    public class BlobFileresult
    {
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

        public BlobFileresult(string fileName, Uri absoluteUri)
        {
            m_fileName = fileName;
            m_absoluteUri = absoluteUri;
        }

    }
}
