namespace ProductClientHub.Communication.Responses
{
    public class ResponseClientJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<ResponseShortProductJson> Products { get; set; } = [];
    }
}
