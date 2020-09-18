using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Models;

namespace TPModule3.Database
{
    public class FakeDb
    {
        private static readonly Lazy<FakeDb> lazy =
            new Lazy<FakeDb>(() => new FakeDb());

        /// <summary>
        /// FakeDb singleton access.
        /// </summary>
        public static FakeDb Instance { get { return lazy.Value; } }

        private FakeDb()
        {
            this.ListeChats = new List<Chat>();
            this.InitialiserDatas();
        }

        public List<Chat> ListeChats { get; private set; }
       

        private void InitialiserDatas()
        {
            ListeChats = Chat.GetMeuteDeChats();
        }
    }
}
