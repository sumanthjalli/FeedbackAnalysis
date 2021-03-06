﻿using FBA.DataAL.Entity;
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

        public bool SaveFeedback(int FeedBackCategoryId, int UserId, int ProductId, string FeedBackDesc, int FeedBackIndex, int StarRating, string conStr)
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

        public List<ProductFeedbackAnalysis> GetProductFeedbackAnalysisDetails(string conStr)
        {
            List<ProductFeedbackAnalysis> products = new List<ProductFeedbackAnalysis>();
            // Creating Connection 
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "SP_GetProductFeedBackAnalysis";
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                        ProductFeedbackAnalysis pr = new ProductFeedbackAnalysis();
                        pr.ProductName = reader["ProductName"].ToString();
                        pr.CategoryDesc = reader["CategoryDesc"].ToString();
                        pr.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
                        pr.CategoryId = Convert.ToInt32(reader["CategoryId"].ToString());
                        pr.PosCnt = Convert.ToDouble(reader["PosCnt"]);
                        pr.NegCnt = Convert.ToDouble(reader["NegCnt"]);
                        pr.TotalCnt = Convert.ToDouble(reader["TotalCnt"]);
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


        public List<GetProductFeedBackDetails> GetProductFeedBackDetails(string conStr)
        {
            List<GetProductFeedBackDetails> productQuestions = new List<GetProductFeedBackDetails>();
            // Creating Connection 
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "SP_GetProductFeedBackDetails";
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.Add("@FeatureId", SqlDbType.Int).Value = featureID;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GetProductFeedBackDetails obj = new GetProductFeedBackDetails();
                        obj.FeedbackCategoryid = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        obj.CategoryDesc = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        obj.featureID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        obj.FeatureName = reader.IsDBNull(3) ? "" : reader.GetString(3);
                        obj.ProductId = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                        obj.ProductName = reader.IsDBNull(5) ? "" : reader.GetString(5);

                        obj.feedbackDesc = reader.IsDBNull(6) ? "" : reader.GetString(6);                     

                        obj.rating = reader.IsDBNull(7) ? 0 : reader.GetDouble(7);
                        //obj.ranking = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                        obj.AvgVal = reader.IsDBNull(9) ? 0 : reader.GetDouble(9);
                        productQuestions.Add(obj);
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



        public List<ProductCompitator> GetCompitatorsFeedBackDetails(string conStr, int featureID)
        {
            List<ProductCompitator> productQuestions = new List<ProductCompitator>();
            // Creating Connection 
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "SP_GetCompitatorsFeedBackDetails";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@FeatureId", SqlDbType.Int).Value = featureID;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductCompitator obj = new ProductCompitator();
                        obj.FeedbackCategoryid = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        obj.CategoryDesc = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        obj.featureID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        obj.FeatureName = reader.IsDBNull(3) ? "" : reader.GetString(3);
                        obj.ProductId = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);

                        obj.ProductName = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        obj.CompanyId = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                        obj.CompanyName = reader.IsDBNull(7) ? "" : reader.GetString(7);
                        obj.feedbackDesc = reader.IsDBNull(8) ? "" : reader.GetString(8);
                        obj.rating = reader.IsDBNull(9) ? 0 : reader.GetDouble(9);
                        //obj.ranking = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
                        obj.AvgVal = reader.IsDBNull(11) ? 0 : reader.GetDouble(11);

                        productQuestions.Add(obj);
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
