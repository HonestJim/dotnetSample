using System;
using System.Data.SqlClient;
using System.Data;

namespace Samples
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Sample1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//Set the connection string for the database
			string connectionstring="Initial Catalog=TestCatalog; Data Source=myDataSource;user id=admin;password=adminadmin;";
			string tainted_query= "Select name=" + args[1].Clone() + " from Employees";

			//Create Connection and open it
			System.Data.SqlClient.SqlConnection  conn = new SqlConnection(connectionstring);
			conn.Open ();

			//Create an adapter object with a clean string
			SqlDataAdapter adapter = new SqlDataAdapter("Select employeeid, lastname, firstname, city from Employees", connectionstring);
			//Create an adapter object with a directly tainted string
			SqlDataAdapter adapter1 = new SqlDataAdapter(args[1], connectionstring);
			//Create an adapter object with a string contructed froma tainted sub-string
			SqlDataAdapter adapter2 = new SqlDataAdapter(tainted_query, connectionstring);

			//Create a dataset object and fill the values from Employees table
			DataSet oDataSet = new DataSet();
			adapter.Fill(oDataSet, "Contents");

			//Print the records in XML format
			Console.WriteLine(oDataSet.GetXml());
		}
	}
}