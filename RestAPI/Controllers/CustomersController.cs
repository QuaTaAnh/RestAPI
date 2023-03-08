using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class CustomersController : ApiController
    {
		//httpGet: dùng để lấy thông tin khách hàng
		//1. Dịch vụ lấy thông tin của toàn bộ khách hàng
		[HttpGet]
		public List<tblKhach> GetTblKhaches()
		{
			DataClasses1DataContext dbCustomer = new DataClasses1DataContext();
			return dbCustomer.tblKhaches.ToList();
		}
		//2. Dịch vụ lấy thông tin một khách hàng với mã nào đó
		[HttpGet]
        public tblKhach GetCustomer(string id)
        {
            DataClasses1DataContext dbCustomer = new DataClasses1DataContext();
            return dbCustomer.tblKhaches.FirstOrDefault(x =>
           x.MaKhach == id);
        }
        //3. httpPost, dịch vụ thêm mới một khách hàng
        /*[HttpPost]
        public bool InsertNewCustomer(string id, string name, string adress, string phoneNumber)
        {
            try
            {
                DataClasses1DataContext dbCustomer = new DataClasses1DataContext();
                tblKhach customer = new tblKhach();
                customer.MaKhach = id;
                customer.TenKhach = name;
                customer.DiaChi = adress;
                customer.DienThoai = phoneNumber;

                dbCustomer.tblKhaches.InsertOnSubmit(customer);
                dbCustomer.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }*/

		//3. httpPost, dịch vụ thêm mới một khách hàng
		[HttpPost]
		public bool InsertNewCustomer(string id, string name,
		string adress, string phoneNumber)
		{
			try
			{
				DataClasses1DataContext dbCustomer = new
				DataClasses1DataContext();
				tblKhach customer = new tblKhach();
				customer.MaKhach = id;
				customer.TenKhach = name;
				customer.DiaChi = adress;
				customer.DienThoai = phoneNumber;
				dbCustomer.tblKhaches.InsertOnSubmit(customer);
				dbCustomer.SubmitChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
		//4. httpPut để chỉnh sửa thông tin một khách hàng
		[HttpPut]
        public bool UpdateCustomer(string id, string name,
       string adress, string phoneNumber)
        {
            try
            {
                DataClasses1DataContext dbCustomer = new DataClasses1DataContext();
                //Lấy mã khách đã có
                tblKhach customer =
               dbCustomer.tblKhaches.FirstOrDefault(x => x.MaKhach == id);
                if (customer == null) return false;
                customer.MaKhach = id;
                customer.TenKhach = name;
                customer.DiaChi = adress;
                customer.DienThoai = phoneNumber;
                dbCustomer.SubmitChanges();//Xác nhận chỉnh sửa
            return true;
            }
            catch
            {
                return false;
            }
        }
        //5.httpDelete để xóa một Khách hàng
        [HttpDelete]
        public bool DeleteCustomer(string id)
        {
            try
            {
                DataClasses1DataContext dbCustomer = new DataClasses1DataContext();
                //Lấy mã khách đã có
                tblKhach customer = dbCustomer.tblKhaches.FirstOrDefault(x => x.MaKhach == id);
                if (customer == null) return false;

                dbCustomer.tblKhaches.DeleteOnSubmit(customer);
                dbCustomer.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
