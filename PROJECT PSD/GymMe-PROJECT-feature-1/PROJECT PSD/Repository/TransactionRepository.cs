using PROJECT_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_PSD.Repository
{
    public class TransactionRepository
    {
        static LocalDatabaseEntities db = Singleton.GetInstance();

        public static List<TransactionDetail> GetAllTransactionDetail()
        {
            List<TransactionDetail> transactionDetail = db.TransactionDetails.ToList();
            return transactionDetail;
        }

        public static List<TransactionHeader> GetAllTransactionHeader()
        {
            List<TransactionHeader> transactionHeaders = db.TransactionHeaders.ToList();
            return transactionHeaders;
        }

        public static List<TransactionHeader> GetAllUserTransaction(int id)
        {
            return (from transaction in db.TransactionHeaders where transaction.UserID == id select transaction).ToList();
        }

        public static TransactionHeader GetTransactionHeaderById(int id)
        {
            TransactionHeader getTransactionHeader = (from transaction in db.TransactionHeaders where transaction.TransactionID == id select transaction).FirstOrDefault();
            return getTransactionHeader;
        }

        public static List<TransactionHeader> GetUnhandledTransacion()
        {
            return (from transaction in db.TransactionHeaders where transaction.Status == "Unhandled" select transaction).ToList();
        }

        public static void UpdateTransactionstatus(TransactionHeader transactionHeader)
        {
            var existingTransaction = db.TransactionHeaders.Find(transactionHeader.TransactionID);
            existingTransaction.Status = transactionHeader.Status;
            db.SaveChanges();
        }
    }
}