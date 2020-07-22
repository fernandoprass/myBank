namespace API.Helpers
{

    public class Response : BaseResponse
    {
        public static Response Success = new Response(0, "The requested operation was successfully performed");
        public static Response Failure = new Response(1, "Failed to perform requested operation, try again later");
        public static Response InvalidCustomer = new Response(2, "Invalid customer identifier");
        public static Response InvalidInitialValue = new Response(3, "The initial value must be greater than or equal to zero");

        public Response(int id, string name)
          : base(id, name)
        {
        }
    }
}
