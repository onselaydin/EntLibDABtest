using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using System.Data.Common;

namespace EntLibDABtest
{
    public partial class Products : System.Web.UI.Page
    {
        //ICacheManager cacheManager=CacheFactory.GetCacheManager();
        //private CacheManager myCache;

        protected void Page_Load(object sender, EventArgs e)
        {
            test4();
        }

        private void test4()
        {
            //myCache.Add("MyData", new DLEmployee().PersonelListesi(), CacheItemPriority.Normal, null, new Microsoft.Practices.EnterpriseLibrary
            //    .Caching.Expirations.AbsoluteTime(TimeSpan.FromMinutes(5)));
            GridView1.DataSource = new DLEmployee().PersonelListesi();
            GridView1.DataBind();
        }

        private void test2()
        {
            Database db = DatabaseFactory.CreateDatabase("testconn");
            DataTable dt = new DataTable();
            string sorgu = "select * from tblEmployee where EmployeeId=@EmployeeId";
            DbCommand command;
            command = db.GetSqlStringCommand(sorgu);
            db.AddInParameter(command, "@EmployeeId", DbType.Int32, 1);
            dt = db.ExecuteDataSet(command).Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        private void test3()
        {
            Database db = DatabaseFactory.CreateDatabase("testconn");
            DataTable dt = new DataTable();
            string sorgu = "select * from tblEmployee";
            DbCommand command;
            command = db.GetSqlStringCommand(sorgu);
         //   db.AddInParameter(command, "@EmployeeId", DbType.Int32, 1);
            dt = db.ExecuteDataSet(command).Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        private void kaydet()
        {
            Database defaultDB = DatabaseFactory.CreateDatabase("testconn");
            using (DbCommand sprocCmd = defaultDB.GetStoredProcCommand("AddEmployee"))
            {
                defaultDB.AddInParameter(sprocCmd, "@adsoyad", DbType.String, TextBox1.Text);
                defaultDB.AddInParameter(sprocCmd, "@adres", DbType.String, TextBox2.Text);
                defaultDB.AddInParameter(sprocCmd, "@maas", DbType.String, TextBox3.Text);

                using (DbConnection connection = defaultDB.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction();
                    try
                    {

                        defaultDB.ExecuteNonQuery(sprocCmd, transaction);
                        
                        transaction.Commit();
                    }
                    catch
                    {
               
                        transaction.Rollback();
                    }
                    connection.Close();
       
                }


            }
          
            test3();
        }

        private void test1()
        {
            Database objDatabase = DatabaseFactory.CreateDatabase("Database Connection String");
            //cacheManager = CacheFactory.GetCacheManager("Cache Manager");

            DataSet ds = new DataSet();
          //  cacheManager.GetData("BenimDatam");
            try
            {
                ds = objDatabase.ExecuteDataSet("GetProducts");
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ex) { throw ex; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            kaydet();


        }
    }
}