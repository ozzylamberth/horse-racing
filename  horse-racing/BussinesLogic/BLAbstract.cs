using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataEntities;

namespace BussinesLogic
{
    public class BLAbstract
    {
        //private static bedazEntities Context = null;

        //public static bedazEntities GetContext()
        //{
        //    if (Context == null)
        //        Context = new bedazEntities();
        //    return Context;
        //}

        private readonly apuestasEntities context;

        #region Singleton Pattern

        private static readonly BLAbstract instance = new BLAbstract();

        private BLAbstract()
        {
            context = new apuestasEntities();
        }

        public static BLAbstract Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        public apuestasEntities Context
        {
            get
            {
                return context;
            }
        }
    }
}
