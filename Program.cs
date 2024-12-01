using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kütüphane_uygulaması
{
    using System;
    using System.Collections.Generic;

    namespace KutuphaneSistemi
    {
        // Kitap sınıfı
        class Kitap
        {
            public string Ad { get; set; }
            public string Yazar { get; set; }
            public string ISBN { get; set; }
            public int YayınYılı { get; set; }
            public int Adet { get; set; }
            public bool KiraliMi { get; set; }
            public string KitapTuru { get; set; } // Kitap türü (Kategori)
            public DateTime? SonKiralanmaTarihi { get; set; } // En son kiralanma tarihi
            public string KiralayanKisi { get; set; }
            public DateTime? IadeTarihi { get; set; }

            public Kitap(string ad, string yazar, string isbn, int yayinYili, int adet, string kitapTuru)
            {
                Ad = ad;
                Yazar = yazar;
                ISBN = isbn;
                YayınYılı = yayinYili;
                Adet = adet;
                KiraliMi = false;
                KiralayanKisi = string.Empty;
                IadeTarihi = null;
                KitapTuru = kitapTuru;
                SonKiralanmaTarihi = null;
            }

            public void KitapBilgileriniGoster()
            {
                Console.WriteLine($"Kitap Adı: {Ad}, Yazar: {Yazar}, ISBN: {ISBN}, Yayın Yılı: {YayınYılı}, Adet: {Adet}, Tür: {KitapTuru}, Durum: {(KiraliMi ? "Kiralanmış" : "Mevcut")}");
                if (KiraliMi)
                {
                    Console.WriteLine($"Kiralanan Kişi: {KiralayanKisi}, İade Tarihi: {IadeTarihi?.ToString("dd.MM.yyyy")}");
                }
                if (SonKiralanmaTarihi.HasValue)
                {
                    Console.WriteLine($"Son Kiralanma Tarihi: {SonKiralanmaTarihi?.ToString("dd.MM.yyyy")}");
                }
            }

            public static Kitap KitapVarmi(List<Kitap> kitaplar, string isbn)
            {
                return kitaplar.FirstOrDefault(kitap => kitap.ISBN == isbn);
            }
        }

        // Kiralama bilgisi sınıfı
        class Kiralama
        {
            public string KullaniciAdi { get; set; }
            public string KitapAdi { get; set; }
            public int KiralamaSuresi { get; set; }
            public DateTime IadeTarihi { get; set; }

            public Kiralama(string kullaniciAdi, string kitapAdi, int kiralamaSuresi, DateTime iadeTarihi)
            {
                KullaniciAdi = kullaniciAdi;
                KitapAdi = kitapAdi;
                KiralamaSuresi = kiralamaSuresi;
                IadeTarihi = iadeTarihi;
            }

            public void KiralamaBilgileriniGoster()
            {
                Console.WriteLine($"Kullanıcı: {KullaniciAdi}, Kitap: {KitapAdi}, Kiralama Süresi: {KiralamaSuresi} gün, İade Tarihi: {IadeTarihi.ToString("dd.MM.yyyy")}");
            }
        }

        class Program
        {
            static List<Kitap> kitaplar = new List<Kitap>();
            static List<Kiralama> kiralamaGeçmisi = new List<Kiralama>();

            static void Main(string[] args)
            {
                int secim;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Kütüphane Yönetim Sistemi");
                    Console.WriteLine("1. Kitap Ekle");
                    Console.WriteLine("2. Kitap Kirala");
                    Console.WriteLine("3. Kitap İade");
                    Console.WriteLine("4. Kitap Arama");
                    Console.WriteLine("5. Raporlama");
                    Console.WriteLine("6. Kiralama Geçmişi");
                    Console.WriteLine("7. Çıkış");
                    Console.Write("Bir seçenek girin: ");
                    while (!int.TryParse(Console.ReadLine(), out secim) || secim < 1 || secim > 7)
                    {
                        Console.WriteLine("Geçersiz seçim! Lütfen 1 ile 7 arasında bir sayı girin.");
                    }

                    switch (secim)
                    {
                        case 1:
                            KitapEkle();
                            break;
                        case 2:
                            KitapKirala();
                            break;
                        case 3:
                            KitapIade();
                            break;
                        case 4:
                            KitapArama();
                            break;
                        case 5:
                            Raporlama();
                            break;
                        case 6:
                            KiralamaGecmisi();
                            break;
                        case 7:
                            Console.WriteLine("Çıkılıyor...");
                            break;
                    }

                    // Kullanıcıya herhangi bir tuşa basmasını isteyelim
                    if (secim != 7)
                    {
                        Console.WriteLine("Devam etmek için bir tuşa basın...");
                        Console.ReadKey();
                    }

                } while (secim != 7);
            }

            // Kitap ekleme metodu
            static void KitapEkle()
            {
                Console.WriteLine("Yeni Kitap Ekle");

                Console.Write("Kitap Adı: ");
                string ad = Console.ReadLine();

                Console.Write("Yazar: ");
                string yazar = Console.ReadLine();

                Console.Write("ISBN: ");
                string isbn = Console.ReadLine();

                Console.Write("Kitap Türü (Örneğin: Roman, Bilim, Tarih vb.): ");
                string kitapTuru = Console.ReadLine();

                Kitap mevcutKitap = Kitap.KitapVarmi(kitaplar, isbn);

                if (mevcutKitap != null)
                {
                    Console.Write("Stok miktarını girin: ");
                    int eklenenAdet;
                    while (!int.TryParse(Console.ReadLine(), out eklenenAdet) || eklenenAdet <= 0)
                    {
                        Console.Write("Geçersiz stok miktarı. Lütfen pozitif bir sayı girin: ");
                    }
                    mevcutKitap.Adet += eklenenAdet;
                    Console.WriteLine($"Mevcut kitap sayısı güncellenmiştir. Yeni stok: {mevcutKitap.Adet}");
                }
                else
                {
                    Console.Write("Yayın Yılı: ");
                    int yayinYili;
                    while (!int.TryParse(Console.ReadLine(), out yayinYili) || yayinYili <= 0)
                    {
                        Console.Write("Geçersiz yayın yılı. Lütfen pozitif bir yıl girin: ");
                    }

                    Console.Write("Adet (Stok Adedi): ");
                    int adet;
                    while (!int.TryParse(Console.ReadLine(), out adet) || adet <= 0)
                    {
                        Console.Write("Geçersiz adet. Lütfen pozitif bir sayı girin: ");
                    }

                    Kitap yeniKitap = new Kitap(ad, yazar, isbn, yayinYili, adet, kitapTuru);
                    kitaplar.Add(yeniKitap);

                    Console.WriteLine("Kitap başarıyla eklendi.");
                }
            }

            // Kitap kiralama metodu
            static void KitapKirala()
            {
                Console.WriteLine("Kiralamak istediğiniz kitabı seçin:");
                KitaplariListele();

                Console.Write("Seçim: ");
                int secilenKitap;
                if (!int.TryParse(Console.ReadLine(), out secilenKitap) || secilenKitap < 1 || secilenKitap > kitaplar.Count)
                {
                    Console.WriteLine("Geçersiz seçim!");
                    return;
                }

                Kitap secilen = kitaplar[secilenKitap - 1];

                if (secilen.Adet <= 0)
                {
                    Console.WriteLine("Stokta yeterli kitap yok.");
                    return;
                }

                if (secilen.KiraliMi)
                {
                    Console.WriteLine("Bu kitap zaten kiralanmış.");
                }
                else
                {
                    Console.Write("Kiralamak istediğiniz gün sayısını girin: ");
                    int gunSayisi;
                    while (!int.TryParse(Console.ReadLine(), out gunSayisi) || gunSayisi <= 0)
                    {
                        Console.Write("Geçersiz gün sayısı! Lütfen pozitif bir sayı girin: ");
                    }

                    int kiraBedeli = gunSayisi * 5;

                    Console.Write("Bütçeniz nedir? ");
                    int butce;
                    while (!int.TryParse(Console.ReadLine(), out butce) || butce < kiraBedeli)
                    {
                        Console.WriteLine($"Bütçeniz yetersiz. Lütfen {kiraBedeli} TL veya daha fazla bir tutar girin.");
                    }

                    Console.Write("Kitap kiralanacak kişinin adı: ");
                    string kiralayanKisi = Console.ReadLine();

                    DateTime iadeTarihi = DateTime.Now.AddDays(gunSayisi);
                    Kiralama yeniKiralama = new Kiralama(kiralayanKisi, secilen.Ad, gunSayisi, iadeTarihi);
                    kiralamaGeçmisi.Add(yeniKiralama);

                    secilen.KiralayanKisi = kiralayanKisi;
                    secilen.IadeTarihi = iadeTarihi;
                    secilen.KiraliMi = true;
                    secilen.SonKiralanmaTarihi = DateTime.Now;
                    secilen.Adet--;

                    Console.WriteLine("Kitap başarıyla kiralandı.");
                }
            }

            // Kitap iade etme metodu
            static void KitapIade()
            {
                Console.WriteLine("İade etmek istediğiniz kitabı seçin:");
                KitaplariListele();

                Console.Write("Seçim: ");
                int secilenKitap;
                if (!int.TryParse(Console.ReadLine(), out secilenKitap) || secilenKitap < 1 || secilenKitap > kitaplar.Count)
                {
                    Console.WriteLine("Geçersiz seçim!");
                    return;
                }

                Kitap secilen = kitaplar[secilenKitap - 1];

                if (secilen.KiraliMi)
                {
                    secilen.KiralayanKisi = string.Empty;
                    secilen.IadeTarihi = null;
                    secilen.KiraliMi = false;
                    secilen.Adet++;

                    // Kiralama geçmişinden sil
                    kiralamaGeçmisi.RemoveAll(k => k.KitapAdi == secilen.Ad);

                    Console.WriteLine("Kitap başarıyla iade alındı.");
                }
                else
                {
                    Console.WriteLine("Bu kitap zaten kiralanmamış.");
                }
            }

            // Kitap arama metodu
            static void KitapArama()
            {
                Console.WriteLine("Arama yapmak için kitap adı veya yazar adı girin:");
                string aramaTerimi = Console.ReadLine().ToLower();

                var bulunanKitaplar = kitaplar.Where(k => k.Ad.ToLower().Contains(aramaTerimi) || k.Yazar.ToLower().Contains(aramaTerimi)).ToList();

                if (bulunanKitaplar.Count > 0)
                {
                    foreach (var kitap in bulunanKitaplar)
                    {
                        kitap.KitapBilgileriniGoster();
                    }
                }
                else
                {
                    Console.WriteLine("Aradığınız kritere uyan kitap bulunamadı.");
                }
            }

            // Raporlama metodu
            static void Raporlama()
            {
                Console.WriteLine("Raporlama Seçenekleri:");
                Console.WriteLine("1. Tüm kitapları listele");
                Console.WriteLine("2. Belirli bir yazara ait kitapları listele");
                Console.WriteLine("3. Belirli bir yayın yılına ait kitapları listele");
                Console.WriteLine("4. Kirada olan kitapları listele");
                Console.Write("Seçiminizi yapın: ");
                int secim;
                while (!int.TryParse(Console.ReadLine(), out secim) || secim < 1 || secim > 4)
                {
                    Console.Write("Geçersiz seçim! Lütfen 1 ile 4 arasında bir sayı girin: ");
                }

                switch (secim)
                {
                    case 1:
                        KitaplariListele();
                        break;
                    case 2:
                        Console.Write("Yazar adı girin: ");
                        string yazarAdi = Console.ReadLine().ToLower();
                        var yazarKitaplari = kitaplar.Where(k => k.Yazar.ToLower().Contains(yazarAdi)).ToList();
                        foreach (var kitap in yazarKitaplari)
                        {
                            kitap.KitapBilgileriniGoster();
                        }
                        break;
                    case 3:
                        Console.Write("Yayın yılı girin: ");
                        int yayinYili;
                        while (!int.TryParse(Console.ReadLine(), out yayinYili) || yayinYili <= 0)
                        {
                            Console.Write("Geçersiz yıl! Lütfen geçerli bir yıl girin: ");
                        }
                        var yayinYiliKitaplari = kitaplar.Where(k => k.YayınYılı == yayinYili).ToList();
                        foreach (var kitap in yayinYiliKitaplari)
                        {
                            kitap.KitapBilgileriniGoster();
                        }
                        break;
                    case 4:
                        var kiradaOlanKitaplar = kitaplar.Where(k => k.KiraliMi).ToList();
                        foreach (var kitap in kiradaOlanKitaplar)
                        {
                            kitap.KitapBilgileriniGoster();
                        }
                        break;
                }
            }

            // Kitapları listeleme
            static void KitaplariListele()
            {
                for (int i = 0; i < kitaplar.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {kitaplar[i].Ad} - {kitaplar[i].Yazar} ({kitaplar[i].YayınYılı})");
                }
            }

            // Kiralama geçmişini gösterme
            static void KiralamaGecmisi()
            {
                Console.WriteLine("Kiralama Geçmişi:");
                foreach (var kiralama in kiralamaGeçmisi)
                {
                    kiralama.KiralamaBilgileriniGoster();
                }
            }
        }
    }
}

