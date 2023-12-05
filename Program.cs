using System.Data.SqlClient;

namespace MySalesAB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=MySales;Trusted_Connection=True;MultipleActiveResultSets=True"; //Vi sparar en sträng som connection väg till databasen
            int customerToDelete = 4; //Här sätter vi vilket värde vi vill tilldela CustomerId nedan
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) //Vi ansluter till databasen genom att göra en ny SqlConnection och skickar med vår sträng med vägen in till den.
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("delete from customer where CustomerId = @CustomerId", connection)) //Vi använder oss av using för att bara köra detta medans vi kör. Sen väljer vi att köra SqlCommand för att kunna ställa en query
                                                                                                                                //mot databasen. Där är det samma kommando som vi skriver in i query, sen bifogar vi vår connection som vi anropat.
                    {
                        command.Parameters.AddWithValue("@CustomerId", customerToDelete); //Här skapar vi en parameter för @CustomerId för att kunna styra det med tex ReadLine input lite enklare.
                        int affecteRows = command.ExecuteNonQuery(); //Vi sparar i en int, det antalet rader som vi deletat med kommandot ExecuteNonQuery för att se vad vårt command precis gjorde.
                        if (affecteRows > 0)
                        {
                            Console.WriteLine("Antal rader: " + affecteRows);
                        }
                        else
                        {
                            Console.WriteLine("Inga rader borttagna");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("no");
                throw;
            }
        }
    }
}
