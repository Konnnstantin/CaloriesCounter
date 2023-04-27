using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCount.BL.Controller
{
        public abstract class BaseController
        {
            protected IDataSaver dataSaver = new SerializeDataSaver();

            protected void Save(string fileName, object item)
            {
                dataSaver.Save(fileName, item);
            }

            protected T Load<T>(string fileName)
            {
                return dataSaver.Load<T>(fileName);
            }
        }
}
