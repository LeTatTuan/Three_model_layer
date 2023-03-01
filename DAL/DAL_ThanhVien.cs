using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThanhVien : DBConnect
    {
        public DataTable getThanhVien()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM THANHVIEN", _conn);
            DataTable dtThanhVien = new DataTable();
            da.Fill(dtThanhVien);
            return dtThanhVien;
        }

        public bool themThanhVien(DTO_ThanhVien tv)
        {
            try
            {
                _conn.Open();
                string SQL = String.Format("INSERT INTO THANHVIEN(TV_NAME,TV_PHONE,TV_EMAIL) VALUES('{0}','{1}','{2}')", tv.THANHVIEN_NAME, tv.THANHVIEN_PHONE, tv.THANHVIEN_EMAIL);
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool suaThanhVien(DTO_ThanhVien tv)
        {
            try
            {
                _conn.Open();
                string SQL = String.Format("UPDATE THANHVIEN SET TV_NAME = '{0}', TV_PHONE = '{1}',TV_EMAIL = '{2}' WHERE TV_ID = {3}", tv.THANHVIEN_NAME, tv.THANHVIEN_PHONE, tv.THANHVIEN_EMAIL, tv.THANHVIEN_ID);
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool xoaThanhVien(int TV_ID)
        {
            try
            {
                _conn.Open();
                string SQL = String.Format("DELETE FROM THANHVIEN WHERE TV_ID = {0}", TV_ID);
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
    }
}
