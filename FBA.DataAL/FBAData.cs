using FBA.DataAL.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FBA.DataAL
{
    public class FBAData
    {
        public FBAData()
        {
            var configurationBuilder = new ConfigurationBuilder();
        }

        public bool SaveFeedback(int FeedBackCategoryId, int UserId,int ProductId,string FeedBackDesc,int FeedBackIndex,int StarRating, string conStr)
        {
            bool result = false;
            try
            {


                // Creating Connection 
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = con;
                    command.Parameters.Add("@FeedBackCategoryId", SqlDbType.Int).Value = FeedBackCategoryId;
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                    command.Parameters.Add("@ProductId", SqlDbType.Int).Value = ProductId;
                    command.Parameters.Add("@FeedBackDesc", SqlDbType.NVarChar).Value = FeedBackDesc;
                    command.Parameters.Add("@FeedBackIndex", SqlDbType.Int).Value = FeedBackIndex;
                    command.Parameters.Add("@StarRating", SqlDbType.Int).Value = StarRating;
                    command.CommandText = "AddFeedBack";
                    command.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    bool res = command.ExecuteNonQuery() > 0 ? true : false;
                    result = true;
                }
            }
            catch (Exception ex)
            {

                result = false;
            }
            return result;

        }


        public List<Product> GetProductDetails(string conStr)
        {
            List<Product> products = new List<Product>();
            // Creating Connection 
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "GetProducts";
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                        Product pr = new Product();
                        pr.ProductId = Convert.ToInt32(reader["ProductId"]);
                        pr.ProductName = reader["ProductName"].ToString();

                        products.Add(pr);
                    }
                }
                else
                {
                    //Handle custom message
                }
                reader.Close();
            }
            return products;
            //string val = conStr;
        }

        public List<ProductQuestion> GetProductQuestionSList(string conStr, int productId)
        {
            List<ProductQuestion> productQuestions = new List<ProductQuestion>();
            // Creating Connection 
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "SP_GetProductQuestions";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@productid", SqlDbType.Int).Value = productId;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                        ProductQuestion question = new ProductQuestion();
                        question.questionId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        question.ProductId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                        question.questionDescription = reader.IsDBNull(2) ? "" : reader.GetString(2);
                        question.questionType = reader.IsDBNull(3) ? "" : reader.GetString(3);
                        question.FeedBackCategoryId = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);

                        productQuestions.Add(question);
                    }
                }
                else
                {
                    //Handle custom message
                }
                reader.Close();
            }
            return productQuestions;
            //string val = conStr;
        }

        public List<FeedBack> GetFeedBackAnalysis(string conStr)
        {
            List<FeedBack> feedback = new List<FeedBack>();
            // Creating Connection 
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "sp_GetFeedbackAnalysis";
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                        FeedBack fb = new FeedBack();
                        fb.FeedBackId = Convert.ToInt32(reader["FeedBackId"]);
                        //fb.CategoryDesc = reader["CategoryDesc"].ToString();
                        //fb.UserName = reader["UserName"].ToString();
                        //fb.ProductName = reader["ProductName"].ToString();
                        //fb.FeedBackDesc = reader["FeedBackDesc"].ToString();
                        //fb.FeedBackIndex = Convert.ToDecimal(reader["FeedBackIndex"]);
                        feedback.Add(fb);
                    }
                }
                else
                {
                    //Handle custom message
                }
                reader.Close();
            }
            return feedback;
            //string val = conStr;
        }
        public bool AddFeedBackAnalysisCategory(string conStr, string text)
        {
            // Creating Connection 
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;

                command.Parameters.Add(new SqlParameter("@CategoryDesc", SqlDbType.NVarChar));
                command.Parameters["@CategoryDesc"].Value = text;

                command.CommandText = "sp_AddFeedbackCategory";
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                bool res = command.ExecuteNonQuery() > 0 ? true : false;
                return res;
            }
        }

        public bool AddFeedBackAnalysis(string conStr, FBEntry fB)
        {
            // Creating Connection 
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;

                command.Parameters.Add(new SqlParameter("@FeedBackCategoryId", SqlDbType.Int));
                command.Parameters["@FeedBackCategoryId"].Value = fB.FeedBackCategoryId;

                command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
                command.Parameters["@UserId"].Value = fB.UserId;

                command.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int));
                command.Parameters["@ProductId"].Value = fB.ProductId;

                command.Parameters.Add(new SqlParameter("@FeedBackDesc", SqlDbType.VarChar));
                command.Parameters["@FeedBackDesc"].Value = fB.FeedBackDesc;

                command.Parameters.Add(new SqlParameter("@FeedBackIndex", SqlDbType.Float));
                command.Parameters["@FeedBackIndex"].Value = fB.FeedBackIndex;

                command.CommandText = "sp_AddFeedBack";
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                bool res = command.ExecuteNonQuery() > 0 ? true : false;
                return res;
            }
        }
    }
}
