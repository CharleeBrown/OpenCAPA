namespace OpenCAPA
{
    public class CAPA
    {
        public int CAPA_ID;
        private string status;
        private string origin;
        private string Description;
        private string issuer;
        private DateTime issueDate;
        private object[] Attachments;
        private string CAPA_Reason;
        private Comment comments;

        public CAPA(string _status) => status = _status;

    }
}
