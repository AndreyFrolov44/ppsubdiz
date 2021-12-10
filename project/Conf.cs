using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace project
{
    public static class Conf
    {
        public static String connString = "Server=141.8.192.151;Database=f0608526_ppsubdiz;port=3306;User Id=f0608526_ppsubdiz;password=ppsubdiz";
        public static MySqlDataReader reader;
        private static String oneRes;
        public static MySqlConnection conn = new MySqlConnection(connString);
        public static String GetOneMeaning(String sql)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                String rdr = cmd.ExecuteScalar().ToString();
                oneRes = rdr;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return oneRes;
        }

        public static void GetOne(String sql)
        {
            
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                reader = rdr;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void GetAll(String sql)
        {

        }

        public static void Close()
        {
            reader.Close();
            conn.Close();
        }

        public static void ResizeGrid(DataGridView grid)
        {
            for (int i = 0; i < grid.Columns.Count - 1; i++)
            {
                grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            grid.Columns[grid.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                int colw = grid.Columns[i].Width;
                grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                grid.Columns[i].Width = colw;
            }
        }
    }
}
