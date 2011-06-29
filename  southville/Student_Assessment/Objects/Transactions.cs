using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StudentAssessment.Objects
{
    public class Transactions : CollectionBase
    {
        public void Add(Transaction transaction)
        {            
            List.Add(transaction);
        }

        public void Delete(Transaction transaction)
        {
            List.Remove(transaction);
        }

        public Transaction GetTransaction(int index)
        {
            return (Transaction)List[index];
        }

        public int IndexOf(Transaction transaction)
        {
            return List.IndexOf(transaction);
        }

        public Transaction GetTransaction(string transactionNo, Transaction_Type sopType)
        {
            Transaction transaction = null;
            for (int i = 0; i <= List.Count - 1; i++)
            {
                if (GetTransaction(i).DocumentNumber == transactionNo
                    && GetTransaction(i).TransactionType == sopType)
                {
                    transaction = GetTransaction(i);
                }
            }
            return transaction;
        }
    }
}
