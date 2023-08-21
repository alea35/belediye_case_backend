namespace TestCaseWebApp.Utils
{
    public class GlobalData
    {

        public string JWTToken { get; set; } = "";

        private GlobalData()
        {

        }
        private static object lockObject = new object();
        private static GlobalData instance = null;
        public static GlobalData Instance
        {
            get
            {
                lock (lockObject)
                {

                    if (instance == null)
                    {
                        instance = new GlobalData();
                    }

                    return instance;
                }
            }
        }

    }
}
