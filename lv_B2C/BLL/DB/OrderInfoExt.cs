using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using lv_Common;
using lv_B2C.Model;
using System.Collections;

namespace lv_B2C.BLL {
	 	//OrderInfo
	public partial class OrderInfoExt : OrderInfo
	{

        public Hashtable GetHashList(string strWhere, string fieldOrder, int pageIndex, int pageSize)
        {
            Hashtable result = new Hashtable();
            IList<Model.OrderInfo> ilist = GetPageList(strWhere, fieldOrder, pageIndex, pageSize);
            result["data"] = ilist;
            result["total"] = BLL.Pager.PageExtend.GetPageCount(strWhere, "OrderInfo");
            return result;
        }

        public Hashtable ModelToHashtable(lv_B2C.Model.OrderInfo modelOrder)
        {
            Hashtable ht = new Hashtable();
            ht[modelOrder.OrderID] = modelOrder.OrderID;
            ht[modelOrder.UserName] = modelOrder.UserName;
            ht[modelOrder.OrderNum] = modelOrder.OrderNum;
            ht[modelOrder.LogisticsNum] = modelOrder.LogisticsNum;
            ht[modelOrder.Consignee] = modelOrder.Consignee;
            ht[modelOrder.Province] = modelOrder.Province;
            ht[modelOrder.City] = modelOrder.City;
            ht[modelOrder.Town] = modelOrder.Town;
            ht[modelOrder.Post] = modelOrder.Post;
            ht[modelOrder.Address] = modelOrder.Address;
            ht[modelOrder.MobilePhone] = modelOrder.MobilePhone;
            ht[modelOrder.TelPhone] = modelOrder.TelPhone;
            ht[modelOrder.Email] = modelOrder.Email;
            ht[modelOrder.Landmark] = modelOrder.Landmark;
            ht[modelOrder.BestTime] = modelOrder.BestTime;
            ht[modelOrder.Logistics] = modelOrder.Logistics;
            ht[modelOrder.LogisticsDetail] = modelOrder.LogisticsDetail;
            ht[modelOrder.IsInsure] = modelOrder.IsInsure;
            ht[modelOrder.Payment] = modelOrder.Payment;
            ht[modelOrder.PaymentDetail] = modelOrder.PaymentDetail;
            ht[modelOrder.PayPoundage] = modelOrder.PayPoundage;
            ht[modelOrder.InvoiceType] = modelOrder.InvoiceType;
            ht[modelOrder.InvoiceTitle] = modelOrder.InvoiceTitle;
            ht[modelOrder.InvoiceDetail] = modelOrder.InvoiceDetail;
            ht[modelOrder.InvoiceCustomersMsg] = modelOrder.InvoiceCustomersMsg;
            ht[modelOrder.InvoiceMerchantsMsg] = modelOrder.InvoiceMerchantsMsg;
            ht[modelOrder.InvoiceMoney] = modelOrder.InvoiceMoney;
            ht[modelOrder.ProductTotalPrice] = modelOrder.ProductTotalPrice;
            ht[modelOrder.Postage] = modelOrder.Postage;
            ht[modelOrder.Insurance] = modelOrder.Insurance;
            ht[modelOrder.PackingMoney] = modelOrder.PackingMoney;
            ht[modelOrder.CARDSMoney] = modelOrder.CARDSMoney;
            ht[modelOrder.Discount] = modelOrder.Discount;
            ht[modelOrder.DiscountDetail] = modelOrder.DiscountDetail;
            ht[modelOrder.PostageDerate] = modelOrder.PostageDerate;
            ht[modelOrder.UsedBalance] = modelOrder.UsedBalance;
            ht[modelOrder.UsedIntegral] = modelOrder.UsedIntegral;
            ht[modelOrder.ProductQuantity] = modelOrder.ProductQuantity;
            ht[modelOrder.ProductWeight] = modelOrder.ProductWeight;
            ht[modelOrder.ActualPayMoney] = modelOrder.ActualPayMoney;
            ht[modelOrder.MerchantsModifyPrice] = modelOrder.MerchantsModifyPrice;
            ht[modelOrder.OrderStatus] = modelOrder.OrderStatus;
            ht[modelOrder.CreateDate] = modelOrder.CreateDate;
            ht[modelOrder.LastModifyDate] = modelOrder.LastModifyDate;
            ht[modelOrder.Hits] = modelOrder.Hits;
            ht[modelOrder.IsShow] = modelOrder.IsShow;
            ht[modelOrder.Types] = modelOrder.Types;
            ht[modelOrder.Tag] = modelOrder.Tag;
            ht[modelOrder.StringValue] = modelOrder.StringValue;
            ht[modelOrder.IsDel] = modelOrder.IsDel;
            ht[modelOrder.Sort] = modelOrder.Sort;
            ht[modelOrder.ExtendID] = modelOrder.ExtendID;
            return ht;
        }
	}
}