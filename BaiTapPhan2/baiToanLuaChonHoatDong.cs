using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTapPhan2
{
    class HoatDong
    {
        public int Start { get; set; }
        public int End { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Nhập dữ liệu các hoạt động
            Console.Write("Nhap so luong hoat dong ");
            int n = int.Parse(Console.ReadLine());
            List<HoatDong> activities = new List<HoatDong>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Hoat dong {i + 1}:");
                Console.Write("Thoi gian bat dau: ");
                int start = int.Parse(Console.ReadLine());
                Console.Write("Thoi gian ket thuc: ");
                int end = int.Parse(Console.ReadLine());
                activities.Add(new HoatDong { Start = start, End = end });
            }

            List<HoatDong> selectedActivities = GreedyScheduling(activities);

            // In kết quả
            Console.WriteLine("Cac hoat dong duoc chon:");
            foreach (var activity in selectedActivities)
            {
                Console.WriteLine($"Bat dau: {activity.Start}, Ket thuc: {activity.End}");
            }
        }

        static List<HoatDong> GreedyScheduling(List<HoatDong> activities)
        {
            // Sắp xếp các hoạt động theo thời gian kết thúc tăng dần
            activities.Sort((a, b) => a.End.CompareTo(b.End));

            List<HoatDong> selectedActivities = new List<HoatDong>();
            selectedActivities.Add(activities[0]); // Chọn hoạt động đầu tiên

            int lastEndTime = activities[0].End;
            for (int i = 1; i < activities.Count; i++)
            {
                if (activities[i].Start >= lastEndTime)
                {
                    selectedActivities.Add(activities[i]);
                    lastEndTime = activities[i].End;
                }
            }

            return selectedActivities;
        }
    }
}
