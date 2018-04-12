using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

using System.Data;
using System.Data.Common;

namespace EntLibDABtest
{
    public class DLDB
    {
        public Database db;
        public DLDB()
        {
            db = DatabaseFactory.CreateDatabase("testconn");
        }

        public DLDB(string WebConfigName)
        {
            db = DatabaseFactory.CreateDatabase(WebConfigName);
        }

        public void LoadDataSet(DbCommand cw,DataSet ds,string[] str)
        {
            db.LoadDataSet(cw, ds, str);
        }

        public DataSet ExecuteDataSet(DbCommand cw)
        {
            //myCache.Add("MyData", db.ExecuteDataSet(cw), CacheItemPriority.Normal, null, new Microsoft.Practices.EnterpriseLibrary
            //.Caching.Expirations.AbsoluteTime(TimeSpan.FromMinutes(5)));
            return db.ExecuteDataSet(cw);//(DataSet) myCache.GetData("MyData");
        }

        public DataSet ExecuteDataSet(CommandType ct,string strSQL)
        {
            return db.ExecuteDataSet(ct, strSQL);
        }

        public IDataReader LoadView(CommandType ct,string strSQL)
        {
            return db.ExecuteReader(ct, strSQL);
        }

        public void ExecuteNonQuery(DbCommand cw)
        {
            db.ExecuteNonQuery(cw);
        }

        public void ExecuteNonQuery(CommandType ct,string SQL)
        {
            db.ExecuteNonQuery(ct, SQL);
        }
    }
}
