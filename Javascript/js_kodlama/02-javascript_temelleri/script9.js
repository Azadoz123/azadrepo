// let siparis_1 = {
//     "siparis_id" : 101,
//     "siparis_tarihi" : "31.12.2022",
//     "odeme_sekli" : "kredi kartı",
//     "kargo_adresi" : "Yahya Kaptan mah.",
//     "satın_alınan_urunler":{
//         "ürün_id" : 5,
//         "urun_basligi" : "IPhone 13 Pro",
//         "urun_url" : "http://abc.com",
//         "urun_fiyatı" : 22000
//     },
//     "musteri_id" : 12,
//     "satici" : {
//         "firma_id" : 34,
//         "firma_adi" : "Apple Türkiye"
//     }
// }

let siparis_1 = {
    "siparis_id" : 102,
    "siparis_tarihi" : "31.12.2022",
    "odeme_sekli" : "kredi kartı",
    "kargo_adresi" : {
        "mahalle" : "Yahya Kaptan mah.",
        "ilce" : "izmit",
        "sehir" : "kocaeli "
    } ,
    "satın_alınan_urunler":[
        {
        "urun_id" : 5,
        "urun_basligi" : "IPhone 13 Pro",
        "urun_url" : "http://abc.com",
        "urun_fiyatı" : 22000
        },
        {
            "urun_id" : 6,
            "urun_basligi" : "IPhone 13 Pro Max",
            "urun_url" : "http://abc.com",
            "urun_fiyatı" : 25000
            }
    ] ,
    "musteri_id" : 12,
    "satici" : {
        "firma_id" : 34,
        "firma_adi" : "Apple Türkiye"
    }
}

let siparis_2 = {
    "siparis_id" : 102,
    "siparis_tarihi" : "31.12.2022",
    "odeme_sekli" : "kredi kartı",
    "kargo_adresi" : {
        "mahalle" : "Yahya Kaptan mah.",
        "ilce" : "izmit",
        "sehir" : "kocaeli "
    } ,
    "satın_alınan_urunler":[
        {
            "urun_id" : 6,
            "urun_basligi" : "IPhone 13 Pro Max",
            "urun_url" : "http://abc.com",
            "urun_fiyatı" : 25000
            }
    ] ,
    "musteri_id" : 12,
    "satici" : {
        "firma_id" : 34,
        "firma_adi" : "Apple Türkiye"
    }
}

let siparis_1_toplam = (siparis_1.satın_alınan_urunler[0].urun_fiyatı + siparis_1.satın_alınan_urunler[1].urun_fiyatı) * 1.18;

console.log(siparis_1_toplam)

let siparisler = [siparis_1, siparis_2];