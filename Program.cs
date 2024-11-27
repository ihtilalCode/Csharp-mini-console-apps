using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satış_Depo
{
    using System;
    using System.Collections.Generic;

    using System;
    using System.Collections.Generic;

    class Urun
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public int Stok { get; set; }
        public double Fiyat { get; set; }

        public Urun(int id, string ad, int stok, double fiyat)
        {
            ID = id;
            Ad = ad;
            Stok = stok;
            Fiyat = fiyat;
        }

        public void UrunGoster()
        {
            Console.WriteLine("Ürün Numarası: " + ID + ", Ürün Adı: " + Ad + ", Stok: " + Stok + ", Fiyat: " + Fiyat + " TL");
        }
    }

    class Satis
    {
        public Urun Urun { get; set; }
        public int Miktar { get; set; }
        public double ToplamTutar { get; set; }

        public Satis(Urun urun, int miktar)
        {
            Urun = urun;
            Miktar = miktar;
            ToplamTutar = urun.Fiyat * miktar;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Urun> depo = new List<Urun>();  // Depo için dinamik bir liste
            List<Satis> satislar = new List<Satis>();  // Satışları takip etmek için liste
            int urunID = 1; // İlk ürün için ID'yi 1'den başlatıyoruz

            while (true)
            {
                Console.Clear(); // Ekranı temizle
                Console.WriteLine("\nSatış Depo Programı");
                Console.WriteLine("1. Ürün Ekle");
                Console.WriteLine("2. Ürün Güncelle");
                Console.WriteLine("3. Müşteri Satış Menüsü");
                Console.WriteLine("4. Depo Durumunu Görüntüle");
                Console.WriteLine("5. Satış Raporunu Görüntüle");
                Console.WriteLine("6. Çıkış");
                Console.Write("Bir seçenek girin: ");
                int secim = Convert.ToInt32(Console.ReadLine());

                if (secim == 1)
                {
                    // Ürün ekleme işlemi
                    Console.Clear(); // Ekranı temizle
                    Console.Write("Yeni Ürün Adı: ");
                    string ad = Console.ReadLine();

                    // Ürün zaten var mı kontrol ediyoruz
                    Urun mevcutUrun = depo.Find(u => u.Ad.ToLower() == ad.ToLower());

                    if (mevcutUrun != null)
                    {
                        Console.WriteLine("Bu ürün zaten depoda mevcut.");
                    }
                    else
                    {
                        // Yeni ürün ekleme
                        Console.Write("Yeni stok miktarını girin: ");
                        int stok = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Yeni fiyatı girin: ");
                        double fiyat = Convert.ToDouble(Console.ReadLine());

                        depo.Add(new Urun(urunID, ad, stok, fiyat)); // Yeni ürünü depoya ekliyoruz.
                        urunID++; // Her yeni ürün için ID'yi artırıyoruz
                        Console.WriteLine("Yeni ürün başarıyla eklendi.");
                    }

                    Console.WriteLine("Ana menüye dönmek için bir tuşa basın...");
                    Console.ReadKey();
                }
                else if (secim == 2)
                {
                    // Ürün güncelleme işlemi
                    Console.Clear(); // Ekranı temizle
                    Console.WriteLine("\nMevcut Ürünler:");
                    for (int i = 0; i < depo.Count; i++)
                    {
                        Console.WriteLine($"{depo[i].ID}. {depo[i].Ad}");
                    }

                    Console.Write("Güncellemek istediğiniz ürünün numarasını girin: ");
                    int urunNumarasi = Convert.ToInt32(Console.ReadLine());

                    // Ürün numarasına göre ürün bulunuyor
                    Urun guncellenecekUrun = depo.Find(u => u.ID == urunNumarasi);

                    if (guncellenecekUrun != null)
                    {
                        Console.WriteLine("Bu ürün depoda mevcut.");
                        Console.WriteLine("1. Stok Güncelle");
                        Console.WriteLine("2. Fiyat Güncelle");
                        Console.WriteLine("3. İkisini de Güncelle");
                        Console.Write("Yapmak istediğiniz işlemi seçin: ");
                        int guncellemeSecimi = Convert.ToInt32(Console.ReadLine());

                        if (guncellemeSecimi == 1)
                        {
                            Console.Write("Yeni stok miktarını girin: ");
                            int yeniStok = Convert.ToInt32(Console.ReadLine());
                            guncellenecekUrun.Stok = yeniStok;
                            Console.WriteLine("Stok başarıyla güncellendi.");
                        }
                        else if (guncellemeSecimi == 2)
                        {
                            Console.Write("Yeni fiyatı girin: ");
                            double yeniFiyat = Convert.ToDouble(Console.ReadLine());
                            guncellenecekUrun.Fiyat = yeniFiyat;
                            Console.WriteLine("Fiyat başarıyla güncellendi.");
                        }
                        else if (guncellemeSecimi == 3)
                        {
                            Console.Write("Yeni stok miktarını girin: ");
                            int yeniStok = Convert.ToInt32(Console.ReadLine());
                            guncellenecekUrun.Stok = yeniStok;

                            Console.Write("Yeni fiyatı girin: ");
                            double yeniFiyat = Convert.ToDouble(Console.ReadLine());
                            guncellenecekUrun.Fiyat = yeniFiyat;

                            Console.WriteLine("Stok ve fiyat başarıyla güncellendi.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz seçim.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bu ürün numarası ile ürün bulunamadı.");
                    }

                    Console.WriteLine("Ana menüye dönmek için bir tuşa basın...");
                    Console.ReadKey();
                }
                else if (secim == 3)
                {
                    // Müşteri satış menüsü
                    Console.Clear(); // Ekranı temizle
                    Console.WriteLine("\nMüşteri Satış Menüsü:");
                    if (depo.Count == 0)
                    {
                        Console.WriteLine("Depoda ürün bulunmamaktadır.");
                    }
                    else
                    {
                        // Depodaki ürünleri göster
                        for (int i = 0; i < depo.Count; i++)
                        {
                            depo[i].UrunGoster(); // Ürün numarası, adı, stok ve fiyatı gösterir
                        }

                        Console.Write("Satmak istediğiniz ürünün numarasını girin: ");
                        int urunNumarasi = Convert.ToInt32(Console.ReadLine()) - 1;

                        if (urunNumarasi >= 0 && urunNumarasi < depo.Count)
                        {
                            Console.Write("Satılacak miktarı girin: ");
                            int miktar = Convert.ToInt32(Console.ReadLine());

                            // Elindeki para miktarını soruyoruz
                            Console.Write("Elinizdeki parayı girin: ");
                            double para = Convert.ToDouble(Console.ReadLine());

                            double toplamTutar = depo[urunNumarasi].Fiyat * miktar;

                            // Eğer müşteri yeterli paraya sahipse ve stok yeterliyse
                            if (para >= toplamTutar && depo[urunNumarasi].Stok >= miktar)
                            {
                                depo[urunNumarasi].Stok -= miktar;  // Satılan miktar depodan düşer
                                Satis satis = new Satis(depo[urunNumarasi], miktar);
                                satislar.Add(satis);  // Satışı kaydediyoruz
                                Console.WriteLine("Satış başarılı! Toplam Tutar: " + toplamTutar + " TL");
                            }
                            else if (depo[urunNumarasi].Stok < miktar)
                            {
                                Console.WriteLine("Yetersiz stok.");
                            }
                            else
                            {
                                Console.WriteLine("Yetersiz bakiye.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz ürün numarası.");
                        }
                    }

                    Console.WriteLine("Ana menüye dönmek için bir tuşa basın...");
                    Console.ReadKey();
                }
                else if (secim == 4)
                {
                    // Depo durumunu görüntüleme
                    Console.Clear(); // Ekranı temizle
                    Console.WriteLine("\nDepo Durumu:");
                    if (depo.Count == 0)
                    {
                        Console.WriteLine("Depoda ürün bulunmamaktadır.");
                    }
                    else
                    {
                        for (int i = 0; i < depo.Count; i++)
                        {
                            depo[i].UrunGoster();
                        }
                    }

                    Console.WriteLine("Ana menüye dönmek için bir tuşa basın...");
                    Console.ReadKey();
                }
                else if (secim == 5)
                {
                    // Satış raporu görüntüleme
                    Console.Clear(); // Ekranı temizle
                    Console.WriteLine("\nSatış Raporu:");
                    if (satislar.Count == 0)
                    {
                        Console.WriteLine("Henüz bir satış yapılmamıştır.");
                    }
                    else
                    {
                        double toplamSatis = 0;
                        foreach (var satis in satislar)
                        {
                            Console.WriteLine("Ürün: " + satis.Urun.Ad + ", Miktar: " + satis.Miktar + ", Toplam Satış: " + satis.ToplamTutar + " TL");
                            toplamSatis += satis.ToplamTutar;
                        }
                        Console.WriteLine("\nToplam Satış Miktarı: " + toplamSatis + " TL");
                    }

                    Console.WriteLine("Ana menüye dönmek için bir tuşa basın...");
                    Console.ReadKey();
                }
                else if (secim == 6)
                {
                    // Çıkış işlemi
                    Console.Clear(); // Ekranı temizle
                    Console.WriteLine("Programdan çıkılıyor...");
                    break;
                }
                else
                {
                    Console.Clear(); // Ekranı temizle
                    Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                    Console.WriteLine("Ana menüye dönmek için bir tuşa basın...");
                    Console.ReadKey();
                }
            }
        }
    }
}