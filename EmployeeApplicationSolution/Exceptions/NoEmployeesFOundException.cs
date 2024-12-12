namespace EmployeeApplicationSolution.Exceptions
{
    public class NoEmployeesFOundException : Exception
    {
        string msg;
        public NoEmployeesFOundException()
        {
            msg = "An entity with the same key already exists in the repository";
        }
        public NoEmployeesFOundException(string message)
        {
            msg = message;
        }
        public override string Message => msg;
    }
}
