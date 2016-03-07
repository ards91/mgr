using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGRAnalysisHelper.DAL
{
    public class DataModelInitializer :System.Data.Entity.DropCreateDatabaseIfModelChanges<DataModelContext>
    {
        protected override void Seed(DataModelContext context)
        {
            base.Seed(context);
        }
    }
}