
namespace SOUKSAMLANE_Hugo_TP3_ST2TRD.Properties
{
    public class StartClass
    {
        public static void Main()
        {
            Queries all_queries = new Queries();
            all_queries.run_queries();

            Thread_Printer threads_ = new Thread_Printer();
            threads_.run_threads();

        }
    }
}