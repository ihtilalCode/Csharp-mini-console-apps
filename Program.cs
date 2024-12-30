using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uçak_Bilet_Satış_Sistemi
{
    class Program
    {
        static List<UcakSeferi> seferListesi = new List<UcakSeferi>();
        static List<Bilet> satilanBiletler = new List<Bilet>();
        static List<Bilet> iptalEdilenBiletler = new List<Bilet>();
        static int biletID = 100000;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ana Menü:");
                Console.WriteLine("1. Uçak Seferi Bilgisi Girişi");
                Console.WriteLine("2. Uçak Seferlerini Gör");
                Console.WriteLine("3. Bilet Satışı");
                Console.WriteLine("4. Bilet İptali");
                Console.WriteLine("5. Bilet İşlem Geçmişi");
                Console.WriteLine("0. Çıkış");
                Console.Write("Seçiminizi yapınız: ");

                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        UcakSeferiEkle();
                        break;
                    case "2":
                        UcakSeferleriniGor();
                        break;
                    case "3":
                        BiletSatisi();
                        break;
                    case "4":
                        BiletIptali();
                        break;
                    case "5":
                        BiletIslemGecmisi();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                        break;
                }
            }
        }

        // Uçak seferi ekleme
        static void UcakSeferiEkle()
        {
            Console.Clear();
            Console.WriteLine("Uçak Seferi Bilgisi Girişi");

            // Sefer bilgilerini al
            Console.Write("Nereden: ");
            string nereden = Console.ReadLine();
            Console.Write("Nereye: ");
            string nereye = Console.ReadLine();
            Console.Write("Tarih (yyyy-MM-dd): ");
            DateTime tarih = DateTime.Parse(Console.ReadLine());
            Console.Write("Saat (HH:mm): ");
            TimeSpan saat = TimeSpan.Parse(Console.ReadLine());
            Console.Write("Toplam Koltuk Sayısı: ");
            int koltukSayisi = int.Parse(Console.ReadLine());

            // Fiyat bilgileri
            Console.Write("Ekonomi Bilet Fiyatı: ");
            decimal ekonomiFiyat = decimal.Parse(Console.ReadLine());
            Console.Write("Business Bilet Fiyatı: ");
            decimal businessFiyat = decimal.Parse(Console.ReadLine());

            // Uçak seferini oluştur
            UcakSeferi yeniSefer = new UcakSeferi(seferListesi.Count + 1, nereden, nereye, tarih, saat, koltukSayisi, ekonomiFiyat, businessFiyat);
            seferListesi.Add(yeniSefer);
            Console.WriteLine("Uçak seferi başarıyla eklendi.");
            Console.ReadKey();
        }

        // Uçak seferlerini gösterme
        static void UcakSeferleriniGor()
        {
            Console.Clear();
            Console.WriteLine("Uçak Seferleri:");

            foreach (var sefer in seferListesi)
            {
                Console.WriteLine(sefer);
            }
            Console.ReadKey();
        }

        // Bilet satışı işlemi
        static void BiletSatisi()
        {
            Console.Clear();
            Console.WriteLine("Bilet Satışı");

            // Tüm seferleri listele
            for (int i = 0; i < seferListesi.Count; i++)
            {
                Console.WriteLine("{0}. {1}", seferListesi[i].SeferNo, seferListesi[i]);
            }

            Console.Write("Satın almak istediğiniz seferin numarasını giriniz: ");
            int seferNo = int.Parse(Console.ReadLine());
            UcakSeferi secilenSefer = seferListesi.Find(s => s.SeferNo == seferNo);

            if (secilenSefer == null)
            {
                Console.WriteLine("Geçersiz sefer numarası.");
                Console.ReadKey();
                return;
            }

            // Kullanıcıya ilk 100 koltuğun business olduğunu belirt
            Console.WriteLine("Not: İlk 100 koltuk Business sınıfıdır, sonrasındaki koltuklar Ekonomi sınıfına aittir.");

            // Sınıf seçimi yap
            Console.WriteLine("Uçmak istediğiniz sınıfı seçiniz:");
            Console.WriteLine("1. Ekonomi");
            Console.WriteLine("2. Business");
            Console.Write("Seçiminizi yapınız (1 veya 2): ");
            int sinifSecimi = int.Parse(Console.ReadLine());
            decimal biletFiyati = 0;

            // Ekonomi veya Business sınıfını seçme
            if (sinifSecimi == 1)
            {
                biletFiyati = secilenSefer.EkonomiFiyat;
            }
            else if (sinifSecimi == 2)
            {
                biletFiyati = secilenSefer.BusinessFiyat;
            }
            else
            {
                Console.WriteLine("Geçersiz seçenek.");
                Console.ReadKey();
                return;
            }

            // Koltuk seçimi yap
            Console.WriteLine("Seçmek istediğiniz koltuk numaralarını giriniz (örnek: 1,2,3): ");
            string[] secilenKoltuklar = Console.ReadLine().Split(',');
            List<int> koltuklar = new List<int>();
            foreach (var koltuk in secilenKoltuklar)
            {
                koltuklar.Add(int.Parse(koltuk));
            }

            // Koltukların daha önce alınmış olup olmadığını kontrol et
            foreach (var koltuk in koltuklar)
            {
                if (secilenSefer.KoltukDurumlari.ContainsKey(koltuk) && secilenSefer.KoltukDurumlari[koltuk] == true)
                {
                    Console.WriteLine("Hata: Koltuk {0} zaten alınmış. Lütfen farklı bir koltuk seçiniz.", koltuk);
                    Console.ReadKey();
                    return;
                }
            }

            // Eğer Ekonomi seçildiyse, ilk 100 koltuktan birini seçememeliler
            if (sinifSecimi == 1)
            {
                foreach (var koltuk in koltuklar)
                {
                    if (koltuk >= 1 && koltuk <= 100)
                    {
                        Console.WriteLine("Hata: Ekonomi sınıfı için ilk 100 koltuk seçilemez. Lütfen farklı bir koltuk seçiniz.");
                        Console.ReadKey();
                        return;
                    }
                }
            }

            // Müşteri bilgilerini al
            Console.Write("Adınız: ");
            string ad = Console.ReadLine();
            Console.Write("Soyadınız: ");
            string soyad = Console.ReadLine();
            Console.Write("T.C. Kimlik Numaranız: ");
            string tc = Console.ReadLine();
            Console.Write("Bütçeniz: ");
            decimal butce = decimal.Parse(Console.ReadLine());

            // Bilet fiyatını hesapla ve kontrol et
            decimal toplamFiyat = biletFiyati * koltuklar.Count;

            // Ödeme kontrolü
            if (butce >= toplamFiyat)
            {
                // Yeni bilet oluştur
                Bilet yeniBilet = new Bilet(biletID++, ad, soyad, tc, secilenSefer.SeferNo, toplamFiyat, koltuklar);
                satilanBiletler.Add(yeniBilet);

                // Alınan koltukların durumunu güncelle
                foreach (var koltuk in koltuklar)
                {
                    secilenSefer.KoltukDurumlari[koltuk] = true; // Koltuk alınmış olarak işaretleniyor
                }

                // Seferin koltuk sayısını güncelle
                secilenSefer.KoltukSayisi -= koltuklar.Count;

                Console.WriteLine("Bilet satış işlemi başarıyla tamamlandı.");
            }
            else
            {
                Console.WriteLine("Bütçeniz yetersiz.");
            }

            Console.ReadKey();
        }

        // Bilet iptali işlemi
        static void BiletIptali()
        {
            Console.Clear();
            Console.WriteLine("Bilet İptali");

            // Bilet ID'si ile bilet arama
            Console.Write("İptal etmek istediğiniz biletin ID'sini giriniz: ");
            int biletId = int.Parse(Console.ReadLine());
            Bilet bilet = satilanBiletler.Find(b => b.BiletID == biletId);

            if (bilet != null)
            {
                Console.Write("T.C. Kimlik Numaranız: ");
                string tc = Console.ReadLine();

                if (tc == bilet.Tc)
                {
                    satilanBiletler.Remove(bilet);
                    iptalEdilenBiletler.Add(bilet);
                    var sefer = seferListesi.Find(s => s.SeferNo == bilet.SeferNo);
                    sefer.KoltukDurumlari[bilet.Koltuklar[0]] = false; // Koltuk iptal edildiğinde boş olarak işaretleniyor
                    sefer.KoltukSayisi++; // Koltuk sayısı artıyor
                    Console.WriteLine("Bilet iptal işlemi başarıyla tamamlandı.");
                }
                else
                {
                    Console.WriteLine("T.C. Kimlik numarası hatalı.");
                }
            }
            else
            {
                Console.WriteLine("Bilet bulunamadı.");
            }

            Console.ReadKey();
        }

        // Bilet işlem geçmişi
        static void BiletIslemGecmisi()
        {
            Console.Clear();
            Console.WriteLine("Bilet İşlem Geçmişi");

            Console.WriteLine("Satılan Biletler:");
            foreach (var bilet in satilanBiletler)
            {
                Console.WriteLine(bilet);
            }

            Console.WriteLine("\nİptal Edilen Biletler:");
            foreach (var bilet in iptalEdilenBiletler)
            {
                Console.WriteLine(bilet);
            }

            Console.ReadKey();
        }
    }

    // Uçak seferi sınıfı
    class UcakSeferi
    {
        public int SeferNo { get; set; }
        public string Nereden { get; set; }
        public string Nereye { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan Saat { get; set; }
        public int KoltukSayisi { get; set; }
        public decimal EkonomiFiyat { get; set; }
        public decimal BusinessFiyat { get; set; }
        public Dictionary<int, bool> KoltukDurumlari { get; set; }  // Koltuk numarası ve durumu (true = alındı, false = boş)

        public UcakSeferi(int seferNo, string nereden, string nereye, DateTime tarih, TimeSpan saat, int koltukSayisi, decimal ekonomiFiyat, decimal businessFiyat)
        {
            SeferNo = seferNo;
            Nereden = nereden;
            Nereye = nereye;
            Tarih = tarih;
            Saat = saat;
            KoltukSayisi = koltukSayisi;
            EkonomiFiyat = ekonomiFiyat;
            BusinessFiyat = businessFiyat;
            KoltukDurumlari = new Dictionary<int, bool>();

            // Tüm koltuklar boş (false) olarak başlatılır
            for (int i = 1; i <= koltukSayisi; i++)
            {
                KoltukDurumlari[i] = false;  // false: Koltuk boş
            }
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1}, {2} {3}, Koltuk Sayısı: {4}, Ekonomi Fiyat: {5} TL, Business Fiyat: {6} TL", Nereden, Nereye, Tarih.ToShortDateString(), Saat, KoltukSayisi, EkonomiFiyat, BusinessFiyat);
        }
    }

    // Bilet sınıfı
    class Bilet
    {
        public int BiletID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tc { get; set; }
        public int SeferNo { get; set; }
        public decimal Fiyat { get; set; }
        public List<int> Koltuklar { get; set; }

        public Bilet(int biletID, string ad, string soyad, string tc, int seferNo, decimal fiyat, List<int> koltuklar)
        {
            BiletID = biletID;
            Ad = ad;
            Soyad = soyad;
            Tc = tc;
            SeferNo = seferNo;
            Fiyat = fiyat;
            Koltuklar = koltuklar;
        }

        public override string ToString()
        {
            return string.Format("Bilet ID: {0}, {1} {2}, TC: {3}, Sefer No: {4}, Fiyat: {5} TL, Koltuklar: {6}",
                BiletID, Ad, Soyad, Tc, SeferNo, Fiyat, string.Join(", ", Koltuklar));
        }
    }
}
