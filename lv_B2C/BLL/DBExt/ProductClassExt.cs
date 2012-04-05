using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using lv_Common;
using lv_B2C.Model;
using System.Collections;

namespace lv_B2C.BLL {
	 	//ProductClass
	public partial class ProductClassExt : ProductClass
	{
        private lv_B2C.DAL.ProductClassExt dal = null;
        public bool HasProductClassSon(int productClassID)
        {
            dal = new DAL.ProductClassExt();
            int rs = dal.HasProductClassSon(productClassID);
            if (rs != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}