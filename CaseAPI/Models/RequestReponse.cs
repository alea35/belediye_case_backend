namespace CaseAPI.Models
{
    public class RequestReponse
    {
        public RequestReponse()
        {
            Errors = new List<string>();
        }
        public bool IsOk { get; set; }
        public List<string> Errors { get; set; }


       
    }
}
