let kullanici = {
    "ad" : "Sadık",
    "soyad" : "Turan",
    "yas" : 38,
    "adres" : {
        "sehir" : "kocaeli",
        "ilce" : "izmit"
    },
    "hobiler" : ["sinema", "spor"]
}

let sonuc;

sonuc = kullanici.ad;
sonuc = kullanici.soyad;
sonuc = kullanici["yas"];
sonuc = kullanici.adres.ilce;
// sonuc = kullanici["adres:ilce"]
sonuc = kullanici.hobiler[0];

let urunler = [
    {
        "urun_adi" : "samsung s22",
        "urun_fiyat" : "13000"
    },
    {
        "urun_adi" : "samsung s23",
        "urun_fiyat" : "15000"
    }
]

sonuc = urunler[0].urun_adi

console.log(sonuc);