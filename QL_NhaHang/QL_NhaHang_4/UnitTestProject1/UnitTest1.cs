using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string tenDN = "ngoc123";
            string mk = "12345678";

            DAO_NguoiDung nguoidung = new DAO_NguoiDung();
            int ExpectedResult = 1;

            int ActualResult = nguoidung.sp_KiemTraDangNhap(tenDN, mk);

            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string tenDN = "ngoc123";
            string mk = "123456789";

            DAO_NguoiDung nguoidung = new DAO_NguoiDung();
            int ExpectedResult = 1;

            int ActualResult = nguoidung.sp_KiemTraDangNhap(tenDN, mk);

            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
