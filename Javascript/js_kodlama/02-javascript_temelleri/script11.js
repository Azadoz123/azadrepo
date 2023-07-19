let sayilar = [1, 5, 7, 15, 3, 25];

for(let index in sayilar){
   sayilar[index] = sayilar[index] * sayilar[index];
}

console.log(sayilar);

for(let sayi of sayilar){
    if(sayi % 5 == 0){
         console.log(sayi)
    }
}

let toplam = 0;

for(let sayi of sayilar){
    if(sayi % 2 == 0){
        toplam += sayi 
    }
}

console.log(toplam)

let urunler = ["iphone 12", "samsung s22", "iphone 13", "samsung s23"];

for (let i in urunler){
    urunler[i] = urunler[i].toUpperCase();
}

console.log(urunler);

let urunler1 = ["iphone 12", "samsung s22", "iphone 13", "samsung s23"];
let count = 0;
for (let i in urunler1){
    if(urunler1[i].includes("samsung")){
        count++;
    }
        
}

console.log(count);


let ogrenciler = [
    {"ad" : "yiğit", "soyad" : "bilgi", "notlar" : [60, 70, 60]},
    {"ad" : "ada", "soyad" : "bilgi", "notlar" : [80, 70, 90]},
    {"ad" : "çınar", "soyad" : "turan", "notlar" : [10, 20, 60]},
]



toplam = 0;
let ort = 0;
for( let i in ogrenciler){
   for(let j in ogrenciler[i].notlar){
    toplam += ogrenciler[i].notlar[j]
   }
   console.log(toplam/3);
   toplam = 0;
}

for( let ogrenci of ogrenciler){
    //console.log(ogrenci.notlar)
    let not_toplam = 0;
    let ortalama = 0;
    let adet = 0;
    for(let not of ogrenci.notlar){
        not_toplam += not
        adet++;
    }
    ortalama = not_toplam / adet;

    console.log(`${ogrenci.ad} ${ogrenci.soyad} isimli öğrencinin not ortalması ${ortalama}.`);

    if(ortalama >= 50){
        console.log(`başarılı.`);
    }else{
        console.log(`başarısız.`);
    }
}