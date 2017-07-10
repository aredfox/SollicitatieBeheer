namespace Beheerdersportaal.Api.Infrastructuur.Handlers
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            HasSucceeded = true;
            Error = null;
        }

        public bool HasSucceeded { get; set; }
        public string Error { get; set; }        
    }
}
