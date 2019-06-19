using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SCI.Data.Tests
{
    [TestClass]
    public class FuntionalTest
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            using (var bd = new sci_bdEntities())
            {
                if (bd.Database.Exists())
                    bd.Database.Delete();

                bd.Database.Create();
            }
        }

        //[TestCleanup]
        //public virtual void TestCleanup()
        //{
        //    using (var bd = new sci_bdEntities())
        //    {
        //        if (bd.Database.Exists())
        //            bd.Database.Delete();
        //    }
        //}
    }
}
