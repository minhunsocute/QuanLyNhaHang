using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace WindowsFormsApp1
{
    public class TableInstance
    {
        private string conStr = @"Data Source=LAPTOP-DI57MUOG;Initial Catalog=QLNH;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter myAdapter;
        private SqlCommand comm;
        private DataSet ds;
        private DataTable dt;

        private static TableInstance _instance;
        public static TableInstance Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TableInstance();
                return TableInstance._instance;
            }
            private set { TableInstance._instance = value; }
        }
        private TableInstance() { }

        public List<Table> LoadTableList()
        {
            List<Table> table = new List<Table>();
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlStringUpdate = "EXEC UPDATE_TABLE";
            comm = new SqlCommand(sqlStringUpdate, conn);
            try
            {
                object run = comm.ExecuteNonQuery();
            }
            catch { }
            string sqlString = "SELECT * FROM TABLE_FOOD";
            myAdapter = new SqlDataAdapter(sqlString, conn);
            ds = new DataSet();
            myAdapter.Fill(ds, "ID");
            dt = ds.Tables["ID"];
            
            foreach (DataRow item in dt.Rows)
            {
                Table t = new Table(item);
                table.Add(t);
            }
            return table;
        }
    }
}
