using System;
using System.Collections.Generic;

namespace BaiTapQLSV
{
    class Sinh_Vien
        
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string Gioi_Tinh { get; set; }
        public int Tuoi { get; set; }
        public double Diem_Mon_1 { get; set; }
        public double Diem_Mon_2 { get; set; }
        public double Diem_Mon_3 { get; set; }
        public double Diem_TB { get; set; }
        public string Hoc_Luc { get; set; }
    }
    class Quan_Ly_Sinh_Vien
    {
        private List<Sinh_Vien> List_Sinh_Vien = null;

        public Quan_Ly_Sinh_Vien()
        {
            List_Sinh_Vien = new List<Sinh_Vien>();
        }

       
        private int Chi_ID()
        {
            int max = 1;
            if (List_Sinh_Vien != null && List_Sinh_Vien.Count > 0)
            {
                max = List_Sinh_Vien[0].ID;
                foreach (Sinh_Vien sv in List_Sinh_Vien)
                {
                    if (max < sv.ID)
                    {
                        max = sv.ID;
                    }
                }
                max++;
            }
            return max;
        }

        public int So_Luong_Sinh_Vien()
        {
            int Count = 0;
            if (List_Sinh_Vien != null)
            {
                Count = List_Sinh_Vien.Count;
            }
            return Count;
        }

        public void Nhap_Sinh_Vien()
        {
           
            Sinh_Vien sv = new Sinh_Vien();
            sv.ID = Chi_ID();
            Console.Write("Nhap ten sinh vien: ");
            sv.Ten = Convert.ToString(Console.ReadLine());

            Console.Write("Nhap gioi tinh sinh vien: ");
            sv.Gioi_Tinh = Convert.ToString(Console.ReadLine());

            Console.Write("Nhap tuoi sinh vien: ");
            sv.Tuoi = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhap diem 1: ");
            sv.Diem_Mon_1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap diem 2: ");
            sv.Diem_Mon_2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap diem 3: ");
            sv.Diem_Mon_3 = Convert.ToDouble(Console.ReadLine());

            Tinh_DTB(sv);
            Xep_Loai_Hoc_Luc(sv);

            List_Sinh_Vien.Add(sv);
        }

        public void Cap_Nhat_Thong_Tin(int ID)
        {
           
            Sinh_Vien sv = Tim_ID(ID);
          
            if (sv != null)
            {
                Console.Write("Nhap ten sinh vien: ");
                string Ten = Convert.ToString(Console.ReadLine());
                
                if (Ten != null && Ten.Length > 0)
                {
                    sv.Ten  = Ten;
                }

                Console.Write("Nhap gioi tinh sinh vien: ");

                string Gioi_Tinh = Convert.ToString(Console.ReadLine());
                if (Gioi_Tinh != null && Gioi_Tinh.Length > 0)
                {
                    sv.Gioi_Tinh = Gioi_Tinh;
                }

                Console.Write("Nhap tuoi sinh vien: ");
                string Tuoi_Str = Convert.ToString(Console.ReadLine());
               
                if (Tuoi_Str != null && Tuoi_Str.Length > 0)
                {
                    sv.Tuoi = Convert.ToInt32(Tuoi_Str);
                }

                Console.Write("Nhap diem 1: ");
                string Diem_Mon_1_Str = Convert.ToString(Console.ReadLine());
                
                if (Diem_Mon_1_Str != null && Diem_Mon_1_Str.Length > 0)
                {
                    sv.Diem_Mon_1 = Convert.ToDouble(Diem_Mon_1_Str);
                }

                Console.Write("Nhap diem 2: ");
                string Diem_Mon_2_Str = Convert.ToString(Console.ReadLine());
               
                if (Diem_Mon_2_Str != null && Diem_Mon_2_Str.Length > 0)
                {
                    sv.Diem_Mon_2 = Convert.ToDouble(Diem_Mon_2_Str);
                }

                Console.Write("Nhap diem 3: ");
                string Diem_Mon_3_Str = Convert.ToString(Console.ReadLine());
             
                if (Diem_Mon_3_Str != null && Diem_Mon_3_Str.Length > 0)
                {
                    sv.Diem_Mon_3 = Convert.ToDouble(Diem_Mon_3_Str);
                }

                Tinh_DTB(sv);
                Xep_Loai_Hoc_Luc(sv);
            }
            else
            {
                Console.WriteLine("Sinh vien co ID = {0} khong ton tai.", ID);
            }
        }

       
        public void Xep_Bang_ID()
        {
            List_Sinh_Vien.Sort(delegate (Sinh_Vien sv1, Sinh_Vien sv2) {
                return sv1.ID.CompareTo(sv2.ID);
            });
        }

       
        public void Xep_Bang_Ten()
        {
            List_Sinh_Vien.Sort(delegate (Sinh_Vien sv1, Sinh_Vien sv2) {
                return sv1.Ten.CompareTo(sv2.Ten);
            });
        }

        
        public void Xep_Bang_Diem_TB()
        {
            List_Sinh_Vien.Sort(delegate (Sinh_Vien sv1, Sinh_Vien sv2) {
                return sv1.Diem_TB.CompareTo(sv2.Diem_TB);
            });
        }

        
        public Sinh_Vien Tim_ID(int ID)
        {
            Sinh_Vien searchResult = null;
            if (List_Sinh_Vien != null && List_Sinh_Vien.Count > 0)
            {
                foreach (Sinh_Vien sv in List_Sinh_Vien)
                {
                    if (sv.ID == ID)
                    {
                        searchResult = sv;
                    }
                }
            }
            return searchResult;
        }

       
        public List<Sinh_Vien> Tim_Bang_Ten(String keyword)
        {
            List<Sinh_Vien> searchResult = new List<Sinh_Vien>();
            if (List_Sinh_Vien != null && List_Sinh_Vien.Count > 0)
            {
                foreach (Sinh_Vien sv in List_Sinh_Vien)
                {
                    if (sv.Ten.ToUpper().Contains(keyword.ToUpper()))
                    {
                        searchResult.Add(sv);
                    }
                }
            }
            return searchResult;
        }

        
        public bool Xoa_Bang_Ten(int ID)
        {
            bool IsDeleted = false;
       
            Sinh_Vien sv = Tim_ID(ID);
            if (sv != null)
            {
                IsDeleted = List_Sinh_Vien.Remove(sv);
            }
            return IsDeleted;
        }

        
        private void Tinh_DTB(Sinh_Vien sv)
        {
            double DiemTB = (sv.Diem_Mon_1 + sv.Diem_Mon_2 + sv.Diem_Mon_3) / 3;
            sv.Diem_TB = Math.Round(DiemTB, 2, MidpointRounding.AwayFromZero);
        }

       
        private void Xep_Loai_Hoc_Luc(Sinh_Vien sv)
        {
            if (sv.Diem_TB >= 8)
            {
                sv.Hoc_Luc = "A";
            }
            else if (sv.Diem_TB >= 6.5)
            {
                sv.Hoc_Luc = "B";
            }
            else if (sv.Diem_TB >= 5)
            {
                sv.Hoc_Luc = "C";
            }
            else
            {
                sv.Hoc_Luc = "D";
            }
        }

        
        public void Hien_Sinh_Vien(List<Sinh_Vien> listSV)
        {
         
            Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, 5} {5, 5} {6, 5} {7, 10} {8, 10}",
                  "ID", "Ten ", "Gioi Tinh", "Tuoi", "Mon 1", "Mon 2", "Mon 3", "Diem TB", "Hoc Luc");
         
            if (listSV != null && listSV.Count > 0)
            {
                foreach (Sinh_Vien sv in listSV)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, 5} {5, 5} {6, 5} {7, 10} {8, 10}",
                                      sv.ID, sv.Ten, sv.Gioi_Tinh, sv.Tuoi, sv.Diem_Mon_1, sv.Diem_Mon_2, sv.Diem_Mon_3,
                                      sv.Diem_TB, sv.Hoc_Luc);
                }
            }
            Console.WriteLine();
        }

      
        public List<Sinh_Vien> get_List_Sinh_Vien()
        {
            return List_Sinh_Vien;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Quan_Ly_Sinh_Vien quan_Ly_Sinh_Vien = new Quan_Ly_Sinh_Vien();

            while (true)
            {
                Console.WriteLine("\nCHUONG TRINH QUAN LY SINH VIEN C#");
                Console.WriteLine("*************************MENU**************************");
                Console.WriteLine("**  1. Them sinh vien.                               **");
                Console.WriteLine("**  2. Cap nhat thong tin sinh vien boi ID.          **");
                Console.WriteLine("**  3. Xoa sinh vien boi ID.                         **");
                Console.WriteLine("**  4. Tim kiem sinh vien theo ten.                  **");
                Console.WriteLine("**  5. Sap xep sinh vien theo diem trung binh (GPA). **");
                Console.WriteLine("**  6. Sap xep sinh vien theo ten.                   **");
                Console.WriteLine("**  7. Sap xep sinh vien theo ID.                    **");
                Console.WriteLine("**  8. Hien thi danh sach sinh vien.                 **");
                Console.WriteLine("**  0. Thoat                                         **");
                Console.WriteLine("*******************************************************");
                Console.Write("Nhap tuy chon: ");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Console.WriteLine("\n1. Them sinh vien.");
                        quan_Ly_Sinh_Vien.Nhap_Sinh_Vien();
                        Console.WriteLine("\nThem sinh vien thanh cong!");
                        break;
                    case 2:
                        if (quan_Ly_Sinh_Vien.So_Luong_Sinh_Vien() > 0)
                        {
                            int id;
                            Console.WriteLine("\n2. Cap nhat thong tin sinh vien. ");
                            Console.Write("\nNhap ID: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            quan_Ly_Sinh_Vien.Cap_Nhat_Thong_Tin(id);
                        }
                        else
                        {
                            Console.WriteLine("\nSanh sach sinh vien trong!");
                        }
                        break;
                    case 3:
                        if (quan_Ly_Sinh_Vien.So_Luong_Sinh_Vien() > 0)
                        {
                            int id;
                            Console.WriteLine("\n3. Xoa sinh vien.");
                            Console.Write("\nNhap ID: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            if (quan_Ly_Sinh_Vien.Xoa_Bang_Ten(id))
                            {
                                Console.WriteLine("\nSinh vien co id = {0} da bi xoa.", id);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nSanh sach sinh vien trong!");
                        }
                        break;
                    case 4:
                        if (quan_Ly_Sinh_Vien.So_Luong_Sinh_Vien() > 0)
                        {
                            Console.WriteLine("\n4. Tim kiem sinh vien theo ten.");
                            Console.Write("\nNhap ten de tim kiem: ");
                            string Ten = Convert.ToString(Console.ReadLine());
                            List<Sinh_Vien> searchResult = quan_Ly_Sinh_Vien.Tim_Bang_Ten(Ten);
                            quan_Ly_Sinh_Vien.Hien_Sinh_Vien(searchResult);
                        }
                        else
                        {
                            Console.WriteLine("\nSanh sach sinh vien trong!");
                        }
                        break;
                    case 5:
                        if (quan_Ly_Sinh_Vien.So_Luong_Sinh_Vien() > 0)
                        {
                            Console.WriteLine("\n5. Sap xep sinh vien theo diem trung binh (GPA).");
                            quan_Ly_Sinh_Vien.Xep_Bang_Diem_TB();
                            quan_Ly_Sinh_Vien.Hien_Sinh_Vien(quan_Ly_Sinh_Vien.get_List_Sinh_Vien());
                        }
                        else
                        {
                            Console.WriteLine("\nSanh sach sinh vien trong!");
                        }
                        break;
                    case 6:
                        if (quan_Ly_Sinh_Vien.So_Luong_Sinh_Vien() > 0)
                        {
                            Console.WriteLine("\n6. Sap xep sinh vien theo ten.");
                            quan_Ly_Sinh_Vien.Xep_Bang_Ten();
                            quan_Ly_Sinh_Vien.Hien_Sinh_Vien(quan_Ly_Sinh_Vien.get_List_Sinh_Vien());
                        }
                        else
                        {
                            Console.WriteLine("\nSanh sach sinh vien trong!");
                        }
                        break;
                    case 7:
                        if (quan_Ly_Sinh_Vien.So_Luong_Sinh_Vien() > 0)
                        {
                            Console.WriteLine("\n6. Sap xep sinh vien theo ID.");
                            quan_Ly_Sinh_Vien.Xep_Bang_ID();
                            quan_Ly_Sinh_Vien.Hien_Sinh_Vien(quan_Ly_Sinh_Vien.get_List_Sinh_Vien());
                        }
                        else
                        {
                            Console.WriteLine("\nSanh sach sinh vien trong!");
                        }
                        break;
                    case 8:
                        if (quan_Ly_Sinh_Vien.So_Luong_Sinh_Vien() > 0)
                        {
                            Console.WriteLine("\n7. Hien thi danh sach sinh vien.");
                            quan_Ly_Sinh_Vien.Hien_Sinh_Vien(quan_Ly_Sinh_Vien.get_List_Sinh_Vien());
                        }
                        else
                        {
                            Console.WriteLine("\nSanh sach sinh vien trong!");
                        }
                        break;
                    case 0:
                        Console.WriteLine("\nBan da chon thoat chuong trinh!");
                        return;
                    default:
                        Console.WriteLine("\nKhong co chuc nang nay!");
                        Console.WriteLine("\nHay chon chuc nang trong hop menu.");
                        break;
                }
            }
        }
    }
}