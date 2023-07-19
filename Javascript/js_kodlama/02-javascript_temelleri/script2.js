let kursAdi = "Komple Uygulamalı Web Geliştirme Eğitimi";

let sonuc;

sonuc = kursAdi.toLocaleLowerCase();
sonuc = kursAdi.toLocaleLowerCase();
sonuc = kursAdi.length;
sonuc = kursAdi[0];
sonuc = kursAdi.slice(7);

sonuc = kursAdi.substring(0,6);

sonuc = kursAdi.replace("Eğitimi", "Kursu");
sonuc = kursAdi.trim();
sonuc = kursAdi.trimStart();

sonuc = kursAdi.indexOf("Komple");
sonuc = kursAdi.split(" ");
sonuc = kursAdi.split(" ")[0];


console.log(sonuc)