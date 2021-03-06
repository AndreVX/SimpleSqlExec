﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace SimpleSqlExec
{
    class Capture
    {
        internal static int _RowsAffected = 0;
        public static string MessagesFile = String.Empty;
        public static Encoding OutputEncoding;

        internal static void StatementCompletedHandler(object Sender,
            StatementCompletedEventArgs EventInfo)
        {
            _RowsAffected += EventInfo.RecordCount;

            return;
        }

        internal static void InfoMessageHandler(object Sender,
            SqlInfoMessageEventArgs EventInfo)
        {
            File.AppendAllText(MessagesFile, EventInfo.Message + "\n", OutputEncoding);

            return;
        }
    
    }
}
