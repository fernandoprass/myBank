namespace API.Implementation
{
    public abstract class Repository
    {
        protected readonly string Filename;


        protected Repository(string filename)
        {
            Filename = filename;
        }
    }
}
