using Microsoft.Data.SqlClient;

namespace SqlQuerey.AdoSql
{
    public class DepartmintSql
    {
        private readonly string connectionString;

        public DepartmintSql(string ConnectionString)
        {
            connectionString = ConnectionString;
        }
        public List<object> getDepartmints()
        {
            List<object> list = new List<object>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                string querey = "SELECT Id,NameDepartmint FROM departmints";
                using (SqlCommand cmd = new SqlCommand(querey, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dep = new
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            list.Add(dep);
                        }
                    }
                }
            }
            return list;
        }
    }
}
