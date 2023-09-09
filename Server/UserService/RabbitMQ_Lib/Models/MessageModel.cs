namespace RabbitMQ_Lib.Models
{
    public class MessageModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string? ObjectInMessage { get; set; } //Json
        public string? Content { get; set; }
        public int Action { get; set; }

        /*
        <Action Type>
            0 : Nothing to do
            1 : Created
            2 : Find
        */
        public int Status { get; set; }

        /*
        <Status Type>
            -1: Fail, NotFound
            0 : Nothing (Default)
            1 : Successful, Found
        */
    }
}
