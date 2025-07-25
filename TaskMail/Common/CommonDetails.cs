namespace TaskMail.Common
{
    public class CommonDetails
    {
        public static int StatusCode(int status)
        {
            int StatusCode = 0;

            if (status == 0 || status == 1 || status == 2 || status == 4 || status == 5 || status == 6)
            {
                StatusCode = 200;
            }
            else if (status == -1)
            {
                StatusCode = 500;
            }
            else if (status == 3)
            {
                StatusCode = 409;
            }
            else if (status == 5)
            {
                StatusCode = 406;
            }
            else if (status == 6)
            {
                StatusCode = 450;
            }
            return StatusCode;
        }
    }
}
