let url = "https://www.sadikturan.com/";
let kursAdi = "Komple Uygulamalı Web Geliştirme Eğitimi";

let sonuc;

sonuc = url.length;

sonuc = kursAdi.split(" ").length;

sonuc = kursAdi.includes("Eğitimi", 6)
sonuc = kursAdi.indexOf("Eğitimm");

kursAdi = kursAdi.toLocaleLowerCase().replaceAll(" ", "-").replaceAll("ş","s").replaceAll("ı", "i");

sonuc = `${url}${kursAdi}`

console.log(sonuc);

