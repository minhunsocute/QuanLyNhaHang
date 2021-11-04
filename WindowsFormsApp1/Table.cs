using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApp1
{
    public class Table
    {

        public Table(int id,string name,string status)
        {
            this.iD = id;
            this.name = name;
            this.status = status;
        }
        public Table(DataRow row)
        {
            this.iD = int.Parse(row["ID"].ToString());
            this.name = row["NAME"].ToString(); 
            this.status = row["STATUS"].ToString();
        }
        private int iD;    
        public int ID { get => iD; set => iD = value; }
        private string name;
        public string Name { get => name; set => name = value; }
        private string status;
        public string Status { get => status; set => status = value; }
        
    }
}
