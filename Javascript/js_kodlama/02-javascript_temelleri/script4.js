let sonuc;

sonuc = 10;
sonuc = "10";
sonuc = Number("10");
sonuc = parseInt("10.6");
sonuc = parseFloat("10.6")

sonuc = isNaN("10a");

let sayi = 15.1234567;

sonuc = sayi.toPrecision(5);
sonuc = sayi.toFixed(5);

sonuc = Math.round(2.4);
sonuc = Math.ceil(2.6);
sonuc = Math.floor(2.6);
sonuc = Math.sqrt(25);
sonuc = Math.pow(2,3);
sonuc = Math.abs(-10);
sonuc = Math.floor(Math.random() * 100);

console.log(typeof sonuc);
console.log(sonuc);