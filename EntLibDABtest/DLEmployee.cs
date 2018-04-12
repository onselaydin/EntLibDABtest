using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
namespace EntLibDABtest
{
    public class DLEmployee
    {
        DLDB myDB = new DLDB();

        public void PersonelEkle(string adsoyad,string adres,string maas)
        {
            DbCommand myDbCommand = myDB.db.GetStoredProcCommand("AddEmployee");
            myDB.db.AddInParameter(myDbCommand, "adsoyad", DbType.String, adsoyad);
            myDB.db.AddInParameter(myDbCommand, "adres", DbType.String, adres);
            myDB.db.AddInParameter(myDbCommand, "maas", DbType.String, maas);
            myDB.db.ExecuteNonQuery(myDbCommand);
        }

        public DataSet PersonelListesi()
        {
            DbCommand myDbCommand = myDB.db.GetStoredProcCommand("GetEmployees");
            return myDB.ExecuteDataSet(myDbCommand);
        }
    }
}