using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using EmlakciLibFinal;
using System.Runtime.CompilerServices;

namespace EmlakciAppFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            string klasoradi = @"c:\odevFinal"; 
            System.IO.Directory.CreateDirectory(klasoradi);
            string dosyaAdi = "odev.txt"; 
            string dosyaYolu = @"c:\odevFinal\odev.txt"; 
            string hedefYol = System.IO.Path.Combine(klasoradi, dosyaAdi);
            Console.WriteLine("Dosya varlığı kontrol ediliyor.");
            if (System.IO.File.Exists(hedefYol))
            {
                Console.WriteLine("Gerekli Dosya Bilgisayarınızda mecvuttur.");
            }
            else
            {
                System.IO.File.Create(hedefYol);
                Console.WriteLine("Dosya Bulunamadı.");
                Console.WriteLine("Gerekli Dosya Bilgisayarınızda oluşturuldu.");
            }
            List<Ev> evler = new List<Ev>();
            bool devamEt = true;
            while (devamEt)
            {
                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz:(Kayıtlı ev bilgilerini getir[1]/ Yeni ev girişi yap[2]");

                while (true)
                {
                    string islem = Console.ReadLine();
                    if (islem == "1")
                    {
                        Console.WriteLine("Kayıtlı ev bilgileri getiriliyor");
                        Console.WriteLine($"Kayıtlı ev sayısı {Ev.Sayac}");
                        if (Ev.Sayac == 0)
                        {
                            Console.WriteLine("Henüz Bir Ev Kaydı Oluşturulmamıştır.");
                        }
                        else
                        {
                            string[] bilgiler = System.IO.File.ReadAllLines(dosyaYolu);
                            foreach (string s in bilgiler)
                            {
                                Console.WriteLine(s);
                            }
                        }
                        break;
                    }
                    else if (islem == "2")
                    {
                        Console.WriteLine("Lütfen Ev Tipini Seçiniz(Satılık Ev[S]/ Kiralık Ev[K])");
                        while (true)
                        {
                            string cevap = Console.ReadLine().ToUpper();
                            if (cevap == "S")
                            {
                                SatilikEv yeniSatilikEv = new SatilikEv();
                                Console.WriteLine("Lütfen Satılık Ev Bilgilerini Giriniz:");
                                Console.WriteLine("Oda Sayısı Giriniz");
                                yeniSatilikEv.Odasayisi = int.Parse(Console.ReadLine());
                                Console.WriteLine("Kat No Giriniz");
                                yeniSatilikEv.Katno = int.Parse(Console.ReadLine());
                                Console.WriteLine("Alan Giriniz");
                                yeniSatilikEv.Alan = double.Parse(Console.ReadLine());
                                Console.WriteLine("Semt Giriniz");
                                yeniSatilikEv.Semt = Console.ReadLine();
                                Console.WriteLine("Satış Fiyatı Giriniz");
                                yeniSatilikEv.SatisFiyat = double.Parse(Console.ReadLine());

                                string dosya = @"c:\odevFinal\odev.txt";
                                using (StreamWriter dosya1 = new StreamWriter(dosya, true))
                                {
                                    dosya1.WriteLine(yeniSatilikEv.EvBilgileri());
                                }


                                break;
                            }
                            else if (cevap == "K")
                            {
                                KiralikEv yeniKiralikEv = new KiralikEv();
                                Console.WriteLine("Lütfen Kiralık Ev Bilgilerini Giriniz:");
                                Console.WriteLine("Oda Sayısı Giriniz");
                                int odasayisi = int.Parse(Console.ReadLine());
                                Console.WriteLine("Kat No Giriniz");
                                int katno = int.Parse(Console.ReadLine());
                                Console.WriteLine("Alan Giriniz");
                                double alan = double.Parse(Console.ReadLine());
                                Console.WriteLine("Semt Giriniz");
                                string semt = Console.ReadLine();
                                Console.WriteLine("Kira Giriniz");
                                int kira = int.Parse(Console.ReadLine());
                                Console.WriteLine("Depozito Giriniz");
                                int depozito = int.Parse(Console.ReadLine());

                                evler.Add(yeniKiralikEv);

                                using (StreamWriter dosya1 = new StreamWriter(dosyaYolu, true))
                                {
                                    dosya1.WriteLine(yeniKiralikEv.EvBilgileri());
                                }

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Lütfen Geçerli Bir Tip Seçiniz");
                            }
                            
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen geçerli bir işlem seçiniz");
                    }
                }


                Console.WriteLine("İşlemlere devam etmek ister misiniz?(E/H)");
                while (true)
                {
                    string cevap = Console.ReadLine().ToUpper();

                    if (cevap == "E")
                    {
                        Console.WriteLine("Ana İşleme Yönlendiriliyorsunuz.");
                        break;
                    }
                    else if (cevap == "H")
                    {
                        devamEt = false;
                        Console.WriteLine("Program sonlandırılıyor");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen geçerli bir cevap yazınız.");
                    }
                }
            }  
        }
       
    }
}