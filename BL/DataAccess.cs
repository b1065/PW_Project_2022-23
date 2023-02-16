using Chazan.GamesCatalog.INTERFACES;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Chazan.GamesCatalog.BL
{
    public class DataAccess
    {
        public IDAO DAO { get; set; }
        public IEnumerable<IGame> Games
        {
            get { return DAO.GetAllGames(); }
        }
        public IEnumerable<IProducer> Producers
        {
            get { return DAO.GetAllProducers(); }
        }
        public IGame AddGame()
        {
            return DAO.AddNewGame();
        }
        public void SaveGame(IGame game)
        {
            DAO.SaveGame(game);
        }
        public IProducer AddProducer()
        {
            return DAO.AddNewProducer();
        }
        public void SaveProducer(IProducer producer)
        {
            DAO.SaveProducer(producer);
        }
        public void DeleteGame(IGame game)
        {
            DAO.DeleteGame(game);
        }
        public void DeleteProducer(IProducer producer)
        {
            DAO.DeleteProducer(producer);
        }
        public DataAccess(string setting)
        {
            if (DAO == null)
            {
                var dllFile = new FileInfo(@"..\..\..\..\READY_DAOS\" + setting);
                Assembly assembly = Assembly.UnsafeLoadFrom(dllFile.FullName);
                Type type = null;
                Type typeToFind = typeof(Chazan.GamesCatalog.INTERFACES.IDAO);
                foreach (var t in assembly.GetTypes())
                {
                    if (t.IsAssignableTo(typeToFind))
                    {
                        type = t;
                        break;
                    }
                }
                if (type != null)
                {
                    DAO = (IDAO)Activator.CreateInstance(type, null);
                }
            }
        }
    }
}
