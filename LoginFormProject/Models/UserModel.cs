using System.Data.SqlClient;
using System.Data;

namespace LoginFormProject.Models
{
    public class UserModel
    {
        private IConfiguration _configuration;
        public UserModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<UserEntity> GetAllUsers()
        {

            string? str = _configuration.GetConnectionString("DefaultConnection");

            SqlConnection Con = new SqlConnection(str);

            Con.Open();

            SqlCommand cmd = new SqlCommand("spGetAllUserEntity", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader getData = cmd.ExecuteReader();
            List<UserEntity> list = new List<UserEntity>();

            while (getData.Read())
            {
                UserEntity user = new UserEntity();

                user.Id = Convert.ToInt32(getData["Id"]);
                user.Name = getData["Name"].ToString();
                user.PhoneNumber = getData["PhoneNumber"].ToString();
                user.Email = getData["Email"].ToString();
                user.Gender = getData["Gender"].ToString();
                list.Add(user);

            }


            Con.Close();


            return list;
        }

        public void SaveUser(UserEntity user)
        {

            string? str = _configuration.GetConnectionString("DefaultConnection");

            SqlConnection Con = new SqlConnection(str);

            Con.Open();

            SqlCommand cmd = new SqlCommand("spAddUserEntity", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = user.Name;
            cmd.Parameters.AddWithValue("@PhoneNumber", SqlDbType.NVarChar).Value = user.PhoneNumber;
            cmd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = user.Email;
            cmd.Parameters.AddWithValue("@Gender", SqlDbType.NVarChar).Value = user.Gender;
            cmd.ExecuteNonQuery();


            Con.Close();


        }

        public void DeleteUser(int id)
        {

            string? str = _configuration.GetConnectionString("DefaultConnection");

            SqlConnection Con = new SqlConnection(str);

            Con.Open();

            SqlCommand cmd = new SqlCommand("spDeleteUserEntity", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UEId", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();


            Con.Close();


        }

        public UserEntity GetUser(int id)
        {

            string? str = _configuration.GetConnectionString("DefaultConnection");

            SqlConnection Con = new SqlConnection(str);

            Con.Open();

            SqlCommand cmd = new SqlCommand("spGetUserEntityById", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UEId", SqlDbType.Int).Value = id;

            SqlDataReader getData = cmd.ExecuteReader();
            UserEntity user = new UserEntity();
            while (getData.Read())
            {


                user.Id = Convert.ToInt32(getData["Id"]);
                user.Name = getData["Name"].ToString();
                user.PhoneNumber = getData["PhoneNumber"].ToString();
                user.Email = getData["Email"].ToString();
                user.Gender = getData["Gender"].ToString();

            }


            Con.Close();


            return user;
        }

        public void UpdateUser(UserEntity user)
        {

            string? str = _configuration.GetConnectionString("DefaultConnection");

            SqlConnection Con = new SqlConnection(str);

            Con.Open();

            SqlCommand cmd = new SqlCommand("spUpdateUserEntity", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = user.Id;
            cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = user.Name;
            cmd.Parameters.AddWithValue("@phone", SqlDbType.NVarChar).Value = user.PhoneNumber;
            cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = user.Email;
            cmd.Parameters.AddWithValue("@gen", SqlDbType.NVarChar).Value = user.Gender;
            cmd.ExecuteNonQuery();


            Con.Close();


        }
    }
}

