using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QuanLyCuaHangBanQuaTet
{
    public static class DatabaseUtils
    {
        // THAY ĐỔI CHUỖI KẾT NỐI CHO PHÙ HỢP VỚI MÁY CỦA BẠN
        // Ví dụ: Server=.;Database=DB_QuanLyQuaTet;Integrated Security=True;
        private static string connectionString = @"Server=localhost\SQLEXPRESS;Database=DB_QuanLyQuaTet;Integrated Security=True;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public static DataTable GetDataTable(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu Database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("Thao tác thất bại do dữ liệu này đang được dính dáng ở nơi khác (Ví dụ: Khách hàng này đã có Lịch sử Hóa Đơn, hoặc Sản phẩm này đã tồn tại trong Hóa Đơn). Vui lòng xóa các Hóa đơn/Tham chiếu liên quan trước!", "Dữ Liệu Đang Được Sử Dụng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lỗi Database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi Database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return result;
        }
    }
}
