using System;
using System.Collections.Generic;


namespace BaiTapPhan2
{

    
    struct DoVat
    {
        public string Ten;
        public float TrongLuong, GiaTri, DonGia;
        public float PhuongAn;
    }

    class baiToanCaiBalo

    {
        const int MAX_SIZE = 100;
        static void Main(string[] args)
        {
            DoVat[] dsdv = new DoVat[MAX_SIZE];
            float W = 0; // Trọng lượng tối đa của ba lô

            // Nhập dữ liệu các đồ vật
            Console.Write("Nhap so luong do vat: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Do vat {i + 1}:");
                Console.Write("Ten: ");
                dsdv[i].Ten = Console.ReadLine();
                Console.Write("Trong luong: ");
                dsdv[i].TrongLuong = float.Parse(Console.ReadLine());
                Console.Write("Gia tri: ");
                dsdv[i].GiaTri = float.Parse(Console.ReadLine());
                dsdv[i].DonGia = dsdv[i].GiaTri / dsdv[i].TrongLuong;
                dsdv[i].PhuongAn = 0;
            }
            Console.Write("Nhap trong luong toi da cua balo: ");
            W = float.Parse(Console.ReadLine());

            Greedy(dsdv, W, n);

            // In kết quả
            float TongGiaTri = 0;
            Console.WriteLine("Phuong an chon do vat:");
            for (int i = 0; i < n; i++)
            {
                if (dsdv[i].PhuongAn > 0)
                {
                    Console.WriteLine($"{dsdv[i].Ten} - Trong luong : {dsdv[i].TrongLuong} - Gia tri: {dsdv[i].GiaTri} - Phuong an: {dsdv[i].PhuongAn}");
                    TongGiaTri += dsdv[i].GiaTri * dsdv[i].PhuongAn;
                }
            }
            Console.WriteLine($"Tong gia tri: {TongGiaTri}");
        }

        static void Greedy(DoVat[] dsdv, float W, int n)
        {
            // Sắp xếp mảng dsdv theo thứ tự giảm của don_gia
            Array.Sort(dsdv, (a, b) => b.DonGia.CompareTo(a.DonGia));

            float remainingWeight = W;
            for (int i = 0; i < n; i++)
            {
                if (dsdv[i].TrongLuong <= remainingWeight)
                {
                    dsdv[i].PhuongAn = 1;
                    remainingWeight -= dsdv[i].TrongLuong;
                }
                else
                {
                    dsdv[i].PhuongAn = remainingWeight / dsdv[i].TrongLuong;
                    remainingWeight = 0;
                }
            }
        }
    }
}
