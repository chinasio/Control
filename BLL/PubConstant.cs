using System;
using System.Data;
using System.Reflection;
using System.Text;
using LTP.Common;
namespace Maticsoft.BLL
{
	/// <summary>
	/// PubConstant ��ժҪ˵����
	/// </summary>
	public class PubConstant
	{
        public static string GetConstantConfig()
        {           
            string CacheKey = "IsKeysReg";
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    string iskeyreg = LTP.Common.ConfigHelper.GetConfigString("IsKeysReg");
                    DataCache.SetCache(CacheKey, iskeyreg, DateTime.Now.AddMinutes(60), TimeSpan.Zero);
                }
                catch
                { }
            }
            return objModel.ToString();
        }		
	}
}
