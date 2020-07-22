namespace API.Helpers
{

    public class Response : BaseResponse
    {
        public static Response Success = new Response(0, "The requested operation was successfully performed");
        public static Response OperationError = new Response(1, "operation error (not identified)");
        public static Response InputOutError = new Response(2, "It was not possible to save the Json file");
        public static Response InvalidCustomer = new Response(3, "Invalid customer identifier");
        public static Response InvalidAccount = new Response(4, "Invalid account identifier");

        public Response(int id, string name)
          : base(id, name)
        {
        }
    }
}
