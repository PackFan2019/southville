using System;
using System.Collections.Generic;
using System.Text;
using StudentAssessment.Objects;
using StudentAssessment.Data;

namespace StudentAssessment.Adapter
{
    public class TransactionAdapter
    {
        static TransactionAdapter instance;

        static TransactionAdapter() { }

        public static TransactionAdapter Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new TransactionAdapter();
                }
                return instance; 
            }
        }

        public Transaction CreateTransaction(Transaction_Type type, string documentID)
        {
            return TransactionData.Instance.CreateTransaction(type, documentID);
        }

        public void RollbackDocumentNumber(string transactionNo, Transaction_Type type, string documentID)
        {
            TransactionData.Instance.RollbackDocumentNumber(transactionNo, type, documentID);
        }

        public void SaveTransaction(Transaction transaction, string documentID, string defaultSiteID)
        {
            TransactionData.Instance.SaveTransaction(transaction, documentID, defaultSiteID);
        }

        public Transactions GetTransactionsByStudentID(string studentID)
        {
            return TransactionData.Instance.GetTransactionsByStudentID(studentID);
        }
    }
}
