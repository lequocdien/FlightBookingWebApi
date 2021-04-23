using DatVeMayBay.Model;
using DatVeMayBay.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatVeMayBay.Web.Infrastructure.Extension
{
    public static class ConvertToModel
    {
        public static VeModel ConvertToVeModel(this VeViewModel x_objVeVM)
        {
            VeModel objVeModel = new VeModel();
            objVeModel.MaVe = x_objVeVM.MaVe;
            objVeModel.ThoiGianDat = x_objVeVM.ThoiGianDat;
            objVeModel.SoGhe = x_objVeVM.SoGhe;
            objVeModel.GiaVe = x_objVeVM.GiaVe;
            objVeModel.DaDat = x_objVeVM.DaDat;
            objVeModel.MaChuyenBay = x_objVeVM.MaChuyenBay;
            objVeModel.MaHoaDon = x_objVeVM.MaHoaDon;
            return objVeModel;
        }

        public static HoaDonModel ConvertToHoaDonModel(this HoaDonViewModel x_objHoaDonVM)
        {
            HoaDonModel hoadDonModel = new HoaDonModel();
            hoadDonModel.MaHoaDon = x_objHoaDonVM.MaHoaDon;
            hoadDonModel.NgayLap = x_objHoaDonVM.NgayLap.Value;
            hoadDonModel.ThanhTien = x_objHoaDonVM.ThanhTien;
            hoadDonModel.DaThanhToan = x_objHoaDonVM.DaThanhToan;
            hoadDonModel.GhiChu = x_objHoaDonVM.GhiChu;
            hoadDonModel.MaNhanVien = x_objHoaDonVM.MaNhanVien;
            hoadDonModel.CMND = x_objHoaDonVM.CMND;
            return hoadDonModel;
        }

        public static MayBayModel ConvertToMayBayModel(this MayBayViewModel x_objMayBayVM)
        {
            MayBayModel objMayBay = new MayBayModel();
            objMayBay.MaMayBay = x_objMayBayVM.MaMayBay;
            objMayBay.TenMayBay = x_objMayBayVM.TenMayBay;
            objMayBay.TongSoGhe = x_objMayBayVM.TongSoGhe;
            objMayBay.SoGheHang1 = x_objMayBayVM.SoGheHang1;
            objMayBay.SoGheHang2 = x_objMayBayVM.SoGheHang2;
            return objMayBay;
        }

        public static SanBayModel ConvertToSanBayModel(this SanBayViewModel x_objSanBayVM)
        {
            SanBayModel objSanBay = new SanBayModel();
            objSanBay.MaSanBay = x_objSanBayVM.MaSanBay;
            objSanBay.TenSanBay = x_objSanBayVM.TenSanBay;
            objSanBay.ThanhPho = x_objSanBayVM.ThanhPho;
            objSanBay.QuocGia = x_objSanBayVM.QuocGia;
            objSanBay.GhiChu = x_objSanBayVM.GhiChu;
            return objSanBay;
        }
    }
}