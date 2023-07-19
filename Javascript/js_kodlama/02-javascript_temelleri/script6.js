let ogrenciler = ["çınar", "yiğit","ada"];

sonuc = ogrenciler.length;
sonuc = ogrenciler.toString();
sonuc = ogrenciler.join("-");
sonuc = ogrenciler.pop();
sonuc = ogrenciler.shift()
sonuc = ogrenciler.push("sena");
sonuc = ogrenciler.unshift("sena");

let markalar1 = ["mazda", "toyota"];
let markalar2 = ["opel", "renault"];
let markalar3 = ["mercedes"];

// sonuc = markalar1.concat(markalar2, markalar3);

sonuc = markalar1.splice(0, 1, "bmw", "audi");

console.log(sonuc);
console.log(markalar1);