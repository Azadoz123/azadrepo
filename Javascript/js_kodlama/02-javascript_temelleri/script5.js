let simdi = new Date();

sonuc = simdi;
sonuc = simdi.getDate();
sonuc = simdi.getDay();
sonuc = simdi.getFullYear();
sonuc = simdi.getHours();
sonuc = simdi.getDate();
sonuc = simdi.getTime();

//sonuc = simdi.setFullYear(2025);
sonuc = simdi.setMonth(8);
sonuc = simdi.setDate(15);

let dogumTarihi = new Date(1990, 5, 15);

sonuc = simdi.getFullYear() - dogumTarihi.getFullYear();
sonuc = simdi - dogumTarihi;

let milisecond = simdi - dogumTarihi;
let saniye = milisecond / 1000 ;
let dakika = saniye / 60;

sonuc = dakika;

console.log(sonuc);
console.log(typeof sonuc);