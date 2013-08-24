/* ===================================================
 * wjkTranslateControls
 * http://help.thaifarang.net/wjk-software.wjkTranslateControls
 * ===================================================
 * (c) Copyright 2013 Dipl.-Ing. Walter Kohl - wjk-Software(R)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ========================================================== */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;


namespace wjkTranslateControls
{
    public class translator
    {
        public string baseLang
        {
            get
            {
                return baseLang;
            }
            private set
            {
                getBaseLang();
            }
        }
                   
        public string translate(string strPage, string strID, string strProperty, string strLanguage, string Text)
        {
            try
            {
                DataSet dsData = new DataSet();
                string connection = getSqlConnection();
                string strSelect = "SELECT * FROM tblRessources WHERE ([page]='" + strPage + "') AND ([ControlID]='" + strID + "') AND ([Property]='" + strProperty + "') AND ([lang] LIKE '" + strLanguage.Substring(0, 2) + "%')";
                SqlDataAdapter daDataAdapter1 = new SqlDataAdapter(strSelect, connection);
                daDataAdapter1.Fill(dsData, "tblRessources");
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    if (strLanguage.Substring(0, 2) == baseLang && dsData.Tables[0].Rows[0]["text"].ToString() != Text)
                    {
                        UpdateDataset(dsData.Tables[0].Rows[0]["ID"].ToString(), dsData.Tables[0].Rows[0]["text"].ToString());
                    }
                    else
                    {
                        return dsData.Tables[0].Rows[0]["text"].ToString();
                    }
                }
                else
                {
                    if (strLanguage.Substring(0, 2) == baseLang) InserDataset(strPage, strID, strProperty, strLanguage, Text);
                }
            }
            catch
            { }
            return Text;
        }

        public void UpdateDataset(string strID, string strText)
        {
            int numRowsAffected = 0;
            DataSet dsData = new DataSet();
            ConnectionStringSettings settings;
            settings = ConfigurationManager.ConnectionStrings["ConnectionString"];
            SqlConnection connection = new SqlConnection(settings.ConnectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                command.Connection = connection;
                command.CommandText = "UPDATE tblRessources SET [Text] = @Text, UpdateDate = @Date WHERE (ID = @ID)";

                SqlParameter param1 = new SqlParameter("@ID", SqlDbType.BigInt);
                param1.Value = strID;
                command.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@Text", SqlDbType.NVarChar);
                param2.Value = strText;
                command.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Date", SqlDbType.DateTime);
                param3.Value = DateTime.Now.ToLocalTime();
                command.Parameters.Add(param3);

                connection.Open();
                numRowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
            catch { }
        }

        public void InserDataset(string strPage, string strID, string strProperty, string strLanguage, string strText)
        {
            int numRowsAffected = 0;
            DataSet dsData = new DataSet();
            ConnectionStringSettings settings;
            settings = ConfigurationManager.ConnectionStrings["ConnectionString"];
            SqlConnection connection = new SqlConnection(settings.ConnectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                command.CommandText = "INSERT INTO tblRessources (page,lang,ControlID,Text,Property,CreationDate) " +
                                                                    "VALUES (@page,@lang,@ControlID,@Text,@property,@date)";
                command.Connection = connection;

                SqlParameter param1 = new SqlParameter("@page", SqlDbType.NVarChar, 100);
                param1.Value = strPage;
                command.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@lang", SqlDbType.NVarChar, 10);
                param2.Value = strLanguage;
                command.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@ControlID", SqlDbType.NVarChar, 100);
                param3.Value = strID;
                command.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@Text", SqlDbType.NVarChar);
                param4.Value = strText;
                command.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@property", SqlDbType.NVarChar, 50);
                param5.Value = strProperty;
                command.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@date", SqlDbType.DateTime);
                param6.Value = DateTime.Now.ToLocalTime();
                command.Parameters.Add(param6);

                connection.Open();
                numRowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
            catch { }
        }

        private string getSqlConnection()
        {
            ConnectionStringSettings settings;
            settings = ConfigurationManager.ConnectionStrings["ConnectionString"];
            return settings.ConnectionString;
        }

        private string getBaseLang()
        {
            return ConfigurationManager.AppSettings.GetValues("baseLang")[0];
        }
    }
}
